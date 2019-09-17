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

namespace XmlFinder
{
    public partial class Page4 : UserControl
    {

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
            url = Settings.Default["EnderecoServidorFTP"].ToString();
            usuario = Settings.Default["Usuario"].ToString();
            senha = Settings.Default["Senha"].ToString();

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
                        backgroundWorker1.ReportProgress(i);
                    }
                    testeFtp = false;

                }
                else
                {
                    new alerta("Erro de REDE", alerta.AlertType.info).Show();
                    listarPastasBox.DataSource = null;
                    listarPastasBox.Items.Clear();
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
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bunifuProgressBar1.Value = 0;
            bunifuProgressBar1.Refresh();
            bunifuProgressBar1.Update();
            new alerta("Arquivos Salvos", alerta.AlertType.sucesso).Show();
            //Se não for monitoramento, retornar os botoes ao finalizar
            if (timer1.Enabled == false)
            {
                botoesControle(true);
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

        public void enviarFtp()
        {
            DirectoryInfo directory = new DirectoryInfo(pastaLocal);
            int range = directory.GetFiles().Length;
            bunifuProgressBar1.MaximumValue = range;
            bunifuProgressBar1.AnimationStep = 4;
            botoesControle(false);
            backgroundWorker1.RunWorkerAsync();
        }

        public void botoesControle(bool botao)
        {
            bunifuButton1.Visible = botao;
            listarPastasBox.Visible = botao;
            btnSelecionarPasta.Visible = botao;
            btnEnviarFtp.Visible = botao;
            btnMonitorar.Visible = botao;
            label4.Visible = botao;
            label6.Visible = botao;
        }
    }
}
