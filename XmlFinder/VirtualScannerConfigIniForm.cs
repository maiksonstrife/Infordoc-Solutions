using Microsoft.WindowsAPICodePack.Dialogs;
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
    public partial class VirtualScannerConfigIniForm : Form
    {
        UserSetting m_setting;

        public VirtualScannerConfigIniForm()
        {
            InitializeComponent();
        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //botao recortar
        private void bunifuToggleSwitch1_OnValuechange(object sender, EventArgs e)
        {
            if (isCutter.Value == false)
            {
                m_setting.isCutter = false;
                m_setting.isPreProcessing = false;
            }

            if (isCutter.Value == true)
            {
                m_setting.isCutter = true;
                m_setting.isPreProcessing = true;
            }
        }

        private void IsSignatureSwitch_OnValuechange(object sender, EventArgs e)
        {
            if (IsSignatureSwitch.Value == false)
            {
                m_setting.isSignature = false;
                m_setting.isProProcessing = false;
            }

            if (IsSignatureSwitch.Value == true)
            {
                m_setting.isSignature = true;
                m_setting.isProProcessing = true;
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            m_setting.autor = autorTextBox.Text;
            m_setting.titulo = tituloTextBox.Text;
            m_setting.assunto = assuntoTextBox.Text;
            m_setting.palavrasChave = keywordTextBox.Text;
            m_setting.criador = criadorTextBox.Text;
            m_setting.produtor = produtorTextBox.Text;
            m_setting.razao = razaoTextBox.Text;
            m_setting.contato = contatoTextBox.Text;
            m_setting.Endereco = enderecoTextBox.Text;
            m_setting.passwordCertificate = certificadoSenhaTextBox.Text;
            m_setting.pathCertificate = certificadoPath;


            m_setting.Save();
            new alerta("Configurações Salvas", alerta.AlertType.atencao).Show();
            this.Close();
        }

        string certificadoPath;
        private void certiciadoButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "Certificate files *.pfx|*.pfx";
            openFile.Title = "Select a file";
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            certificadoPath = openFile.FileName;
        }

        private void VirtualScannerConfigIniForm_Load(object sender, EventArgs e)
        {
            Load_AppSettings();

            autorTextBox.Text = m_setting.autor;
            tituloTextBox.Text = m_setting.titulo;
            assuntoTextBox.Text = m_setting.assunto;
            keywordTextBox.Text = m_setting.palavrasChave;
            criadorTextBox.Text = m_setting.criador;
            produtorTextBox.Text = m_setting.produtor;
            razaoTextBox.Text = m_setting.razao;
            contatoTextBox.Text = m_setting.contato;
            enderecoTextBox.Text = m_setting.Endereco;
            certificadoSenhaTextBox.Text = m_setting.passwordCertificate;
            certificadoPath = m_setting.pathCertificate;
            isCutter.Value = m_setting.isCutter;
            bunifuRadioButton2.Checked = m_setting.isVertical;
            bunifuRadioButton1.Checked = m_setting.isHorizontal;

            if (m_setting.isSignature == true)
            {
                IsSignatureSwitch.Value = true;
            }

            if(m_setting.signVisivel == true)
            {
                assinaturaVisivelChkBox.Checked = true;
            }
            else
            {
                assinaturaVisivelChkBox.Checked = false;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void assinaturaVisivelChkBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (assinaturaVisivelChkBox.Checked == false)
            {
                m_setting.signVisivel = false;
            }

            if (assinaturaVisivelChkBox.Checked == true)
            {
                m_setting.signVisivel = true;
            }
        }

        private void pathEntradaButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            string tempPath = "";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                tempPath = browser.SelectedPath; // prints path
            }

            m_setting.entradaPath = tempPath;
        }

        private void pathSaidaButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            string tempPath = "";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                tempPath = browser.SelectedPath; // prints path
            }

            m_setting.saidaPath = tempPath;
        }

        
        private void label6_Click(object sender, EventArgs e)
        {

        }

        //radial button Vertical
        private void bunifuRadioButton2_Click(object sender, EventArgs e)
        {
            if (bunifuRadioButton2.Checked == false)
            {
                m_setting.isVertical = false;
            }

            if (bunifuRadioButton2.Checked == true)
            {
                m_setting.isVertical = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            m_setting.numeroCortes = Convert.ToInt32(textBox5.Text);
        }

        //radial button Horizontal
        private void bunifuRadioButton1_Click(object sender, EventArgs e)
        {
            if (bunifuRadioButton1.Checked == false)
            {
                m_setting.isHorizontal = false;
            }

            if (bunifuRadioButton1.Checked == true)
            {
                m_setting.isHorizontal = true;
            }
        }
    }
}
