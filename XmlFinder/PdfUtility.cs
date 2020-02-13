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
using System.Threading;
using Timer = System.Windows.Forms.Timer;

using iTextSharpSign;
using System.Drawing.Imaging;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;

namespace XmlFinder
{
    public class PdfUtility
    {


        string fname_full = "", fname = "", out_fname = "";

        

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


        string fileName;
        string indice1;
        string indice2;

        public void processoNomear()
        {

            #region //Carregando UserSetting
            UserSetting userSettingN = new UserSetting();
            try
            {
                userSettingN = UserSetting.Load();
                if (userSettingN == null)
                    userSettingN = new UserSetting();
            }
            catch (Exception ex)
            {
                ErrorLogging.ErrorLog(ex);
                return;
            }
            #endregion

            VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();
            VirtualScannerDiretorios.criarDiretorios();

            //LISTAR ARQUIVOS DA PASTA
            string[] filesToIndex = Directory.GetFiles(virtualScannerDiretorios.pathIndexar, "*.pdf");
            foreach (string file in filesToIndex)
            {

                //FAZ OS INDICES
                try
                {
                    //PREENCHE INDICE 1 COM OS BOTOES
                    if (userSettingN.indice1 == "<BARCODE>")
                    {
                        //pegar só nome do arquivo sem extenção quando voltar do almoço
                        indice1 = Path.GetFileNameWithoutExtension(file);
                    }
                    else if (userSettingN.indice1 == "<DATA>")
                    {
                        DateTime aDate = DateTime.Now;
                        indice1 = aDate.ToString("ddMMyyyy");
                    }
                    else if (userSettingN.indice1 == "<COUNTER>")
                    {
                        indice1 = userSettingN.Counter.ToString();
                    }
                    else if (userSettingN.indice1 == "<RANDOMN>")
                    {
                        Random rnd = new Random();
                        int randomn = rnd.Next(1, 5000);
                        indice1 = randomn.ToString();
                    }
                    else //Se não foi nenhum botão então só pode ser custom
                    {
                        indice1 = userSettingN.indice1;
                    }

                    //FAZ O SUBSTRING
                    if (userSettingN.indice1isSubstring == true)
                    {
                        indice1 = indice1.Substring(userSettingN.indice1SubI, userSettingN.indice1SubE);
                    }

                    //FAZ DELIMITER
                    if (userSettingN.indice1isDelimiter == true)
                    {
                        indice1 += userSettingN.indice1Delimiter;
                    }

                    if (String.IsNullOrEmpty(indice1))
                    {
                        return;
                    }
                    else
                    {
                        fileName = indice1;
                    }

                    //Checa indice 2
                    if (userSettingN.isIndice2 == true)
                    {
                        //PREENCHE INDICE 1 COM OS BOTOES
                        if (userSettingN.indice2 == "<BARCODE>")
                        {
                            //pegar só nome do arquivo sem extenção quando voltar do almoço
                            indice2 = Path.GetFileNameWithoutExtension(file);
                        }
                        else if (userSettingN.indice2 == "<DATA>")
                        {
                            DateTime aDate = DateTime.Now;
                            indice2 = aDate.ToString("ddMMyyyy");
                        }
                        else if (userSettingN.indice2 == "<COUNTER>")
                        {
                            indice2 = userSettingN.Counter.ToString();
                        }
                        else if (userSettingN.indice2 == "<RANDOMN>")
                        {
                            Random rnd = new Random();
                            int randomn = rnd.Next(1, 5000);
                            indice2 = randomn.ToString();
                        }
                        else //Se não foi nenhum botão então só pode ser custom
                        {
                            indice2 = userSettingN.indice2;
                        }

                        //FAZ O SUBSTRING
                        if (userSettingN.indice1isSubstring == true)
                        {
                            indice2 = indice2.Substring(userSettingN.indice2SubI, userSettingN.indice2SubE);
                        }

                        //FAZ DELIMITER
                        if (userSettingN.indice1isDelimiter == true)
                        {
                            indice2 += userSettingN.indice2Delimiter;
                        }

                        if (String.IsNullOrEmpty(indice2))
                        {
                            return;
                        }
                        else
                        {
                            fileName = indice1 += indice2;
                        }

                    }
                }
                catch (Exception ex)
                {
                    ErrorLogging.ErrorLog(ex);
                    return;
                }
                

                //SALVA NA PASTA SAIDA
                try
                {
                    System.IO.File.Copy(file, userSettingN.saidaPath + "\\" + fileName + ".PDF", true);
                    File.Delete(file);
                    userSettingN.Counter += userSettingN.Counter + 1;
                }
                catch (Exception ex)
                {
                    ErrorLogging.ErrorLog(ex);
                    return;
                }

                //fazer a Thread pausar após finalizar cada arquivo
                Wait_for(40);
                Thread.Sleep(1000);

            }
        }


