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
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtArquivo = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.txtTempo = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnImportarPlanilha = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnSelecionaPlanilha = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(3, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(171, 28);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "Importar Planilha";
            this.bunifuCustomLabel1.Click += new System.EventHandler(this.bunifuCustomLabel1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "Nome Arquivo";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // txtArquivo
            // 
            this.txtArquivo.AcceptsReturn = true;
            this.txtArquivo.AcceptsTab = true;
            this.txtArquivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtArquivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtArquivo.BackColor = System.Drawing.Color.Transparent;
            this.txtArquivo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtArquivo.BackgroundImage")));
            this.txtArquivo.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtArquivo.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtArquivo.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(38)))), ((int)(((byte)(157)))));
            this.txtArquivo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.txtArquivo.BorderRadius = 1;
            this.txtArquivo.BorderThickness = 2;
            this.txtArquivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtArquivo.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArquivo.DefaultText = "";
            this.txtArquivo.FillColor = System.Drawing.Color.White;
            this.txtArquivo.HideSelection = true;
            this.txtArquivo.IconLeft = null;
            this.txtArquivo.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtArquivo.IconPadding = 10;
            this.txtArquivo.IconRight = null;
            this.txtArquivo.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtArquivo.Location = new System.Drawing.Point(3, 145);
            this.txtArquivo.MaxLength = 32767;
            this.txtArquivo.MinimumSize = new System.Drawing.Size(100, 35);
            this.txtArquivo.Modified = false;
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.PasswordChar = '\0';
            this.txtArquivo.ReadOnly = false;
            this.txtArquivo.SelectedText = "";
            this.txtArquivo.SelectionLength = 0;
            this.txtArquivo.SelectionStart = 0;
            this.txtArquivo.ShortcutsEnabled = true;
            this.txtArquivo.Size = new System.Drawing.Size(654, 126);
            this.txtArquivo.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtArquivo.TabIndex = 4;
            this.txtArquivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtArquivo.TextMarginLeft = 5;
            this.txtArquivo.TextPlaceholder = "";
            this.txtArquivo.UseSystemPasswordChar = false;
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(3, 419);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(654, 95);
            this.ListBox1.TabIndex = 6;
            // 
            // txtTempo
            // 
            this.txtTempo.AcceptsReturn = false;
            this.txtTempo.AcceptsTab = false;
            this.txtTempo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTempo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTempo.BackColor = System.Drawing.Color.Transparent;
            this.txtTempo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTempo.BackgroundImage")));
            this.txtTempo.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtTempo.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtTempo.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(38)))), ((int)(((byte)(157)))));
            this.txtTempo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.txtTempo.BorderRadius = 1;
            this.txtTempo.BorderThickness = 2;
            this.txtTempo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTempo.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempo.DefaultText = "";
            this.txtTempo.FillColor = System.Drawing.Color.White;
            this.txtTempo.HideSelection = true;
            this.txtTempo.IconLeft = null;
            this.txtTempo.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtTempo.IconPadding = 10;
            this.txtTempo.IconRight = null;
            this.txtTempo.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtTempo.Location = new System.Drawing.Point(785, 232);
            this.txtTempo.MaxLength = 32767;
            this.txtTempo.MinimumSize = new System.Drawing.Size(100, 35);
            this.txtTempo.Modified = false;
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.PasswordChar = '\0';
            this.txtTempo.ReadOnly = false;
            this.txtTempo.SelectedText = "";
            this.txtTempo.SelectionLength = 0;
            this.txtTempo.SelectionStart = 0;
            this.txtTempo.ShortcutsEnabled = true;
            this.txtTempo.Size = new System.Drawing.Size(100, 39);
            this.txtTempo.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtTempo.TabIndex = 8;
            this.txtTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTempo.TextMarginLeft = 5;
            this.txtTempo.TextPlaceholder = "";
            this.txtTempo.UseSystemPasswordChar = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnImportarPlanilha
            // 
            this.btnImportarPlanilha.ActiveBorderThickness = 1;
            this.btnImportarPlanilha.ActiveCornerRadius = 20;
            this.btnImportarPlanilha.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnImportarPlanilha.ActiveForecolor = System.Drawing.Color.White;
            this.btnImportarPlanilha.ActiveLineColor = System.Drawing.Color.Transparent;
            this.btnImportarPlanilha.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportarPlanilha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportarPlanilha.BackgroundImage")));
            this.btnImportarPlanilha.ButtonText = "Importar Planilha";
            this.btnImportarPlanilha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportarPlanilha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarPlanilha.ForeColor = System.Drawing.Color.SeaShell;
            this.btnImportarPlanilha.IdleBorderThickness = 1;
            this.btnImportarPlanilha.IdleCornerRadius = 20;
            this.btnImportarPlanilha.IdleFillColor = System.Drawing.Color.Green;
            this.btnImportarPlanilha.IdleForecolor = System.Drawing.Color.Honeydew;
            this.btnImportarPlanilha.IdleLineColor = System.Drawing.Color.Transparent;
            this.btnImportarPlanilha.Location = new System.Drawing.Point(5, 370);
            this.btnImportarPlanilha.Margin = new System.Windows.Forms.Padding(5);
            this.btnImportarPlanilha.Name = "btnImportarPlanilha";
            this.btnImportarPlanilha.Size = new System.Drawing.Size(235, 41);
            this.btnImportarPlanilha.TabIndex = 9;
            this.btnImportarPlanilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImportarPlanilha.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // btnSelecionaPlanilha
            // 
            this.btnSelecionaPlanilha.ActiveBorderThickness = 1;
            this.btnSelecionaPlanilha.ActiveCornerRadius = 20;
            this.btnSelecionaPlanilha.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSelecionaPlanilha.ActiveForecolor = System.Drawing.Color.White;
            this.btnSelecionaPlanilha.ActiveLineColor = System.Drawing.Color.Transparent;
            this.btnSelecionaPlanilha.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelecionaPlanilha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecionaPlanilha.BackgroundImage")));
            this.btnSelecionaPlanilha.ButtonText = "Selecionar Planilha";
            this.btnSelecionaPlanilha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionaPlanilha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionaPlanilha.ForeColor = System.Drawing.Color.SeaShell;
            this.btnSelecionaPlanilha.IdleBorderThickness = 1;
            this.btnSelecionaPlanilha.IdleCornerRadius = 20;
            this.btnSelecionaPlanilha.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnSelecionaPlanilha.IdleForecolor = System.Drawing.Color.Honeydew;
            this.btnSelecionaPlanilha.IdleLineColor = System.Drawing.Color.Transparent;
            this.btnSelecionaPlanilha.Location = new System.Drawing.Point(5, 96);
            this.btnSelecionaPlanilha.Margin = new System.Windows.Forms.Padding(5);
            this.btnSelecionaPlanilha.Name = "btnSelecionaPlanilha";
            this.btnSelecionaPlanilha.Size = new System.Drawing.Size(235, 41);
            this.btnSelecionaPlanilha.TabIndex = 10;
            this.btnSelecionaPlanilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelecionaPlanilha.Click += new System.EventHandler(this.bunifuThinButton21_Click_1);
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.BorderRadius = 19;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(810, 187);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(39, 39);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 11;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Page1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.bunifuPictureBox1);
            this.Controls.Add(this.btnSelecionaPlanilha);
            this.Controls.Add(this.btnImportarPlanilha);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Name = "Page1";
            this.Size = new System.Drawing.Size(888, 535);
            this.Load += new System.EventHandler(this.Page1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtArquivo;
        private System.Windows.Forms.ListBox ListBox1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtTempo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Bunifu.Framework.UI.BunifuThinButton2 btnImportarPlanilha;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSelecionaPlanilha;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}
