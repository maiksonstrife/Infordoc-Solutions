using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScanPDF;

namespace XmlFinder
{
    public partial class PageConfigSelect : UserControl
    {
        UserSetting m_setting;

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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Load_AppSettings();
            m_setting.Exportar();
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