        //TESTAR MULTIPLA PAGINA
        public static void processoAssinar()
        {

            VirtualScannerDiretorios.criarDiretorios();
            //Instancio objeto e pego informações do settings.ini
            UserSetting userSetting = new UserSetting();
            try
            {
                userSetting = UserSetting.Load();
                if (userSetting == null)
                    userSetting = new UserSetting();
            }
            catch (Exception ex)
            {
                ErrorLogging.ErrorLog(ex);
                return;
            }

            VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();

            //LISTAR ARQUIVOS DA PASTA METODO DIRETORIO UNICO
            //string[] filesTosign = Directory.GetFiles(virtualScannerDiretorios.pathSignature, "*.pdf");

            //foreach (string file in filesTosign)
            //{
            //    Cert myCert = null;
            //    try
            //    {
            //        myCert = new Cert(userSetting.pathCertificate, userSetting.passwordCertificate);
            //    }
            //    catch (Exception ex)
            //    {
            //        ErrorLogging.ErrorLog(ex);
            //        return;
            //    }


            //    MetaData MyMD = new MetaData();
            //    MyMD.Author = userSetting.autor;
            //    MyMD.Title = userSetting.titulo;
            //    MyMD.Subject = userSetting.assunto;
            //    MyMD.Keywords = userSetting.palavrasChave;
            //    MyMD.Creator = userSetting.criador;
            //    MyMD.Producer = userSetting.produtor;

            //    //pegar o novo nome
            //    try
            //    {
            //        string saida = virtualScannerDiretorios.pathIndexar + "\\" + Path.GetFileName(file);
            //        PDFSigner pdfs = new PDFSigner(file, saida, myCert, MyMD);
            //        pdfs.Sign(userSetting.razao, userSetting.contato, userSetting.Endereco, userSetting.signVisivel);
            //        Thread.Sleep(1000);
            //        File.Delete(file);
            //    }
            //    catch (Exception ex)
            //    {
            //        ErrorLogging.ErrorLog(ex);
            //        return;
            //    }





            //    //fazer a Thread pausar após finalizar cada arquivo
            //    Thread.Sleep(1000);
            //}

            // ARTEMIS - LISTAR ARQUIVOS DAS PASTAS  MÉTODO RECURSIVO, Todos subdiretorios
            string[] files = Directory.GetFiles(userSetting.entradaPath, "*.pdf", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                Cert myCert = null;
                try
                {
                    myCert = new Cert(userSetting.pathCertificate, userSetting.passwordCertificate);
                }
                catch (Exception ex)
                {
                    ErrorLogging.ErrorLog(ex);
                    return;
                }


                MetaData MyMD = new MetaData();
                MyMD.Author = userSetting.autor;
                MyMD.Title = userSetting.titulo;
                MyMD.Subject = userSetting.assunto;
                MyMD.Keywords = userSetting.palavrasChave;
                MyMD.Creator = userSetting.criador;
                MyMD.Producer = userSetting.produtor;

                //pegar o novo nome
                try
                {
                    
                    //Pego diretorio do arquivo
                    string path = Path.GetDirectoryName(file);
                    string pdfname = "\\" + Path.GetFileNameWithoutExtension(file) + " .pdf";
                    string saida = path + pdfname;
                    //faço da saida o mesmo que a entrada
                    
                    //passo pro pdfs sign

                    //string saida = virtualScannerDiretorios.pathIndexar + "\\" + Path.GetFileName(file); //Joga pra pasta de saida do virtual scanner
                    PDFSigner pdfs = new PDFSigner(file, saida, myCert, MyMD);
                    pdfs.Sign(userSetting.razao, userSetting.contato, userSetting.Endereco, userSetting.signVisivel);
                    Thread.Sleep(1000);
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    ErrorLogging.ErrorLog(ex);
                    return;
                }





                //fazer a Thread pausar após finalizar cada arquivo
                Thread.Sleep(1000);
            }



        }

