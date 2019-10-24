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
            using (VirtualScannerConfigIniForm virtualScannerConfigIni = new VirtualScannerConfigIniForm())
            {
                virtualScannerConfigIni.ShowDialog();
            }
        }

        private void PageConfigSelect_Load(object sender, EventArgs e)
        {

        }

        private void ButtonConfigXMLFinder_Click(object sender, EventArgs e)
        {
            using (XML_FinderConfigIniForm xML_FinderConfigIniForm = new XML_FinderConfigIniForm())
            {
                xML_FinderConfigIniForm.ShowDialog();
            }
        }

        private void ButtonConfigIniInforFTP_Click(object sender, EventArgs e)
        {
            using (INFORFTPConfigIniForm iNFORFTP = new INFORFTPConfigIniForm())
            {
                iNFORFTP.ShowDialog();
            }
        }

        private void appRestart_Click(object sender, EventArgs e)
        {
                Application.Restart();
        }
    }
}
