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
    public partial class PageConfigSelect : UserControl
    {

        public PageConfigSelect()
        {
            InitializeComponent();
            
        }

        private void ButtonConfigIniInforScanner_Click(object sender, EventArgs e)
        {
            //tudo errado mais facil abrir um popup!!!
            using (VirtualScannerConfigIniForm virtualScannerConfigIni = new VirtualScannerConfigIniForm())
            {
                virtualScannerConfigIni.ShowDialog();
            }
        }

        private void PageConfigSelect_Load(object sender, EventArgs e)
        {

        }
    }
}