        //FUNIONA COM PAGINA UNICA E MULTIPLA PAGINA
        public static void processoRecortar()
        {
            VirtualScannerDiretorios.criarDiretorios();
            UserSetting userSettingR = new UserSetting();
            try
            {
                userSettingR = UserSetting.Load();
                if (userSettingR == null)
                    userSettingR = new UserSetting();
            }
            catch (Exception ex)
            {
                ErrorLogging.ErrorLog(ex);
                return;
            }

            String[] pdfRecortarhFiles;
            VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();
            pdfRecortarhFiles = Directory.GetFiles(virtualScannerDiretorios.pathCutter);

            foreach (string pdffile in pdfRecortarhFiles)
            {
                try
                {
                    //abre pdf na pasta
                    PdfSharp.Pdf.PdfDocument pdf = PdfSharp.Pdf.IO.PdfReader.Open(pdffile, PdfDocumentOpenMode.Import);

                    //economizar tempo-processamento, separei em duas rotinas, com ou sem loop baseado na quantidade de paginas, se for igual a 1 -> sem loop
                    //if( pdf.PageCount == 1)
                    //{
                    //Configura magick reader
                    MagickReadSettings settings = new MagickReadSettings()
                    {
                        Density = new Density(300, 300)
                    };
                    //Usa magick Reader para converter para jpg na pasta temp
                    MagickImageCollection images = new MagickImageCollection();
                    images.Dispose();
                    images.Read(pdffile, settings);
                    images.Write("temp.jpg");

                    //Usar uma copia da imagem temp para evitar erros



                    //A partir desse momento temos duas situações
                    //1 - Se for pagina unica o arquivo tempo salvou como temp.jpg como esperado
                    //2 - Se for multiplas paginas serão gerado dois arquivos temp-0.jpg e temp-1.jpg... assim sucetivamente


                    if (images.Count > 1) //ponteiro começa em 1 //PRA SEGUNDA -> OS ARQUIVOS A PARTIR DO SEGUNDO LOOP SÃO SUBSTITUIDOS
                                          //fazer a formula do contador do PDF -> a * b + 1 = onde parou, sendo a -> nº de cortes, b -> nº da página, +1 -> constante (não discuta só aceita)
                    {
                        for (int counter = 1; counter <= images.Count; counter++)
                        {
                            int temp = counter - 1;
                            Bitmap image = new Bitmap(FromFile("temp-" + temp + ".jpg")); //Essa amostra será usada para separar recortes e deverá persistir até o final do processo de recorte

                            if (userSettingR.isHorizontal == true)
                            {
                                ImgRecorte.PDFRecorteHorizontal(image, pdffile, virtualScannerDiretorios.pathCutterCompleted, userSettingR.numeroCortes, images.Count, counter);

                                image.Dispose();
                                File.Delete("temp-" + temp + ".jpg");
                                Thread.Sleep(1000);
                            }

                            if (userSettingR.isHorizontal == false)
                            {
                                ImgRecorte.PDFRecorteVertical(image, pdffile, virtualScannerDiretorios.pathCutterCompleted, userSettingR.numeroCortes, images.Count, counter);
                                image.Dispose();
                                File.Delete("temp-" + temp + ".jpg");
                                Thread.Sleep(1000);
                            }

                        }
                        File.Delete(pdffile);
                        images.Dispose(); //libero o MagickReader da memória
                        Thread.Sleep(1000);
                    }

                    if (images.Count == 1)
                    {
                        Bitmap originalImage = new Bitmap(FromFile("temp.jpg")); //Essa amostra será usada para separar recortes e deverá persistir até o final do processo de recorte
                        #region //DIPOSE
                        /*
                         * Dispose é uma classe do tipo Interface (IDispose) que recebe diversos objetos e possui uma rotina indeferente para estes objetos para que os
                         * objetos sejam gerenciados de forma otimizada para que liberem memória, normalmente, este método está incluso em classes que usam Handlers, isso é, 
                         * tranca arquivo ou um código para lidar com futuras necessidades, quando não é mais necessário esta classe, usar Dipose();
                        */
                        #endregion
                        int counter = 1;
                        if (userSettingR.isHorizontal == true)
                        {
                            ImgRecorte.PDFRecorteHorizontal(originalImage, pdffile, virtualScannerDiretorios.pathCutterCompleted, userSettingR.numeroCortes, images.Count, counter);
                            File.Delete(pdffile);
                            originalImage.Dispose();
                            Thread.Sleep(1000);
                            File.Delete("temp.jpg");
                        }

                        if (userSettingR.isHorizontal == false)
                        {
                            ImgRecorte.PDFRecorteVertical(originalImage, pdffile, virtualScannerDiretorios.pathCutterCompleted, userSettingR.numeroCortes, images.Count, counter);
                            File.Delete(pdffile);
                            originalImage.Dispose();
                            Thread.Sleep(1000);
                            File.Delete("temp.jpg");
                        }
                        images.Dispose(); //libero o MagickReader da memória
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogging.ErrorLog(ex);
                    return;
                }
                

                //fazer a Thread pausar após finalizar cada arquivo
                Thread.Sleep(1000);
            }
        }

        //TESTAR MULTIPLA PAGINA
        public static void processoInserirMarcadagua()
        {
            VirtualScannerDiretorios.criarDiretorios();
            UserSetting userSettingM = new UserSetting();
            try
            {
                userSettingM = UserSetting.Load();
                if (userSettingM == null)
                    userSettingM = new UserSetting();
            }
            catch (Exception ex)
            {
                ErrorLogging.ErrorLog(ex);
                return;
                
            }

            try
            {
                String[] pdfMarcarFiles;
                VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();
                pdfMarcarFiles = Directory.GetFiles(virtualScannerDiretorios.pathWaterMark);

                foreach (string pdffile in pdfMarcarFiles)
                {
                    PdfSharp.Pdf.PdfDocument pdf = PdfSharp.Pdf.IO.PdfReader.Open(pdffile, PdfDocumentOpenMode.Import);
                    int page_count = pdf.PageCount;
                    PdfSharp.Pdf.PdfPage first = pdf.Pages[0];
                    PdfSharp.Pdf.PdfDocument out_pdf = null;

                    MagickImageCollection images = new MagickImageCollection();
                    MagickReadSettings settings = new MagickReadSettings()
                    {
                        Density = new Density(300, 300)
                    };
                    images.Read(pdffile, settings);
                    Thread.Sleep(1000);

                    //INSERINDO MARCA DAGUA
                    images[0].Write("temp.jpg");//salva primeira imagem do pdf no pasta repo
                    Bitmap page_img = new Bitmap(FromFile("temp.jpg")); //pega imagem repo // MEMORIA INSUFICIENTE
                    Bitmap watermark_img = new Bitmap(FromFile(userSettingM.WatermarkImagePath));

                    //MagickImage Le a imagem que vai receber marca d'agua
                    using (MagickImage image = new MagickImage(page_img))
                    {
                        //APLICANDO MARCA DAGUA
                        using (MagickImage watermark = new MagickImage(watermark_img)) // Lê a marca dágua que será inserida na imagem           

                        {
                            if (userSettingM.isPremadeMark == true)
                            {
                                if (userSettingM.ismarkSoutheast == true)
                                {
                                    image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);
                                }
                                else if (userSettingM.ismarkSouthwest == true)
                                {
                                    image.Composite(watermark, Gravity.Southwest, CompositeOperator.Over);
                                }
                                else if (userSettingM.ismarkSouth == true)
                                {
                                    image.Composite(watermark, Gravity.South, CompositeOperator.Over);
                                }
                                else if (userSettingM.ismarkNorth == true)
                                {
                                    image.Composite(watermark, Gravity.North, CompositeOperator.Over);
                                }
                                else if (userSettingM.ismarkNortheast == true)
                                {
                                    image.Composite(watermark, Gravity.Northeast, CompositeOperator.Over);
                                }
                                else if (userSettingM.ismarkNorthwest == true)
                                {
                                    image.Composite(watermark, Gravity.Northwest, CompositeOperator.Over);
                                }
                                else if (userSettingM.ismarkEast == true)
                                {
                                    image.Composite(watermark, Gravity.East, CompositeOperator.Over);
                                }
                                else if (userSettingM.ismarkWest == true)
                                {
                                    image.Composite(watermark, Gravity.West, CompositeOperator.Over);
                                }
                                Thread.Sleep(1000);
                            }

                            else  //OU desenhe em um lugar com x/y
                            {
                                image.Composite(watermark, userSettingM.markX, userSettingM.markY, CompositeOperator.Over);
                                Thread.Sleep(1000);
                            }

                            watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, userSettingM.markTransparency);
                            Thread.Sleep(1000);
                        }

                        // Salvando o resultado na pasta temporaria
                        image.Write("temp.jpg");
                    }


                    //SALVANDO COMO PDF
                    page_img = new Bitmap(FromFile("temp.jpg")); //Pegando o arquivo na pagina temporaria
                    PdfUtility pdfUtility = new PdfUtility();
                    //dfUtility.Wait_for(1000);

                    out_pdf = new PdfSharp.Pdf.PdfDocument()
                    {
                        Version = pdf.Version
                    };

                    out_pdf.Info.Title = String.Format("Page {0} of {1}", 0, pdf.Info.Title);
                    out_pdf.Info.Creator = pdf.Info.Creator;


                    string saida = virtualScannerDiretorios.pathWaterMarkCompleted + "\\" + Path.GetFileName(pdffile);

                    //se signature for verdade, jogar em signature, se não, jogar em indexação
                    pdfUtility.Add_new_page(page_img, out_pdf);
                    out_pdf.Save(saida);
                    //esperar ao copiar cada arquivo
                    Thread.Sleep(1000);
                    out_pdf.Close();
                    page_img.Dispose();
                    File.Delete(pdffile);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                ErrorLogging.ErrorLog(ex);
                return;
            }

        }

