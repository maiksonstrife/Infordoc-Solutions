using System;
using System.ComponentModel;

namespace InforPlan
{
    partial class Page1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page1));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnImportarPlanilha = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnSelecionaPlanilha = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.isPressedButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPastaPDF = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnPastaXML = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnImportar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.listBoxPDF = new System.Windows.Forms.ListBox();
            this.listBoxXML = new System.Windows.Forms.ListBox();
            this.listBoxImportado = new System.Windows.Forms.ListBox();
            this.btnPararVerificacao = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(100, 23);
            this.bunifuCustomLabel1.TabIndex = 0;
            // 
            // ListBox1
            // 
            this.ListBox1.Location = new System.Drawing.Point(0, 0);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(120, 95);
            this.ListBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnImportarPlanilha
            // 
            this.btnImportarPlanilha.ActiveBorderThickness = 1;
            this.btnImportarPlanilha.ActiveCornerRadius = 20;
            this.btnImportarPlanilha.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnImportarPlanilha.ActiveForecolor = System.Drawing.Color.White;
            this.btnImportarPlanilha.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnImportarPlanilha.BackColor = System.Drawing.Color.White;
            this.btnImportarPlanilha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportarPlanilha.BackgroundImage")));
            this.btnImportarPlanilha.ButtonText = "ThinButton";
            this.btnImportarPlanilha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportarPlanilha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarPlanilha.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnImportarPlanilha.IdleBorderThickness = 1;
            this.btnImportarPlanilha.IdleCornerRadius = 20;
            this.btnImportarPlanilha.IdleFillColor = System.Drawing.Color.White;
            this.btnImportarPlanilha.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnImportarPlanilha.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnImportarPlanilha.Location = new System.Drawing.Point(0, 0);
            this.btnImportarPlanilha.Margin = new System.Windows.Forms.Padding(5);
            this.btnImportarPlanilha.Name = "btnImportarPlanilha";
            this.btnImportarPlanilha.Size = new System.Drawing.Size(181, 41);
            this.btnImportarPlanilha.TabIndex = 0;
            this.btnImportarPlanilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelecionaPlanilha
            // 
            this.btnSelecionaPlanilha.ActiveBorderThickness = 1;
            this.btnSelecionaPlanilha.ActiveCornerRadius = 20;
            this.btnSelecionaPlanilha.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnSelecionaPlanilha.ActiveForecolor = System.Drawing.Color.White;
            this.btnSelecionaPlanilha.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnSelecionaPlanilha.BackColor = System.Drawing.Color.White;
            this.btnSelecionaPlanilha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecionaPlanilha.BackgroundImage")));
            this.btnSelecionaPlanilha.ButtonText = "ThinButton";
            this.btnSelecionaPlanilha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionaPlanilha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionaPlanilha.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSelecionaPlanilha.IdleBorderThickness = 1;
            this.btnSelecionaPlanilha.IdleCornerRadius = 20;
            this.btnSelecionaPlanilha.IdleFillColor = System.Drawing.Color.White;
            this.btnSelecionaPlanilha.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnSelecionaPlanilha.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnSelecionaPlanilha.Location = new System.Drawing.Point(0, 0);
            this.btnSelecionaPlanilha.Margin = new System.Windows.Forms.Padding(5);
            this.btnSelecionaPlanilha.Name = "btnSelecionaPlanilha";
            this.btnSelecionaPlanilha.Size = new System.Drawing.Size(181, 41);
            this.btnSelecionaPlanilha.TabIndex = 0;
            this.btnSelecionaPlanilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // listBox2
            // 
            this.listBox2.Location = new System.Drawing.Point(0, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 0;
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.BackColor = System.Drawing.Color.White;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "ThinButton";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.Location = new System.Drawing.Point(0, 0);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(181, 41);
            this.bunifuThinButton21.TabIndex = 0;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox3
            // 
            this.listBox3.Location = new System.Drawing.Point(0, 0);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 95);
            this.listBox3.TabIndex = 0;
            // 
            // isPressedButton
            // 
            this.isPressedButton.BackColor = System.Drawing.Color.Transparent;
            this.isPressedButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("isPressedButton.BackgroundImage")));
            this.isPressedButton.ButtonText = "Bunifu Button";
            this.isPressedButton.ButtonTextMarginLeft = 0;
            this.isPressedButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.isPressedButton.DisabledFillColor = System.Drawing.Color.Gray;
            this.isPressedButton.DisabledForecolor = System.Drawing.Color.White;
            this.isPressedButton.ForeColor = System.Drawing.Color.White;
            this.isPressedButton.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.isPressedButton.IconPadding = 10;
            this.isPressedButton.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.isPressedButton.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.isPressedButton.IdleBorderRadius = 1;
            this.isPressedButton.IdleBorderThickness = 0;
            this.isPressedButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.isPressedButton.IdleIconLeftImage = null;
            this.isPressedButton.IdleIconRightImage = null;
            this.isPressedButton.Location = new System.Drawing.Point(0, 0);
            this.isPressedButton.Name = "isPressedButton";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties1.BorderRadius = 1;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.isPressedButton.onHoverState = stateProperties1;
            this.isPressedButton.Size = new System.Drawing.Size(210, 45);
            this.isPressedButton.TabIndex = 0;
            this.isPressedButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnPastaPDF
            // 
            this.btnPastaPDF.ActiveBorderThickness = 1;
            this.btnPastaPDF.ActiveCornerRadius = 20;
            this.btnPastaPDF.ActiveFillColor = System.Drawing.Color.Red;
            this.btnPastaPDF.ActiveForecolor = System.Drawing.Color.White;
            this.btnPastaPDF.ActiveLineColor = System.Drawing.Color.Red;
            this.btnPastaPDF.BackColor = System.Drawing.SystemColors.Control;
            this.btnPastaPDF.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPastaPDF.BackgroundImage")));
            this.btnPastaPDF.ButtonText = "Selecionar Pasta PDF";
            this.btnPastaPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPastaPDF.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPastaPDF.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPastaPDF.IdleBorderThickness = 1;
            this.btnPastaPDF.IdleCornerRadius = 20;
            this.btnPastaPDF.IdleFillColor = System.Drawing.Color.Crimson;
            this.btnPastaPDF.IdleForecolor = System.Drawing.Color.White;
            this.btnPastaPDF.IdleLineColor = System.Drawing.Color.Crimson;
            this.btnPastaPDF.Location = new System.Drawing.Point(14, 58);
            this.btnPastaPDF.Margin = new System.Windows.Forms.Padding(5);
            this.btnPastaPDF.Name = "btnPastaPDF";
            this.btnPastaPDF.Size = new System.Drawing.Size(219, 41);
            this.btnPastaPDF.TabIndex = 0;
            this.btnPastaPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPastaPDF.Click += new System.EventHandler(this.btnPastaPDF_Click);
            // 
            // btnPastaXML
            // 
            this.btnPastaXML.ActiveBorderThickness = 1;
            this.btnPastaXML.ActiveCornerRadius = 20;
            this.btnPastaXML.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPastaXML.ActiveForecolor = System.Drawing.Color.White;
            this.btnPastaXML.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPastaXML.BackColor = System.Drawing.SystemColors.Control;
            this.btnPastaXML.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPastaXML.BackgroundImage")));
            this.btnPastaXML.ButtonText = "Selecionar Pasta XML";
            this.btnPastaXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPastaXML.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPastaXML.ForeColor = System.Drawing.Color.White;
            this.btnPastaXML.IdleBorderThickness = 1;
            this.btnPastaXML.IdleCornerRadius = 20;
            this.btnPastaXML.IdleFillColor = System.Drawing.Color.SeaGreen;
            this.btnPastaXML.IdleForecolor = System.Drawing.Color.White;
            this.btnPastaXML.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnPastaXML.Location = new System.Drawing.Point(332, 58);
            this.btnPastaXML.Margin = new System.Windows.Forms.Padding(5);
            this.btnPastaXML.Name = "btnPastaXML";
            this.btnPastaXML.Size = new System.Drawing.Size(219, 41);
            this.btnPastaXML.TabIndex = 1;
            this.btnPastaXML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPastaXML.Click += new System.EventHandler(this.btnPastaXML_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.ActiveBorderThickness = 1;
            this.btnImportar.ActiveCornerRadius = 20;
            this.btnImportar.ActiveFillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnImportar.ActiveForecolor = System.Drawing.Color.White;
            this.btnImportar.ActiveLineColor = System.Drawing.Color.DeepSkyBlue;
            this.btnImportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.ButtonText = "IMPORTAR";
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.IdleBorderThickness = 1;
            this.btnImportar.IdleCornerRadius = 20;
            this.btnImportar.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnImportar.IdleForecolor = System.Drawing.Color.White;
            this.btnImportar.IdleLineColor = System.Drawing.Color.DodgerBlue;
            this.btnImportar.Location = new System.Drawing.Point(650, 58);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(5);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(219, 41);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // listBoxPDF
            // 
            this.listBoxPDF.FormattingEnabled = true;
            this.listBoxPDF.Location = new System.Drawing.Point(14, 117);
            this.listBoxPDF.Name = "listBoxPDF";
            this.listBoxPDF.Size = new System.Drawing.Size(219, 277);
            this.listBoxPDF.TabIndex = 3;
            // 
            // listBoxXML
            // 
            this.listBoxXML.FormattingEnabled = true;
            this.listBoxXML.Location = new System.Drawing.Point(332, 117);
            this.listBoxXML.Name = "listBoxXML";
            this.listBoxXML.Size = new System.Drawing.Size(219, 277);
            this.listBoxXML.TabIndex = 4;
            // 
            // listBoxImportado
            // 
            this.listBoxImportado.FormattingEnabled = true;
            this.listBoxImportado.Location = new System.Drawing.Point(650, 117);
            this.listBoxImportado.Name = "listBoxImportado";
            this.listBoxImportado.Size = new System.Drawing.Size(219, 277);
            this.listBoxImportado.TabIndex = 5;
            // 
            // btnPararVerificacao
            // 
            this.btnPararVerificacao.Active = false;
            this.btnPararVerificacao.Activecolor = System.Drawing.Color.Red;
            this.btnPararVerificacao.BackColor = System.Drawing.Color.Crimson;
            this.btnPararVerificacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPararVerificacao.BorderRadius = 0;
            this.btnPararVerificacao.ButtonText = "Parar";
            this.btnPararVerificacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPararVerificacao.DisabledColor = System.Drawing.Color.Gray;
            this.btnPararVerificacao.Enabled = false;
            this.btnPararVerificacao.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPararVerificacao.Iconimage = null;
            this.btnPararVerificacao.Iconimage_right = null;
            this.btnPararVerificacao.Iconimage_right_Selected = null;
            this.btnPararVerificacao.Iconimage_Selected = null;
            this.btnPararVerificacao.IconMarginLeft = 0;
            this.btnPararVerificacao.IconMarginRight = 0;
            this.btnPararVerificacao.IconRightVisible = true;
            this.btnPararVerificacao.IconRightZoom = 0D;
            this.btnPararVerificacao.IconVisible = true;
            this.btnPararVerificacao.IconZoom = 90D;
            this.btnPararVerificacao.IsTab = false;
            this.btnPararVerificacao.Location = new System.Drawing.Point(615, 480);
            this.btnPararVerificacao.Name = "btnPararVerificacao";
            this.btnPararVerificacao.Normalcolor = System.Drawing.Color.Crimson;
            this.btnPararVerificacao.OnHovercolor = System.Drawing.Color.Crimson;
            this.btnPararVerificacao.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPararVerificacao.selected = false;
            this.btnPararVerificacao.Size = new System.Drawing.Size(252, 23);
            this.btnPararVerificacao.TabIndex = 6;
            this.btnPararVerificacao.Text = "Parar";
            this.btnPararVerificacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPararVerificacao.Textcolor = System.Drawing.Color.White;
            this.btnPararVerificacao.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPararVerificacao.Click += new System.EventHandler(this.btnPararVerificacao_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(543, 444);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 65);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(612, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parar Verificação Automática";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F);
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(3, 0);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(148, 28);
            this.bunifuCustomLabel2.TabIndex = 9;
            this.bunifuCustomLabel2.Text = "Encontrar XML";
            this.bunifuCustomLabel2.Click += new System.EventHandler(this.bunifuCustomLabel2_Click);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F);
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(41, 247);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(132, 28);
            this.bunifuCustomLabel3.TabIndex = 10;
            this.bunifuCustomLabel3.Text = "Verificando...";
            this.bunifuCustomLabel3.Click += new System.EventHandler(this.bunifuCustomLabel3_Click);
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F);
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(375, 247);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(132, 28);
            this.bunifuCustomLabel4.TabIndex = 11;
            this.bunifuCustomLabel4.Text = "Verificando...";
            // 
            // Page1
            // 
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnPararVerificacao);
            this.Controls.Add(this.listBoxImportado);
            this.Controls.Add(this.listBoxXML);
            this.Controls.Add(this.listBoxPDF);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnPastaXML);
            this.Controls.Add(this.btnPastaPDF);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Name = "Page1";
            this.Size = new System.Drawing.Size(888, 535);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Bunifu.Framework.UI.BunifuThinButton2 btnImportarPlanilha;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSelecionaPlanilha;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.ListBox listBox2;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private System.Windows.Forms.ListBox listBox3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton isPressedButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnPastaPDF;
        private Bunifu.Framework.UI.BunifuThinButton2 btnPastaXML;
        private Bunifu.Framework.UI.BunifuThinButton2 btnImportar;
        private System.Windows.Forms.ListBox listBoxPDF;
        private System.Windows.Forms.ListBox listBoxXML;
        private System.Windows.Forms.ListBox listBoxImportado;
        private Bunifu.Framework.UI.BunifuFlatButton btnPararVerificacao;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
    }
}
