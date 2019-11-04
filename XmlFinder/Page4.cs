using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using XmlFinder.Properties;
using ScanPDF;

namespace XmlFinder
{
    public partial class Page4 : UserControl
    {
        UserSetting m_setting;
        string url, usuario, senha;
        string pastaWEB;
        string pastaLocal;
        bool testeFtp = false;
       
         
        public Page4()
        {
            InitializeComponent();
            timer1.Enabled = false;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Load_AppSettings();

            url = m_setting.enderecoFTP;
            usuario = m_setting.usuarioFTP;
            senha = m_setting.senhaFTP;

            if (String.IsNullOrEmpty(url))
            {
                new alerta("Preencher ENDEREÇO em Conifgurações", alerta.AlertType.atencao).Show();
                return;
            }
            if (String.IsNullOrEmpty(usuario))
            {
                new alerta("Preencher USUARIO em Conifgurações", alerta.AlertType.atencao).Show();
                return;
            }
            if (String.IsNullOrEmpty(senha))
            {
                new alerta("Preencher SENHA em Conifgurações", alerta.AlertType.atencao).Show();
                return;
            }


            FtpConnection ftpConnection = new FtpConnection();
            testeFtp = ftpConnection.testFtpConnection(url, usuario, senha);
            if (testeFtp == true)
            {
                listarPastasBox.DataSource = ftpConnection.ListFiles(url, usuario, senha);
                new alerta("CONECTADO!", alerta.AlertType.sucesso).Show();
                testeFtp = false;
            }
            else
            {
                new alerta("Erro de REDE", alerta.AlertType.erro).Show();
                listarPastasBox.DataSource = null;
                listarPastasBox.Items.Clear();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listarPastasBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pastaWEB = this.listarPastasBox.GetItemText(this.listarPastasBox.SelectedItem);
        }




        private void btnEnviarFtp_Click(object sender, EventArgs e)
        {
            Load_AppSettings();

            url = m_setting.enderecoFTP;
            usuario = m_setting.usuarioFTP;
            senha = m_setting.senhaFTP;

            bool isError = false;
            isError = tratamentoErros();

            if (String.IsNullOrEmpty(txtPastaWeb.Text) == false)
            {
                pastaWEB += txtPastaWeb.Text;
            }

            if (isError == true)
            {
                enviarFtp();
            }
            else
            {
                return;
            }
        }

        private void btnSelecionarPasta_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.InitialDirectory = path + "\\FTP";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                pastaLocal = dialog.FileName;
                txtCaminhoLocal.Text = pastaLocal;
            }
        }
        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvarPasta_Click(object sender, EventArgs e)
        {
            new alerta("Pasta Local SALVO!", alerta.AlertType.sucesso).Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listaPastaFtp_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void btnMonitorar_Click(object sender, EventArgs e)
        {
            bool isError = false;
            isError = tratamentoErros();
            if (isError == true)
            {
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                return;
            }

            btnPararVerificacao.Enabled = true;
            btnPararVerificacao.Update();
            botoesControle(false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool isError = false;
            isError = tratamentoErros();
            if (isError == true)
            {
                enviarFtp();
            }
            else
            {
                return;
            }
            
        }

        private void btnPararVerificacao_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            new alerta("Verificação Automática desabilitada", alerta.AlertType.info).Show();
            btnPararVerificacao.Enabled = false;
            btnPararVerificacao.Update();
            backgroundWorker1.CancelAsync();
            botoesControle(true);
            txtCaminhoLocal.Visible = true;
            chkSalvarPerfil.Visible = true;
            label7.Visible = true;
            chkSubDiretorio.Visible = true;
            lblsubdir.Visible = true;
            timer1.Enabled = false;
        }

        private void txtUsuario_OnValueChanged(object sender, EventArgs e)
        {

        }

        //Threading in Background
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isError = false;
            isError = tratamentoErros();
            if (isError == true)
            {
                FtpConnection ftpConnection = new FtpConnection();
                DirectoryInfo directory = new DirectoryInfo(pastaLocal);

                testeFtp = ftpConnection.testFtpConnection(url, usuario, senha);
                if (testeFtp == true)
                {
                    int i = 0;
                    foreach (var file in directory.GetFiles())
                    {
                        
                        ftpConnection.UploadFile(pastaLocal, pastaWEB, file, url, usuario, senha);
                        i++;
                        File.Delete(file.FullName.ToString());
                        backgroundWorker1.ReportProgress(i);
                    }
                    testeFtp = false;

                }
                else
                {

                    BeginInvoke((MethodInvoker)delegate
                    {
                        new alerta("Erro de REDE", alerta.AlertType.info).Show();
                        listarPastasBox.DataSource = null;
                        listarPastasBox.Items.Clear();
                    });
                    
                }
            }
            else
            {
                return;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bunifuProgressBar1.Value = e.ProgressPercentage;
            double dProgress = 100.0 * bunifuProgressBar1.Value / bunifuProgressBar1.MaximumValue;
            percentBar.Text = dProgress + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bunifuProgressBar1.Value = 0;


            bunifuProgressBar1.Update();
            new alerta("Arquivos Salvos", alerta.AlertType.sucesso).Show();
            percentBar.Text = "";
            //Se não for monitoramento, retornar os botoes ao finalizar
            if (timer1.Enabled == false)
            {
                botoesControle(true);
                label4.Visible = true;
                chkSubDiretorio.Visible = true;
                lblsubdir.Visible = true;
                listarPastasBox.Visible = true;
                txtPastaWeb.Visible = true;
                label8.Visible = true;
                label6.Visible = true;
                txtCaminhoLocal.Visible = true;
                btnSelecionarPasta.Visible = true;
                checkboxLocalPadrao.Visible = true;
                label1.Visible = true;
                chkSalvarPerfil.Visible = true;
                label7.Visible = true;
               

                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
            }
        }

        public bool tratamentoErros()
        {

            if (String.IsNullOrEmpty(pastaLocal))
            {
                new alerta("Selecionar PASTA LOCAL", alerta.AlertType.atencao).Show();
                return false;
            }
            if (String.IsNullOrEmpty(pastaWEB))
            {
                new alerta("selecionar PASTA WEB", alerta.AlertType.atencao).Show();
                return false;
            }
            if (String.IsNullOrEmpty(usuario))
            {
                new alerta("USUARIO VAZIO configurações", alerta.AlertType.atencao).Show();
                return false;
            }
            if (String.IsNullOrEmpty(senha))
            {
                new alerta("SENHA VAZIA configurações", alerta.AlertType.atencao).Show();
                return false;
            }

            return true;
        }

        private void checkboxLocalPadrao_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            Load_AppSettings();
            if (checkboxLocalPadrao.Checked == true){
                if (string.IsNullOrEmpty(m_setting.pastalocalFTP))
                {
                    new alerta("Caminho SAIDA PADRAO Vazio", alerta.AlertType.atencao).Show();
                    checkboxLocalPadrao.Checked = false;
                    return;
                }
                else
                {
                    txtCaminhoLocal.Text = m_setting.pastalocalFTP;
                }
            }
            

        }

