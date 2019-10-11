using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFinder
{
    class ImgRecorte
    {
        //da pra usar só essa classe, criar um contador da quantidade de partes a ser recortada, mudar os numeros por i.
        public static void  PDFVertical (Bitmap originalImage, string pdffile, string in_folder, int partes)
        {
            int retangulo = partes; //O retangulo é uma constante, pois ele permanecerá igual em todas partes

            string saidaFilename;
            PdfDocument pdf = PdfReader.Open(pdffile, PdfDocumentOpenMode.Import);
            Bitmap metade;
            ImgRecorte imgrecorte = new ImgRecorte();


            #region //Desenhando um retangulo
            /*
             * desenhando o retangulo, é literalmente o que o nome diz
             *o retangulo é composto de (posição horizontal, posicao vertical, tamanho horizontal, tamanho vertical
             *defino o retangulo na pasição 0 e 0, depois divido seu tamanho vertical pelo tamanho do documento dividido pelo numero de partes que quero
             *como resultado tenho um retangulo com tamanho exato das partes do documento que preciso retornar
            */
            #endregion

            RectangleF rect = new RectangleF (0, 0, originalImage.Width / retangulo, originalImage.Height);
            //agora uso a função clone para clonar uma parte do documento, qual parte? onde esta definido pelo retangulo, lembrando que ele começa sempre na posição 0
            metade = originalImage.Clone(rect, originalImage.PixelFormat);
            //salvado primeira metade como PDF
            PdfDocument out_pdf = null;
            out_pdf = new PdfDocument()
            {
                Version = pdf.Version
            };
            out_pdf.Info.Title = String.Format(pdf.Info.Title);
            out_pdf.Info.Creator = "Infordoc";
            saidaFilename = in_folder + @"\" + Path.GetFileNameWithoutExtension(pdffile).ToString() + "_1.pdf";
            imgrecorte.Add_new_page(metade, out_pdf); //adiciona pagina 0 (a unica)
            out_pdf.Save(saidaFilename);
            out_pdf.Close();

            //configurando loop                      
            float x = originalImage.Width / partes; //decidindo posicao X, exemplo: imagem 800x800, 800/4 = 200(posicao inicial)
            float y = originalImage.Width / partes;
            //loop                               //uso y porque se usasse x, ele começaria a dobrar por ele mesmo dentro do loop, y é uma constante
            for (int i = 2; i <= partes; i++) {  //1 - se começa em 200 termina em 400, 2- se comeca em 400 termina em 600, 3 - se começa em 600 termina em 800

                //recortando bmp  metade 2
                rect = new RectangleF(x, 0, originalImage.Width / retangulo, originalImage.Height);
                Bitmap secondHalf = originalImage.Clone(rect, originalImage.PixelFormat);

                //salvado segunda metade como PDF
                PdfDocument out_pdf2 = null;
                out_pdf2 = new PdfDocument()
                {
                    Version = pdf.Version
                };
                out_pdf2.Info.Title = String.Format(pdf.Info.Title);
                out_pdf2.Info.Creator = "Infordoc";
                saidaFilename = in_folder + @"\" + Path.GetFileNameWithoutExtension(pdffile).ToString() + "_" + i + ".pdf";
                imgrecorte.Add_new_page(secondHalf, out_pdf2);
                out_pdf2.Save(saidaFilename);
                out_pdf2.Close();
                x += y;
            }

        }



            public void Add_new_page(Bitmap region_img, PdfDocument out_pdf)
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