        //TESTAR MULTIPLA PAGINA
        public void processoBarcode()
        {
            VirtualScannerDiretorios.criarDiretorios();
            VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();
           
            Load_AppSettings();
            m_timerRenomear.Interval = 50 * 1000;
            m_timerRenomear.Tick += M_timerRenomear_Tick;
            //criarDiretorios();

                UpdateList();

            if (m_input_files.Count == 0)
            {
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
                PdfSharp.Pdf.PdfDocument pdf = PdfSharp.Pdf.IO.PdfReader.Open(fname_full, PdfDocumentOpenMode.Import);
                PdfSharp.Pdf.PdfPage first = pdf.Pages[0]; //pega a primeira pagina do pdf

                doc_height = (float)first.Height.Centimeter; //define a primeira pagina do pdf como tamanho do documento

                if (doc_height <= float.Epsilon) //Float.Epsilon retorna o menor numero possivel de um float
                {
                    Console.WriteLine(String.Format("File {0} is not valid.", fname_full));
                    pdf.Close();
                    continue;
                }

               
                int page_count = pdf.PageCount;

                PdfSharp.Pdf.PdfPage page = pdf.Pages[barcodePage];
                    
                    images[barcodePage].Write("temp.jpg");      //salva pagina como temp.jpg e jogar para analize


                Bitmap page_img = new Bitmap(FromFile("temp.jpg")); 
                


                Thread.Sleep(200);
                    Wait_for(40);
                    
                    /*if (doc_height <= float.Epsilon) //Se certifica de que cada pagina está em conformidade com tamanho minimo
                    {
                            continue;
                    }*/
                        
                        
                        m_found = false;
                        if (TryReadCode(page_img, 0) == true) //Se retornou true é que m_found (barcode) foi copulado
                        {

                            try
                            {
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
                                string targetPath = virtualScannerDiretorios.pathProcessingCompleted;

                                string sourceFile = System.IO.Path.Combine(virtualScannerDiretorios.pathProcessing, fileName);
                                novoNome = StringFormater.RemoverCaracteresEspeciais(novoNome);
                                string destFile = System.IO.Path.Combine(targetPath, novoNome);
                                System.IO.File.Copy(sourceFile, destFile, true);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogging.ErrorLog(ex);
                                return;
                            }

                            Wait_for(40);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            try
                            {
                                String date = (DateTime.Now.ToString("yyyy-MM-dd:HH:mm:ss"));

                                Wait_for(40);
                                string novoNome = "Nao_Detectado_Barcode_" + date.Replace(":", "_") + ".pdf";
                                string sourcePath = virtualScannerDiretorios.pathProcessing;
                                string targetPath = m_setting.saidaPath;
                                string sourceFile = System.IO.Path.Combine(sourcePath, fname);
                                string destFile = System.IO.Path.Combine(targetPath, novoNome);

                                System.IO.File.Copy(sourceFile, destFile, true);

                                m_found = false;
                                 Wait_for(40);
                                Thread.Sleep(1000);
                            }
                            catch (Exception ex)
                            {
                            ErrorLogging.ErrorLog(ex);
                            return;
                            }
                        }
                try
                {
                    pdf.Close();
                    string lixo = virtualScannerDiretorios.pathProcessing + "\\" + fname;
                    File.Delete(lixo);
                    m_input_files.RemoveAt(0);
                }
                catch (Exception ex)
                {
                    ErrorLogging.ErrorLog(ex);
                    return;
                }
                
            }
        }


