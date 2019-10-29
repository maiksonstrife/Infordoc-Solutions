using ScanPDF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlFinder
{
    public partial class IndexerConfigIniForm : Form
    {
        UserSetting m_setting;

        public IndexerConfigIniForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblExtrair_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBarcode1_Click(object sender, EventArgs e)
        {
            txtIndice1.Text = "<BARCODE>";
        }

        private void btnData1_Click(object sender, EventArgs e)
        {
            txtIndice1.Text = "<DATA>";
        }

        private void btnSalvarIndices_Click(object sender, EventArgs e)
        {
            m_setting.indice1 = txtIndice1.Text;

            if (chkboxIndice1.Checked == true)
            {
                m_setting.indice1isSubstring = true;
                m_setting.indice1SubI = Convert.ToInt32(txtinicio1.Text);
                m_setting.indice1SubE = Convert.ToInt32(txtExtensao1.Text);
            }
            else
            {
                m_setting.indice1isSubstring = false; 
            }

            if (chkboxdelimitar1.Checked == true)
            {
                m_setting.indice1isDelimiter = true;
                m_setting.indice1Delimiter = txtDelimitar1.Text;
            }
            else
            {
                m_setting.indice1isDelimiter = false; 
            }

            m_setting.Save();
            new alerta("Configurações Salvas", alerta.AlertType.atencao).Show();
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

        private void chkboxIndice1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkboxIndice1.Checked == false)
            {
                txtinicio1.Text = "";
                txtExtensao1.Text = "";
                txtinicio1.Visible = false;
                txtExtensao1.Visible = false;
                lblinicio1.Visible = false;
                lblExtensao1.Visible = false;
            }
            else
            {
                txtinicio1.Visible = true;
                txtExtensao1.Visible = true;
                lblinicio1.Visible = true;
                lblExtensao1.Visible = true;
            }
        }

        private void IndexerConfigIniForm_Load(object sender, EventArgs e)
        {
            Load_AppSettings();

                txtIndice1.Text = m_setting.indice1;

                txtinicio1.Text = m_setting.indice1SubI.ToString();
            

                txtExtensao1.Text = m_setting.indice1SubE.ToString();
            


                txtDelimitar1.Text = m_setting.indice1Delimiter;
            

            chkboxIndice1.Checked = m_setting.indice1isSubstring;
            chkboxdelimitar1.Checked = m_setting.indice1isDelimiter;
            
        }

        private void chkboxdelimitar1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkboxdelimitar1.Checked == false)
            {
                txtDelimitar1.Text = "";
                txtDelimitar1.Visible = false;
            }
            else
            {
                txtDelimitar1.Visible = true;
            }
        }
    }
}
