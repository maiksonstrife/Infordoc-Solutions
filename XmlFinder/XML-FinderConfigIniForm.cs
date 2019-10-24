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
    public partial class XML_FinderConfigIniForm : Form
    {
        UserSetting m_setting;

        public XML_FinderConfigIniForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //PASTA PDF BOTAO
        private void certiciadoButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            string tempPath = "";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                tempPath = browser.SelectedPath; // prints path
            }

            m_setting.pdfPath = tempPath;
            txtPDF.Text = tempPath;
        }

        //Load ini
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

        //Botao XML
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            string tempPath = "";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                tempPath = browser.SelectedPath; // prints path
            }

            m_setting.xmlPath = tempPath;
            txtXML.Text = tempPath;
        }
        //Botao Saida
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            string tempPath = "";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                tempPath = browser.SelectedPath; // prints path
            }

            m_setting.saidaxmlPath = tempPath;
            txtSaida.Text = tempPath;
        }
        //Botao Salvar
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            m_setting.Save();
            new alerta("Configurações Salvas", alerta.AlertType.atencao).Show();
            this.Close();
        }

        private void XML_FinderConfigIniForm_Load(object sender, EventArgs e)
        {
            Load_AppSettings();
            txtPDF.Text = m_setting.pdfPath;
            txtXML.Text = m_setting.xmlPath;
            txtSaida.Text = m_setting.saidaxmlPath;
        }
    }
}
