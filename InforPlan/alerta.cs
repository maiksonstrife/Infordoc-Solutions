using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InforPlan
{
    #region //Readme
    // chamar classe => new alerta("Esqueceu de selecionar PASTA XML", alerta.AlertType.atencao).Show();
    #endregion

    public partial class alerta : Form
    {
        public alerta(string _message, AlertType type)
        {
            InitializeComponent();

            message.Text = _message;
            switch (type) {
                case AlertType.sucesso:
                    this.BackColor = Color.SeaGreen;
                    icon.Image = imageList1.Images[0];
                    break;
                case AlertType.info:
                    this.BackColor = Color.Gray;
                    icon.Image = imageList1.Images[1];
                    break;
                case AlertType.atencao:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    icon.Image = imageList1.Images[2];
                    break;
                case AlertType.erro:
                    this.BackColor = Color.Crimson;
                    icon.Image = imageList1.Images[3];
                    break;
            }

        }


        public enum AlertType
        {
            sucesso, info, atencao, erro,
        }

        private void alerta_Load(object sender, EventArgs e)
        {
            this.Top = 60;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            closealert.Start();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        int interval = 0;
        private void show_Tick(object sender, EventArgs e)
        {
            if (this.Top < 60)
            {
                this.Top += interval; //drop the alert
                interval += 2; //double the speed
            }
            else
            {
                show.Stop();
            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity-=0.1;
            }
            else
            {
                this.Close();
            }
        }
    }
}
