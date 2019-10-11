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
using System.Drawing.Imaging;

namespace XmlFinder
{
    public class PdfUtility
    {

        
        string fname_full = "", fname = "", out_fname = "";
        string pathRaiz;
        string pathVirtualScanner;
        string pathCutter;
        string out_folder;
        string done_folder;
        string marked_folder;
        string in_folder;

        public bool debug = true;
        public List<string> m_input_files = new List<string>();
        string m_code;
        BarcodeFormat m_found_format;
        bool m_found;
        public bool monitorar;
        Timer m_timerRenomear = new Timer();
        UserSetting m_setting;

        int barcodePage = 0; //Tecnico vai definir em qual pagina esta o barcode

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

            //m_setting.parametro5i = 5 ;
            //m_setting.Save();


            processoRecortar();
          
            if (this.monitorar == true)
            {
                m_timerRenomear.Start();
            }
            else
            {
                UpdateList();
                processoRenomear();
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

        void processoRecortar()
        {
            String[] pdfRecortarhFiles;
            string saidaFilename;

            pdfRecortarhFiles = Directory.GetFiles(pathCutter);

            foreach (string pdffile in pdfRecortarhFiles)
            {
                //abre pdf na pasta
                PdfDocument pdf = PdfReader.Open(pdffile, PdfDocumentOpenMode.Import);

                //economizar tempo-processamento, separei em duas rotinas, com ou sem loop baseado na quantidade de paginas, se for igual a 1 -> sem loop
                if( pdf.PageCount == 1)
                {
                    //Configura magick reader
                    MagickReadSettings settings = new MagickReadSettings()
                    {
                        Density = new Density(300, 300)
                    };
                    //Usa magick Reader para converter para jpg na pasta temp
                    MagickImageCollection images = new MagickImageCollection();
                    images.Read(pdffile, settings);
                    images.Write("temp.jpg");

                    //Usar uma copia da imagem temp para evitar erros
                    Bitmap originalImage = new Bitmap(FromFile("temp.jpg")); //Essa amostra será usada para separar recortes e deverá persistir até o final do processo de recorte
                    images.Dispose(); //libero o MagickReader da memória

                    #region //DIPOSE
                    /*
                     * Dispose é uma classe do tipo Interface (IDispose) que recebe diversos objetos e possui uma rotina indeferente para estes objetos para que os
                     * objetos sejam gerenciados de forma otimizada para que liberem memória, normalmente, este método está incluso em classes que usam Handlers, isso é, 
                     * tranca arquivo ou um código para lidar com futuras necessidades, quando não é mais necessário esta classe, usar Dipose();
                    */
                    #endregion

                    //if (m_setting.)
                    ImgRecorte.PDFVertical(originalImage, pdffile, in_folder, 4);
                    
                }



                /*using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(out_folder + "@\test.jpg", FileMode.Create, FileAccess.ReadWrite))
                    {
                        firstHalf.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }*/


            }
        }

        //Método para recortar bmp (usado em recorte)
        private static Image cropImageR(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        //processos
        void processoRenomear()
        {
            

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

                            InserirMarcadagua();
                            //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                            //string destFile = System.IO.Path.Combine(targetPath, novoNome);
                            //System.IO.File.Copy(sourceFile, destFile, true);


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
             pathVirtualScanner = pathRaiz + @"\Virtual Scanner";
             pathCutter = pathVirtualScanner + @"\Recortar";
             out_folder = pathVirtualScanner + @"\Saida";
             done_folder = pathVirtualScanner + @"\detectado";
             marked_folder = pathVirtualScanner + @"\Recorte_Invalido";
             in_folder = pathVirtualScanner + @"\Entrada";

            try
            {
                if (Directory.Exists(pathRaiz) == false)
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "InfordocSolutions"));
                }

                if (Directory.Exists(pathVirtualScanner) == false)
                {
                    Directory.CreateDirectory(pathVirtualScanner);
                }

                if (Directory.Exists(pathCutter) == false)
                {
                    Directory.CreateDirectory(pathCutter);
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

        //???
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

        public void InserirMarcadagua()
        {
            string fname_full = m_input_files[0];
            PdfDocument pdf = PdfReader.Open(fname_full, PdfDocumentOpenMode.Import);
            int page_count = pdf.PageCount;
            PdfPage first = pdf.Pages[0];
            PdfDocument out_pdf = null;
            MagickImageCollection images = new MagickImageCollection();
            MagickReadSettings settings = new MagickReadSettings()
            {
                Density = new Density(300, 300)  //Originall
                                                 //  Density = new Density(50)
                                                 //settings.Density = new PointD(300);
                                                 // Density = new Density(260,260)
            };
            images.Read(fname_full, settings);


                //INSERINDO MARCA DAGUA
                images[barcodePage].Write("temp.jpg");//salva primeira imagem do pdf no pasta repo
                Bitmap page_img = new Bitmap(FromFile("temp.jpg")); //pega imagem repo
                Bitmap watermark_img = new Bitmap(FromFile("C:\\Users\\Maikson\\Pictures\\WaterMark_Example.jpg"));

                //MagickImage Le a imagem que vai receber marca d'agua
                using (MagickImage image = new MagickImage(page_img))
                {
                    // Lê a marca dágua que será inserida na imagem
                    using (MagickImage watermark = new MagickImage(watermark_img))
                    {
                        // Desenhando a marca no canto inferior direito (no futuro colocar pro usuario escolher)
                        image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);

                        // OU desenhe em um lugar com x/y
                        //image.Composite(watermark, 200, 50, CompositeOperator.Over);

                        // Transparencia
                        watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 4);
                    }

                    // Salvando o resultado na pasta temporaria
                    image.Write("temp.jpg");
                }
                //salvo a imagem com marca d'agua em uma variavel para ser usada futuramente
                page_img = new Bitmap(FromFile("temp.jpg")); //Pegando o arquivo na pagina temporaria
                Wait_for(40);

                //out_pdf.Save(out_fname);
                //out_pdf.Close();

                out_pdf = new PdfDocument()
                {
                    Version = pdf.Version
                };

            out_pdf.Info.Title = String.Format("Page {0} of {1}", barcode, pdf.Info.Title);
            out_pdf.Info.Creator = pdf.Info.Creator;
            out_fname = String.Format("{0}\\{1}_{2}.pdf", out_folder, fname, barcode);
            Add_new_page(page_img, out_pdf);
            //region_img.Save(out_fname + ".bmp");
            out_pdf.Save(out_fname);
            out_pdf.Close();
        }

        private void Add_new_page(Bitmap region_img, PdfDocument out_pdf)
        {
            // Adiciona a pagina e salva ela
            MemoryStream strm = new MemoryStream();
            region_img.Save(strm, System.Drawing.Imaging.ImageFormat.Png);
            PdfPage new_page = out_pdf.AddPage();
            using (XImage img = XImage.FromStream(strm))
            {
                // Calcula nova altura para manter a proporção da imagem
                var width = region_img.Width;
                var height = (int)(((double)width / (double)img.PixelWidth) * img.PixelHeight);

                // Alterar o tamanho da pagina PDF para corresponder à imagem
                new_page.Width = width;
                new_page.Height = height;

                XGraphics gfx = XGraphics.FromPdfPage(new_page);
                gfx.DrawImage(img, 0, 0, width, height);
            }
        }

    }
}
