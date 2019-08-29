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

namespace InforPlan
{
    public partial class Page1 : UserControl
    {
        //variaveis globais (acessadas por mais de um metodo)
        String[] pdfPathFiles;
        String[] xmlPathFiles;
        String pdfPath;
        String xmlPath;
        String result = null;
        String result2 = null;
        String verificacao = null;
        bool isPressed = false;
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
                xmlPath = dialog.FileName;
                xmlPathFiles = Directory.GetFiles(xmlPath, "*.XML").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray(); ;
                foreach (string arq in xmlPathFiles)
                {
                    listBoxXML.Items.Add(arq);
                }
            }
            listBoxImportado.Items.Clear();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            #region //verifica campo PDF
            if (pdfPathFiles == null)
            {
                new alerta("Esqueceu de selecionar PASTA PDF", alerta.AlertType.atencao).Show();
                return;
            }
            //Verifica Campo XML
            if (xmlPathFiles == null)
            {
                new alerta("Esqueceu de selecionar PASTA XML", alerta.AlertType.atencao).Show();
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
                timer1.Start();
            }

            if (verificacao == "nao")
            {
                ComparaArquivos();
                // N xmls importados
                pdfPathFiles = null;
                xmlPathFiles = null;
                counter = 0;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPararVerificacao.Enabled = true;
            btnPararVerificacao.Update();
            ComparaArquivos();
        }

        private void btnPararVerificacao_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            new alerta("Verificação Automática desabilitada", alerta.AlertType.info).Show();
        }

        private void ComparaArquivos()
        {
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

                    //Remove caracteres antes da chave => 'NFe' =>arq2
                    if (arq2.Contains("NFe"))
                    {
                        result2 = arq2.Remove(0, 3);
                    }

                    //Se nome pdf for igual xml copia para pasta pdf
                    if (!string.IsNullOrEmpty(result) && result.Equals(result2)) //!string converte pra boolean 
                    {
                        string origem = xmlPath + "\\" + arq2 + ".xml";
                        string destino = pdfPath + "\\" + arq2 + ".xml";
                        File.Move(origem, destino);
                        listBoxImportado.Items.Add(result + ".pdf");
                        listBoxImportado.Items.Add(arq2 + ".xml");

                        //Renomeia PDF original
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(pdfPath + "\\" + arq + ".pdf", "NFe" + result + ".pdf");
                        //Limpa verificação
                        counter += 1;
                        new alerta(counter + " XML importados", alerta.AlertType.sucesso).Show();
                    }
                }
            }
        }

    }
}
