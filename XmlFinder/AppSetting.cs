using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ScanPDF
{
    //Essa classe é uma constante, ela instancia um objeto quando chamada automaticamente
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.ini";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            try
            {
                File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
            }
            catch (Exception e)
            {
                Console.WriteLine("## App Setting Saving Failed : " + e.Message);
            }
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            try
            { 
                T t = new T();
                if (File.Exists(fileName))
                    t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
                else
                    return default(T);
                return t;
            }
            catch (Exception e)
            {
                Console.WriteLine("## App Setting Loading Failed : " + e.Message);
                return default(T);
            }
        }
    }

    //Essa classe é instancia a partir de ouras classes
    //Ela recebe AppSettings para propriedades de Save() e Load()
    //Como parametro genérico ela envia ela mesma, pois são esses atributos que desejo salvar
    public class UserSetting : AppSettings<UserSetting>
    {

        #region //VIRTUAL SCANNER

        //Entrada e saída User
        public string entradaPath;
        public string saidaPath;

        //Verificadores de funções a serem utilizadas
        public bool isCutter = false;
        public bool isBarcodeReader = false;
        public bool isWaterMark = false;
        public bool isSignature = false;
        public bool isPreProcessing = false;
        public bool isProcessing = false;
        public bool isProProcessing = false;


        //Cutter Settings  (v -> vertical, x1-3-7 -> n. de cortes, doc2-3-8 -> resultado)
        public bool isVertical = false;
        public bool isHorizontal = false;
        public int numeroCortes = 0;

        //Page Settings
        public float doc_height = 29.7f;
        public float header_height = 1.5f;
        public float footer_height = 2.5f;
        public int region_count = 6;
        public int check_interval = 1;
        public int search_depth = 2;
        public int tam_cod = 7;
        public int reg_count = 7; //quantidade de corte
        public float reg_height = 4.1f; //tamanho do corte
        public float region_height = 4.1f; //tamanho do corte (de novo ?)


        
        //Barcode Settings
        public char delimiter = ';';
        public string positions = "1;2;3";

        //Parametros Barcode
        //para retornar text que poderá ser atribuido a algum indice
        public int QuantidadeParametros = 0;

        public int parametro1i = 1;
        public int parametro1e = 2;

        public int parametro2i;
        public int parametro2e;

        public int parametro3i;
        public int parametro3e;

        public int parametro4i;
        public int parametro4e;

        public int parametro5i;
        public int parametro5e;

        public int parametro6i;
        public int parametro6e;

        public int parametro7i;
        public int parametro7e;

        public int parametro8i;
        public int parametro8e;

        public int parametro9i;
        public int parametro9e;

        public int parametro10i;
        public int parametro10e;

        //Indice Settings
        public int QuantidadeIndices;
        public string indice1 = "";
        public string indice2 = "";
        public string indice3 = "";
        public string indice4 = "";
        public string indice5 = "";

        //Signature Settings
        public string autor = "";
        public string titulo = "";
        public string assunto = "";
        public string palavrasChave = "";
        public string criador = "";
        public string produtor = "";

        public string pathCertificate = "";
        public string passwordCertificate = "";

        public string razao = "";
        public string contato = "";
        public string Endereco = "";
        public bool signVisivel = false;

        #endregion

        //XML Settings


        //FTP Settings


        //Plan Settings



    }

    public class VirtualScannerDiretorios
    {
        //nivel programa -> Para funcionalidades internas das aplicações
        public string pathRaizInterno = @"C:\\INFORVirtualScanner";
        public string pathPostProcessing = @"C:\\INFORVirtualScanner\\pos-processamento";
        public string pathPreProcessing = @"C:\\INFORVirtualScanner\\PreProcessamento";
        public string pathProcessing = @"C:\\INFORVirtualScanner\\Processamento";
        public string pathProcessingCompleted = @"C:\\INFORVirtualScanner\\ProcessamentoCompleted";
        public string pathCutter = @"C:\\INFORVirtualScanner\\PreProcessamento\\Cutter";
        public string pathCutterCompleted = @"C:\\INFORVirtualScanner\\PreProcessamento\\CutterCompleted";
        public string pathWaterMark = @"C:\\INFORVirtualScanner\\pos-processamento\\WaterMark";
        public string pathWaterMarkCompleted = @"C:\\INFORVirtualScanner\\pos-processamento\\WaterMarkCompleted";
        public string pathSignature = @"C:\\INFORVirtualScanner\\pos-processamento\\Signature";
        public string pathSignatureCompleted = @"C:\\INFORVirtualScanner\\pos-processamento\\SignatureCompleted";
        public string pathIndexar = @"C:\\INFORVirtualScanner\\Indexacao";
        public string pathIndexarCompleted = @"C:\\INFORVirtualScanner\\IndexacaoCompleted";

        public static void criarDiretorios()
        {

            try
            {
                VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();

                //Criando Diretorios Internos
                if (Directory.Exists(virtualScannerDiretorios.pathRaizInterno) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathRaizInterno);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathPreProcessing) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathPreProcessing);

                }

                if (Directory.Exists(virtualScannerDiretorios.pathCutter) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathCutter);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathCutterCompleted) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathCutterCompleted);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathProcessing) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathProcessing);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathProcessingCompleted) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathProcessingCompleted);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathPostProcessing) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathPostProcessing);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathWaterMark) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathWaterMark);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathWaterMarkCompleted) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathWaterMark);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathSignature) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathSignature);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathSignatureCompleted) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathSignatureCompleted);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathIndexar) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathIndexar);
                }

                if (Directory.Exists(virtualScannerDiretorios.pathIndexarCompleted) == false)
                {
                    Directory.CreateDirectory(virtualScannerDiretorios.pathIndexarCompleted);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "erro ao criar diretorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }
    }
}