        public string TesteBarcode(string pdfFile)
        {
            VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();
            string pathPreProcessing = pathRaizInterno + @"\PreProcessamento";
            string pathProcessing = pathRaizInterno + @"\Processamento";
            string pathPostProcessing = pathRaizInterno + @"\pos-processamento";


            Load_AppSettings();
            m_timerRenomear.Interval = 50 * 1000;
            m_timerRenomear.Tick += M_timerRenomear_Tick;



            Thread.Sleep(200); // Faz a thread aguardar processos
            Wait_for(40); //Helper: Faz com que o windows descarregue processos em fila

            float doc_height;
            float region_height = m_setting.region_height;


                fname_full = pdfFile;
                fname = fname_full.Substring(fname_full.LastIndexOf('\\') + 1);

                //Configura MagickRead (leitura, conversão e gravação de imagens)
                MagickReadSettings settings = new MagickReadSettings()
                {
                    Density = new Density(300, 300)
                };
                MagickImageCollection images = new MagickImageCollection();
                images.Read(fname_full, settings);

                //Configura pdf Sharp
                PdfSharp.Pdf.PdfDocument pdf = PdfSharp.Pdf.IO.PdfReader.Open(fname_full, PdfDocumentOpenMode.Import);
                PdfSharp.Pdf.PdfPage first = pdf.Pages[0]; //pega a primeira pagina do pdf

                doc_height = (float)first.Height.Centimeter; //define a primeira pagina do pdf como tamanho do documento

                int page_count = pdf.PageCount;

                PdfSharp.Pdf.PdfPage page = pdf.Pages[barcodePage];

                images[barcodePage].Write("temp.jpg");      //salva pagina como temp.jpg e jogar para analize

                
                Bitmap page_img = new Bitmap(FromFile("temp.jpg"));


                Thread.Sleep(200);
                Wait_for(40);


                m_found = false;
                if (TryReadCode(page_img, 0) == true) //Se retornou true é que m_found (barcode) foi copulado
                {


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
                    string targetPath = virtualScannerDiretorios.pathProcessingCompleted;

                    string sourceFile = System.IO.Path.Combine(virtualScannerDiretorios.pathProcessing, fileName);
                    novoNome = StringFormater.RemoverCaracteresEspeciais(novoNome);
                    return novoNome;
                }
                else
                {

                string error = "barcode não detectado";
                    return error;
                }
            
        }

