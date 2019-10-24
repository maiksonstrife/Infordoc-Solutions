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

        private VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();

        string barcode;
        bool monitorar = false;

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

            //bora iniciar
            PdfUtility pdfUtility = new PdfUtility();
            // TESTES pdfUtility.processoRenomear();

            //Calculando porcentagem
            int max = 0;
            if (m_setting.isBarcodeReader == true)
            {
                max += 1;
            }
            if (m_setting.isCutter == true)
            {
                max += 1;
            }
            if (m_setting.isWaterMark == true)
            {
                max += 1;
            }
            if (m_setting.isSignature == true)
            {
                max += 1;
            }

            scannerCircleProgress.Maximum = max;
            enterPoint.RunWorkerAsync();
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
                    File.Move(file, virtualScannerDiretorios.pathCutter + "\\" + Filename); //mandar pra cutter path *FAZER CAMINHOS INTERNOS NO S_SETTINGS PRA ACESSO GLOBAL
                    File.Delete(file);
                }

                //iniciar bw pre processamento
                bwpreprocessamento.RunWorkerAsync();

            }
            else  if (m_setting.isProcessing == true) //Se não for -> jogar na processamento
            {
                
               
                
                //jogar os arquivos na pasta processamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, virtualScannerDiretorios.pathProcessing + "\\" + Filename, true);
                    //File.Move(file, virtualScannerDiretorios.pathProcessing + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw processamento
                bwprocessamento.RunWorkerAsync();

            }
            else if (m_setting.isWaterMark == true)
            {
                

                //jogar os arquivos na pasta WaterMark
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw watermark
                bwposprocessamentoWatermark.RunWorkerAsync();

            }

            else if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathSignature + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw signature
                bwposprocessamentoSignature.RunWorkerAsync();
            }

            //rodar indexador aqui no final sem condições, porque será OBRIGATORIO

        }

        //Threading (background work métodos)

        private void bwpreprocessamento_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoRecortar();
        }

        private void bwpreprocessamento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();
            BeginInvoke((MethodInvoker)delegate // Esse método permite que a thread em background (backgroundworker) acesse a UI
            {
                scannerCircleProgress.Value += 1;
                scannerCircleProgress.Update();
                txtCent.Text = scannerCircleProgress.Text + "%";
                txtCentText.Text = "Documentos Recortados";
                txtCent.Visible = true;
                txtCentText.Visible = true;
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
                    File.Move(file, virtualScannerDiretorios.pathProcessing + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw processamento
                bwprocessamento.RunWorkerAsync();
            }
            else if (m_setting.isWaterMark == true)
            {
                

                //jogar os arquivos na pasta WaterMark
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw watermark
                bwposprocessamentoWatermark.RunWorkerAsync();
            }

            else if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathSignature + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw signature
                bwposprocessamentoSignature.RunWorkerAsync();
            }

            if (m_setting.isProcessing == false && m_setting.isWaterMark == false && m_setting.isSignature == false){
               
                    
                    //jogar os arquivos na pasta indexacao
                    foreach (string file in arquivosEntrada)
                    {
                        string Filename = Path.GetFileName(file);
                        File.Move(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename); //mandar pra indexar path
                        File.Delete(file);
                    }

                //iniciar bwindexacao


            }
            #endregion
        }

        private void bwprocessamento_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility pdfUtility = new PdfUtility();
            pdfUtility.processoRenomear();
        }

        private void bwprocessamento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();
            BeginInvoke((MethodInvoker)delegate
            {
                scannerCircleProgress.Value += 1;
                txtCent.Text = scannerCircleProgress.Text + "%";
                txtCentText.Text = "Barcodes Lidos";
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
                    File.Move(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw watermark
                bwposprocessamentoWatermark.RunWorkerAsync();
            }

            else if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathSignature + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw signature
                bwposprocessamentoSignature.RunWorkerAsync();
            }

            if (m_setting.isWaterMark == false && m_setting.isSignature == false)
            {

                
                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename); //mandar pra indexar path
                    File.Delete(file);
                }


                //iniciar bwindexacao

            }

        }

        private void bwposprocessamentoWatermark_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoInserirMarcadagua();
        }

        private void bwposprocessamentoWatermark_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();
            BeginInvoke((MethodInvoker)delegate
            {
                scannerCircleProgress.Value += 1;
                txtCent.Text = scannerCircleProgress.Text + "%";
                txtCentText.Text = "Marcas D'agua Inseridas";
            });

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathWaterMarkCompleted);

             if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathSignature + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw signature
                bwposprocessamentoSignature.RunWorkerAsync();
            }

            if (m_setting.isSignature == false)
            {

                
                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename); //mandar pra indexar path
                    File.Delete(file);
                }

                //iniciar bwindexacao

            }
        }



        private void bwposprocessamentoSignature_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoAssinar();
        }

        private void bwposprocessamentoSignature_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();
            BeginInvoke((MethodInvoker)delegate
            {
                scannerCircleProgress.Value += 1;
                txtCent.Text = scannerCircleProgress.Text + "%";
                txtCentText.Text = "Assinaturas Inseridas";
            });

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathSignatureCompleted);

            if (m_setting.isSignature == true)
            {
                

                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }

                //iniciar bw indexacao
                //bwposprocessamentoSignature.RunWorkerAsync();
            }
        }






        private void PageBarcodeReader_Load(object sender, EventArgs e)
        {
            Load_AppSettings();
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
                txtAssinaturaVisivel.Text = "Sim";
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

        private void labelCentCutter_Click(object sender, EventArgs e)
        {

        }

        /*private void backgroundRenomear_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                barcode = (string)e.Result;

                if (String.IsNullOrEmpty(barcode))
                {
                    MessageBox.Show("Não foi encontrado barcode;");
                    return;
                }

                //teste
                int[,] array = new int[1, 2];
                array[0, 0] = 1;
                array[0, 1] = 5;
                //Na pratica a pessoa ativara a quantidade de parametros e os valores do parametro atraves da UI configuracao Barcode
                //if tamanho igual = 1(){  int[,] array = new int[1,2] com valor [0,0] = a,b e [0,1} = c,d;

                barcode = StringFormater.DelimitarString(barcode, ";", array); //funciona supimpa!!!
        }*/

    }
}
