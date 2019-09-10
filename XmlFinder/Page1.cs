using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using XmlFinder.Properties;

namespace XmlFinder
{
    public partial class Page1 : UserControl
    {
        //variaveis globais (acessadas por mais de um metodo)
        String[] pdfPathFiles;
        String pdfPath;
        String outputPath;
        String verificacao = null;
        String url = "www.infordoc.com/central/financeiro/costas a pagar/";
        int counter = 0;

        public Page1()
        {
            InitializeComponent();
            txtAtivado.Text = "DESATIVADO";
        }

        private void btnPastaPDF_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                listBoxPDF.Items.Clear();
                pdfPath = dialog.FileName;
                pdfPathFiles = Directory.GetFiles(pdfPath, "*.pdf").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
                foreach (string arq in pdfPathFiles)
                {
                    listBoxPDF.Items.Add(arq);
                }
            }

            listBoxImportado.Items.Clear();
        }


        private void btnImportar_Click(object sender, EventArgs e)
        {
            #region //verifica se caminho foi selecionado
            //Verifica PDF
            if (pdfPathFiles == null)
            {
                new alerta("Esqueceu de selecionar PASTA PDF", alerta.AlertType.atencao).Show();
                return;
            }
            //Verifica Saída
            if (outputPath == null)
            {
                new alerta("Esqueceu de selecionar PASTA Saída", alerta.AlertType.atencao).Show();
                return;
            }
            #endregion  

            //Popup Timer
            using (Alerta1 _verificacao = new Alerta1())
            {
                _verificacao.ShowDialog();
                verificacao = _verificacao.resposta;
            }

            //verifica resposta
            if (verificacao == "sim")
            {
                btnPararVerificacao.Enabled = true;
                btnPararVerificacao.Update();

                #region //desativa botões
                btnPastaPDF.Enabled = false;
                btnPastaPDF.Visible = false;
                btnSelecionarSaida.Enabled = false;
                btnSelecionarSaida.Visible = false;
                btnImportar.Enabled = false;
                btnImportar.Visible = false;
                listBoxPDF.Visible = false;
                bunifuCheckBox1.Visible = false;
                #endregion

                timer1.Start();
            }

            if (verificacao == "nao")
            {
                enviaArquivos();
                new alerta(counter + " XML importados", alerta.AlertType.sucesso).Show();
                counter = 0;
                pdfPath = null;
                pdfPathFiles = null;
                listBoxPDF.Items.Clear();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            enviaArquivos();
            new alerta(counter + " XML importados", alerta.AlertType.sucesso).Show();
        }

        private void btnPararVerificacao_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            new alerta("Verificação Automática desabilitada", alerta.AlertType.info).Show();
            btnPararVerificacao.Enabled = false;
            counter = 0;
            #region //ativa botões
            btnPastaPDF.Enabled = true;
            btnPastaPDF.Visible = true;
            btnImportar.Enabled = true;
            btnImportar.Visible = true;
            btnSelecionarSaida.Enabled = true;
            btnSelecionarSaida.Visible = true;
            listBoxPDF.Visible = true;
            bunifuCheckBox1.Visible = true;
            #endregion
            pdfPath = null;
            pdfPathFiles = null;
            listBoxPDF.Items.Clear();
            bunifuCheckBox1.Checked = false;
        }

        public  void montarPasta()
        {
            pdfPathFiles = Directory.GetFiles(pdfPath, "*.pdf").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
        }

        private void enviaArquivos()
        {
            montarPasta();
            //Ponteiro a cada pdf encontrado no diretorio
            foreach (string pdf in pdfPathFiles)
            {
                Documentos _documentos = new Documentos();
                _documentos.nomeDocumento = pdf;
                _documentos.url = url + pdf + ".pdf"; //salvar como variavel "extenção" mais pra frente
                _documentos.data = DateTime.Now.ToString();
                //dividir nome de cada pdf por "_"
                string[] parametros = pdf.Split(new string[] { "_" }, StringSplitOptions.None); //separa linha por _ e salva cada parametro em array
                int i = 0;
                    foreach (string param in parametros)
                    {
                        _documentos.SetIndice(i, param);
                        i++;
                    }
                DocumentosDAO.Insert(_documentos);
            }
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void Page1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuCheckBox1.Checked)
            {
                
                //Se algum for igual a VAZIO faça
                if (Settings.Default.standardPdfPath == "" || Settings.Default.standardXmlPath == "" || Settings.Default.standardOutputPath == "")
                {
                    new alerta("Caminho padrão VAZIO", alerta.AlertType.info).Show();
                    bunifuCheckBox1.Checked = false;
                    return;
                }
                else
                {

                }

                txtAtivado.Text = "ATIVADO";

                //Função do botão PDF usando padrão
                btnPastaPDF.Visible = false;
                pdfPath = Settings.Default["standardPdfPath"].ToString();
                pdfPathFiles = Directory.GetFiles(pdfPath, "*.pdf").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
                foreach (string arq in pdfPathFiles)
                {
                    listBoxPDF.Items.Add(arq);
                }

                //Função do botão SAIDA usando padrão
                btnSelecionarSaida.Visible = false;
                outputPath = Settings.Default["standardOutputPath"].ToString();

                //Ativa aviso que a função do botão está em padrão
                txtPdfPadrao.Visible = true;
                txtSaidaPadrao.Visible = true;
            }
            else
            {
                txtAtivado.Text = "DESATIVADO";
                //retorna tudo ao padrão
                btnPastaPDF.Visible = true;
                btnSelecionarSaida.Visible = true;
                pdfPath = null;
                pdfPathFiles = null;
                listBoxPDF.Items.Clear();
                txtPdfPadrao.Visible = false;
                txtSaidaPadrao.Visible = false;

            
            } 

        } 

        private void btnSelecionarSaida_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                outputPath = dialog.FileName;
            }

            listBoxImportado.Items.Clear();
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
