using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlFinder
{
    public partial class Page4 : UserControl
    {
        //contato@infordoc.com.br
        //55745922
        string arquivo, url, usuario, senha;
        string pastaSelecionada;
        bool testeFtp;
         
        public Page4()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            url =  txtEnderecoServidorFTP.Text;
            usuario = txtUsuario.Text; senha = txtSenha.Text;
            FtpConnection ftpConnection = new FtpConnection();
            testeFtp = ftpConnection.testFtpConnection(url, usuario, senha);
            if (testeFtp == true)
            {
                //salvar no settings
                listarPastasBox.DataSource = ftpConnection.ListFiles(url, usuario, senha);
            }
            else
            {
                new alerta("Erro de REDE", alerta.AlertType.info).Show();
                listarPastasBox.DataSource = null;
                listarPastasBox.Items.Clear();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listarPastasBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pastaSelecionada = this.listarPastasBox.GetItemText(this.listarPastasBox.SelectedItem);
        }

        private void btnEnviarFtp_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listaPastaFtp_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
