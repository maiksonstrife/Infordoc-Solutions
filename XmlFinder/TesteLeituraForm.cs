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
    public partial class TesteLeituraForm : Form
    {
        public TesteLeituraForm()
        {
            InitializeComponent();
        }
        string pdfLeitura;
        private void btnProcurarPDF_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "Documentos PDF | *.pdf";
            openFile.Title = "Seleciona um PDF";
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            pdfLeitura = openFile.FileName;
        }

        string resposta;
        private void btnLerBarcode_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pdfLeitura))
            {
                MessageBox.Show("Selecione um arquivo PDF antes");
                return;
            }

            PdfUtility pdfUtility = new PdfUtility();

            resposta = pdfUtility.TesteBarcode(pdfLeitura);

            lblResposta.Text = resposta;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string simulartxt;
        int inicio;
        int fim;
        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtInicio.Text) || String.IsNullOrEmpty(txtExtensao.Text))
            {
                MessageBox.Show("Preenche os campos de inicio e fim antes");
                return;
            }
            try
            {
                inicio = Convert.ToInt32(txtInicio.Text);
                fim = Convert.ToInt32(txtExtensao.Text);
                simulartxt = resposta.Substring(inicio, fim);
            }
            catch
            {
                MessageBox.Show("Extensão mais longa que o código original");
                return;
            }
            

            lblResposta.Text = simulartxt;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            lblResposta.Text = resposta;
        }
    }
}
