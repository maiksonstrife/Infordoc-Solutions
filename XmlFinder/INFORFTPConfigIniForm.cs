using ScanPDF;
using System;
using System.Windows.Forms;

namespace XmlFinder
{
    public partial class INFORFTPConfigIniForm : Form
    {
        UserSetting m_setting;

        public INFORFTPConfigIniForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            txtEnderecoServidorFTP.Text = "ftp.box.com";
        }

        private void btnSalvarRede_Click(object sender, EventArgs e)
        {
            m_setting.enderecoFTP = txtEnderecoServidorFTP.Text;
            m_setting.usuarioFTP = txtUsuario.Text;
            m_setting.senhaFTP = txtSenha.Text;
            m_setting.pastalocalFTP = txtPastaLocal.Text;
            m_setting.Save();
            this.Close();
            new alerta("CONFIGURAÇÃO SALVA", alerta.AlertType.atencao).Show();
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

        private void INFORFTPConfigIniForm_Load(object sender, EventArgs e)
        {
            Load_AppSettings();
            txtUsuario.Text = m_setting.usuarioFTP;
            txtSenha.Text = m_setting.senhaFTP;
            txtEnderecoServidorFTP.Text = m_setting.enderecoFTP;
        }
        //BOTÃO SELECIONAR PASTA PADRAO
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            string tempPath = "";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                tempPath = browser.SelectedPath; // prints path
            }

            txtPastaLocal.Text = tempPath;
        }

        private void btnTesteFtp_Click(object sender, EventArgs e)
        {
            FtpConnection ftpConnection = new FtpConnection();
            bool testeFtp = false;

            string url = m_setting.enderecoFTP;
            string usuario = m_setting.usuarioFTP;
            string senha = m_setting.senhaFTP;

            testeFtp = ftpConnection.testFtpConnection(url, usuario, senha);
            if (testeFtp == true)
            {
                new alerta("CONECTADO!", alerta.AlertType.sucesso).Show();
                testeFtp = false;
            }
            else
            {
                new alerta("Erro de REDE", alerta.AlertType.erro).Show();
            }
        }
    }
}
