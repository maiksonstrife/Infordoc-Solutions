namespace XmlFinder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.sideBar = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuFlatButton6 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton5 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton4 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton3 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.homeButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.topBar = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.minimizeButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.closeButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pagePdfReader1 = new XmlFinder.PagePdfReader();
            this.pageConfigSelect1 = new XmlFinder.PageConfigSelect();
            this.pageBarcodeReader1 = new XmlFinder.PageBarcodeReader();
            this.pagePdfReader2 = new XmlFinder.PagePdfReader();
            this.homePage1 = new XmlFinder.homePage();
            this.page12 = new XmlFinder.Page1();
            this.page41 = new XmlFinder.Page4();
            this.page31 = new XmlFinder.Page3();
            this.page21 = new XmlFinder.Page2();
            this.page11 = new XmlFinder.Page1();
            this.panel2.SuspendLayout();
            this.sideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pageConfigSelect1);
            this.panel2.Controls.Add(this.pageBarcodeReader1);
            this.panel2.Controls.Add(this.pagePdfReader2);
            this.panel2.Controls.Add(this.homePage1);
            this.panel2.Controls.Add(this.page12);
            this.panel2.Controls.Add(this.page41);
            this.panel2.Controls.Add(this.page31);
            this.panel2.Controls.Add(this.page21);
            this.panel2.Controls.Add(this.page11);
            this.panel2.Location = new System.Drawing.Point(202, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 563);
            this.panel2.TabIndex = 9;
            // 
            // sideBar
            // 
            this.sideBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sideBar.BackgroundImage")));
            this.sideBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sideBar.Controls.Add(this.bunifuFlatButton6);
            this.sideBar.Controls.Add(this.bunifuFlatButton5);
            this.sideBar.Controls.Add(this.pagePdfReader1);
            this.sideBar.Controls.Add(this.bunifuFlatButton4);
            this.sideBar.Controls.Add(this.bunifuFlatButton3);
            this.sideBar.Controls.Add(this.homeButton);
            this.sideBar.Controls.Add(this.pictureBox1);
            this.sideBar.Controls.Add(this.bunifuFlatButton2);
            this.sideBar.Controls.Add(this.bunifuFlatButton1);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.GradientBottomLeft = System.Drawing.Color.DarkBlue;
            this.sideBar.GradientBottomRight = System.Drawing.Color.DimGray;
            this.sideBar.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sideBar.GradientTopRight = System.Drawing.Color.Cyan;
            this.sideBar.Location = new System.Drawing.Point(0, 0);
            this.sideBar.Name = "sideBar";
            this.sideBar.Quality = 10;
            this.sideBar.Size = new System.Drawing.Size(202, 603);
            this.sideBar.TabIndex = 0;
            // 
            // bunifuFlatButton6
            // 
            this.bunifuFlatButton6.Active = false;
            this.bunifuFlatButton6.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(153)))));
            this.bunifuFlatButton6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton6.BorderRadius = 0;
            this.bunifuFlatButton6.ButtonText = "Virtual Scanner";
            this.bunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton6.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton6.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton6.Iconimage")));
            this.bunifuFlatButton6.Iconimage_right = null;
            this.bunifuFlatButton6.Iconimage_right_Selected = null;
            this.bunifuFlatButton6.Iconimage_Selected = null;
            this.bunifuFlatButton6.IconMarginLeft = 0;
            this.bunifuFlatButton6.IconMarginRight = 0;
            this.bunifuFlatButton6.IconRightVisible = true;
            this.bunifuFlatButton6.IconRightZoom = 0D;
            this.bunifuFlatButton6.IconVisible = true;
            this.bunifuFlatButton6.IconZoom = 90D;
            this.bunifuFlatButton6.IsTab = true;
            this.bunifuFlatButton6.Location = new System.Drawing.Point(0, 343);
            this.bunifuFlatButton6.Name = "bunifuFlatButton6";
            this.bunifuFlatButton6.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton6.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(160)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton6.selected = false;
            this.bunifuFlatButton6.Size = new System.Drawing.Size(251, 48);
            this.bunifuFlatButton6.TabIndex = 10;
            this.bunifuFlatButton6.Text = "Virtual Scanner";
            this.bunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton6.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton6.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton6.Click += new System.EventHandler(this.bunifuFlatButton6_Click);
            // 
            // bunifuFlatButton5
            // 
            this.bunifuFlatButton5.Active = false;
            this.bunifuFlatButton5.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(153)))));
            this.bunifuFlatButton5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton5.BorderRadius = 0;
            this.bunifuFlatButton5.ButtonText = "Leitor Barcode";
            this.bunifuFlatButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton5.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton5.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton5.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton5.Iconimage")));
            this.bunifuFlatButton5.Iconimage_right = null;
            this.bunifuFlatButton5.Iconimage_right_Selected = null;
            this.bunifuFlatButton5.Iconimage_Selected = null;
            this.bunifuFlatButton5.IconMarginLeft = 0;
            this.bunifuFlatButton5.IconMarginRight = 0;
            this.bunifuFlatButton5.IconRightVisible = true;
            this.bunifuFlatButton5.IconRightZoom = 0D;
            this.bunifuFlatButton5.IconVisible = true;
            this.bunifuFlatButton5.IconZoom = 90D;
            this.bunifuFlatButton5.IsTab = true;
            this.bunifuFlatButton5.Location = new System.Drawing.Point(0, 407);
            this.bunifuFlatButton5.Name = "bunifuFlatButton5";
            this.bunifuFlatButton5.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton5.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(160)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton5.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton5.selected = false;
            this.bunifuFlatButton5.Size = new System.Drawing.Size(251, 48);
            this.bunifuFlatButton5.TabIndex = 9;
            this.bunifuFlatButton5.Text = "Leitor Barcode";
            this.bunifuFlatButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton5.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton5.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton5.Visible = false;
            this.bunifuFlatButton5.Click += new System.EventHandler(this.bunifuFlatButton5_Click);
            // 
            // bunifuFlatButton4
            // 
            this.bunifuFlatButton4.Active = false;
            this.bunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(153)))));
            this.bunifuFlatButton4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton4.BorderRadius = 0;
            this.bunifuFlatButton4.ButtonText = "Enviar para WEB";
            this.bunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton4.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton4.Iconimage")));
            this.bunifuFlatButton4.Iconimage_right = null;
            this.bunifuFlatButton4.Iconimage_right_Selected = null;
            this.bunifuFlatButton4.Iconimage_Selected = null;
            this.bunifuFlatButton4.IconMarginLeft = 0;
            this.bunifuFlatButton4.IconMarginRight = 0;
            this.bunifuFlatButton4.IconRightVisible = true;
            this.bunifuFlatButton4.IconRightZoom = 0D;
            this.bunifuFlatButton4.IconVisible = true;
            this.bunifuFlatButton4.IconZoom = 90D;
            this.bunifuFlatButton4.IsTab = true;
            this.bunifuFlatButton4.Location = new System.Drawing.Point(0, 296);
            this.bunifuFlatButton4.Name = "bunifuFlatButton4";
            this.bunifuFlatButton4.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(160)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton4.selected = false;
            this.bunifuFlatButton4.Size = new System.Drawing.Size(251, 48);
            this.bunifuFlatButton4.TabIndex = 7;
            this.bunifuFlatButton4.Text = "Enviar para WEB";
            this.bunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton4.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton4.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton4.Click += new System.EventHandler(this.bunifuFlatButton4_Click_1);
            // 
            // bunifuFlatButton3
            // 
            this.bunifuFlatButton3.Active = false;
            this.bunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(153)))));
            this.bunifuFlatButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton3.BorderRadius = 0;
            this.bunifuFlatButton3.ButtonText = "Configurações";
            this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton3.Iconimage")));
            this.bunifuFlatButton3.Iconimage_right = null;
            this.bunifuFlatButton3.Iconimage_right_Selected = null;
            this.bunifuFlatButton3.Iconimage_Selected = null;
            this.bunifuFlatButton3.IconMarginLeft = 0;
            this.bunifuFlatButton3.IconMarginRight = 0;
            this.bunifuFlatButton3.IconRightVisible = true;
            this.bunifuFlatButton3.IconRightZoom = 0D;
            this.bunifuFlatButton3.IconVisible = true;
            this.bunifuFlatButton3.IconZoom = 90D;
            this.bunifuFlatButton3.IsTab = true;
            this.bunifuFlatButton3.Location = new System.Drawing.Point(0, 555);
            this.bunifuFlatButton3.Name = "bunifuFlatButton3";
            this.bunifuFlatButton3.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(160)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton3.selected = false;
            this.bunifuFlatButton3.Size = new System.Drawing.Size(251, 48);
            this.bunifuFlatButton3.TabIndex = 6;
            this.bunifuFlatButton3.Text = "Configurações";
            this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton3.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton3.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton3.Click += new System.EventHandler(this.bunifuFlatButton3_Click_1);
            // 
            // homeButton
            // 
            this.homeButton.Active = true;
            this.homeButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(153)))));
            this.homeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(153)))));
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeButton.BorderRadius = 0;
            this.homeButton.ButtonText = "Home";
            this.homeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeButton.DisabledColor = System.Drawing.Color.Gray;
            this.homeButton.Iconcolor = System.Drawing.Color.Transparent;
            this.homeButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("homeButton.Iconimage")));
            this.homeButton.Iconimage_right = null;
            this.homeButton.Iconimage_right_Selected = null;
            this.homeButton.Iconimage_Selected = null;
            this.homeButton.IconMarginLeft = 0;
            this.homeButton.IconMarginRight = 0;
            this.homeButton.IconRightVisible = true;
            this.homeButton.IconRightZoom = 0D;
            this.homeButton.IconVisible = true;
            this.homeButton.IconZoom = 90D;
            this.homeButton.IsTab = true;
            this.homeButton.Location = new System.Drawing.Point(0, 202);
            this.homeButton.Name = "homeButton";
            this.homeButton.Normalcolor = System.Drawing.Color.Transparent;
            this.homeButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(160)))), ((int)(((byte)(177)))));
            this.homeButton.OnHoverTextColor = System.Drawing.Color.White;
            this.homeButton.selected = true;
            this.homeButton.Size = new System.Drawing.Size(251, 48);
            this.homeButton.TabIndex = 5;
            this.homeButton.Text = "Home";
            this.homeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeButton.Textcolor = System.Drawing.Color.White;
            this.homeButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint_1);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown_1);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove_1);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp_1);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Active = false;
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(153)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "Exportar Planilha";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 90D;
            this.bunifuFlatButton2.IsTab = true;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(0, 461);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(160)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(251, 48);
            this.bunifuFlatButton2.TabIndex = 1;
            this.bunifuFlatButton2.Text = "Exportar Planilha";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Visible = false;
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Active = false;
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(153)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "Encontrar XML";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = true;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(0, 249);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(160)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(251, 48);
            this.bunifuFlatButton1.TabIndex = 0;
            this.bunifuFlatButton1.Text = "Encontrar XML";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.White;
            this.topBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topBar.Controls.Add(this.bunifuCustomLabel1);
            this.topBar.Controls.Add(this.minimizeButton);
            this.topBar.Controls.Add(this.closeButton);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(202, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(888, 46);
            this.topBar.TabIndex = 8;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI Emoji", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(5, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(324, 49);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "Infordoc Solutions";
            // 
            // minimizeButton
            // 
            this.minimizeButton.ActiveImage = null;
            this.minimizeButton.AllowAnimations = true;
            this.minimizeButton.AllowZooming = true;
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("minimizeButton.ErrorImage")));
            this.minimizeButton.FadeWhenInactive = false;
            this.minimizeButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.ImageActive = null;
            this.minimizeButton.ImageLocation = null;
            this.minimizeButton.ImageMargin = 40;
            this.minimizeButton.ImageSize = new System.Drawing.Size(36, 22);
            this.minimizeButton.ImageZoomSize = new System.Drawing.Size(76, 62);
            this.minimizeButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("minimizeButton.InitialImage")));
            this.minimizeButton.Location = new System.Drawing.Point(767, -6);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Rotation = 0;
            this.minimizeButton.ShowActiveImage = true;
            this.minimizeButton.ShowCursorChanges = true;
            this.minimizeButton.ShowImageBorders = true;
            this.minimizeButton.ShowSizeMarkers = true;
            this.minimizeButton.Size = new System.Drawing.Size(76, 62);
            this.minimizeButton.TabIndex = 7;
            this.minimizeButton.ToolTipText = "";
            this.minimizeButton.WaitOnLoad = false;
            this.minimizeButton.Zoom = 40;
            this.minimizeButton.ZoomSpeed = 10;
            this.minimizeButton.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // closeButton
            // 
            this.closeButton.ActiveImage = null;
            this.closeButton.AllowAnimations = true;
            this.closeButton.AllowZooming = true;
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("closeButton.ErrorImage")));
            this.closeButton.FadeWhenInactive = false;
            this.closeButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageActive = null;
            this.closeButton.ImageLocation = null;
            this.closeButton.ImageMargin = 40;
            this.closeButton.ImageSize = new System.Drawing.Size(36, 31);
            this.closeButton.ImageZoomSize = new System.Drawing.Size(76, 71);
            this.closeButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("closeButton.InitialImage")));
            this.closeButton.Location = new System.Drawing.Point(826, -15);
            this.closeButton.Name = "closeButton";
            this.closeButton.Rotation = 0;
            this.closeButton.ShowActiveImage = true;
            this.closeButton.ShowCursorChanges = true;
            this.closeButton.ShowImageBorders = true;
            this.closeButton.ShowSizeMarkers = true;
            this.closeButton.Size = new System.Drawing.Size(76, 71);
            this.closeButton.TabIndex = 6;
            this.closeButton.ToolTipText = "";
            this.closeButton.WaitOnLoad = false;
            this.closeButton.Zoom = 40;
            this.closeButton.ZoomSpeed = 10;
            this.closeButton.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 5;
            this.bunifuElipse2.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.topBar;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pagePdfReader1
            // 
            this.pagePdfReader1.Location = new System.Drawing.Point(214, 378);
            this.pagePdfReader1.Name = "pagePdfReader1";
            this.pagePdfReader1.Size = new System.Drawing.Size(728, 535);
            this.pagePdfReader1.TabIndex = 8;
            // 
            // pageConfigSelect1
            // 
            this.pageConfigSelect1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageConfigSelect1.AutoSize = true;
            this.pageConfigSelect1.BackColor = System.Drawing.Color.Indigo;
            this.pageConfigSelect1.Location = new System.Drawing.Point(0, 0);
            this.pageConfigSelect1.Name = "pageConfigSelect1";
            this.pageConfigSelect1.Size = new System.Drawing.Size(894, 569);
            this.pageConfigSelect1.TabIndex = 8;
            this.pageConfigSelect1.Load += new System.EventHandler(this.pageConfigSelect1_Load);
            // 
            // pageBarcodeReader1
            // 
            this.pageBarcodeReader1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageBarcodeReader1.Location = new System.Drawing.Point(0, 0);
            this.pageBarcodeReader1.Name = "pageBarcodeReader1";
            this.pageBarcodeReader1.Size = new System.Drawing.Size(888, 563);
            this.pageBarcodeReader1.TabIndex = 7;
            this.pageBarcodeReader1.Load += new System.EventHandler(this.pageBarcodeReader1_Load);
            // 
            // pagePdfReader2
            // 
            this.pagePdfReader2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pagePdfReader2.Location = new System.Drawing.Point(0, -16);
            this.pagePdfReader2.Name = "pagePdfReader2";
            this.pagePdfReader2.Size = new System.Drawing.Size(888, 563);
            this.pagePdfReader2.TabIndex = 6;
            this.pagePdfReader2.Load += new System.EventHandler(this.pagePdfReader2_Load);
            // 
            // homePage1
            // 
            this.homePage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homePage1.AutoScroll = true;
            this.homePage1.AutoSize = true;
            this.homePage1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.homePage1.Location = new System.Drawing.Point(0, 0);
            this.homePage1.Name = "homePage1";
            this.homePage1.Size = new System.Drawing.Size(891, 566);
            this.homePage1.TabIndex = 4;
            this.homePage1.Load += new System.EventHandler(this.homePage1_Load);
            // 
            // page12
            // 
            this.page12.AllowDrop = true;
            this.page12.AutoSize = true;
            this.page12.BackColor = System.Drawing.SystemColors.Control;
            this.page12.Location = new System.Drawing.Point(0, 0);
            this.page12.Name = "page12";
            this.page12.Size = new System.Drawing.Size(891, 566);
            this.page12.TabIndex = 5;
            // 
            // page41
            // 
            this.page41.BackColor = System.Drawing.SystemColors.Control;
            this.page41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page41.Location = new System.Drawing.Point(0, 0);
            this.page41.Name = "page41";
            this.page41.Size = new System.Drawing.Size(888, 563);
            this.page41.TabIndex = 3;
            this.page41.Load += new System.EventHandler(this.page41_Load);
            // 
            // page31
            // 
            this.page31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page31.Location = new System.Drawing.Point(0, 0);
            this.page31.Name = "page31";
            this.page31.Size = new System.Drawing.Size(888, 563);
            this.page31.TabIndex = 2;
            // 
            // page21
            // 
            this.page21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page21.Location = new System.Drawing.Point(0, 0);
            this.page21.Name = "page21";
            this.page21.Size = new System.Drawing.Size(888, 563);
            this.page21.TabIndex = 1;
            // 
            // page11
            // 
            this.page11.AllowDrop = true;
            this.page11.AutoSize = true;
            this.page11.BackColor = System.Drawing.SystemColors.Control;
            this.page11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page11.Location = new System.Drawing.Point(0, 0);
            this.page11.Name = "page11";
            this.page11.Size = new System.Drawing.Size(888, 563);
            this.page11.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 603);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.sideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private PageBarcodeReader pageBarcodeReader1;
        private PagePdfReader pagePdfReader2;
        private homePage homePage1;
        private Page1 page12;
        private Page4 page41;
        private Page3 page31;
        private Page2 page21;
        private Page1 page11;
        private Bunifu.Framework.UI.BunifuGradientPanel sideBar;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton6;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton5;
        private PagePdfReader pagePdfReader1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton4;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton3;
        private Bunifu.Framework.UI.BunifuFlatButton homeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.Panel topBar;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.UI.WinForms.BunifuImageButton minimizeButton;
        private Bunifu.UI.WinForms.BunifuImageButton closeButton;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        public System.Windows.Forms.Panel panel2;
        public PageConfigSelect pageConfigSelect1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}