        //timers
        private void M_timerRenomear_Tick(object sender, EventArgs e)
        {
            UpdateList();
            if (m_input_files.Count > 0)
            {
                processoBarcode();
            }
        }

        

        //diretorio nivel interno programa
        string pathRaizInterno = @"C:\\INFORVirtualScanner";
        

       

        public void Wait_for(int milisec)
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

            List<BarcodeFormat> codeformats = new List<BarcodeFormat>();
            codeformats.Add(BarcodeFormat.QR_CODE);
            codeformats.Add(BarcodeFormat.CODE_128);

            // Primeira Tentativa : ZXing
            BarcodeReader reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,


                Options = {
                PossibleFormats = codeformats,
                TryHarder = true,
                ReturnCodabarStartEnd = true,
                PureBarcode = false,
                }
            };

            Result res = reader.Decode(img);


                if (res != null )
                {
                    m_found = true;
                    m_code = res.Text;
                    m_found_format = res.BarcodeFormat;
                    return true;
                }

            //segunda tentativa
            //Tentar em preto e branco
            //Se BW estiver ativado fazer
            /*
            //funcionou pra um barcode
            string file2 = Path.GetDirectoryName(@"temp.jpg");
            using (var image = Image.Load<Rgba32>(@"temp.jpg"))
            {
                
                image.Mutate(img2 => img2.Resize(image.Width / 2, image.Height / 2)
                        .GaussianSharpen(sigma: 3.0f)
                        .BlackWhite());
                image.Save("image.jpg");
                Bitmap page_img2 = new Bitmap(FromFile("image.jpg"));
                Result res2 = reader.Decode(page_img2);

                if (res2 != null)
                {
                    m_found = true;
                    m_code = res.Text;
                    m_found_format = res2.BarcodeFormat;
                    return true;
                }
            } */