        private void bunifuProgressBar1_onValueChange(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        public void enviarFtp()
        {
            DirectoryInfo directory = new DirectoryInfo(pastaLocal);
            int range = directory.GetFiles().Length;
            bunifuProgressBar1.MaximumValue = range;
            botoesControle(false);
            backgroundWorker1.RunWorkerAsync();
        }

        private void chkSubDiretorio_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkSalvarPerfil.Checked == true)
            {
                dropPerfis.Visible = true;
                label9.Visible = true;
                txtNomePerfil.Visible = true;
                btnSalvarPerfil.Visible = true;



                dropPerfis.Items.Add(m_setting.perfil1);
                dropPerfis.Items.Add(m_setting.perfil2);
                dropPerfis.Items.Add(m_setting.perfil3);
            }

            if (chkSalvarPerfil.Checked == false)
            {
                dropPerfis.Visible = false;
                label9.Visible = false;
                txtNomePerfil.Visible = false;
                btnSalvarPerfil.Visible = false;
                txtNomePerfil.Text = "";
            }
        }

        private void Page4_Load(object sender, EventArgs e)
        {
            Load_AppSettings();

            if (m_setting.perfil1 == "<Perfil1>")
            {
                btnPerfil1.Enabled = false;
            }
            else
            {
                btnPerfil1.ButtonText = m_setting.perfil1;
                btnPerfil1.Enabled = true; 
            }

            if (m_setting.perfil2 == "<Perfil2>")
            {
                btnPerfil2.Enabled = false;
            }
            else
            {
                btnPerfil2.ButtonText = m_setting.perfil2;
                btnPerfil2.Enabled = true;
            }

            if (m_setting.perfil3 == "<Perfil3>")
            {
                btnPerfil3.Enabled = false;
            }
            else
            {
                btnPerfil3.ButtonText = m_setting.perfil3;
                btnPerfil3.Enabled = true;
            }
        }

        private void chkSubDiretorio_CheckedChanged_1(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkSubDiretorio.Checked == true)
            {
                txtPastaWeb.Visible = true;
                label8.Visible = true;
            }

            if (chkSubDiretorio.Checked == false)
            {
                txtPastaWeb.Visible = false;
                label8.Visible = false;
                txtPastaWeb.Text = "";
            }
            

        }

        private void btnSalvarPerfil_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNomePerfil.Text))
            {
                new alerta("Insira um nome", alerta.AlertType.atencao).Show();
                return;
            }
            Load_AppSettings();

            int index = dropPerfis.SelectedIndex;

            if (index == 0)
            {
                m_setting.perfil1 = txtNomePerfil.Text;
                m_setting.pastaLOCALperfil1 = txtCaminhoLocal.Text;
                m_setting.pastaWEBperfil1 = this.listarPastasBox.GetItemText(this.listarPastasBox.SelectedItem);

                if (String.IsNullOrEmpty(txtPastaWeb.Text) == false)
                {
                    m_setting.pastaWEBperfil1 += txtPastaWeb.Text;
                }

                m_setting.Save();
            }

            if (index == 1)
            {
                m_setting.perfil2 = txtNomePerfil.Text;
                m_setting.pastaLOCALperfil2 = txtCaminhoLocal.Text;
                m_setting.pastaWEBperfil2 = this.listarPastasBox.GetItemText(this.listarPastasBox.SelectedItem);

                if (String.IsNullOrEmpty(txtPastaWeb.Text) == false)
                {
                    m_setting.pastaWEBperfil2 += txtPastaWeb.Text;
                }

                m_setting.Save();
            }

            if (index == 2)
            {
                m_setting.perfil3 = txtNomePerfil.Text;
                m_setting.pastaLOCALperfil3 = txtCaminhoLocal.Text;
                m_setting.pastaWEBperfil3 = this.listarPastasBox.GetItemText(this.listarPastasBox.SelectedItem);

                if (String.IsNullOrEmpty(txtPastaWeb.Text) == false)
                {
                    m_setting.pastaWEBperfil3 += txtPastaWeb.Text;
                }

                m_setting.Save();
            }

        }

        private void btnPerfil1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            chkSubDiretorio.Visible = false;
            lblsubdir.Visible = false;
            listarPastasBox.Visible = false;
            txtPastaWeb.Visible = false;
            label8.Visible = false;
            label6.Visible = false;
            txtCaminhoLocal.Visible = false;
            btnSelecionarPasta.Visible = false;
            checkboxLocalPadrao.Visible = false;
            label1.Visible = false;
            chkSalvarPerfil.Visible = false;
            label7.Visible = false;
            dropPerfis.Visible = false;
            label9.Visible = false;
            txtNomePerfil.Visible = false;
            btnSalvarPerfil.Visible = false;

            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;

            label13.Text = m_setting.pastaLOCALperfil1;
            label14.Text = m_setting.pastaWEBperfil1;

            pastaLocal = m_setting.pastaLOCALperfil1;
            pastaWEB = m_setting.pastaWEBperfil1;
            usuario = m_setting.usuarioFTP;
            senha = m_setting.senhaFTP;
        }

        private void btnPerfil2_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            chkSubDiretorio.Visible = false;
            lblsubdir.Visible = false;
            listarPastasBox.Visible = false;
            txtPastaWeb.Visible = false;
            label8.Visible = false;
            label6.Visible = false;
            txtCaminhoLocal.Visible = false;
            btnSelecionarPasta.Visible = false;
            checkboxLocalPadrao.Visible = false;
            label1.Visible = false;
            chkSalvarPerfil.Visible = false;
            label7.Visible = false;
            dropPerfis.Visible = false;
            label9.Visible = false;
            txtNomePerfil.Visible = false;
            btnSalvarPerfil.Visible = false;

            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;

            label13.Text = m_setting.pastaLOCALperfil2;
            label14.Text = m_setting.pastaWEBperfil2;

            pastaLocal = m_setting.pastaLOCALperfil2;
            pastaWEB = m_setting.pastaWEBperfil2;
            usuario = m_setting.usuarioFTP;
            senha = m_setting.senhaFTP;
        }

        private void btnPerfil3_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            chkSubDiretorio.Visible = false;
            lblsubdir.Visible = false;
            listarPastasBox.Visible = false;
            txtPastaWeb.Visible = false;
            label8.Visible = false;
            label6.Visible = false;
            txtCaminhoLocal.Visible = false;
            btnSelecionarPasta.Visible = false;
            checkboxLocalPadrao.Visible = false;
            label1.Visible = false;
            chkSalvarPerfil.Visible = false;
            label7.Visible = false;
            dropPerfis.Visible = false;
            label9.Visible = false;
            txtNomePerfil.Visible = false;
            btnSalvarPerfil.Visible = false;

            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;

            label13.Text = m_setting.pastaLOCALperfil3;
            label14.Text = m_setting.pastaWEBperfil3;

            pastaLocal = m_setting.pastaLOCALperfil3;
            pastaWEB = m_setting.pastaWEBperfil3;
            usuario = m_setting.usuarioFTP;
            senha = m_setting.senhaFTP;
        }

        public void botoesControle(bool botao)
        {
            bunifuButton1.Visible = botao;
            listarPastasBox.Visible = botao;
            btnSelecionarPasta.Visible = botao;
            btnEnviarFtp.Visible = botao;
            btnMonitorar.Visible = botao;
            label1.Visible = botao;
            label4.Visible = botao;
            label6.Visible = botao;
            checkboxLocalPadrao.Visible = botao;
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

    }
}
