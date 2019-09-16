namespace XmlFinder
{
    partial class Page4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page4));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties13 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties14 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties15 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties16 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.listarPastasBox = new Bunifu.UI.WinForms.BunifuDropdown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnviarFtp = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnMonitorar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPararVerificacao = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelecionarPasta = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtCaminhoLocal = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuProgressBar1 = new Bunifu.UI.Winforms.BunifuProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(3, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(222, 50);
            this.bunifuCustomLabel1.TabIndex = 8;
            this.bunifuCustomLabel1.Text = "1 -Conexão";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 141);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(899, 17);
            this.bunifuSeparator1.TabIndex = 9;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.Load += new System.EventHandler(this.bunifuSeparator1_Load);
            // 
            // listarPastasBox
            // 
            this.listarPastasBox.BackColor = System.Drawing.SystemColors.Control;
            this.listarPastasBox.BorderRadius = 1;
            this.listarPastasBox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.listarPastasBox.DisabledColor = System.Drawing.Color.Gray;
            this.listarPastasBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listarPastasBox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.listarPastasBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listarPastasBox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.listarPastasBox.FillDropDown = false;
            this.listarPastasBox.FillIndicator = false;
            this.listarPastasBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listarPastasBox.ForeColor = System.Drawing.Color.Purple;
            this.listarPastasBox.FormattingEnabled = true;
            this.listarPastasBox.Icon = null;
            this.listarPastasBox.IndicatorColor = System.Drawing.Color.Purple;
            this.listarPastasBox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.listarPastasBox.ItemBackColor = System.Drawing.Color.White;
            this.listarPastasBox.ItemBorderColor = System.Drawing.Color.White;
            this.listarPastasBox.ItemForeColor = System.Drawing.Color.Purple;
            this.listarPastasBox.ItemHeight = 26;
            this.listarPastasBox.ItemHighLightColor = System.Drawing.Color.Thistle;
            this.listarPastasBox.Location = new System.Drawing.Point(12, 322);
            this.listarPastasBox.Name = "listarPastasBox";
            this.listarPastasBox.Size = new System.Drawing.Size(409, 32);
            this.listarPastasBox.TabIndex = 19;
            this.listarPastasBox.Text = null;
            this.listarPastasBox.SelectedIndexChanged += new System.EventHandler(this.listarPastasBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "Pasta na Web - Selecione a pasta na web";
            // 
            // btnEnviarFtp
            // 
            this.btnEnviarFtp.BackColor = System.Drawing.Color.Transparent;
            this.btnEnviarFtp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviarFtp.BackgroundImage")));
            this.btnEnviarFtp.ButtonText = "Enviar";
            this.btnEnviarFtp.ButtonTextMarginLeft = 0;
            this.btnEnviarFtp.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnEnviarFtp.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnEnviarFtp.DisabledForecolor = System.Drawing.Color.White;
            this.btnEnviarFtp.ForeColor = System.Drawing.Color.White;
            this.btnEnviarFtp.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnEnviarFtp.IconPadding = 10;
            this.btnEnviarFtp.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnEnviarFtp.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnEnviarFtp.IdleBorderRadius = 1;
            this.btnEnviarFtp.IdleBorderThickness = 0;
            this.btnEnviarFtp.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnEnviarFtp.IdleIconLeftImage = null;
            this.btnEnviarFtp.IdleIconRightImage = null;
            this.btnEnviarFtp.Location = new System.Drawing.Point(557, 276);
            this.btnEnviarFtp.Name = "btnEnviarFtp";
            stateProperties13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties13.BorderRadius = 1;
            stateProperties13.BorderThickness = 1;
            stateProperties13.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties13.IconLeftImage = null;
            stateProperties13.IconRightImage = null;
            this.btnEnviarFtp.onHoverState = stateProperties13;
            this.btnEnviarFtp.Size = new System.Drawing.Size(217, 34);
            this.btnEnviarFtp.TabIndex = 22;
            this.btnEnviarFtp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEnviarFtp.Click += new System.EventHandler(this.btnEnviarFtp_Click);
            // 
            // btnMonitorar
            // 
            this.btnMonitorar.BackColor = System.Drawing.Color.Transparent;
            this.btnMonitorar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMonitorar.BackgroundImage")));
            this.btnMonitorar.ButtonText = "Monitorar";
            this.btnMonitorar.ButtonTextMarginLeft = 0;
            this.btnMonitorar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnMonitorar.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnMonitorar.DisabledForecolor = System.Drawing.Color.White;
            this.btnMonitorar.ForeColor = System.Drawing.Color.White;
            this.btnMonitorar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnMonitorar.IconPadding = 10;
            this.btnMonitorar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnMonitorar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnMonitorar.IdleBorderRadius = 1;
            this.btnMonitorar.IdleBorderThickness = 0;
            this.btnMonitorar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnMonitorar.IdleIconLeftImage = null;
            this.btnMonitorar.IdleIconRightImage = null;
            this.btnMonitorar.Location = new System.Drawing.Point(557, 338);
            this.btnMonitorar.Name = "btnMonitorar";
            stateProperties14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties14.BorderRadius = 1;
            stateProperties14.BorderThickness = 1;
            stateProperties14.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties14.IconLeftImage = null;
            stateProperties14.IconRightImage = null;
            this.btnMonitorar.onHoverState = stateProperties14;
            this.btnMonitorar.Size = new System.Drawing.Size(217, 34);
            this.btnMonitorar.TabIndex = 23;
            this.btnMonitorar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMonitorar.Click += new System.EventHandler(this.btnMonitorar_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe UI Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(3, 187);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(261, 50);
            this.bunifuCustomLabel2.TabIndex = 21;
            this.bunifuCustomLabel2.Text = "2 - Diretórios";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(427, 150);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(18, 385);
            this.bunifuSeparator2.TabIndex = 24;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = true;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Segoe UI Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(451, 187);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(178, 50);
            this.bunifuCustomLabel3.TabIndex = 25;
            this.bunifuCustomLabel3.Text = "3 - Envio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(609, 457);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 26);
            this.label5.TabIndex = 29;
            this.label5.Text = "Parar Verificação Automática";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(544, 446);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 63);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
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
            this.btnPararVerificacao.Location = new System.Drawing.Point(614, 486);
            this.btnPararVerificacao.Name = "btnPararVerificacao";
            this.btnPararVerificacao.Normalcolor = System.Drawing.Color.Crimson;
            this.btnPararVerificacao.OnHovercolor = System.Drawing.Color.Crimson;
            this.btnPararVerificacao.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPararVerificacao.selected = false;
            this.btnPararVerificacao.Size = new System.Drawing.Size(252, 23);
            this.btnPararVerificacao.TabIndex = 27;
            this.btnPararVerificacao.Text = "Parar";
            this.btnPararVerificacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPararVerificacao.Textcolor = System.Drawing.Color.White;
            this.btnPararVerificacao.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPararVerificacao.Click += new System.EventHandler(this.btnPararVerificacao_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(381, 21);
            this.label6.TabIndex = 31;
            this.label6.Text = "Pasta Local - Selecione a pasta em seu computador";
            // 
            // btnSelecionarPasta
            // 
            this.btnSelecionarPasta.BackColor = System.Drawing.Color.Transparent;
            this.btnSelecionarPasta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecionarPasta.BackgroundImage")));
            this.btnSelecionarPasta.ButtonText = "Selecionar Pasta";
            this.btnSelecionarPasta.ButtonTextMarginLeft = 0;
            this.btnSelecionarPasta.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnSelecionarPasta.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnSelecionarPasta.DisabledForecolor = System.Drawing.Color.White;
            this.btnSelecionarPasta.ForeColor = System.Drawing.Color.White;
            this.btnSelecionarPasta.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSelecionarPasta.IconPadding = 10;
            this.btnSelecionarPasta.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSelecionarPasta.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnSelecionarPasta.IdleBorderRadius = 1;
            this.btnSelecionarPasta.IdleBorderThickness = 0;
            this.btnSelecionarPasta.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnSelecionarPasta.IdleIconLeftImage = null;
            this.btnSelecionarPasta.IdleIconRightImage = null;
            this.btnSelecionarPasta.Location = new System.Drawing.Point(12, 428);
            this.btnSelecionarPasta.Name = "btnSelecionarPasta";
            stateProperties15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties15.BorderRadius = 1;
            stateProperties15.BorderThickness = 1;
            stateProperties15.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties15.IconLeftImage = null;
            stateProperties15.IconRightImage = null;
            this.btnSelecionarPasta.onHoverState = stateProperties15;
            this.btnSelecionarPasta.Size = new System.Drawing.Size(182, 27);
            this.btnSelecionarPasta.TabIndex = 32;
            this.btnSelecionarPasta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelecionarPasta.Click += new System.EventHandler(this.btnSelecionarPasta_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtCaminhoLocal
            // 
            this.txtCaminhoLocal.AcceptsReturn = false;
            this.txtCaminhoLocal.AcceptsTab = false;
            this.txtCaminhoLocal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCaminhoLocal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCaminhoLocal.BackColor = System.Drawing.SystemColors.Control;
            this.txtCaminhoLocal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtCaminhoLocal.BackgroundImage")));
            this.txtCaminhoLocal.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtCaminhoLocal.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtCaminhoLocal.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(38)))), ((int)(((byte)(157)))));
            this.txtCaminhoLocal.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.txtCaminhoLocal.BorderRadius = 1;
            this.txtCaminhoLocal.BorderThickness = 2;
            this.txtCaminhoLocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCaminhoLocal.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminhoLocal.DefaultText = "";
            this.txtCaminhoLocal.FillColor = System.Drawing.SystemColors.Control;
            this.txtCaminhoLocal.HideSelection = true;
            this.txtCaminhoLocal.IconLeft = null;
            this.txtCaminhoLocal.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtCaminhoLocal.IconPadding = 10;
            this.txtCaminhoLocal.IconRight = null;
            this.txtCaminhoLocal.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtCaminhoLocal.Location = new System.Drawing.Point(12, 472);
            this.txtCaminhoLocal.MaxLength = 32767;
            this.txtCaminhoLocal.MinimumSize = new System.Drawing.Size(100, 35);
            this.txtCaminhoLocal.Modified = false;
            this.txtCaminhoLocal.Name = "txtCaminhoLocal";
            this.txtCaminhoLocal.PasswordChar = '\0';
            this.txtCaminhoLocal.ReadOnly = true;
            this.txtCaminhoLocal.SelectedText = "";
            this.txtCaminhoLocal.SelectionLength = 0;
            this.txtCaminhoLocal.SelectionStart = 0;
            this.txtCaminhoLocal.ShortcutsEnabled = true;
            this.txtCaminhoLocal.Size = new System.Drawing.Size(409, 35);
            this.txtCaminhoLocal.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Material;
            this.txtCaminhoLocal.TabIndex = 35;
            this.txtCaminhoLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCaminhoLocal.TextMarginLeft = 5;
            this.txtCaminhoLocal.TextPlaceholder = "";
            this.txtCaminhoLocal.UseSystemPasswordChar = false;
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.ButtonText = "Conectar";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.Gray;
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.White;
            this.bunifuButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.bunifuButton1.IdleBorderRadius = 1;
            this.bunifuButton1.IdleBorderThickness = 0;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.Location = new System.Drawing.Point(12, 79);
            this.bunifuButton1.Name = "bunifuButton1";
            stateProperties16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties16.BorderRadius = 1;
            stateProperties16.BorderThickness = 1;
            stateProperties16.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties16.IconLeftImage = null;
            stateProperties16.IconRightImage = null;
            this.bunifuButton1.onHoverState = stateProperties16;
            this.bunifuButton1.Size = new System.Drawing.Size(346, 34);
            this.bunifuButton1.TabIndex = 17;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.Animation = 0;
            this.bunifuProgressBar1.AnimationStep = 10;
            this.bunifuProgressBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuProgressBar1.BackgroundImage")));
            this.bunifuProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(53)))), ((int)(((byte)(85)))));
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.BorderThickness = 2;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(485, 402);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.MinimumValue = 0;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(53)))), ((int)(((byte)(85)))));
            this.bunifuProgressBar1.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.bunifuProgressBar1.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.bunifuProgressBar1.Size = new System.Drawing.Size(359, 23);
            this.bunifuProgressBar1.TabIndex = 36;
            this.bunifuProgressBar1.Value = 0;
            this.bunifuProgressBar1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Page4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.txtCaminhoLocal);
            this.Controls.Add(this.btnSelecionarPasta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnPararVerificacao);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.btnMonitorar);
            this.Controls.Add(this.btnEnviarFtp);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listarPastasBox);
            this.Controls.Add(this.bunifuButton1);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Name = "Page4";
            this.Size = new System.Drawing.Size(888, 535);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuDropdown listarPastasBox;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnEnviarFtp;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnMonitorar;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuFlatButton btnPararVerificacao;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSelecionarPasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtCaminhoLocal;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.UI.Winforms.BunifuProgressBar bunifuProgressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
