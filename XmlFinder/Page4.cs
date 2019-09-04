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
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            url =  txtEnderecoServidorFTP.Text;
            usuario = txtUsuario.Text;
            senha = txtSenha.Text;

            FtpConnection ftpConnection = new FtpConnection();
            testeFtp = ftpConnection.testFtpConnection(url, usuario, senha);
            if (testeFtp == true)
            {
                listarPastasBox.DataSource = ftpConnection.ListFiles(url, usuario, senha);
                new alerta("Usuario SALVO!", alerta.AlertType.sucesso).Show();
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
            FtpConnection ftpConnection = new FtpConnection();          
            DirectoryInfo directory = new DirectoryInfo (pastaLocal);

            testeFtp = ftpConnection.testFtpConnection(url, usuario, senha);
            if (testeFtp == true)
            {
                foreach (var file in directory.GetFiles())
                {
                    ftpConnection.UploadFile(pastaLocal, pastaWEB, file, url, usuario, senha);
                }
                new alerta("Arquivos Salvos", alerta.AlertType.sucesso).Show();
                testeFtp = false;
            }
            else
            {
                new alerta("Erro de REDE", alerta.AlertType.info).Show();
                listarPastasBox.DataSource = null;
                listarPastasBox.Items.Clear();
            }

            
        }

        private void btnSelecionarPasta_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
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

        public enum Hidetype
        {
            esconder, mostrar,
        }

        public void esconderPasso1(Hidetype type)
        {
            switch (type)
            {
                case Hidetype.esconder:
                    //dar Hide
                    break;
            }
        }
    }
}
