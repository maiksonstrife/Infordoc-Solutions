using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using ZXing;
using ZXing.Common;
using ImageMagick;
using ScanPDF;
using PCKLIB;
using System.ComponentModel;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace XmlFinder
{
    public class PdfUtility
    {
        string pathRaiz;
        string out_folder;
        string done_folder;
        string marked_folder;
        string in_folder;

        private System.Threading.ManualResetEvent _completedEvent;

        public bool debug = true;
        public List<string> m_input_files = new List<string>();
        string m_code;
        BarcodeFormat m_found_format;
        bool m_found;
        public bool monitorar;
        Timer m_timerRenomear = new Timer();
        UserSetting m_setting;

        //quando background worker finalizar devolver m_code
        public string barcode = "";

        //chamadas -> classes para serem chamadas por outras classes
        public string onloadCarregaRenomear (bool monitorar)
        {
            this.monitorar = monitorar;
            Load_AppSettings();
            m_timerRenomear.Interval = 50 * 1000;
            m_timerRenomear.Tick += M_timerRenomear_Tick;
            criarDiretorios();

            
            _completedEvent = new System.Threading.ManualResetEvent(false);

            if (this.monitorar == true)
            {
                m_timerRenomear.Start();
            }
            else
            {
                UpdateList();
                
            }
            
            return m_code;
        }


        //timers
        private void M_timerRenomear_Tick(object sender, EventArgs e)
        {
            UpdateList();
            if (m_input_files.Count > 0)
            {
                processoRenomear();
            }
        }


        //processos
        void processoRenomear()
        {
            string fname_full = "", fname = "", out_fname = "";

            if (m_input_files.Count == 0)
            {
                MessageBox.Show("Sem Pdf na Pasta anexado ao processoRenomear()", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Thread.Sleep(200); // Faz a thread aguardar processos
            Wait_for(40); //Helper: Faz com que o windows descarregue processos em fila

            float doc_height; 
            float region_height = m_setting.region_height;

            while (m_input_files.Count > 0)
            {
                fname_full = m_input_files[0];
                fname = fname_full.Substring(fname_full.LastIndexOf('\\') + 1);

                //Configura MagickRead (leitura, conversão e gravação de imagens)
                MagickReadSettings settings = new MagickReadSettings()
                {
                    Density = new Density(300, 300)
                };
                MagickImageCollection images = new MagickImageCollection();
                images.Read(fname_full, settings);

                //Configura pdf Sharp
                PdfDocument pdf = PdfReader.Open(fname_full, PdfDocumentOpenMode.Import);
                PdfPage first = pdf.Pages[0]; //pega a primeira pagina do pdf

                doc_height = (float)first.Height.Centimeter; //define a primeira pagina do pdf como tamanho do documento

                if (doc_height <= float.Epsilon) //Float.Epsilon retorna o menor numero possivel de um float
                {
                    Console.WriteLine(String.Format("File {0} is not valid.", fname_full));
                    pdf.Close();
                    continue;
                }

                int barcodePage = 0; //Tecnico vai definir em qual pagina esta o barcode
                int page_count = pdf.PageCount; 

                    PdfPage page = pdf.Pages[barcodePage];

                    images[barcodePage].Write("temp.jpg");      //salva pagina como temp.jpg e jogar para analize

                    Bitmap page_img = new Bitmap(FromFile("temp.jpg"));
                    Thread.Sleep(200);
                    Wait_for(40);

                    if (doc_height <= float.Epsilon) //Se certifica de que cada pagina está em conformidade com tamanho minimo
                    {
                            MessageBox.Show("Essa Altura não é valida", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                    }
                        
                        
                        m_found = false;
                        if (TryReadCode(page_img, 0) == true) //Se retornou true é que m_found (barcode) foi copulado
                        {
                            Boolean pulaNumero = true;

                            //MAIK NOTA: Separando posições por "," (QR MAXIPASS as posições são separadas por ",")
                            string[] words = m_code.Split(',');

                            Dictionary<string, string> dict = new Dictionary<string, string>();

                            //MAIK NOTA: Pra cada posição separada por "," limpar caracteres especiais
                            for (int i = 0; i < words.Length; i++)
                            {
                                string[] dados = words[i].Split(':');

                                if (dados[0].Contains("17")) //exigencia MAXIPASS (LUCCA&LUCCA) *Numero aparece duas vezes, pular a primeira.
                                {

                                    pulaNumero = false;

                                }
                                else
                                {
                                    string numero = dados[0].Replace("{", "").Replace("/", "").Replace("\"", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"');

                                    if (Char.IsDigit(numero, 0)) 

                                    {
                                        if (Convert.ToInt32(numero) < 17 && pulaNumero == true || Convert.ToInt32(numero) > 18 && Convert.ToInt32(numero) < 100)  //Original
                                                                                                                                                                  //  if (Convert.ToInt32(dados[0]) < 17 )
                                        {
                                            dict.Add(dados[0].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'), dados[1].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'));
                                        }
                                        else
                                        {

                                            if (Convert.ToInt32(numero) == 18)
                                            {
                                                dict.Add(dados[0].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'), dados[1].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'));
                                                pulaNumero = true;

                                            }
                                        }

                                    }




                                }
                                dados = null;
                            }



                            //MAIK NOTA: USA OS CAMPOS SEPARADOS POR "," E GRAVA SUA POSIÇÃO NO CAMPO CHAVE INSERIDO PELO USUARIO
                            string[] posicao = m_setting.positions.Split(m_setting.delimiter);

                            int tamanho = posicao.Length;


                            if (tamanho == 1)
                            {

                                m_code = dict[(posicao[0])];

                            }
                            else if (tamanho == 2)
                            {

                                m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])];
                            }
                            else if (tamanho == 3)
                            {

                                m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])];
                            }
                            else if (tamanho == 4)
                            {
                                m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])] + "_" + dict[(posicao[3])];
                            }
                            else if (tamanho == 5)
                            {
                                m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])] + "_" + dict[(posicao[3])] + "_" + dict[(posicao[4])];
                            }


                            //MAIK NOTE: LIMPA O RESULTADO DE CARACTERES ESPECIAIS
                            string sendtodecode = m_code.Replace("/", "").ToUpperInvariant();
                            sendtodecode = m_code.Replace("/", "").ToUpperInvariant();
                            sendtodecode = sendtodecode.Replace("{", "");
                            sendtodecode = sendtodecode.Replace("}", "");
                            sendtodecode = sendtodecode.Replace(":", "");


                            //MAIK NOTE: M_CODE passa por um processo "iso"(?) e volta como txtDecode(?)
                            string textEncode = System.Web.HttpUtility.UrlEncode(sendtodecode, Encoding.GetEncoding("iso-8859-7"));
                            string textDecode = System.Web.HttpUtility.UrlDecode(textEncode);

                            //MAIK NOTE: Renomeia e move arquivo
                            string fileName = fname;//NOME ORIGINAL, txt_scan_result.Text + ".pdf";
                            string novoNome = textDecode + ".pdf";
                            string sourcePath = in_folder;
                            string targetPath = out_folder;

                            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                            string destFile = System.IO.Path.Combine(targetPath, novoNome);
                            System.IO.File.Copy(sourceFile, destFile, true);


                            Wait_for(40);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            try
                            {
                                String date = (DateTime.Now.ToString("yyyy-MM-dd:HH:mm:ss"));


                                //Wait_for(40);
                                string novoNome = "Nao_Detectado_" + date.Replace(":", "_") + ".pdf";
                                string sourcePath = in_folder;
                                string targetPath = out_folder;
                                string sourceFile = System.IO.Path.Combine(sourcePath, fname);
                                string destFile = System.IO.Path.Combine(targetPath, novoNome);

                                System.IO.File.Copy(sourceFile, destFile, true);

                                m_found = false;

                            }
                            catch
                            {
                                MessageBox.Show("Erro 22", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                pdf.Close();
                string lixo = in_folder + "\\" + fname;
                File.Delete(lixo);
                m_input_files.RemoveAt(0);
            }
            MessageBox.Show("Processamento Finalizado com Sucesso.", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        //Helpers : Métodos de auxílio para as classes de processos
        void criarDiretorios()
        {
             pathRaiz = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"\InfordocSolutions";
             out_folder = pathRaiz + @"\Saida";
             done_folder = pathRaiz + @"\detectado";
             marked_folder = pathRaiz + @"\Recorte_Invalido";
             in_folder = pathRaiz + @"\Entrada";

            try
            {
                if (Directory.Exists(pathRaiz) == false)
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "InfordocSolutions"));
                }
                if (Directory.Exists(out_folder) == false)
                {
                    Directory.CreateDirectory(out_folder);
                }

                if (Directory.Exists(done_folder) == false)
                {
                    Directory.CreateDirectory(done_folder);
                }

                if (Directory.Exists(marked_folder) == false)
                {
                    Directory.CreateDirectory(marked_folder);
                }

                if (Directory.Exists(in_folder) == false)
                {
                    Directory.CreateDirectory(in_folder);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "erro ao criar diretorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        void Wait_for(int milisec)
        {
            DateTime tm = DateTime.Now;
            while (DateTime.Now.Subtract(tm).Milliseconds < milisec)
            {
                Application.DoEvents();
            }
        }

        private bool TryReadCode(Bitmap img, int depth)
        {
            if (m_found)
                return true;

            // Primeira Tentativa : ZXing
            BarcodeReader reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new DecodingOptions { TryHarder = true }
            };
            Result res = reader.Decode(img);

            if (Properties.Settings.Default.SisRecortar == true)
            {
                
                {
                    m_found = true;
                    m_code = res.Text;
                    m_found_format = res.BarcodeFormat;
                    return true;
                }

            }
            else if (Properties.Settings.Default.SisRenomear == true)
            {
                if (res != null && (res.BarcodeFormat == BarcodeFormat.QR_CODE))
                
                {
                    m_found = true;
                    m_code = res.Text;
                    m_found_format = res.BarcodeFormat;
                    return true;
                }
            }
            else if (Properties.Settings.Default.SisSitema == true)
            {
                if (res != null || (res.BarcodeFormat == BarcodeFormat.QR_CODE))
                
                {
                    m_found = true;
                    m_code = res.Text;
                    m_found_format = res.BarcodeFormat;
                    return true;
                }
            }



            // Proxima Tentativa: BarcodeImaging
            var barcodes = new System.Collections.ArrayList();
            var iScans = 100;
            BarcodeImaging.FullScanPage(ref barcodes, img, iScans);
            int i;
            for (i = 0; i < barcodes.Count; i++)
                if (barcodes[i].ToString().Length > 6)
                   
                    break;
            if (i < barcodes.Count)
                if (i < barcodes.Count)
                    if (i < barcodes.Count)
                    {
                        m_found = true;
                        m_code = barcodes[i].ToString();
                        m_found_format = BarcodeFormat.CODE_128;
                        return true;
                    }

            if (depth < m_setting.search_depth)
            {
                // Tente dividir e reanalizar
                TryReadCode(CropImage(img, 0, 0, img.Width / 2, img.Height / 2), depth + 1);
                TryReadCode(CropImage(img, 0, img.Height / 2, img.Width / 2, img.Height / 2), depth + 1);
                TryReadCode(CropImage(img, img.Width / 2, img.Height / 2, img.Width / 2, img.Height / 2), depth + 1);
                TryReadCode(CropImage(img, img.Width / 2, 0, img.Width / 2, img.Height / 2), depth + 1);
                return m_found;
            }
            else
                return false;
        }

        private string Check_filename_valid(string input)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            string output = r.Replace(input, "");
            if (output == "_")
                return "INVALID";
            else
                return output;
        }

        public void UpdateList()
        {
            try
            {
                // Enumerar arquivos PDF
                m_input_files = Directory.GetFiles(in_folder, "*.pdf").ToList();

                foreach (string fname_full in m_input_files)
                {
                    string fname = fname_full.Substring(fname_full.LastIndexOf('\\') + 1);
                    PdfDocument pdf = PdfReader.Open(fname_full, PdfDocumentOpenMode.Modify);
                    pdf.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("A aualização da pasta falhou. Caminho incorreto. Erro : " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        private Bitmap CropImage(Bitmap src, int x, int y, int width, int height)
        {
            var cropRect = new Rectangle(x, y, width, height);
            var target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
            }

            return target;
        }

        private bool Check_mark(Bitmap bmp)
        {
            try
            {
                bool ret = false;
                PixelUtil pixels = new PixelUtil(bmp);
                pixels.LockBits();

                int w = pixels.Width, h = pixels.Height;
                int r = Math.Min(Math.Min(30, w / 2), h / 2);

                float thresh = 0.5f;
                int _r = 0, _g = 0, _b = 0;
                int x = w - 1, y = 0;

                while (y < h)
                {
                    bool found = false;
                    while (x >= w * 7 / 10)
                    {
                        Color col = pixels.GetPixel(x, y);
                        if (col.GetBrightness() < thresh)
                        {
                            found = true;
                            break;
                        }
                        x--;
                    }
                    if (found)
                        break;
                    else
                    {
                        x = w - 1;
                        y++;
                    }
                }
                if (y == h)
                {
                    pixels.UnlockBits();
                    return false;
                }

                for (int dx = 0; dx < r; dx++)
                {
                    for (int dy = 0; dy < r; dy++)
                    {
                        Color pix = pixels.GetPixel(x - dx, y + dy);
                        _r += pix.R;
                        _g += pix.G;
                        _b += pix.B;
                    }
                }

                _r = _r / (r * r);
                _g = _g / (r * r);
                _b = _b / (r * r);

                if (_r < thresh * 255 && _g < thresh * 255 && _b < thresh * 255)
                    ret = true;
                else
                    ret = false;

                pixels.UnlockBits();
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 08: " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }



        //Settings.ini -> Carrega arquivo Settings.ini
        public void Load_AppSettings()
        {
            try
            {
                m_setting = UserSetting.Load();
                if (m_setting == null)
                    m_setting = new UserSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossivel Carregar AppSettings " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
