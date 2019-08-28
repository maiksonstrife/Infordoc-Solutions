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
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnImportarPlanilha = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnSelecionaPlanilha = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.listBox3 = new System.Windows.Forms.ListBox();
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
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(139, 28);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "Importar XML";
            this.bunifuCustomLabel1.Click += new System.EventHandler(this.bunifuCustomLabel1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "Nome Arquivo";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(246, 171);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(188, 225);
            this.ListBox1.TabIndex = 6;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
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
            this.btnImportarPlanilha.ButtonText = "Selecionar Pasta XML";
            this.btnImportarPlanilha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportarPlanilha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarPlanilha.ForeColor = System.Drawing.Color.SeaShell;
            this.btnImportarPlanilha.IdleBorderThickness = 1;
            this.btnImportarPlanilha.IdleCornerRadius = 20;
            this.btnImportarPlanilha.IdleFillColor = System.Drawing.Color.Green;
            this.btnImportarPlanilha.IdleForecolor = System.Drawing.Color.Honeydew;
            this.btnImportarPlanilha.IdleLineColor = System.Drawing.Color.Transparent;
            this.btnImportarPlanilha.Location = new System.Drawing.Point(246, 112);
            this.btnImportarPlanilha.Margin = new System.Windows.Forms.Padding(5);
            this.btnImportarPlanilha.Name = "btnImportarPlanilha";
            this.btnImportarPlanilha.Size = new System.Drawing.Size(188, 41);
            this.btnImportarPlanilha.TabIndex = 9;
            this.btnImportarPlanilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImportarPlanilha.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // btnSelecionaPlanilha
            // 
            this.btnSelecionaPlanilha.ActiveBorderThickness = 1;
            this.btnSelecionaPlanilha.ActiveCornerRadius = 20;
            this.btnSelecionaPlanilha.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSelecionaPlanilha.ActiveForecolor = System.Drawing.Color.White;
            this.btnSelecionaPlanilha.ActiveLineColor = System.Drawing.Color.Transparent;
            this.btnSelecionaPlanilha.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelecionaPlanilha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecionaPlanilha.BackgroundImage")));
            this.btnSelecionaPlanilha.ButtonText = "Selecionar Pasta PDF";
            this.btnSelecionaPlanilha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionaPlanilha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionaPlanilha.ForeColor = System.Drawing.Color.SeaShell;
            this.btnSelecionaPlanilha.IdleBorderThickness = 1;
            this.btnSelecionaPlanilha.IdleCornerRadius = 20;
            this.btnSelecionaPlanilha.IdleFillColor = System.Drawing.Color.Red;
            this.btnSelecionaPlanilha.IdleForecolor = System.Drawing.Color.Honeydew;
            this.btnSelecionaPlanilha.IdleLineColor = System.Drawing.Color.Transparent;
            this.btnSelecionaPlanilha.Location = new System.Drawing.Point(5, 112);
            this.btnSelecionaPlanilha.Margin = new System.Windows.Forms.Padding(5);
            this.btnSelecionaPlanilha.Name = "btnSelecionaPlanilha";
            this.btnSelecionaPlanilha.Size = new System.Drawing.Size(191, 41);
            this.btnSelecionaPlanilha.TabIndex = 10;
            this.btnSelecionaPlanilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelecionaPlanilha.Click += new System.EventHandler(this.bunifuThinButton21_Click_1);
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
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(8, 171);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(188, 225);
            this.listBox2.TabIndex = 11;
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.DeepSkyBlue;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.Transparent;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "IMPORTAR";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.SeaShell;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.Honeydew;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.Transparent;
            this.bunifuThinButton21.Location = new System.Drawing.Point(502, 112);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(336, 41);
            this.bunifuThinButton21.TabIndex = 12;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click_2);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(502, 171);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(336, 225);
            this.listBox3.TabIndex = 13;
            // 
            // Page1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.bunifuThinButton21);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.btnSelecionaPlanilha);
            this.Controls.Add(this.btnImportarPlanilha);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Name = "Page1";
            this.Size = new System.Drawing.Size(888, 535);
            this.Load += new System.EventHandler(this.Page1_Load);
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
    }
}
