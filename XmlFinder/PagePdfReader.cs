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

namespace XmlFinder
{
    public partial class PagePdfReader : UserControl
    {
        public PagePdfReader()
        {
            InitializeComponent();
        }

        private void btn_sel_in_Click(object sender, EventArgs e)
        {

        }
    }
}
