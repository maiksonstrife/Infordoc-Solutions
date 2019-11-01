using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ScanPDF;

namespace XmlFinder
{
    public partial class PageBarcodeReader : UserControl
    {
        //TUDO SUPOSTAMENTE CORRETO, PARA TESTAR TODAS FASES, FAZER A4 PRA SER RECORTADA COM BARCODES EM CADA PEDAÇO

        #region // Explicando a classe
        /*
         * BackgroundWork chamarão a PDFUtility pra realizar processos no background
         * EntryPoint decidirá por onde começar de acordo com opções do usuario
         * Ao terminar cada backgroundworker, no método completed de cada um, deverá listar arquivos da pasta completed e decidir para onde seguir
         */
        #endregion
        //analise pasta de entrada
        private BackgroundWorker enterPoint;
        private BackgroundWorker bwpreprocessamento;
        private BackgroundWorker bwprocessamento;
        private BackgroundWorker bwposprocessamentoWatermark;
        private BackgroundWorker bwposprocessamentoSignature;
        private BackgroundWorker exitPoint;

        private VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();


        UserSetting m_setting;

        PdfUtility virtualScanner = new PdfUtility();

        public PageBarcodeReader()
        {
            InitializeComponent();

        }

        //Botão Iniciar
        private void CarregaOnloadRenomear_Click(object sender, EventArgs e)
        {
            VirtualScannerDiretorios.criarDiretorios();

            //configurando bw enterpoint -> Inicio
            this.enterPoint = new BackgroundWorker();
            this.enterPoint.DoWork += new DoWorkEventHandler(enterPoint_DoWork);
            //this.enterPoint.RunWorkerCompleted += new RunWorkerCompletedEventHandler(enterPoint_RunWorkerCompleted);
            this.enterPoint.WorkerSupportsCancellation = true;
            //enterPoint.CancelAsync();

            //configurando bw preprocessamento -> Inicio
            this.bwpreprocessamento = new BackgroundWorker();
            this.bwpreprocessamento.DoWork += new DoWorkEventHandler(bwpreprocessamento_DoWork);
            this.bwpreprocessamento.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwpreprocessamento_RunWorkerCompleted);
            this.bwpreprocessamento.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //configurando bw processamento -> Inicio
            this.bwprocessamento = new BackgroundWorker();
            this.bwprocessamento.DoWork += new DoWorkEventHandler(bwprocessamento_DoWork);
            this.bwprocessamento.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwprocessamento_RunWorkerCompleted);
            this.bwprocessamento.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //configurando bwposprocessamento -> Inicio
            this.bwposprocessamentoWatermark = new BackgroundWorker();
            this.bwposprocessamentoWatermark.DoWork += new DoWorkEventHandler(bwposprocessamentoWatermark_DoWork);
            this.bwposprocessamentoWatermark.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwposprocessamentoWatermark_RunWorkerCompleted);
            this.bwposprocessamentoWatermark.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //configurando bwposprocessamento -> Inicio
            this.bwposprocessamentoSignature = new BackgroundWorker();
            this.bwposprocessamentoSignature.DoWork += new DoWorkEventHandler(bwposprocessamentoSignature_DoWork);
            this.bwposprocessamentoSignature.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwposprocessamentoSignature_RunWorkerCompleted);
            this.bwposprocessamentoSignature.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //configurando bwposprocessamento -> Inicio
            this.exitPoint = new BackgroundWorker();
            this.exitPoint.DoWork += new DoWorkEventHandler(exitPoint_DoWork);
            this.exitPoint.RunWorkerCompleted += new RunWorkerCompletedEventHandler(exitPoint_RunWorkerCompleted);
            this.exitPoint.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();


            //bora iniciar
            PdfUtility pdfUtility = new PdfUtility();
            PdfUtility.processoInserirMarcadagua();

            scannerCircleProgress.Value = 1;
            scannerCircleProgress.Text = "scan";
            scannerCircleProgress.SuperScriptMargin = new Padding(4, 45, 0, 0);
            scannerCircleProgress.SubScriptText = "lendo";
            timer1.Enabled = true;
        }

        //Decide por onde começar
        private void enterPoint_DoWork(object sender, DoWorkEventArgs e)
        {
            Load_AppSettings();

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(m_setting.entradaPath);

            //
            if (m_setting.isPreProcessing == true)
            {

                

                //jogar arquivos na pasta preprocessamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathCutter + "\\" + Filename, true);
                    File.Delete(file);
                }
            }
            else  if (m_setting.isProcessing == true) //Se não for -> jogar na processamento
            {
                
               
                
                //jogar os arquivos na pasta processamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathProcessing + "\\" + Filename, true);
                    File.Delete(file);
                }

            }
            else if (m_setting.isWaterMark == true)
            {
                

                //jogar os arquivos na pasta WaterMark
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename, true);
                    File.Delete(file);
                }

            }

            else if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathSignature + "\\" + Filename, true); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            //rodar indexador aqui no final sem condições, porque será OBRIGATORIO

        }

        //Threading (background work métodos)

        private void bwpreprocessamento_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                txtNRecorte.Text = "Lendo...";
                txtNRecorte.Visible = true;
            });
            PdfUtility.processoRecortar();

        }

        private void bwpreprocessamento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();
            BeginInvoke((MethodInvoker)delegate // Esse método permite que a thread em background (backgroundworker) acesse a UI
            {
                txtNRecorte.Text = "Lendo...";
                txtNRecorte.Visible = true;
            });

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathCutterCompleted);

            #region   //DECIDIR ONDE JOGAR

            // 1. Pegar arquivos da pasta Cutter completado
            // 2. Criar loop pra cada arquivo
            // 3. Decidir onde jogar

            if (m_setting.isProcessing == true) //Se não for -> jogar na processamento
            {

                

                //jogar os arquivos na pasta processamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathProcessing + "\\" + Filename, true); //mandar pra processamento path
                    File.Delete(file);
                }

            }
            else if (m_setting.isWaterMark == true)
            {
                

                //jogar os arquivos na pasta WaterMark
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename, true); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            else if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathSignature + "\\" + Filename, true); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            if (m_setting.isProcessing == false && m_setting.isWaterMark == false && m_setting.isSignature == false){
               
                    
                    //jogar os arquivos na pasta indexacao
                    foreach (string file in arquivosEntrada)
                    {
                        string Filename = Path.GetFileName(file);
                        System.IO.File.Copy(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename, true); //mandar pra indexar path
                        File.Delete(file);
                    }
            }
            #endregion
        }

        private void bwprocessamento_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility pdfUtility = new PdfUtility();
            pdfUtility.processoBarcode();
            BeginInvoke((MethodInvoker)delegate // Esse método permite que a thread em background (backgroundworker) acesse a UI
            {
                txtNBarcode.Text = "Lendo...";
                txtNBarcode.Visible = true;
            });

           
        }

        private void bwprocessamento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();
            BeginInvoke((MethodInvoker)delegate
            {
                txtNRecorte.Text = scannerCircleProgress.Text + "%";
                txtNBarcode.Text = "Lendo...";
            });

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathProcessingCompleted);

           

            // 1. Pegar arquivos da pasta Cutter completado
            // 2. Criar loop pra cada arquivo
            // 3. Decidir onde jogar

            if (m_setting.isWaterMark == true)
            {
                

                //jogar os arquivos na pasta WaterMark
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename, true); //mandar pra processamento path
                    File.Delete(file);
                }

            }

            else if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathSignature + "\\" + Filename, true); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            if (m_setting.isWaterMark == false && m_setting.isSignature == false)
            {

                
                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename, true); //mandar pra indexar path
                    File.Delete(file);
                }
            }

        }

        private void bwposprocessamentoWatermark_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoInserirMarcadagua();
            BeginInvoke((MethodInvoker)delegate
            {
                txtNMarca.Text = "Lendo...";
                txtNMarca.Visible = true;
            });

        }

        private void bwposprocessamentoWatermark_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();
            BeginInvoke((MethodInvoker)delegate
            {
                txtNMarca.Text = "Lendo...";
            });

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathWaterMarkCompleted);

             if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathSignature + "\\" + Filename, true); //mandar pra processamento path
                    File.Delete(file);
                }

            }

            if (m_setting.isSignature == false)
            {

                
                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename, true); //mandar pra indexar path
                    File.Delete(file);
                }
            }
        }



        private void bwposprocessamentoSignature_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoAssinar();
            BeginInvoke((MethodInvoker)delegate // Esse método permite que a thread em background (backgroundworker) acesse a UI
            {
                txtNAssinar.Text = "Lendo...";
                txtNAssinar.Visible = true;
            });

        }

        private void bwposprocessamentoSignature_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();
            BeginInvoke((MethodInvoker)delegate
            {
                txtNAssinar.Text = "Lendo...";
            });

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathSignatureCompleted);

            if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename, true); //mandar pra processamento path
                    File.Delete(file);
                }
            }
        }

        private void exitPoint_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility pdfUtility = new PdfUtility();
            pdfUtility.processoNomear();
        }

        private void exitPoint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("terminou OLHAR A PASTA SAIDA");
        }


        private void PageBarcodeReader_Load(object sender, EventArgs e)
        {
            Load_AppSettings();
            scannerCircleProgress.Value = 0;
            scannerCircleProgress.Text = "scan";
            //Carregar informações de configurações na UI
            if (m_setting.isCutter == true)
            {
                txtRecortar.Text = "Sim";
            }
            else
            {
                txtRecortar.Text = "Não";
            }

            if (m_setting.isBarcodeReader == true)
            {
                txtBarcode.Text = "Sim";
            }
            else
            {
                txtBarcode.Text = "Não";
            }

            if (m_setting.isWaterMark == true)
            {
                txtMarcaDagua.Text = "Sim";
            }
            else
            {
                txtMarcaDagua.Text = "Não";
            }

            if (m_setting.isSignature == true)
            {
                txtAssinar.Text = "Sim";
            }
            else
            {
                txtAssinar.Text = "Não";
            }

            if (m_setting.signVisivel == true)
            {
                txtAssinaturaVisivel.Text = "Sim";
            }
            else
            {
                txtAssinaturaVisivel.Text = "Não";
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
                new alerta("Impossivel Carregar AppSettings", alerta.AlertType.erro).Show();

            }
        }

        private void labelCentCutter_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            enterPoint.RunWorkerAsync();

            if (m_setting.isPreProcessing == true)
            {
                while (bwpreprocessamento.IsBusy)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }

                bwpreprocessamento.RunWorkerAsync();
            }

            if (m_setting.isProcessing == true)
            {
                    while (bwprocessamento.IsBusy)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(100);
                    }

                bwprocessamento.RunWorkerAsync();
            }

            if (m_setting.isWaterMark == true)
            {
                while (bwposprocessamentoWatermark.IsBusy)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }
                bwposprocessamentoWatermark.RunWorkerAsync();
            }

            if (m_setting.isSignature == true)
            {
                while (bwposprocessamentoSignature.IsBusy)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }
                bwposprocessamentoSignature.RunWorkerAsync();
            }

            exitPoint.RunWorkerAsync();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}
