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

        public static void Exportar(T pSettings)
        {

            string export = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText(export, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public void Exportar()
        {

            string export = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            export += "\\settings.ini";
            try
            {
                File.WriteAllText(export, (new JavaScriptSerializer()).Serialize(this));
            }
            catch (Exception e)
            {
                Console.WriteLine("## App Setting Saving Failed : " + e.Message);
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
        public string WatermarkImagePath = "";

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

        //Indice Settings
        public int Counter = 0;

        public string indice1 = "";
        public bool indice1isSubstring = false;
        public int indice1SubI = 0;
        public int indice1SubE = 1;
        public bool indice1isDelimiter = false;
        public string indice1Delimiter = "";

        public bool isIndice2 = false;
        public string indice2 = "";
        public bool indice2isSubstring = false;
        public int indice2SubI = 0;
        public int indice2SubE = 1;
        public bool indice2isDelimiter = false;
        public string indice2Delimiter = "";


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

        public bool IsSignTopLeft = false; 
        public bool isSignMiddleTop = true; //default
        public bool isSignTopRight = false;
        public bool isSignLeft = false;
        public bool isSignRight = false;
        public bool isSignBottomLeft = false;
        public bool isSignBottom = false;
        public bool isSignBottomRight = false;
        public string lastSignPosition = "";

        //Watermark Settings
        public bool isPremadeMark = true;
        public bool ismarkSoutheast = true; // direita
        public bool ismarkSouthwest = false; //esquerda
        public bool ismarkSouth = false; //baixo
        public bool ismarkNortheast = false;
        public bool ismarkNorthwest = false;
        public bool ismarkNorth = false;
        public bool ismarkCenter = false;
        public bool ismarkEast = false;
        public bool ismarkWest = false;

        public bool isSpecificMark = false;
        public int markX = 200;
        public int markY = 50;
        public string lastPosition = "Sudeste";


        public double markTransparency = 4;

        #endregion

        //XML Settings
        public string pdfPath;
        public string xmlPath;
        public string saidaxmlPath;

        //FTP Settings
        public string enderecoFTP;
        public string usuarioFTP;
        public string senhaFTP;
        public string pastalocalFTP;

        public string perfil1 = "<Perfil1>";
        public string pastaWEBperfil1;
        public string pastaLOCALperfil1;

        public string perfil2 = "<Perfil2>";
        public string pastaWEBperfil2;
        public string pastaLOCALperfil2;

        public string perfil3 = "<Perfil3>";
        public string pastaWEBperfil3;
        public string pastaLOCALperfil3;

        //Plan Settings



    }

    public class VirtualScannerDiretorios
    {
        //nivel programa -> Para funcionalidades internas das aplicações
        public string pathRaizInterno = @"C:\\INFORVirtualScanner";
        public string pathPostProcessing = @"C:\\INFORVirtualScanner\\pos-processamento";
        public string pathPreProcessing = @"C:\\INFORVirtualScanner\\PreProcessamento";
        public string pathProcessing = @"C:\\INFORVirtualScanner\\Processamento";
        public string pathProcessingCompleted = @"C:\\INFORVirtualScanner\\Processamento\\ProcessamentoCompleted";
        public string pathCutter = @"C:\\INFORVirtualScanner\\PreProcessamento\\Cutter";
        public string pathCutterCompleted = @"C:\\INFORVirtualScanner\\PreProcessamento\\CutterCompleted";
        public string pathWaterMark = @"C:\\INFORVirtualScanner\\pos-processamento\\WaterMark";
        public string pathWaterMarkCompleted = @"C:\\INFORVirtualScanner\\pos-processamento\\WaterMarkCompleted";
        public string pathSignature = @"C:\\INFORVirtualScanner\\pos-processamento\\Signature";
        public string pathSignatureCompleted = @"C:\\INFORVirtualScanner\\pos-processamento\\SignatureCompleted";
        public string pathIndexar = @"C:\\INFORVirtualScanner\\Indexacao";
        public string pathIndexarCompleted = @"C:\\INFORVirtualScanner\\Indexacao\\IndexacaoCompleted";

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
                    Directory.CreateDirectory(virtualScannerDiretorios.pathWaterMarkCompleted);
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
