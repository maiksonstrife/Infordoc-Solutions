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
        //pra amanha
        //Criar pasta de entrada e pasta de saida
            //metodo principal que:
            //vai ler pasta de entrada
           //fazer verificações e chamar os metodos corretos
        //ao terminar jogar na pasta de saida

        //analise pasta de entrada
        private BackgroundWorker enterPoint;
        private BackgroundWorker bwpreprocessamento;
        private BackgroundWorker bwprocessamento;
        private BackgroundWorker bwposprocessamento;

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
            //configurando bw enterpoint -> Inicio
            this.enterPoint = new BackgroundWorker();
            this.enterPoint.DoWork += new DoWorkEventHandler(enterPoint_DoWork);
            //this.enterPoint.RunWorkerCompleted += new RunWorkerCompletedEventHandler(enterPoint_RunWorkerCompleted);
            this.enterPoint.WorkerSupportsCancellation = true;
            //enterPoint.CancelAsync();

            //configurando bw preprocessamento -> Inicio
            this.bwpreprocessamento = new BackgroundWorker();
            this.bwpreprocessamento.DoWork += new DoWorkEventHandler(bwpreprocessamento_DoWork);
            //this.bwpreprocessamento.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwpreprocessamento_RunWorkerCompleted);
            this.bwpreprocessamento.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //configurando bw processamento -> Inicio
            this.bwprocessamento = new BackgroundWorker();
            this.bwprocessamento.DoWork += new DoWorkEventHandler(bwprocessamento_DoWork);
            //this.bwpreprocessamento.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwpreprocessamento_RunWorkerCompleted);
            this.bwprocessamento.WorkerSupportsCancellation = true;
            //bwpreprocessamento.CancelAsync();

            //bora iniciar
            enterPoint.RunWorkerAsync();
        }

        private void enterPoint_DoWork(object sender, DoWorkEventArgs e)
        {
            Load_AppSettings();
            //Pegar arquivos da pasta de entrada
            string[] arquivosEntrada = Directory.GetFiles(m_setting.entradaPath);

            //fazer chegagem se irá fazer pré processamento
            //Se for -> iniciar bw pre processamento, e bw processamento -> realizar loop e jogar na pasta pre processamento
            if (m_setting.isPreProcessing == true)
            {

                //iniciar bw pre processamento
                bwpreprocessamento.RunWorkerAsync();
                //iniciar bw processamento
                bwprocessamento.RunWorkerAsync();

                //jogar arquivos na pasta pre processamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, m_setting + "\\" + Filename); //mandar pra cutter path *FAZER CAMINHOS INTERNOS NO S_SETTINGS PRA ACESSO GLOBAL
                    File.Delete(file);
                }
            }
            else //Se não for -> iniciar  bw processamento -> realizar loop e jogar na pasta processamento
            {
                
                //iniciar bw processamento
                bwprocessamento.RunWorkerAsync();
                
                //jogar os arquivos na pasta processamento
                foreach (string file in arquivosEntrada)
                {
                    string Filename = Path.GetFileName(file);
                    File.Move(file, m_setting + "\\" + Filename); //mandar pra processamento path
                    File.Delete(file);

                }
            }

        }

        //Threading (background work métodos)

        private void bwpreprocessamento_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoRecortar();
        }

        private void bwpreprocessamento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("terminou de recortar");
        }

        private void bwprocessamento_DoWork(object sender, DoWorkEventArgs e)
        {
            PdfUtility.processoAssinar();
        }

        //Threading
        /*private void backgroundRenomear_DoWork(object sender, DoWorkEventArgs e)
        {
            barcode = virtualScanner.onloadCarregaRenomear(monitorar);
            e.Result = barcode;
        }


        private void backgroundRenomear_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

    }
}
