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

        public Page1()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Page1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

        }

        private void ImportarPlanilha_Dados()
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        //BOTAO SELECIONAR PDF
        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
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
                    listBox2.Items.Add(arq);
                }
            }

            listBox3.Items.Clear();
        }

        //BOTAO SELECIONAR XML
        private void bunifuThinButton21_Click(object sender, EventArgs e)
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
                    ListBox1.Items.Add(arq);
                }
            }
            listBox3.Items.Clear();
        }

        private void txtArquivo_TextChange(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           
        }
         
        private void InserirPlanilhaImage_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void InserirPlanilhaImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void bunifuThinButton21_Click_2(object sender, EventArgs e)
        {
            int counter = 0;

            // if campo pdf for igual a nulo => tratamento de erro alerta.atencao "escolher caminho pdf"
            if (pdfPathFiles == null)
            {
                new alerta("Esqueceu de selecionar PASTA PDF", alerta.AlertType.atencao).Show();
                return;
            }
            // if campo xml for igual a nulo => tratamento de erro alerta.atencao "escolher caminho xml"
            if (xmlPathFiles == null)
            {
                new alerta("Esqueceu de selecionar PASTA XML", alerta.AlertType.atencao).Show();
                return;
            }

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
                        listBox3.Items.Add(result + ".pdf");
                        listBox3.Items.Add(arq2);

                        //Renomeia PDF original
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(pdfPath + "\\" + arq + ".pdf", result + ".pdf");
                        //Limpa verificação
                        result = null;
                        result2 = null;
                        counter += 1;
                    }

                }
                
                ListBox1.Items.Clear();
                listBox2.Items.Clear();
            }
            // N xmls importados
            new alerta(counter + " XML importados", alerta.AlertType.sucesso).Show();
            pdfPathFiles = null;
            xmlPathFiles = null;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