            //tentando criar um perfil funcional
            /*
            using (var image = Image.Load<Rgba32>(@"temp.jpg"))
            {

                image.Mutate(img2 => img2.Resize(image.Width , image.Height )
                        .GaussianSharpen(sigma: 3.0f)
                        .Grayscale());
                image.Save("image.jpg");
                Bitmap page_img2 = new Bitmap(FromFile("image.jpg"));
                Result res2 = reader.Decode(page_img2);

                if (res2 != null)
                {
                    m_found = true;
                    m_code = res.Text;
                    m_found_format = res2.BarcodeFormat;
                    return true;
                }
            }
            */
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
            VirtualScannerDiretorios virtualScannerDiretorios = new VirtualScannerDiretorios();

            try
            {
                // Enumerar arquivos PDF
                m_input_files = Directory.GetFiles(virtualScannerDiretorios.pathProcessing, "*.pdf").ToList();

                foreach (string fname_full in m_input_files)
                {
                    string fname = fname_full.Substring(fname_full.LastIndexOf('\\') + 1);
                    PdfSharp.Pdf.PdfDocument pdf = PdfSharp.Pdf.IO.PdfReader.Open(fname_full, PdfDocumentOpenMode.Modify);
                    pdf.Close();
                }

            }
            catch (Exception ex)
            {


            }
        }

        public static System.Drawing.Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = System.Drawing.Image.FromStream(ms);
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
                        System.Drawing.Color col = pixels.GetPixel(x, y);
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
                        System.Drawing.Color pix = pixels.GetPixel(x - dx, y + dy);
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
                ErrorLogging.ErrorLog(ex);
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
                ErrorLogging.ErrorLog(ex);
                return;
            }
        }

        

        private void Add_new_page(Bitmap region_img, PdfSharp.Pdf.PdfDocument out_pdf)
        {
            // Adiciona a pagina e salva ela
            MemoryStream strm = new MemoryStream();
            region_img.Save(strm, System.Drawing.Imaging.ImageFormat.Png);
            PdfSharp.Pdf.PdfPage new_page = out_pdf.AddPage();
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
