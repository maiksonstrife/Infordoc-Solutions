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

namespace XmlFinder
{
    public partial class PagePdfReader : UserControl
    {

        public bool debug = true;
        //public PCKLIB.LicenseAlert ALERT = new PCKLIB.LicenseAlert(2);

        const int m_length = 6;

        List<string> m_input_files = new List<string>();
        string m_code;
        BarcodeFormat m_found_format;
        bool m_found;
        Timer m_timer = new Timer();
        UserSetting m_setting;

        private NotifyIcon m_trayIcon;
        private ContextMenu m_trayMenu;

        public PagePdfReader()
        {
            InitializeComponent();
        }

        private void btn_sel_in_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog dlg = new FolderBrowserDialog()
                {
                    //SelectedPath = Directory.GetCurrentDirectory()
                    //SelectedPath = Directory.GetCurrentDirectory(@"C:")
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txt_in_folder.Text = dlg.SelectedPath;
                    txt_out_folder.Text = txt_in_folder.Text + "\\Saida";

                    if (Properties.Settings.Default.SisRecortar == true)
                    {
                        //  carregaRecortar();
                        txt_marked_folder.Text = txt_in_folder.Text + "\\Marcada";

                    }
                    else
                    {
                        // carregaRenomear(); // carregaSistema3();
                        txt_marked_folder.Text = txt_in_folder.Text + "\\Nao_Detectado";
                        txt_done_folder.Text = txt_in_folder.Text + "\\Erro";
                    }

                    Update_list();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 02: " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PagePdfReader_Load(object sender, EventArgs e)
        {
            //if (String.Equals(Properties.Settings.Default.Data, ""))
            //    {
            //    MessageBox.Show("String vazia");
            //}
            //if (Properties.Settings.Default.Data == "" || Properties.Settings.Default.Data == null)
            //{
            //    Properties.Settings.Default.Data = DateTime.Now.AddDays(7).ToString("dd/mm/yyyy");
            //    Properties.Settings.Default.Save();
            //    // MessageBox.Show(Properties.Settings.Default.Data.ToString("dd/mm/yyyy"));
            //}
            //else
            //{
            //    //if (Properties.Settings.Default.Data  DateTime.Now.ToString("dd/mm/yyyy")
            //    //{
            //    //    Close();
            //    //}
            //}

            txtparamento.Text = Properties.Settings.Default.Posicoes;

            //label11.Text = "Versão: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            /*using (Form1 frmNovo = new Form1())
            {
                frmNovo.ShowDialog();
            }
            if (Properties.Settings.Default.SisRecortar == true)
            {
                carregaRecortar();

            }
            else if (Properties.Settings.Default.SisRenomear == true)
            {
                carregaRenomear();
            }
            else if (Properties.Settings.Default.SisSitema == true)
            {
                carregaSistema3();
            }*/
            
            // Carrega Configuração
        }

        void carregaRenomear()
        {
            // label7.Enabled = false;
            // txt_marked_folder.Enabled = false;
            // btn_sel_marked.Enabled = false;
            // btn_go_marked.Enabled = false;
            label8.Enabled = false;
            txt_done_folder.Enabled = false;
            btn_sel_done.Enabled = false;
            btn_go_done.Enabled = false;
            label9.Enabled = false;
            txt_header_height.Enabled = false;
            label10.Enabled = false;
            txt_footer_height.Enabled = false;
            label12.Enabled = false;
            txtTamCod.Enabled = false;
            rad_reg_height.Enabled = false;
            txt_region_height.Enabled = false;
            rad_reg_count.Enabled = false;
            txt_region_count.Enabled = false;
            // btn_start.Enabled = false;

            label15.Enabled = true;
            txtparamento.Enabled = true;
            // RbMinuto_05.Enabled = true;
            // RbMinuto_10.Enabled = true;
            //  RbMinuto_15.Enabled = true;
            // btniniciar2.Enabled = true;
            Load_setting();

            // Tempo 
            m_timer.Interval = 50 * 1000;
            m_timer.Tick += M_timer_Tick;

            // Menu Contexto
            m_trayMenu = new ContextMenu();
            m_trayIcon = new NotifyIcon()
            {
                Text = "INFOR CUTTER"
            };
            try
            {
                // m_trayIcon.Icon = ScanPDF.Properties.Resources.scan;
                // m_trayIcon.Icon = ScanPDF.Properties.Resources.estrela
                //m_trayIcon.Icon = ScanPDF.Properties.Resources.

            }
            catch
            {
                m_trayIcon.Icon = System.Drawing.SystemIcons.WinLogo;

            }
            m_trayIcon.ContextMenu = m_trayMenu;
            m_trayIcon.Visible = true;
            m_trayMenu.MenuItems.Add("Exit", OnExit);
        }

        void carregaSistema3()
        {
            // label7.Enabled = false;
            // txt_marked_folder.Enabled = false;
            // btn_sel_marked.Enabled = false;
            // btn_go_marked.Enabled = false;
            label8.Enabled = false;
            txt_done_folder.Enabled = false;
            btn_sel_done.Enabled = false;
            btn_go_done.Enabled = false;
            label9.Enabled = false;
            txt_header_height.Enabled = false;
            label10.Enabled = false;
            txt_footer_height.Enabled = false;
            label12.Enabled = false;
            txtTamCod.Enabled = false;
            rad_reg_height.Enabled = false;
            txt_region_height.Enabled = false;
            rad_reg_count.Enabled = false;
            txt_region_count.Enabled = false;
            // btn_start.Enabled = false;

            label15.Enabled = false;
            txtparamento.Enabled = false;
            // RbMinuto_05.Enabled = true;
            // RbMinuto_10.Enabled = true;
            //  RbMinuto_15.Enabled = true;
            // btniniciar2.Enabled = true;
            Load_setting();

            // Tempo 
            m_timer.Interval = 50 * 1000;
            m_timer.Tick += M_timer_Tick;

            // Menu Contexto
            m_trayMenu = new ContextMenu();
            m_trayIcon = new NotifyIcon()
            {
                Text = "INFOR CUTTER"
            };
            try
            {
                // m_trayIcon.Icon = ScanPDF.Properties.Resources.scan;
                // m_trayIcon.Icon = ScanPDF.Properties.Resources.estrela
                //m_trayIcon.Icon = ScanPDF.Properties.Resources.

            }
            catch
            {
                m_trayIcon.Icon = System.Drawing.SystemIcons.WinLogo;

            }
            m_trayIcon.ContextMenu = m_trayMenu;
            m_trayIcon.Visible = true;
            m_trayMenu.MenuItems.Add("Exit", OnExit);
        }


        void carregaRecortar()
        {

            label7.Enabled = true;
            txt_marked_folder.Enabled = true;
            btn_sel_marked.Enabled = true;
            btn_go_marked.Enabled = true;
            label8.Enabled = true;
            txt_done_folder.Enabled = true;
            btn_sel_done.Enabled = true;
            btn_go_done.Enabled = true;
            label9.Enabled = true;
            txt_header_height.Enabled = true;
            label10.Enabled = true;
            txt_footer_height.Enabled = true;
            label12.Enabled = true;
            txtTamCod.Enabled = true;
            rad_reg_height.Enabled = true;
            txt_region_height.Enabled = true;
            rad_reg_count.Enabled = true;
            txt_region_count.Enabled = true;
            btn_start.Enabled = true;
            label15.Enabled = false;
            txtparamento.Enabled = false;
            // RbMinuto_05.Enabled = false;
            // RbMinuto_10.Enabled = false;
            //  RbMinuto_15.Enabled = false;
            // btniniciar2.Enabled = false;
            Load_setting();

            // Inicialização da UI
            txt_header_height.Text = m_setting.header_height.ToString();
            txt_footer_height.Text = m_setting.footer_height.ToString();
            txt_region_height.Text = m_setting.region_height.ToString();
            txt_region_count.Text = m_setting.region_count.ToString();
            txtTamCod.Text = m_setting.tam_cod.ToString();

            // Tempo 
            m_timer.Interval = 50 * 1000;
            m_timer.Tick += M_timer_Tick;

            // Menu Contexto
            m_trayMenu = new ContextMenu();
            m_trayIcon = new NotifyIcon()
            {
                Text = "INFOR CUTTER"
            };
            try
            {
                // m_trayIcon.Icon = ScanPDF.Properties.Resources.scan;
                // m_trayIcon.Icon = ScanPDF.Properties.Resources.estrela
                //m_trayIcon.Icon = ScanPDF.Properties.Resources.

            }
            catch
            {
                m_trayIcon.Icon = System.Drawing.SystemIcons.WinLogo;

            }
            m_trayIcon.ContextMenu = m_trayMenu;
            m_trayIcon.Visible = true;
            m_trayMenu.MenuItems.Add("Exit", OnExit);
        }

        private void OnExit(object sender, EventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao fechar o sistema, " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void M_timer_Tick(object sender, EventArgs e)
        {

            //// show_info("A pasta de entrada será digitalizada automaticamente.");
            Update_list();
            if (m_input_files.Count > 0)
            {

                if (Properties.Settings.Default.SisRecortar == true)
                {
                    //carregaRecortar();
                    MessageBox.Show("A pasta de entrada será digitalizada automaticamente.", "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Process();

                }
                else if (Properties.Settings.Default.SisRenomear == true)
                {
                    //  carregaRenomear();
                    Process2();
                    ContaArquivo();
                }
                else if (Properties.Settings.Default.SisSitema == true)
                {
                    //// CarregaSistema3
                    //
                    Process3();
                }

            }
            //  Process();
        }

        void Load_setting()
        {
            try
            {
                m_setting = UserSetting.Load();
                if (m_setting == null)
                    m_setting = new UserSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 3: " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Update_list()
        {
            try
            {
                // Enumerar arquivos PDF
                m_input_files = Directory.GetFiles(txt_in_folder.Text, "*.pdf").ToList();
                lis_files.Items.Clear();
                pic_current.Image = null;

                txt_scan_result.Text = "";
                prog_tot.Value = 0; prog_sub.Value = 0;
                lab_tot_prog.Text = ""; lab_sub_prog.Text = "";
                foreach (string fname_full in m_input_files)
                {
                    string fname = fname_full.Substring(fname_full.LastIndexOf('\\') + 1);
                    PdfDocument pdf = PdfReader.Open(fname_full, PdfDocumentOpenMode.Modify);
                    lis_files.Items.Add(String.Format("{0}   ({1} pages)", fname, pdf.PageCount));
                    pdf.Close();
                }

                // Ultima atualização
                //lab_update_time.Text = DateTime.Now.ToString(@"MM\/dd\/yyyy hh\:mm tt");
                //lab_update_time.ForeColor = Color.Black;
                lab_update_time.Text = DateTime.Now.ToShortDateString();
                lab_update_time.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aualização da pasta falhou. Caminho incorreto. Erro : " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                // show_info("A aualização da pasta falhou. Caminho incorreto.");
            }
        }


        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        void Process()
        {
            string fname_full = "", fname = "", out_fname = "";

            if (m_input_files.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo será processado....", "Pasta Vazia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //show_info("Nenhum arquivo será processado....");
                return;
            }

            try
            {
                if (Directory.Exists(txt_out_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_out_folder.Text);
                }
                if (Directory.Exists(txt_done_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_done_folder.Text);
                }
                if (Directory.Exists(txt_marked_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_marked_folder.Text);
                }
            }
            catch (Exception e)
            {
                //Show_info(e.Message);
                MessageBox.Show(e.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btn_start.Enabled = false;
            btn_start.ForeColor = Color.Red;
            btn_start.Text = "Processando...";

            m_timer.Stop();

            string out_dir = "";

            Wait_for(40);
            try
            {
                float doc_height = float.Parse(txt_doc_height.Text);
                float region_height = float.Parse(txt_region_height.Text);
                float header_height = float.Parse(txt_header_height.Text);
                float footer_height = float.Parse(txt_footer_height.Text);
                int reg_cnt = int.Parse(txt_region_count.Text);

                if (region_height == 0)
                {
                    region_height = doc_height - header_height - footer_height;
                }

                // A Lista não pode ser atualizada durante o processo
                prog_tot.Maximum = m_input_files.Count;
                prog_tot.Value = 0;
                int done_cnt = 0;
                while (m_input_files.Count > 0)
                {
                    fname_full = m_input_files[0];
                    fname = fname_full.Substring(fname_full.LastIndexOf('\\') + 1);

                    PdfDocument pdf = PdfReader.Open(fname_full, PdfDocumentOpenMode.Import);

                    MagickReadSettings settings = new MagickReadSettings()
                    {
                        Density = new Density(300, 300)  //Originall
                                                         //  Density = new Density(50)
                                                         //settings.Density = new PointD(300);
                                                         // Density = new Density(260,260)
                    };
                    MagickImageCollection images = new MagickImageCollection();
                    images.Read(fname_full, settings);

                    int page_count = pdf.PageCount;
                    prog_sub.Maximum = page_count;

                    PdfPage first = pdf.Pages[0];
                    txt_doc_height.Text = first.Height.Centimeter.ToString();
                    doc_height = (float)first.Height.Centimeter;
                    if (doc_height <= float.Epsilon)
                    {
                        Console.WriteLine(String.Format("File {0} is not valid.", fname_full));
                        pdf.Close();
                        continue;
                    }
                    // first.Size = 26.9;

                    string last_code = "";
                    BarcodeFormat last_format = BarcodeFormat.UPC_E;
                    PdfDocument out_pdf = null;
                    for (int idx = 0; idx < page_count; idx++)
                    {
                        PdfPage page = pdf.Pages[idx];

                        lab_nomeArq.Visible = true;
                        lab_nomeArq.ForeColor = Color.Black;
                        lab_nomeArq.Text = String.Format("{0}  ({1}p)", fname, idx + 1);
                        // lab_current.Text = String.Format("{0}  ({1}p)", fname, idx + 1);
                        //var pdfToImg = new NReco.PdfRenderer.PdfToImageConverter(); // This library is not free! 
                        //pdfToImg.GenerateImage(fname_full, idx+1, ImageFormat.Jpeg, "temp.jpg");
                        images[idx].Write("temp.jpg");

                        Bitmap page_img = new Bitmap(FromFile("temp.jpg"));
                        pic_current.BackgroundImage = page_img;

                        Wait_for(40);
                        if (rad_reg_count.Checked)
                        {
                            if (reg_cnt <= 0)
                            {
                                //Show_info("Insira um numero maior que zero.");
                                MessageBox.Show("Insira um numero maior que zero.", "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                continue;
                            }
                            else
                            {
                                region_height = (doc_height - header_height - footer_height) / reg_cnt;
                            }
                        }
                        if (rad_reg_height.Checked)
                        {
                            if (region_height <= float.Epsilon)
                            {
                                MessageBox.Show("Essa Altura não é valida", "INFOR CUTTERR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //show_info("Region height is invalid.");
                                continue;
                            }
                            reg_cnt = (int)(doc_height / region_height);
                        }

                        if (reg_cnt <= 0 || region_height <= 0)
                        {
                            MessageBox.Show("Essa Altura não é valida", "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //show_info("Region height is invalid.");
                            continue;
                        }

                        for (int reg_id = 0; reg_id < reg_cnt; reg_id++)
                        {
                            int y = (int)((reg_id * region_height + header_height) / doc_height * page_img.Height);
                            int h = (int)(region_height / doc_height * page_img.Height);
                            Rectangle cropRect = new Rectangle(0, y, page_img.Width, h);

                            Graphics g;

                            Bitmap region_img = new Bitmap(cropRect.Width, cropRect.Height);
                            //Original
                            using (g = Graphics.FromImage(region_img))
                            {
                                g.DrawImage(page_img, new Rectangle(0, 0, region_img.Width, region_img.Height), cropRect, GraphicsUnit.Pixel);
                            }
                            //Final
                            bool marked = Check_mark(region_img);

                            // Desenha um triangulo no PicCurrent
                            g = pic_current.CreateGraphics();
                            Pen pen;
                            if (marked == false)
                            {
                                //pen = new Pen(System.Drawing.Color.Red);
                                pen = new Pen(System.Drawing.Color.Cyan);
                                out_dir = txt_out_folder.Text; //Joga na pasta de saida
                            }
                            else
                            {
                                //pen = new Pen(System.Drawing.Color.Blue);
                                pen = new Pen(System.Drawing.Color.DarkSalmon);
                                out_dir = txt_marked_folder.Text; // Joga na pasta Marcada
                            }

                            //Inicio
                            int _y = (int)((reg_id * region_height + header_height) / doc_height * pic_current.Height);
                            int _h = (int)(region_height / doc_height * pic_current.Height);
                            g.DrawRectangle(pen, 0, _y, pic_current.Width - 5, _h);// Original
                                                                                   // g.DrawRectangle(pen, 0, _y + 5, pic_current.Width + 10, _h + 5);
                                                                                   //Fim

                            m_found = false;
                            if (TryReadCode(region_img, 0) == true)
                            {

                                // string phrase = "The quick brown    fox     jumps over the lazy dog.";
                                // string[] words = m_code.Split(',');

                                //foreach (var word in words)
                                //{
                                //    // System.Console.WriteLine($"<{word}>");
                                //    MessageBox.Show($"<{word}>");
                                //}

                                //  m_code = words[3].Substring(6).Replace("\"","")+ "_" + words[4].Substring(6).Replace("\"","").ToLowerInvariant()+"_" + words[5].Substring(6).Replace("\"","");
                                txt_scan_result.Text = m_code;
                                Wait_for(40);
                                if (m_code != last_code)
                                {
                                    last_code = Check_filename_valid(last_code);
                                    if (out_pdf != null && last_code != "" && out_pdf.PageCount > 0)
                                    {
                                        try
                                        {
                                            out_pdf.Save(out_fname);
                                            out_pdf.Close();

                                        }
                                        catch
                                        {

                                        }

                                    }

                                    last_code = m_code;
                                    last_format = m_found_format;

                                    //// Cria novo documento
                                    out_pdf = new PdfDocument()
                                    {
                                        Version = pdf.Version
                                    };
                                    out_pdf.Info.Title = String.Format("Page {0} of {1}", idx + 1, pdf.Info.Title);
                                    out_pdf.Info.Creator = pdf.Info.Creator;

                                    //Renomeia os arquivos 
                                    if (m_found_format == BarcodeFormat.QR_CODE)
                                        out_fname = out_dir + "\\" + last_code + ".pdf";
                                    else
                                        out_fname = out_dir + "\\" + last_code + ".pdf";
                                }

                                // Adiciona a pagina e salva ela
                                Add_new_page(region_img, out_pdf);
                            }
                            else
                            {
                                txt_scan_result.Text = "Nenhum codigo de barra ou QR Code detectado";
                                Wait_for(40);
                                //  last_code = Interaction.InputBox("Informe o codigo", "InfoCutter", "*", 150, 150);
                                if (out_pdf != null && last_code != "" && out_pdf.PageCount > 0)
                                {
                                    out_pdf.Save(out_fname);
                                    out_pdf.Close();
                                }
                                last_code = "";

                                out_pdf = new PdfDocument()
                                {
                                    Version = pdf.Version
                                };
                                out_pdf.Info.Title = String.Format("Page {0} of {1}", idx + 1, pdf.Info.Title);
                                out_pdf.Info.Creator = pdf.Info.Creator;
                                out_fname = String.Format("{0}\\Desconhecido_{1}_{2}_{3}.pdf", out_dir, fname, idx, reg_id);
                                Add_new_page(region_img, out_pdf);
                                //region_img.Save(out_fname + ".bmp");
                                out_pdf.Save(out_fname);
                                out_pdf.Close();
                            }//Acaba aqui !!
                        }
                        prog_sub.Value = idx + 1;
                        lab_sub_prog.Text = String.Format("{0} / {1}", idx + 1, page_count);
                    }

                    if (out_pdf != null && last_code != "" && out_pdf.PageCount > 0)
                    {
                        out_pdf.Save(out_fname);
                    }

                    prog_tot.Value = ++done_cnt;
                    lab_tot_prog.Text = String.Format("{0} / {1}", done_cnt, m_input_files.Count);

                    pdf.Close();

                    // Move o arquivo processado para a pasta concluido
                    string tar_fname = fname;
                    while (File.Exists(Path.Combine(txt_done_folder.Text, tar_fname)))
                    {
                        tar_fname = "_" + tar_fname;
                    }
                    File.Move(fname_full, Path.Combine(txt_done_folder.Text, tar_fname));

                    m_input_files.RemoveAt(0);
                }
                // show_info("Processing ended successfully.");
                MessageBox.Show("Processamento Finalizado com Sucesso.", "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace.ToString());
                Debug.WriteLine(String.Format("ERROR: {0} -> {1}", lab_current.Text, out_fname));
                MessageBox.Show("Processamento interrompido por causa do erro : " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //show_info("Processing stopped because of error: " + ex.Message);
            }
            finally
            {
                Finalize_process();
            }
        }

        void Finalize_process()
        {

            //if (Properties.Settings.Default.SisRecortar == true)
            //{
            //carregaRecortar();
            //Process();
            btn_start.Enabled = true;
            btn_start.Text = "INICIAR";
            btn_start.ForeColor = Color.Cyan;
            Update_list();
            m_timer.Start();

            //}
            //else
            //{
            //    //  carregaRenomear();
            //    //  Process2();
            //    btniniciar2.Enabled = true;
            //    btniniciar2.Text = "INICIAR";
            //    btniniciar2.ForeColor = Color.DarkTurquoise;
            //    Update_list();
            //    m_timer.Start();
            //}

        }
        void Wait_for(int milisec)
        {
            DateTime tm = DateTime.Now;
            while (DateTime.Now.Subtract(tm).Milliseconds < milisec)
            {
                Application.DoEvents();
            }
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

        private string Check_filename_valid(string input)
        {
            //string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            string output = r.Replace(input, "");
            if (output == "_")
                return "INVALID";
            else
                return output;
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
                //  if (res != null && (res.BarcodeFormat == BarcodeFormat.QR_CODE))
                if (res != null && (res.BarcodeFormat == BarcodeFormat.QR_CODE || res.Text.Length == int.Parse(txtTamCod.Text))) //Original 21/06
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
                // if (res != null && (res.BarcodeFormat == BarcodeFormat.QR_CODE || res.Text.Length == int.Parse(txtTamCod.Text))) //Original 21/06
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
                // if (res != null && (res.BarcodeFormat == BarcodeFormat.QR_CODE || res.Text.Length == int.Parse(txtTamCod.Text))) //Original 21/06
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
                    //  if (barcodes[i].ToString().Length == int.Parse(txtTamCod.Text)) //Original 
                    break;
            if (i < barcodes.Count)
                if (i < barcodes.Count)
                    if (i < barcodes.Count)
                    {
                        m_found = true;
                        m_code = barcodes[i].ToString();
                        //m_found_format = BarcodeFormat.CODE_128; // Original
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

        private Bitmap CropImage(Bitmap src, int x, int y, int width, int height)
        {
            var cropRect = new Rectangle(x, y, width, height);
            var target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
            }
            //**********************************************Teste**********************************************
            //using (var doc = new PdfSharp.Pdf.PdfDocument())
            //{
            //    var page = doc.AddPage();
            //    var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
            //    var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
            //   // var font = new PdfSharp.Drawing.XFont("Arial", 14, PdfSharp.Drawing.XFontStyle.BoldItalic);

            //    textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
            //   // textFormatter.DrawString("Que belo texto!", font, PdfSharp.Drawing.XBrushes.Red, new PdfSharp.Drawing.XRect(0, 50, page.Width, page.Height));

            //   // graphics.DrawLine(PdfSharp.Drawing.XPens.Blue, 150, 150, 250, 200);
            //   // graphics.DrawRoundedRectangle(PdfSharp.Drawing.XPens.Green, PdfSharp.Drawing.XBrushes.LightGreen, 100, 300, 100, 50, 10, 10);

            //    graphics.DrawImage(PdfSharp.Drawing.XImage.FromFile(page_img), 250, 300);

            //    doc.Save("arquivo.pdf");
            //    System.Diagnostics.Process.Start("arquivo.pdf");
            //}

            return target;
        }

        private void Link_url_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Pic_logo_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(link_url.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 05: " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Btn_start_EnabledChanged(object sender, EventArgs e)
        {
            //Button from = sender as Button;
            //btn_start.ForeColor = from.Enabled == false ? Color.Red : Color.White;
            //btn_start.BackColor = from.Enabled == false ? Color.FromArgb(100, 100, 100): Color.FromArgb(80, 80, 80);
        }



        public void Show_info(string text)
        {
            if (true)
            {
                //MessageBox.Show(text);
                //  MessageBox.Show(text , "INFO PDF",3000);
                AutoClosingMessageBox.Show(text, "ScanPDF", 3000);
            }
            else
            {
                //   m_trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                // m_trayIcon.BalloonTipTitle = "INFO PDF";
                //m_trayIcon.BalloonTipText = text;
                //m_trayIcon.ShowBalloonTip(2000);
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                m_setting.header_height = float.Parse(txt_header_height.Text);
                m_setting.footer_height = float.Parse(txt_footer_height.Text);
                m_setting.region_height = float.Parse(txt_region_height.Text);
                m_setting.region_count = int.Parse(txt_region_count.Text);
                m_setting.tam_cod = int.Parse(txtTamCod.Text);
                m_setting.Save();

                m_trayIcon.Dispose();

                Properties.Settings.Default.Posicoes = txtparamento.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                //show_info("Settings are not saved because of format error: " + ex.Message);
                MessageBox.Show("As configurações não seram salvas devido a um erro de formato : " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
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

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(link_url.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 15: " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process2();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void Process2()
        {

            string fname_full = "", fname = "", out_fname = "";

            if (m_input_files.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo será processado....", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //show_info("Nenhum arquivo será processado....");
                return;
            }

            try
            {
                if (Directory.Exists(txt_out_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_out_folder.Text);
                }
                if (Directory.Exists(txt_done_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_done_folder.Text);
                }
                if (Directory.Exists(txt_marked_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_marked_folder.Text);
                }
            }
            catch (Exception e)
            {
                //Show_info(e.Message);
                MessageBox.Show(e.Message, "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btn_start.Enabled = false;
            btn_start.ForeColor = Color.Red;
            btn_start.Text = "Processando....";

            m_timer.Stop();

            string out_dir = "";

            Wait_for(40);
            try
            {
                float doc_height = float.Parse(txt_doc_height.Text);
                float region_height = float.Parse(txt_region_height.Text);
                float header_height = 0f;//float.Parse(txt_header_height.Text);
                float footer_height = 0f;//float.Parse(txt_footer_height.Text);
                int reg_cnt = 1;//int.Parse(txt_region_count.Text);

                if (region_height == 0)
                {
                    region_height = doc_height - header_height - footer_height;
                }

                // A Lista não pode ser atualizada durante o processo
                prog_tot.Maximum = m_input_files.Count;
                prog_tot.Value = 0;
                int done_cnt = 0;
                while (m_input_files.Count > 0)
                {
                    fname_full = m_input_files[0];
                    fname = fname_full.Substring(fname_full.LastIndexOf('\\') + 1);

                    PdfDocument pdf = PdfReader.Open(fname_full, PdfDocumentOpenMode.Import);

                    MagickReadSettings settings = new MagickReadSettings()
                    {
                        Density = new Density(300, 300)  //Originall

                    };
                    MagickImageCollection images = new MagickImageCollection();
                    images.Read(fname_full, settings);

                    int page_count = pdf.PageCount;
                    prog_sub.Maximum = page_count;

                    PdfPage first = pdf.Pages[0];
                    txt_doc_height.Text = first.Height.Centimeter.ToString();
                    doc_height = (float)first.Height.Centimeter;
                    if (doc_height <= float.Epsilon)
                    {
                        Console.WriteLine(String.Format("File {0} is not valid.", fname_full));
                        pdf.Close();
                        continue;
                    }
                    // first.Size = 26.9;

                    string last_code = "";
                    BarcodeFormat last_format = BarcodeFormat.UPC_E;
                    PdfDocument out_pdf = null;
                    //for (int idx = 0; idx < page_count; idx++) //Original lendo pagina por pagina
                    for (int idx = 0; idx < 1; idx++) // Lendo a primeira pagina 
                    {
                        PdfPage page = pdf.Pages[idx];

                        lab_nomeArq.Visible = true;
                        lab_nomeArq.ForeColor = Color.Black;
                        lab_nomeArq.Text = String.Format("{0}  ({1}p)", fname, idx + 1);
                        // lab_current.Text = String.Format("{0}  ({1}p)", fname, idx + 1);
                        //var pdfToImg = new NReco.PdfRenderer.PdfToImageConverter(); // This library is not free! 
                        //pdfToImg.GenerateImage(fname_full, idx+1, ImageFormat.Jpeg, "temp.jpg");
                        images[idx].Write("temp.jpg");

                        Bitmap page_img = new Bitmap(FromFile("temp.jpg"));
                        pic_current.BackgroundImage = page_img;

                        Wait_for(40);
                        if (rad_reg_count.Checked)
                        {
                            if (reg_cnt <= 0)
                            {
                                //Show_info("Insira um numero maior que zero.");
                                MessageBox.Show("Insira um numero maior que zero.", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }
                            else
                            {
                                region_height = (doc_height - header_height - footer_height) / reg_cnt;
                            }
                        }
                        if (rad_reg_height.Checked)
                        {
                            if (region_height <= float.Epsilon)
                            {
                                MessageBox.Show("Essa Altura não é valida", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //show_info("Region height is invalid.");
                                continue;
                            }
                            reg_cnt = (int)(doc_height / region_height);
                        }

                        if (reg_cnt <= 0 || region_height <= 0)
                        {
                            MessageBox.Show("Essa Altura não é valida", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //show_info("Region height is invalid.");
                            continue;
                        }

                        for (int reg_id = 0; reg_id < reg_cnt; reg_id++)
                        {
                            int y = (int)((reg_id * region_height + header_height) / doc_height * page_img.Height);
                            int h = (int)(region_height / doc_height * page_img.Height);
                            Rectangle cropRect = new Rectangle(0, y, page_img.Width, h);

                            Graphics g;

                            Bitmap region_img = new Bitmap(cropRect.Width, cropRect.Height);
                            //Original
                            using (g = Graphics.FromImage(region_img))
                            {
                                g.DrawImage(page_img, new Rectangle(0, 0, region_img.Width, region_img.Height), cropRect, GraphicsUnit.Pixel);
                            }
                            //Final
                            bool marked = Check_mark(region_img);

                            // Desenha um triangulo no PicCurrent
                            g = pic_current.CreateGraphics();
                            Pen pen;
                            if (marked == false)
                            {
                                //pen = new Pen(System.Drawing.Color.Red);
                                pen = new Pen(System.Drawing.Color.Cyan);
                                out_dir = txt_out_folder.Text; //Joga na pasta de saida
                            }
                            else
                            {
                                //pen = new Pen(System.Drawing.Color.Blue);
                                pen = new Pen(System.Drawing.Color.DarkSalmon);
                                out_dir = txt_marked_folder.Text; // Joga na pasta Marcada
                            }

                            //Inicio
                            int _y = (int)((reg_id * region_height + header_height) / doc_height * pic_current.Height);
                            int _h = (int)(region_height / doc_height * pic_current.Height);
                            g.DrawRectangle(pen, 0, _y, pic_current.Width - 5, _h);// Original
                                                                                   // g.DrawRectangle(pen, 0, _y + 5, pic_current.Width + 10, _h + 5);
                                                                                   //Fim

                            m_found = false;
                            if (TryReadCode(region_img, 0) == true)
                            {
                                Boolean pulaNumero = true;

                                // MessageBox.Show(m_code);
                                // string phrase = "The quick brown    fox     jumps over the lazy dog.";
                                string[] words = m_code.Split(',');

                                Dictionary<string, string> dict = new Dictionary<string, string>();

                                //dict.Add(words[0].Substring(2,1).Replace(":","").Replace("{",""),words[0].Substring(6).Replace(":","").Replace("'",""));
                                //dict.Add(words[1], words[1]);
                                for (int i = 0; i < words.Length; i++)
                                //  foreach (var word in words)
                                {
                                    // System.Console.WriteLine($"<{word}>");

                                    //MessageBox.Show($"<{word}>");
                                    string[] dados = words[i].Split(':');

                                    if (dados[0].Contains("17"))
                                    {

                                        pulaNumero = false;
                                        //break;

                                    }
                                    else
                                    {
                                        string numero = dados[0].Replace("{", "").Replace("/", "").Replace("\"", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"');

                                        if (Char.IsDigit(numero, 0)) //------representa numeros, comeca a ler apartir da posicao zero

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


                                        // dict.Add(Convert.ToInt32(dados[0].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"')), dados[1].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'));

                                    }
                                    //  MessageBox.Show("1" + dados[0] + "dados: " + dados[1]);
                                    //dict.Add(Convert.ToInt32(dados[0].Replace("{", "").Replace("\"","").Replace("}","").Replace("/","").Replace("-","").Replace(".","").TrimStart('"').TrimEnd('"')), dados[1].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".","").TrimStart('"').TrimEnd('"')) ;
                                    // MessageBox.Show(dict[i]);
                                    dados = null;
                                }

                                //m_code = dict[12];
                                //foreach (var item in dict)
                                //{
                                //    MessageBox.Show("Chave: " + item.Key + " - Valor: " + item.Value);
                                //}
                                //dict.Add(words[2], words[2]);
                                //dict.Add(words[3], words[3]);
                                //dict.Add(words[4], words[4]);
                                //dict.Add(words[5], words[5]);
                                //dict.Add(words[6], words[6]);
                                //dict.Add(words[7], words[7]);
                                //dict.Add(words[8], words[8]);
                                //dict.Add(words[9], words[9]);
                                //dict.Add(words[10], words[10]);
                                //dict.Add(words[11], words[11]);

                                string[] posicao = txtparamento.Text.Split(';');

                                int tamanho = posicao.Length;

                                //foreach (var word in words)
                                //{
                                //    // System.Console.WriteLine($"<{word}>");
                                //    MessageBox.Show($"<{word}>");
                                //}

                                if (tamanho == 1)
                                {
                                    //m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                    m_code = dict[(posicao[0])];

                                }
                                else if (tamanho == 2)
                                {
                                    //  m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                    m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])];
                                }
                                else if (tamanho == 3)
                                {
                                    // m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[2]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                    m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])];
                                }
                                else if (tamanho == 4)
                                {
                                    // m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[2]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[3]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                    m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])] + "_" + dict[(posicao[3])];
                                }
                                else if (tamanho == 5)
                                {
                                    // m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[2]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[3]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[4]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                    m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])] + "_" + dict[(posicao[3])] + "_" + dict[(posicao[4])];
                                }

                                //  m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "") + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToLowerInvariant() + "_" + words[(Convert.ToInt32(posicao[2]))].Substring(6).Replace("\"", "");
                                //  m_code = words[3].Substring(6).Replace("\"", "") + "_" + words[4].Substring(6).Replace("\"", "").ToLowerInvariant() + "_" + words[5].Substring(6).Replace("\"", ""); Original

                                txt_scan_result.Text = m_code.Replace("/", "").ToUpperInvariant();

                                txt_scan_result.Text = txt_scan_result.Text.Replace("{", "");
                                txt_scan_result.Text = txt_scan_result.Text.Replace("}", "");
                                txt_scan_result.Text = txt_scan_result.Text.Replace(":", "");
                                //Teste copiar
                                string fileName = fname;//txt_scan_result.Text + ".pdf";
                                string textEncode = System.Web.HttpUtility.UrlEncode(txt_scan_result.Text, Encoding.GetEncoding("iso-8859-7"));
                                string textDecode = System.Web.HttpUtility.UrlDecode(textEncode);
                                // string novoNome = txt_scan_result.Text + ".pdf";
                                string novoNome = textDecode + ".pdf";
                                string sourcePath = txt_in_folder.Text;
                                string targetPath = txt_out_folder.Text;

                                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                                string destFile = System.IO.Path.Combine(targetPath, novoNome);

                                System.IO.File.Copy(sourceFile, destFile, true);

                                //Fim 
                                Wait_for(40);

                            }
                            else
                            {
                                try
                                {
                                    String date = (DateTime.Now.ToString("yyyy-MM-dd:HH:mm:ss"));
                                    txt_scan_result.Text = "Nenhum QR Code detectado";
                                    //Wait_for(40);
                                    string novoNome = "Nao_Detectado_" + date.Replace(":", "_") + ".pdf";
                                    string sourcePath = txt_in_folder.Text;
                                    string targetPath = txt_marked_folder.Text;
                                    string sourceFile = System.IO.Path.Combine(sourcePath, fname);
                                    string destFile = System.IO.Path.Combine(targetPath, novoNome);

                                    System.IO.File.Copy(sourceFile, destFile, true);

                                    //  MessageBox.Show("Nenhum Codigo detectado", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                catch
                                {
                                    MessageBox.Show("Erro 22", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                //show_info("Nenhum arquivo será processado....");
                                //  return;

                                ////  last_code = Interaction.InputBox("Informe o codigo", "InfoCutter", "*", 150, 150);
                                //if (out_pdf != null && last_code != "" && out_pdf.PageCount > 0)
                                //{
                                //    out_pdf.Save(out_fname);
                                //    out_pdf.Close();
                                //}
                                //last_code = "";
                                //finally {
                                //  Finalize_process();
                                // }
                                //out_pdf = new PdfDocument()
                                //{
                                //    Version = pdf.Version
                                //};
                                //out_pdf.Info.Title = String.Format("Page {0} of {1}", idx + 1, pdf.Info.Title);
                                //out_pdf.Info.Creator = pdf.Info.Creator;
                                //out_fname = String.Format("{0}\\Desconhecido_{1}_{2}_{3}.pdf", out_dir, fname, idx, reg_id);
                                //Add_new_page(region_img, out_pdf);
                                ////region_img.Save(out_fname + ".bmp");
                                //out_pdf.Save(out_fname);
                                //out_pdf.Close();
                            }//Acaba aqui !!

                        }
                        prog_sub.Value = idx + 1;
                        lab_sub_prog.Text = String.Format("{0} / {1}", idx + 1, page_count);
                    }

                    if (out_pdf != null && last_code != "" && out_pdf.PageCount > 0)
                    {
                        //  out_pdf.Save(out_fname);
                    }

                    prog_tot.Value = ++done_cnt;
                    lab_tot_prog.Text = String.Format("{0} / {1}", done_cnt, m_input_files.Count);

                    pdf.Close();

                    // Move o arquivo processado para a pasta concluido
                    //string tar_fname = fname;
                    //while (File.Exists(Path.Combine(txt_done_folder.Text, tar_fname)))
                    //{
                    //    tar_fname = "_" + tar_fname;
                    //}
                    //File.Move(fname_full, Path.Combine(txt_done_folder.Text, tar_fname));

                    string lixo = txt_in_folder.Text + "\\" + fname;
                    File.Delete(lixo);
                    m_input_files.RemoveAt(0);
                }
                // show_info("Processing ended successfully.");
                MessageBox.Show("Processamento Finalizado com Sucesso.", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace.ToString());
                Debug.WriteLine(String.Format("ERROR: {0} -> {1}", lab_current.Text, out_fname));
                MessageBox.Show("Processamento interrompido por causa do erro : " + ex.Message, "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //show_info("Processing stopped because of error: " + ex.Message);
                string tar_fname = fname;
                while (File.Exists(Path.Combine(txt_done_folder.Text, tar_fname)))
                {
                    tar_fname = "_" + tar_fname;
                }
                File.Move(fname_full, Path.Combine(txt_done_folder.Text, tar_fname));

                m_input_files.RemoveAt(0);
                ContaArquivo();

            }
            finally
            {
                Finalize_process();
            }
        }

        void Process3()
        {
            string fname_full = "", fname = "", out_fname = "";

            if (m_input_files.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo será processado....", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //show_info("Nenhum arquivo será processado....");
                return;
            }

            try
            {
                if (Directory.Exists(txt_out_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_out_folder.Text);
                }
                if (Directory.Exists(txt_done_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_done_folder.Text);
                }
                if (Directory.Exists(txt_marked_folder.Text) == false)
                {
                    Directory.CreateDirectory(txt_marked_folder.Text);
                }
            }
            catch (Exception e)
            {
                //Show_info(e.Message);
                MessageBox.Show(e.Message, "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btn_start.Enabled = false;
            btn_start.ForeColor = Color.Red;
            btn_start.Text = "Processando....";

            m_timer.Stop();

            string out_dir = "";

            Wait_for(40);
            try
            {
                float doc_height = float.Parse(txt_doc_height.Text);
                float region_height = float.Parse(txt_region_height.Text);
                float header_height = 0f;//float.Parse(txt_header_height.Text);
                float footer_height = 0f;//float.Parse(txt_footer_height.Text);
                int reg_cnt = 1;//int.Parse(txt_region_count.Text);

                if (region_height == 0)
                {
                    region_height = doc_height - header_height - footer_height;
                }

                // A Lista não pode ser atualizada durante o processo
                prog_tot.Maximum = m_input_files.Count;
                prog_tot.Value = 0;
                int done_cnt = 0;
                while (m_input_files.Count > 0)
                {
                    fname_full = m_input_files[0];
                    fname = fname_full.Substring(fname_full.LastIndexOf('\\') + 1);

                    PdfDocument pdf = PdfReader.Open(fname_full, PdfDocumentOpenMode.Import);

                    MagickReadSettings settings = new MagickReadSettings()
                    {
                        Density = new Density(300, 300)  //Originall

                    };
                    MagickImageCollection images = new MagickImageCollection();
                    images.Read(fname_full, settings);

                    int page_count = pdf.PageCount;
                    prog_sub.Maximum = page_count;

                    PdfPage first = pdf.Pages[0];
                    txt_doc_height.Text = first.Height.Centimeter.ToString();
                    doc_height = (float)first.Height.Centimeter;
                    if (doc_height <= float.Epsilon)
                    {
                        Console.WriteLine(String.Format("File {0} is not valid.", fname_full));
                        pdf.Close();
                        continue;
                    }
                    // first.Size = 26.9;

                    string last_code = "";
                    BarcodeFormat last_format = BarcodeFormat.UPC_E;
                    PdfDocument out_pdf = null;
                    //for (int idx = 0; idx < page_count; idx++) //Original lendo pagina por pagina
                    for (int idx = 0; idx < 1; idx++) // Lendo a primeira pagina 
                    {
                        PdfPage page = pdf.Pages[idx];

                        lab_nomeArq.Visible = true;
                        lab_nomeArq.ForeColor = Color.Black;
                        lab_nomeArq.Text = String.Format("{0}  ({1}p)", fname, idx + 1);
                        // lab_current.Text = String.Format("{0}  ({1}p)", fname, idx + 1);
                        //var pdfToImg = new NReco.PdfRenderer.PdfToImageConverter(); // This library is not free! 
                        //pdfToImg.GenerateImage(fname_full, idx+1, ImageFormat.Jpeg, "temp.jpg");
                        images[idx].Write("temp.jpg");

                        Bitmap page_img = new Bitmap(FromFile("temp.jpg"));
                        pic_current.BackgroundImage = page_img;

                        Wait_for(40);
                        if (rad_reg_count.Checked)
                        {
                            if (reg_cnt <= 0)
                            {
                                //Show_info("Insira um numero maior que zero.");
                                MessageBox.Show("Insira um numero maior que zero.", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }
                            else
                            {
                                region_height = (doc_height - header_height - footer_height) / reg_cnt;
                            }
                        }
                        if (rad_reg_height.Checked)
                        {
                            if (region_height <= float.Epsilon)
                            {
                                MessageBox.Show("Essa Altura não é valida", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //show_info("Region height is invalid.");
                                continue;
                            }
                            reg_cnt = (int)(doc_height / region_height);
                        }

                        if (reg_cnt <= 0 || region_height <= 0)
                        {
                            MessageBox.Show("Essa Altura não é valida", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //show_info("Region height is invalid.");
                            continue;
                        }

                        for (int reg_id = 0; reg_id < reg_cnt; reg_id++)
                        {
                            int y = (int)((reg_id * region_height + header_height) / doc_height * page_img.Height);
                            int h = (int)(region_height / doc_height * page_img.Height);
                            Rectangle cropRect = new Rectangle(0, y, page_img.Width, h);

                            Graphics g;

                            Bitmap region_img = new Bitmap(cropRect.Width, cropRect.Height);
                            //Original
                            using (g = Graphics.FromImage(region_img))
                            {
                                g.DrawImage(page_img, new Rectangle(0, 0, region_img.Width, region_img.Height), cropRect, GraphicsUnit.Pixel);
                            }
                            //Final
                            bool marked = Check_mark(region_img);

                            // Desenha um triangulo no PicCurrent
                            g = pic_current.CreateGraphics();
                            Pen pen;
                            if (marked == false)
                            {
                                //pen = new Pen(System.Drawing.Color.Red);
                                pen = new Pen(System.Drawing.Color.Cyan);
                                out_dir = txt_out_folder.Text; //Joga na pasta de saida
                            }
                            else
                            {
                                //pen = new Pen(System.Drawing.Color.Blue);
                                pen = new Pen(System.Drawing.Color.DarkSalmon);
                                out_dir = txt_marked_folder.Text; // Joga na pasta Marcada
                            }

                            //Inicio
                            int _y = (int)((reg_id * region_height + header_height) / doc_height * pic_current.Height);
                            int _h = (int)(region_height / doc_height * pic_current.Height);
                            g.DrawRectangle(pen, 0, _y, pic_current.Width - 5, _h);// Original
                                                                                   // g.DrawRectangle(pen, 0, _y + 5, pic_current.Width + 10, _h + 5);
                                                                                   //Fim

                            m_found = false;
                            if (TryReadCode(region_img, 0) == true)
                            {
                                Boolean pulaNumero = true;

                                // MessageBox.Show(m_code);
                                // string phrase = "The quick brown    fox     jumps over the lazy dog.";
                                string[] words = m_code.Split(',');

                                Dictionary<string, string> dict = new Dictionary<string, string>();

                                //dict.Add(words[0].Substring(2,1).Replace(":","").Replace("{",""),words[0].Substring(6).Replace(":","").Replace("'",""));
                                //dict.Add(words[1], words[1]);
                                for (int i = 0; i < words.Length; i++)
                                //  foreach (var word in words)
                                {
                                    // System.Console.WriteLine($"<{word}>");

                                    //MessageBox.Show($"<{word}>");
                                    string[] dados = words[i].Split(':');

                                    //if (dados[0].Contains("17"))
                                    //{

                                    //    pulaNumero = false;
                                    //    //break;

                                    //}
                                    //else
                                    //{
                                    //    string numero = dados[0].Replace("{", "").Replace("/", "").Replace("\"", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"');

                                    //    if (Char.IsDigit(numero, 0)) //------representa numeros, comeca a ler apartir da posicao zero

                                    //    {
                                    //        if (Convert.ToInt32(numero) < 17 && pulaNumero == true || Convert.ToInt32(numero) > 18 && Convert.ToInt32(numero) < 100)  //Original
                                    //                                                                                                                                  //  if (Convert.ToInt32(dados[0]) < 17 )
                                    //        {
                                    //            dict.Add(dados[0].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'), dados[1].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'));
                                    //        }
                                    //        else
                                    //        {

                                    //            if (Convert.ToInt32(numero) == 18)
                                    //            {
                                    //                dict.Add(dados[0].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'), dados[1].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'));
                                    //                pulaNumero = true;

                                    //            }
                                    //        }

                                    //    }


                                    //    // dict.Add(Convert.ToInt32(dados[0].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"')), dados[1].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".", "").TrimStart('"').TrimEnd('"'));

                                    //}
                                    //  MessageBox.Show("1" + dados[0] + "dados: " + dados[1]);
                                    //dict.Add(Convert.ToInt32(dados[0].Replace("{", "").Replace("\"","").Replace("}","").Replace("/","").Replace("-","").Replace(".","").TrimStart('"').TrimEnd('"')), dados[1].Replace("{", "").Replace("\"", "").Replace("}", "").Replace("/", "").Replace("-", "").Replace(".","").TrimStart('"').TrimEnd('"')) ;
                                    // MessageBox.Show(dict[i]);
                                    dados = null;
                                }

                                //m_code = dict[12];
                                //foreach (var item in dict)
                                //{
                                //    MessageBox.Show("Chave: " + item.Key + " - Valor: " + item.Value);
                                //}
                                //dict.Add(words[2], words[2]);
                                //dict.Add(words[3], words[3]);
                                //dict.Add(words[4], words[4]);
                                //dict.Add(words[5], words[5]);
                                //dict.Add(words[6], words[6]);
                                //dict.Add(words[7], words[7]);
                                //dict.Add(words[8], words[8]);
                                //dict.Add(words[9], words[9]);
                                //dict.Add(words[10], words[10]);
                                //dict.Add(words[11], words[11]);

                                string[] posicao = txtparamento.Text.Split(';');

                                int tamanho = posicao.Length;

                                //foreach (var word in words)
                                //{
                                //    // System.Console.WriteLine($"<{word}>");
                                //    MessageBox.Show($"<{word}>");
                                //}

                                //if (tamanho == 1)
                                //{
                                //    //m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                //    m_code = dict[(posicao[0])];

                                //}
                                //else if (tamanho == 2)
                                //{
                                //    //  m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                //    m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])];
                                //}
                                //else if (tamanho == 3)
                                //{
                                //    // m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[2]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                //    m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])];
                                //}
                                //else if (tamanho == 4)
                                //{
                                //    // m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[2]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[3]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                //    m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])] + "_" + dict[(posicao[3])];
                                //}
                                //else if (tamanho == 5)
                                //{
                                //    // m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[2]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[3]))].Substring(6).Replace("\"", "").ToUpperInvariant() + "_" + words[(Convert.ToInt32(posicao[4]))].Substring(6).Replace("\"", "").ToUpperInvariant();
                                //    m_code = dict[(posicao[0])] + "_" + dict[(posicao[1])] + "_" + dict[(posicao[2])] + "_" + dict[(posicao[3])] + "_" + dict[(posicao[4])];
                                //}

                                //  m_code = words[(Convert.ToInt32(posicao[0]))].Substring(6).Replace("\"", "") + "_" + words[(Convert.ToInt32(posicao[1]))].Substring(6).Replace("\"", "").ToLowerInvariant() + "_" + words[(Convert.ToInt32(posicao[2]))].Substring(6).Replace("\"", "");
                                //  m_code = words[3].Substring(6).Replace("\"", "") + "_" + words[4].Substring(6).Replace("\"", "").ToLowerInvariant() + "_" + words[5].Substring(6).Replace("\"", ""); Original

                                txt_scan_result.Text = m_code.Replace("/", "").ToUpperInvariant();

                                txt_scan_result.Text = txt_scan_result.Text.Replace("{", "");
                                txt_scan_result.Text = txt_scan_result.Text.Replace("}", "");
                                txt_scan_result.Text = txt_scan_result.Text.Replace(":", "");
                                txt_scan_result.Text = txt_scan_result.Text.Replace(";", "");
                                txt_scan_result.Text = txt_scan_result.Text.Replace("\"", "");
                                //Teste copiar
                                string fileName = fname;//txt_scan_result.Text + ".pdf";
                                string textEncode = System.Web.HttpUtility.UrlEncode(txt_scan_result.Text, Encoding.GetEncoding("iso-8859-7"));
                                string textDecode = System.Web.HttpUtility.UrlDecode(textEncode);
                                // string novoNome = txt_scan_result.Text + ".pdf";
                                string novoNome = textDecode + ".pdf";
                                string sourcePath = txt_in_folder.Text;
                                string targetPath = txt_out_folder.Text;

                                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                                string destFile = System.IO.Path.Combine(targetPath, novoNome);

                                System.IO.File.Copy(sourceFile, destFile, true);

                                //Fim 
                                Wait_for(40);

                            }
                            else
                            {
                                try
                                {
                                    String date = (DateTime.Now.ToString("yyyy-MM-dd:HH:mm:ss"));
                                    txt_scan_result.Text = "Nenhum QR Code detectado";
                                    //Wait_for(40);
                                    string novoNome = "Nao_Detectado_" + date.Replace(":", "_") + ".pdf";
                                    string sourcePath = txt_in_folder.Text;
                                    string targetPath = txt_marked_folder.Text;
                                    string sourceFile = System.IO.Path.Combine(sourcePath, fname);
                                    string destFile = System.IO.Path.Combine(targetPath, novoNome);

                                    System.IO.File.Copy(sourceFile, destFile, true);

                                    //  MessageBox.Show("Nenhum Codigo detectado", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                catch
                                {
                                    MessageBox.Show("Erro 22", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                //show_info("Nenhum arquivo será processado....");
                                //  return;

                                ////  last_code = Interaction.InputBox("Informe o codigo", "InfoCutter", "*", 150, 150);
                                //if (out_pdf != null && last_code != "" && out_pdf.PageCount > 0)
                                //{
                                //    out_pdf.Save(out_fname);
                                //    out_pdf.Close();
                                //}
                                //last_code = "";
                                //finally {
                                //  Finalize_process();
                                // }
                                //out_pdf = new PdfDocument()
                                //{
                                //    Version = pdf.Version
                                //};
                                //out_pdf.Info.Title = String.Format("Page {0} of {1}", idx + 1, pdf.Info.Title);
                                //out_pdf.Info.Creator = pdf.Info.Creator;
                                //out_fname = String.Format("{0}\\Desconhecido_{1}_{2}_{3}.pdf", out_dir, fname, idx, reg_id);
                                //Add_new_page(region_img, out_pdf);
                                ////region_img.Save(out_fname + ".bmp");
                                //out_pdf.Save(out_fname);
                                //out_pdf.Close();
                            }//Acaba aqui !!

                        }
                        prog_sub.Value = idx + 1;
                        lab_sub_prog.Text = String.Format("{0} / {1}", idx + 1, page_count);
                    }

                    if (out_pdf != null && last_code != "" && out_pdf.PageCount > 0)
                    {
                        //  out_pdf.Save(out_fname);
                    }

                    prog_tot.Value = ++done_cnt;
                    lab_tot_prog.Text = String.Format("{0} / {1}", done_cnt, m_input_files.Count);

                    pdf.Close();

                    // Move o arquivo processado para a pasta concluido
                    //string tar_fname = fname;
                    //while (File.Exists(Path.Combine(txt_done_folder.Text, tar_fname)))
                    //{
                    //    tar_fname = "_" + tar_fname;
                    //}
                    //File.Move(fname_full, Path.Combine(txt_done_folder.Text, tar_fname));

                    string lixo = txt_in_folder.Text + "\\" + fname;
                    File.Delete(lixo);
                    m_input_files.RemoveAt(0);
                }
                // show_info("Processing ended successfully.");
                MessageBox.Show("Processamento Finalizado com Sucesso.", "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace.ToString());
                Debug.WriteLine(String.Format("ERROR: {0} -> {1}", lab_current.Text, out_fname));
                MessageBox.Show("Processamento interrompido por causa do erro : " + ex.Message, "INFOR CUTTER 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //show_info("Processing stopped because of error: " + ex.Message);
                string tar_fname = fname;
                while (File.Exists(Path.Combine(txt_done_folder.Text, tar_fname)))
                {
                    tar_fname = "_" + tar_fname;
                }
                File.Move(fname_full, Path.Combine(txt_done_folder.Text, tar_fname));

                m_input_files.RemoveAt(0);
                ContaArquivo();

            }
            finally
            {
                Finalize_process();
            }
        }

        private void MainFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {

                Properties.Settings.Default.SisRecortar = false;
                Properties.Settings.Default.SisRenomear = false;
                Properties.Settings.Default.SisSitema = false;
                Properties.Settings.Default.Save();

                Form1 frmNovo = new Form1();
                frmNovo.ShowDialog();
                if (Properties.Settings.Default.SisRecortar == true)
                {
                    carregaRecortar();

                }
                else if (Properties.Settings.Default.SisRenomear == true)
                {
                    carregaRenomear();
                }
                else if (Properties.Settings.Default.SisSitema == true)
                {
                    MessageBox.Show("Escolheu o sistema 3!!");
                }
            }
        }

        private void MainFrm_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void Btniniciar2_EnabledChanged(object sender, EventArgs e)
        {
            //Button from = sender as Button;
            //btniniciar2.ForeColor = from.Enabled == false ? Color.Red : Color.White;
            //btniniciar2.BackColor = from.Enabled == false ? Color.FromArgb(100, 100, 100) : Color.FromArgb(80, 80, 80);
        }

        void ContaArquivo()
        {
            try
            {
                if (Directory.Exists(txt_out_folder.Text) == true)
                {
                    //Directory.CreateDirectory(txt_out_folder.Text);
                    string s = txt_done_folder.Text;

                    System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(s);

                    int files;

                    files = d.GetFiles().Length;

                    if (files > 0)
                    {

                        label17.Visible = true;
                        label17.Text = "Arquivos com erro: " + files;
                    }
                }
            }
            catch
            {

            }

            //string s = @"C:\PathAndFolder";

            //System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(s);

            //int files;

            //files = d.GetFiles().Length;
        }

        private void txt_doc_height_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_sel_out_Click_1(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog()
                {
                    //  SelectedPath = Directory.GetCurrentDirectory(),
                    ShowNewFolderButton = true
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txt_out_folder.Text = dlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 01: " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sel_marked_Click_1(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog()
                {
                    //SelectedPath = Directory.GetCurrentDirectory(),
                    ShowNewFolderButton = true
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txt_marked_folder.Text = dlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 07: " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sel_done_Click_2(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog()
                {
                    SelectedPath = Directory.GetCurrentDirectory(),
                    ShowNewFolderButton = true
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txt_done_folder.Text = dlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 06 " + ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_start_Click_1(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.SisRecortar == true)
            {
                Process();

            }
            else if (Properties.Settings.Default.SisRenomear == true)
            {
                Process2();
            }
            else if (Properties.Settings.Default.SisSitema == true)
            {
                Process3();
            }
        }

        private void btniniciar2_Click(object sender, EventArgs e)
        {

        }

        private void btn_go_in_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txt_in_folder.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_go_out_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txt_out_folder.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "INFOR CUTTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_go_marked_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txt_marked_folder.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btn_go_done_Click_2(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txt_done_folder.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
