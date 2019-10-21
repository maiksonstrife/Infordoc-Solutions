namespace XmlFinder
{
    partial class PageBarcodeReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageBarcodeReader));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.CarregaOnloadRenomear = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAssinaturaVisivel = new System.Windows.Forms.Label();
            this.txtAssinar = new System.Windows.Forms.Label();
            this.txtMarcaDagua = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.Label();
            this.txtRecortar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCircleProgress1 = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CarregaOnloadRenomear
            // 
            this.CarregaOnloadRenomear.BackColor = System.Drawing.Color.Transparent;
            this.CarregaOnloadRenomear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CarregaOnloadRenomear.BackgroundImage")));
            this.CarregaOnloadRenomear.ButtonText = "Iniciar Scanner";
            this.CarregaOnloadRenomear.ButtonTextMarginLeft = 0;
            this.CarregaOnloadRenomear.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.CarregaOnloadRenomear.DisabledFillColor = System.Drawing.Color.Gray;
            this.CarregaOnloadRenomear.DisabledForecolor = System.Drawing.Color.White;
            this.CarregaOnloadRenomear.ForeColor = System.Drawing.Color.White;
            this.CarregaOnloadRenomear.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.CarregaOnloadRenomear.IconPadding = 10;
            this.CarregaOnloadRenomear.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.CarregaOnloadRenomear.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.CarregaOnloadRenomear.IdleBorderRadius = 1;
            this.CarregaOnloadRenomear.IdleBorderThickness = 0;
            this.CarregaOnloadRenomear.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.CarregaOnloadRenomear.IdleIconLeftImage = null;
            this.CarregaOnloadRenomear.IdleIconRightImage = null;
            this.CarregaOnloadRenomear.Location = new System.Drawing.Point(645, 492);
            this.CarregaOnloadRenomear.Name = "CarregaOnloadRenomear";
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.BorderRadius = 1;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.CarregaOnloadRenomear.onHoverState = stateProperties2;
            this.CarregaOnloadRenomear.Size = new System.Drawing.Size(218, 38);
            this.CarregaOnloadRenomear.TabIndex = 0;
            this.CarregaOnloadRenomear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CarregaOnloadRenomear.Click += new System.EventHandler(this.CarregaOnloadRenomear_Click);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.label6);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCircleProgress1);
            this.bunifuGradientPanel1.Controls.Add(this.label11);
            this.bunifuGradientPanel1.Controls.Add(this.txtAssinaturaVisivel);
            this.bunifuGradientPanel1.Controls.Add(this.txtAssinar);
            this.bunifuGradientPanel1.Controls.Add(this.txtMarcaDagua);
            this.bunifuGradientPanel1.Controls.Add(this.txtBarcode);
            this.bunifuGradientPanel1.Controls.Add(this.txtRecortar);
            this.bunifuGradientPanel1.Controls.Add(this.label5);
            this.bunifuGradientPanel1.Controls.Add(this.label4);
            this.bunifuGradientPanel1.Controls.Add(this.label3);
            this.bunifuGradientPanel1.Controls.Add(this.label2);
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.Controls.Add(this.CarregaOnloadRenomear);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.MediumBlue;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DeepSkyBlue;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(888, 560);
            this.bunifuGradientPanel1.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(14, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(238, 25);
            this.label11.TabIndex = 11;
            this.label11.Text = "Configurações de Trabalho";
            // 
            // txtAssinaturaVisivel
            // 
            this.txtAssinaturaVisivel.AutoSize = true;
            this.txtAssinaturaVisivel.BackColor = System.Drawing.Color.Transparent;
            this.txtAssinaturaVisivel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssinaturaVisivel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAssinaturaVisivel.Location = new System.Drawing.Point(230, 384);
            this.txtAssinaturaVisivel.Name = "txtAssinaturaVisivel";
            this.txtAssinaturaVisivel.Size = new System.Drawing.Size(47, 25);
            this.txtAssinaturaVisivel.TabIndex = 10;
            this.txtAssinaturaVisivel.Text = "Não";
            // 
            // txtAssinar
            // 
            this.txtAssinar.AutoSize = true;
            this.txtAssinar.BackColor = System.Drawing.Color.Transparent;
            this.txtAssinar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssinar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAssinar.Location = new System.Drawing.Point(230, 324);
            this.txtAssinar.Name = "txtAssinar";
            this.txtAssinar.Size = new System.Drawing.Size(47, 25);
            this.txtAssinar.TabIndex = 9;
            this.txtAssinar.Text = "Não";
            // 
            // txtMarcaDagua
            // 
            this.txtMarcaDagua.AutoSize = true;
            this.txtMarcaDagua.BackColor = System.Drawing.Color.Transparent;
            this.txtMarcaDagua.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarcaDagua.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMarcaDagua.Location = new System.Drawing.Point(230, 262);
            this.txtMarcaDagua.Name = "txtMarcaDagua";
            this.txtMarcaDagua.Size = new System.Drawing.Size(47, 25);
            this.txtMarcaDagua.TabIndex = 8;
            this.txtMarcaDagua.Text = "Não";
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoSize = true;
            this.txtBarcode.BackColor = System.Drawing.Color.Transparent;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtBarcode.Location = new System.Drawing.Point(230, 206);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(47, 25);
            this.txtBarcode.TabIndex = 7;
            this.txtBarcode.Text = "Não";
            // 
            // txtRecortar
            // 
            this.txtRecortar.AutoSize = true;
            this.txtRecortar.BackColor = System.Drawing.Color.Transparent;
            this.txtRecortar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecortar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtRecortar.Location = new System.Drawing.Point(230, 156);
            this.txtRecortar.Name = "txtRecortar";
            this.txtRecortar.Size = new System.Drawing.Size(47, 25);
            this.txtRecortar.TabIndex = 6;
            this.txtRecortar.Text = "Não";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(14, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Assinatura Visível :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(14, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Assinar em Lote :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(14, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Inserir Marca D\'agua :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(14, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Leitura Barcode :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(14, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recortar Pagina :";
            // 
            // bunifuCircleProgress1
            // 
            this.bunifuCircleProgress1.Animated = true;
            this.bunifuCircleProgress1.AnimationInterval = 1;
            this.bunifuCircleProgress1.AnimationSpeed = 1;
            this.bunifuCircleProgress1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgress1.CircleMargin = 10;
            this.bunifuCircleProgress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold);
            this.bunifuCircleProgress1.ForeColor = System.Drawing.Color.White;
            this.bunifuCircleProgress1.IsPercentage = true;
            this.bunifuCircleProgress1.LineProgressThickness = 8;
            this.bunifuCircleProgress1.LineThickness = 5;
            this.bunifuCircleProgress1.Location = new System.Drawing.Point(348, 165);
            this.bunifuCircleProgress1.Name = "bunifuCircleProgress1";
            this.bunifuCircleProgress1.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgress1.ProgressColor = System.Drawing.Color.SlateBlue;
            this.bunifuCircleProgress1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bunifuCircleProgress1.Size = new System.Drawing.Size(184, 184);
            this.bunifuCircleProgress1.Step = 25;
            this.bunifuCircleProgress1.SubScriptColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCircleProgress1.SubScriptMargin = new System.Windows.Forms.Padding(5, -35, 0, 0);
            this.bunifuCircleProgress1.SubScriptText = "";
            this.bunifuCircleProgress1.SuperScriptColor = System.Drawing.Color.White;
            this.bunifuCircleProgress1.SuperScriptMargin = new System.Windows.Forms.Padding(5, 50, 0, 0);
            this.bunifuCircleProgress1.SuperScriptText = "%";
            this.bunifuCircleProgress1.TabIndex = 16;
            this.bunifuCircleProgress1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(333, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 32);
            this.label6.TabIndex = 17;
            this.label6.Text = "VIRTUAL SCANNER";
            // 
            // PageBarcodeReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Name = "PageBarcodeReader";
            this.Size = new System.Drawing.Size(888, 560);
            this.Load += new System.EventHandler(this.PageBarcodeReader_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuButton.BunifuButton CarregaOnloadRenomear;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtAssinaturaVisivel;
        private System.Windows.Forms.Label txtAssinar;
        private System.Windows.Forms.Label txtMarcaDagua;
        private System.Windows.Forms.Label txtBarcode;
        private System.Windows.Forms.Label txtRecortar;
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuCircleProgress bunifuCircleProgress1;
        private System.Windows.Forms.Label label6;
    }
}
