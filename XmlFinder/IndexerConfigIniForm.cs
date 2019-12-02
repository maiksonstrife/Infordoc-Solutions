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
            Load_AppSettings();

            //Salvando Indice 1
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

            //Salvando Indice 2
            m_setting.indice2 = txtIndice2.Text;

            if (chkboxIndice2.Checked == true)
            {
                m_setting.indice2isSubstring = true;
                m_setting.indice2SubI = Convert.ToInt32(txtinicio2.Text);
                m_setting.indice2SubE = Convert.ToInt32(txtExtensao2.Text);
            }
            else
            {
                m_setting.indice2isSubstring = false;
            }

            if (chkboxdelimitar2.Checked == true)
            {
                m_setting.indice2isDelimiter = true;
                m_setting.indice2Delimiter = txtDelimitar2.Text;
            }
            else
            {
                m_setting.indice2isDelimiter = false;
            }

            try
            {
                m_setting.Save();
                new alerta("Configurações Salvas", alerta.AlertType.atencao).Show();
            }
            catch
            {
                new alerta("Impossivel Salvar", alerta.AlertType.atencao).Show();
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

            if (String.IsNullOrEmpty(m_setting.indice2) == false)
            {
                chkboxAdd2.Checked = true;
                txtIndice2.Text = m_setting.indice2;

                if (m_setting.indice2isSubstring == true)
                {
                    chkboxIndice2.Checked = true;
                    txtinicio2.Text = m_setting.indice2SubI.ToString();
                    txtExtensao2.Text = m_setting.indice2SubE.ToString();
                }

                if (m_setting.indice2isDelimiter == true)
                {
                    chkboxdelimitar2.Checked = true;
                    txtDelimitar2.Text = m_setting.indice2Delimiter;
                }
            }
            
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

        private void btnDigitalizações1_Click(object sender, EventArgs e)
        {
            txtIndice1.Text = "<COUNTER>";
        }

        private void chkboxAdd2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkboxAdd2.Checked == true)
            {
                m_setting.isIndice2 = true;

                lblIndice2.Visible = true;
                txtIndice2.Visible = true;
                chkboxIndice2.Visible = true;
                lblExtrair2.Visible = true;
                //lblinicio2.Visible = true;
                //lblExtensao2.Visible = true;
                //txtinicio2.Visible = true;
                //txtExtensao2.Visible = true;
                chkboxdelimitar2.Visible = true;
                lblDelimitar2.Visible = true;
                //txtDelimitar2.Visible = true;
                btnBarcode2.Visible = true;
                btnData2.Visible = true;
                btnDigitalizações2.Visible = true;
                btnRandomn2.Visible = true;
            }

            else
            {
                m_setting.isIndice2 = false;

                lblIndice2.Visible = false;
                txtIndice2.Visible = false;
                txtIndice2.Text = "";
                chkboxIndice2.Visible = false;
                chkboxIndice2.Checked = false;
                lblExtrair2.Visible = false;
                lblinicio2.Visible = false;
                lblExtensao2.Visible = false;
                txtinicio2.Visible = false;
                txtinicio2.Text = "";
                txtExtensao2.Visible = false;
                txtExtensao2.Text = "";
                chkboxdelimitar2.Visible = false;
                chkboxdelimitar2.Checked = false;
                lblDelimitar2.Visible = false;
                txtDelimitar2.Visible = false;
                txtDelimitar2.Text = "";
                btnBarcode2.Visible = false;
                btnData2.Visible = false;
                btnDigitalizações2.Visible = false;
                btnRandomn2.Visible = false;
            }

        }

        private void chkboxIndice2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkboxIndice2.Checked == false)
            {
                txtinicio2.Text = "";
                txtExtensao2.Text = "";
                txtinicio2.Visible = false;
                txtExtensao2.Visible = false;
                lblinicio2.Visible = false;
                lblExtensao2.Visible = false;
            }
            else
            {
                txtinicio2.Visible = true;
                txtExtensao2.Visible = true;
                lblinicio2.Visible = true;
                lblExtensao2.Visible = true;
            }
        }

        private void chkboxdelimitar2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkboxdelimitar2.Checked == false)
            {
                txtDelimitar2.Text = "";
                txtDelimitar2.Visible = false;
            }
            else
            {
                txtDelimitar2.Visible = true;
            }
        }

        private void btnBarcode2_Click(object sender, EventArgs e)
        {
            txtIndice2.Text = "<BARCODE>";
        }

        private void btnData2_Click(object sender, EventArgs e)
        {
            txtIndice2.Text = "<DATA>";
        }

        private void btnDigitalizações2_Click(object sender, EventArgs e)
        {
            txtIndice2.Text = "<COUNTER>";
        }

        private void btnRandomn1_Click(object sender, EventArgs e)
        {
            txtIndice1.Text = "<RANDOMN>";
        }
    }
}
