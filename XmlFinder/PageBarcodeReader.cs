using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlFinder
{
    public partial class PageBarcodeReader : UserControl
    {
        public PageBarcodeReader()
        {
            InitializeComponent();
        }

        private void CarregaOnloadRenomear_Click(object sender, EventArgs e)
        {
            string barcode;
            bool monitorar = false;
            PdfUtility pdfRenomear = new PdfUtility();

            //teste
            int[,] array = new int[1,2];
            array[0, 0] = 1;
            array[0, 1] = 5;
            //Na pratica a pessoa ativara a quantidade de parametros e os valores do parametro atraves da UI configuracao Barcode
            //if tamanho igual = 1(){  int[,] array = new int[1,2] com valor [0,0] = a,b e [0,1} = c,d;

            barcode = pdfRenomear.onloadCarregaRenomear(monitorar);
            barcode = StringFormater.DelimitarString(barcode, ";", array); //funciona supimpa!!!

        }
    }
}
