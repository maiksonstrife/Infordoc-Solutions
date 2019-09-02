using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InforPlan
{
    public partial class Page3 : UserControl
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Page3_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {

        }

        private void isStandardDirectory_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            btnPastaPadraoPDF.Visible = isStandardDirectory.Checked;
            btnPastaPadraoXML.Visible = isStandardDirectory.Checked;
            TextBoxPDF.Visible = isStandardDirectory.Checked;
            TextBoxXML.Visible = isStandardDirectory.Checked;
        }
    }
}
