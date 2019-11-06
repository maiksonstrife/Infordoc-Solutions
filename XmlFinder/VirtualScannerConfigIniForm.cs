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
            if (String.IsNullOrEmpty(autorTextBox.Text) == false)
            {
                m_setting.autor = autorTextBox.Text;
            }

            if (String.IsNullOrEmpty(tituloTextBox.Text) == false)
            {
                m_setting.titulo = tituloTextBox.Text;
            }

            if (String.IsNullOrEmpty(assuntoTextBox.Text) == false)
            {
                m_setting.assunto = assuntoTextBox.Text;
            }

            if (String.IsNullOrEmpty(keywordTextBox.Text) == false)
            {
                m_setting.palavrasChave = keywordTextBox.Text;
            }

            if (String.IsNullOrEmpty(criadorTextBox.Text) == false)
            {
                m_setting.criador = criadorTextBox.Text;
            }

            if (String.IsNullOrEmpty(produtorTextBox.Text) == false)
            {
                m_setting.produtor = produtorTextBox.Text;
            }

            if (String.IsNullOrEmpty(razaoTextBox.Text) == false)
            {
                m_setting.razao = razaoTextBox.Text;
            }

            if (String.IsNullOrEmpty(contatoTextBox.Text) == false)
            {
                m_setting.contato = contatoTextBox.Text;
            }

            if (String.IsNullOrEmpty(enderecoTextBox.Text) == false)
            {
                m_setting.Endereco = enderecoTextBox.Text;
            }

            if (String.IsNullOrEmpty(certificadoSenhaTextBox.Text) == false)
            {
                m_setting.passwordCertificate = certificadoSenhaTextBox.Text;
            }

            if (String.IsNullOrEmpty(certificadoPath) == false)
            {
                m_setting.pathCertificate = certificadoPath;
            }

            if (String.IsNullOrEmpty(imagemPath) == false)
            {
                m_setting.WatermarkImagePath = imagemPath;
            }

            if (String.IsNullOrEmpty(txtMarkX.Text) == false)
            {
                m_setting.markX = Convert.ToInt32(txtMarkX.Text);
            }

            if (String.IsNullOrEmpty(txtMarkY.Text) == false)
            {
                m_setting.markY = Convert.ToInt32(txtMarkY.Text);

            }


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
            txtCaminhoPrx.Text = certificadoPath;
        }

        private void VirtualScannerConfigIniForm_Load(object sender, EventArgs e)
        {
            Load_AppSettings();
            txtSaida.Text = m_setting.saidaPath;
            txtEntrada.Text = m_setting.entradaPath;
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
            assinaturaVisivelChkBox.Checked = m_setting.signVisivel;
            imagemPath = m_setting.WatermarkImagePath;
            label32.Text = m_setting.lastPosition;
            txtMarkX.Text = m_setting.markX.ToString();
            txtMarkY.Text = m_setting.markY.ToString();
            txtCaminhoPrx.Text = m_setting.pathCertificate;
            txtCaminhoMark.Text = m_setting.WatermarkImagePath;

            if (m_setting.isSpecificMark == true)
            {
                bunifuToggleSwitch1.Value = true;
            }
            else
            {
                bunifuToggleSwitch1.Value = false;
            }


            //BOTAO SIGNATURE
            if (m_setting.isSignature == true)
            {
                IsSignatureSwitch.Value = true;
            }
            else
            {
                IsSignatureSwitch.Value = false;
            }
            //BOTAO WATERMARK
            if (m_setting.isWaterMark == true)
            {
                isWaterMark.Value = true;
            }
            else
            {
                isWaterMark.Value = false;
            }
            //BOTAO Barcode
            if (m_setting.isBarcodeReader == true)
            {
                isBarcodeReader.Value = true;
            }
            else
            {
                isBarcodeReader.Value = false;
            }
            //BOTAO ASSINATURA VISIVEL
            if (m_setting.signVisivel == true)
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
            txtEntrada.Text = tempPath;
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
            txtSaida.Text = tempPath;
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

        private void isWaterMark_OnValuechange(object sender, EventArgs e)
        {

            if (isWaterMark.Value == false)
            {
                m_setting.isWaterMark = false;
                m_setting.isProProcessing = false;
            }

            if (isWaterMark.Value == true)
            {
                m_setting.isWaterMark = true;
                m_setting.isProProcessing = true;
            }

        }

        private void isBarcodeReader_OnValuechange(object sender, EventArgs e)
        {
            if (isBarcodeReader.Value == false)
            {
                m_setting.isBarcodeReader = false;
                m_setting.isProcessing = false;
            }

            if (isBarcodeReader.Value == true)
            {
                m_setting.isBarcodeReader = true;
                m_setting.isProcessing = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void isParameterReader_OnValuechange(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void formConfigurarIndiceIni_Click(object sender, EventArgs e)
        {
            using (IndexerConfigIniForm indexerConfigIniForm = new IndexerConfigIniForm())
            {
                indexerConfigIniForm.ShowDialog();
            }
        }

        private void formTesteLeitura_Click(object sender, EventArgs e)
        {
            using (TesteLeituraForm testeLeitura = new TesteLeituraForm())
            {
                testeLeitura.ShowDialog();
            }
        }

        string imagemPath;
        private void btnImagerDagua_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "Imagens JPG e PNG *.jpg|*.png";
            openFile.Title = "Seleciona imagem";
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            imagemPath = openFile.FileName;
            txtCaminhoMark.Text = imagemPath;
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Toggle Marca dagua predefinida
        private void bunifuToggleSwitch1_OnValuechange_1(object sender, EventArgs e)
        {
            if (bunifuToggleSwitch1.Value == true)
            {
                m_setting.isPremadeMark = true;
            }

            if (bunifuToggleSwitch1.Value == false)
            {
                m_setting.isPremadeMark = false;
            }
        }

        //Noroeste
        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            label32.Text = "Noroeste";
            m_setting.lastPosition = "Noroeste";

            //deixando true o settings
            m_setting.ismarkCenter = false;
            m_setting.ismarkEast = false;
            m_setting.ismarkNorth = false;
            m_setting.ismarkNortheast = false;
            m_setting.ismarkNorthwest = true;
            m_setting.ismarkSouth = false;
            m_setting.ismarkSoutheast = false;
            m_setting.ismarkSouthwest = false;
            m_setting.ismarkWest = false;

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            label32.Text = "Norte";
            m_setting.lastPosition = "Norte";

            //deixando true o settings
            m_setting.ismarkCenter = false;
            m_setting.ismarkEast = false;
            m_setting.ismarkNorth = true;
            m_setting.ismarkNortheast = false;
            m_setting.ismarkNorthwest = false;
            m_setting.ismarkSouth = false;
            m_setting.ismarkSoutheast = false;
            m_setting.ismarkSouthwest = false;
            m_setting.ismarkWest = false;
        }


        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            label32.Text = "Nordeste";
            m_setting.lastPosition = "Nordeste";


            //deixando true o settings
            m_setting.ismarkCenter = false;
            m_setting.ismarkEast = false;
            m_setting.ismarkNorth = false;
            m_setting.ismarkNortheast = true;
            m_setting.ismarkNorthwest = false;
            m_setting.ismarkSouth = false;
            m_setting.ismarkSoutheast = false;
            m_setting.ismarkSouthwest = false;
            m_setting.ismarkWest = false;
        }

        
        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            label32.Text = "Oeste";
            m_setting.lastPosition = "Oeste";

            //deixando true o settings
            m_setting.ismarkCenter = false;
            m_setting.ismarkEast = false;
            m_setting.ismarkNorth = false;
            m_setting.ismarkNortheast = false;
            m_setting.ismarkNorthwest = false;
            m_setting.ismarkSouth = false;
            m_setting.ismarkSoutheast = false;
            m_setting.ismarkSouthwest = false;
            m_setting.ismarkWest = true;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            label32.Text = "Centro";
            m_setting.lastPosition = "Centro";


            //deixando true o settings
            m_setting.ismarkCenter = true;
            m_setting.ismarkEast = false;
            m_setting.ismarkNorth = false;
            m_setting.ismarkNortheast = false;
            m_setting.ismarkNorthwest = false;
            m_setting.ismarkSouth = false;
            m_setting.ismarkSoutheast = false;
            m_setting.ismarkSouthwest = false;
            m_setting.ismarkWest = false;
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            label32.Text = "Leste";
            m_setting.lastPosition = "Leste";


            //deixando true o settings
            m_setting.ismarkCenter = false;
            m_setting.ismarkEast = true;
            m_setting.ismarkNorth = false;
            m_setting.ismarkNortheast = false;
            m_setting.ismarkNorthwest = false;
            m_setting.ismarkSouth = false;
            m_setting.ismarkSoutheast = false;
            m_setting.ismarkSouthwest = false;
            m_setting.ismarkWest = false;
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            label32.Text = "Sudoeste";
            m_setting.lastPosition = "Sudoeste";


            //deixando true o settings
            m_setting.ismarkCenter = false;
            m_setting.ismarkEast = false;
            m_setting.ismarkNorth = false;
            m_setting.ismarkNortheast = false;
            m_setting.ismarkNorthwest = false;
            m_setting.ismarkSouth = false;
            m_setting.ismarkSoutheast = false;
            m_setting.ismarkSouthwest = true;
            m_setting.ismarkWest = false;
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            label32.Text = "Sul";
            m_setting.lastPosition = "Sul";

            //deixando true o settings
            m_setting.ismarkCenter = false;
            m_setting.ismarkEast = false;
            m_setting.ismarkNorth = false;
            m_setting.ismarkNortheast = false;
            m_setting.ismarkNorthwest = false;
            m_setting.ismarkSouth = true;
            m_setting.ismarkSoutheast = false;
            m_setting.ismarkSouthwest = false;
            m_setting.ismarkWest = false;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            label32.Text = "Sudeste";
            m_setting.lastPosition = "Sudeste";


            //deixando true o settings
            m_setting.ismarkCenter = false;
            m_setting.ismarkEast = false;
            m_setting.ismarkNorth = false;
            m_setting.ismarkNortheast = false;
            m_setting.ismarkNorthwest = false;
            m_setting.ismarkSouth = false;
            m_setting.ismarkSoutheast = true;
            m_setting.ismarkSouthwest = false;
            m_setting.ismarkWest = false;
        }
    }
}
