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

namespace InforPlan
{
    public partial class Page1 : UserControl
    {
        //variaveis globais (acessadas por mais de um metodo)
        String[] planilhaConteudo;
        Planilha _planilha = new Planilha(); 

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

        //BOTAO SELECIONAR PLANILHA
        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //Se abrir caixa dialogo foi  OK
            {
                planilhaConteudo = File.ReadAllLines(openFileDialog1.FileName); //preenche array por linhas txt
                txtArquivo.Text = String.Join("\n", planilhaConteudo); //apresentar linhas carregadas
            }


            ListBox1.Items.Clear();
        }

        //BOTAO IMPORTAR PLANILA
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (txtArquivo != null)
            {
               // goto continua;
            }
            else
            {
                MessageBox.Show("Selecione o Arquivo");
                return;
            }
            //continua:
            foreach (string line in planilhaConteudo) //foreach => laço que percorre linhas do array, Cada linha = novo objeto planilha
            {
                string[] parametros = line.Split(new string[] { ";" }, StringSplitOptions.None); //separa linha por ; e salva cada parametro em array
                _planilha.Data = parametros[0].ToString();
                _planilha.Filial = parametros[1].ToString();
                _planilha.Ano = parametros[2].ToString();           //preenche membros do objeto com cada unidade de array
                _planilha.Caixa = parametros[3].ToString();
                _planilha.Protocolo = parametros[4].ToString();
                PlanilhaDAO.Insert(_planilha);                      //Insere o objeto  no banco
                ListBox1.Items.Add(_planilha.Data + _planilha.Filial + _planilha.Ano + _planilha.Caixa + _planilha.Protocolo); //preenche ListBox
            }
        }  
    }
}
