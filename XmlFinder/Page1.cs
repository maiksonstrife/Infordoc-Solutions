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
        String[] xmlPathFiles;
        String pdfPath;
        String xmlPath;
        String outputPath;
        String result = null;
        String result2 = null;
        String verificacao = null;
        int counter = 0;

        public Page1()
        {
            InitializeComponent();
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

        private void btnPastaXML_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                listBoxXML.Items.Clear();
                xmlPath = dialog.FileName;
                xmlPathFiles = Directory.GetFiles(xmlPath, "*.XML").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray(); 
                foreach (string arq in xmlPathFiles)
                {
                    listBoxXML.Items.Add(arq);
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
            //Verifica XML
            if (xmlPathFiles == null)
            {
                new alerta("Esqueceu de selecionar PASTA XML", alerta.AlertType.atencao).Show();
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
                btnPastaXML.Enabled = false;
                btnPastaXML.Visible = false;
                btnSelecionarSaida.Enabled = false;
                btnSelecionarSaida.Visible = false;
                btnImportar.Enabled = false;
                btnImportar.Visible = false;
                listBoxPDF.Visible = false;
                listBoxXML.Visible = false;
                bunifuCheckBox1.Visible = false;
                #endregion

                timer1.Start();
            }

            if (verificacao == "nao")
            {
                ComparaArquivos();
                new alerta(counter + " XML importados", alerta.AlertType.sucesso).Show();
                counter = 0;
                pdfPath = null;
                xmlPath = null;
                pdfPathFiles = null;
                xmlPathFiles = null;
                listBoxPDF.Items.Clear();
                listBoxXML.Items.Clear();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            ComparaArquivos();
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
            btnPastaXML.Enabled = true;
            btnPastaXML.Visible = true;
            btnImportar.Enabled = true;
            btnImportar.Visible = true;
            btnSelecionarSaida.Enabled = true;
            btnSelecionarSaida.Visible = true;
            listBoxPDF.Visible = true;
            listBoxXML.Visible = true;
            bunifuCheckBox1.Visible = true;
            #endregion
            pdfPath = null;
            xmlPath = null;
            pdfPathFiles = null;
            xmlPathFiles = null;
            listBoxPDF.Items.Clear();
            listBoxXML.Items.Clear();
            bunifuCheckBox1.Checked = false;
        }

        public  void montarPasta()
        {
            pdfPathFiles = Directory.GetFiles(pdfPath, "*.pdf").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
            xmlPathFiles = Directory.GetFiles(xmlPath, "*.XML").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
        }

        private void ComparaArquivos()
        {
            result = null;
            result2 = null;
            montarPasta();
            foreach (string arq in pdfPathFiles)
            {

                foreach (string arq2 in xmlPathFiles)
                {
                    //Remove caracteres depois de espaço do pdf =>arq
                    if (arq.Contains(' '))
                    {
                        int index = arq.IndexOf(' '); // index = pega indice a partir da ocorrencia do caractere
                        result = arq.Substring(0, index); //inicio da cadeia, fim da cadeia
                    }
                    else
                    {
                        result = arq;
                    }

                    //Remove caracteres antes da chave => 'NFe' =>arq2
                    if (arq2.Contains("NFe"))
                    {
                        result2 = arq2.Remove(0, 3);
                    }
                    else
                    {
                        result2 = arq2;
                    }

                    //Se nome pdf for igual xml copia para pasta pdf
                    if (!string.IsNullOrEmpty(result) && result.Equals(result2)) //!string converte pra boolean 
                    {
                        //Caminhos Original e pasta de Saída
                        string origemXml = xmlPath + "\\" + arq2 + ".xml";
                        string destinoXml = outputPath + "\\" + arq2 + ".xml";

                        string origemPdf = pdfPath + "\\" + arq + ".pdf";
                        string destinoPdf = outputPath + "\\" + arq + ".pdf";

                        //Movendo XML
                        if (File.Exists(destinoXml))
                        {
                            File.Delete(destinoXml);
                            File.Move(origemXml, destinoXml);
                        }
                        else
                        {
                            File.Move(origemXml, destinoXml);
                        }

                        //Movendo PDF
                        if (File.Exists(destinoPdf))
                        {
                            File.Delete(destinoPdf);
                            File.Move(origemPdf, destinoPdf);
                        }
                        else
                        {
                            File.Move(origemPdf, destinoPdf);
                        }

                        //Verifica se já existe nome igual ao renomear
                        string pdfRenomeado = "NFe" + result + ".pdf";

                        if (File.Exists(outputPath + "\\" + pdfRenomeado))
                        {
                            File.Delete(outputPath + "\\" + pdfRenomeado);
                            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(outputPath + "\\" + arq + ".pdf", pdfRenomeado);
                        }
                        else
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(outputPath + "\\" + arq + ".pdf", pdfRenomeado);
                        }
                        
                        //Adicionando a lista
                        listBoxImportado.Items.Add(result + ".pdf");
                        listBoxImportado.Items.Add(arq2 + ".xml");

                        //Limpa verificação
                        counter += 1;
                        break;
                    }
                }

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

                //Função do botão XML usando padrão
                btnPastaXML.Visible = false;
                xmlPath = Settings.Default["standardXmlPath"].ToString();
                xmlPathFiles = Directory.GetFiles(xmlPath, "*.XML").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
                foreach (string arq in xmlPathFiles)
                {
                    listBoxXML.Items.Add(arq);
                }

                //Função do botão SAIDA usando padrão
                btnSelecionarSaida.Visible = false;
                outputPath = Settings.Default["standardOutputPath"].ToString();

                //Ativa aviso que a função do botão está em padrão
                txtPdfPadrao.Visible = true;
                txtXmlPadrao.Visible = true;
                txtSaidaPadrao.Visible = true;
            }
            else
            {
                txtAtivado.Text = "DESATIVADO";
                //retorna tudo ao padrão
                btnPastaPDF.Visible = true;
                btnPastaXML.Visible = true;
                btnSelecionarSaida.Visible = true;
                pdfPath = null;
                xmlPath = null;
                pdfPathFiles = null;
                xmlPathFiles = null;
                listBoxPDF.Items.Clear();
                listBoxXML.Items.Clear();
                txtPdfPadrao.Visible = false;
                txtXmlPadrao.Visible = false;
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
    }
}
