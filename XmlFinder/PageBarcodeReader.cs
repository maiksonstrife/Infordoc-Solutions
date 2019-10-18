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
            this.bwpreprocessamento.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwpreprocessamento_RunWorkerCompleted);
            this.bwprocessamento.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //configurando bwposprocessamento -> Inicio
            this.bwposprocessamentoWatermark = new BackgroundWorker();
            this.bwposprocessamentoWatermark.DoWork += new DoWorkEventHandler(bwposprocessamentoWatermark_DoWork);
            this.bwpreprocessamento.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwposprocessamentoWatermark_RunWorkerCompleted);
            this.bwposprocessamentoWatermark.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //configurando bwposprocessamento -> Inicio
            this.bwposprocessamentoSignature = new BackgroundWorker();
            this.bwposprocessamentoSignature.DoWork += new DoWorkEventHandler(bwposprocessamentoSignature_DoWork);
            this.bwpreprocessamento.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwposprocessamentoSignature_RunWorkerCompleted);
            this.bwposprocessamentoSignature.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //bora iniciar
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

                //iniciar bw pre processamento
                bwpreprocessamento.RunWorkerAsync();

                //jogar arquivos na pasta preprocessamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathPreProcessing + "\\" + Filename); //mandar pra cutter path *FAZER CAMINHOS INTERNOS NO S_SETTINGS PRA ACESSO GLOBAL
                    File.Delete(file);
                }
            }
            else  if (m_setting.isProcessing == true) //Se não for -> jogar na processamento
            {
                
                //iniciar bw processamento
                bwprocessamento.RunWorkerAsync();
                
                //jogar os arquivos na pasta processamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathProcessing + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }
            else if (m_setting.isWaterMark == true)
            {
                //iniciar bw watermark
                bwposprocessamentoWatermark.RunWorkerAsync();

                //jogar os arquivos na pasta WaterMark
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            else if (m_setting.isSignature == true)
            {
                //iniciar bw signature
                bwposprocessamentoSignature.RunWorkerAsync();

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathSignature + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
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

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathCutterCompleted);

            #region   //DECIDIR ONDE JOGAR

            // 1. Pegar arquivos da pasta Cutter completado
            // 2. Criar loop pra cada arquivo
            // 3. Decidir onde jogar

            if (m_setting.isProcessing == true) //Se não for -> jogar na processamento
            {

                //iniciar bw processamento
                bwprocessamento.RunWorkerAsync();

                //jogar os arquivos na pasta processamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathProcessing + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }
            else if (m_setting.isWaterMark == true)
            {
                //iniciar bw watermark
                bwposprocessamentoWatermark.RunWorkerAsync();

                //jogar os arquivos na pasta WaterMark
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            else if (m_setting.isSignature == true)
            {
                //iniciar bw signature
                bwposprocessamentoSignature.RunWorkerAsync();

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathSignature + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            if (m_setting.isProcessing == false && m_setting.isWaterMark == false && m_setting.isSignature == false){
               
                    //iniciar bwindexacao

                    //jogar os arquivos na pasta indexacao
                    foreach (string file in arquivosEntrada)
                    {
                        string Filename = Path.GetFileName(file);
                        File.Move(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename); //mandar pra indexar path
                        File.Delete(file);
                    }
                
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

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathProcessingCompleted);

           

            // 1. Pegar arquivos da pasta Cutter completado
            // 2. Criar loop pra cada arquivo
            // 3. Decidir onde jogar

            if (m_setting.isWaterMark == true)
            {
                //iniciar bw watermark
                bwposprocessamentoWatermark.RunWorkerAsync();

                //jogar os arquivos na pasta WaterMark
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathWaterMark + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            else if (m_setting.isSignature == true)
            {
                //iniciar bw signature
                bwposprocessamentoSignature.RunWorkerAsync();

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathSignature + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            if (m_setting.isWaterMark == false && m_setting.isSignature == false)
            {

                //iniciar bwindexacao

                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename); //mandar pra indexar path
                    File.Delete(file);
                }

            }

        }

        private void bwposprocessamentoWatermark_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoInserirMarcadagua();
        }

        private void bwposprocessamentoWatermark_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathProcessingCompleted);

             if (m_setting.isSignature == true)
            {
                //iniciar bw signature
                bwposprocessamentoSignature.RunWorkerAsync();

                //jogar os arquivos na pasta Signature
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathSignature + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }

            if (m_setting.isSignature == false)
            {

                //iniciar bwindexacao

                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename); //mandar pra indexar path
                    File.Delete(file);
                }
            }
        }



        private void bwposprocessamentoSignature_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoAssinar();
        }

        private void bwposprocessamentoSignature_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Load_AppSettings();

            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(virtualScannerDiretorios.pathSignatureCompleted);

            if (m_setting.isSignature == true)
            {
                //iniciar bw indexacao
                //bwposprocessamentoSignature.RunWorkerAsync();

                //jogar os arquivos na pasta indexacao
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, virtualScannerDiretorios.pathIndexar + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);
                }
            }
        }






        private void PageBarcodeReader_Load(object sender, EventArgs e)
        {
           

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
