using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlFinder
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            homePage1.BringToFront();
        }
        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            page11.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            page21.BringToFront();
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            page41.BringToFront();
        }

        private void bunifuCards2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            homePage1.BringToFront();
        }

        private void homePage1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            pageConfigSelect1.BringToFront();
            //page31.BringToFront(); pagina de configurar pagina padrao do XML
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            page41.BringToFront();
        }

        private void page41_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            pagePdfReader2.BringToFront();
        }

        private void pagePdfReader2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            pageBarcodeReader1.BringToFront();
        }

        private void pageBarcodeReader1_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void pageConfigSelect1_Load(object sender, EventArgs e)
        {

        }


        //TESTE RETANGULO sobre imagem
        //Futuramente pegar a area do OCR e salvar o retangulo

        Rectangle rect = new Rectangle(125, 125, 50, 50);
        bool isMouseDown = false;

        //att
        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), rect);
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                rect.Location = e.Location;

                if (rect.Right > pictureBox1.Width)
                {
                    rect.X = pictureBox1.Width - rect.Width;
                }
                if (rect.Top < 0)
                {
                    rect.Y = 0;
                }
                if (rect.Left < 0)
                {
                    rect.X = 0;
                }
                if (rect.Bottom > pictureBox1.Height)
                {
                    rect.Y = pictureBox1.Height - rect.Height;
                }
                Refresh();
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }
}
