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
    public partial class Alerta1 : Form
    {
        #region //Readme
        /*Chama classe =>             using (Alerta1 _verificacao = new Alerta1())
            {
                _verificacao.ShowDialog();
                verificacao = _verificacao.resposta;
            }
        */
        #endregion

        public String resposta;

        public Alerta1()
        {
            InitializeComponent();

        }

        private void alerta_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void timeout_Tick(object sender, EventArgs e)
        {

        }


        private void show_Tick(object sender, EventArgs e)
        {

        }

        private void close_Tick(object sender, EventArgs e)
        {

        }

        private void icon_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            //retorna sim
            resposta = "sim";
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            //retorna não
            resposta = "nao";
            this.Close();
        }
    }
}
