using System;

namespace InforPlan
{
    partial class Page2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page2));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dgPlanilha = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.dataInicio = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dataFim = new Bunifu.Framework.UI.BunifuDatepicker();
            this.btnPesquisar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.txtFilial1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtCaixa1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtCte1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnExportar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanilha)).BeginInit();
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
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(168, 28);
            this.bunifuCustomLabel1.TabIndex = 4;
            this.bunifuCustomLabel1.Text = "Exportar Planilha";
            this.bunifuCustomLabel1.Click += new System.EventHandler(this.bunifuCustomLabel1_Click);
            // 
            // dgPlanilha
            // 
            this.dgPlanilha.AllowCustomTheming = false;
            this.dgPlanilha.AllowUserToAddRows = false;
            this.dgPlanilha.AllowUserToDeleteRows = false;
            this.dgPlanilha.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgPlanilha.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPlanilha.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPlanilha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPlanilha.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgPlanilha.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPlanilha.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPlanilha.ColumnHeadersHeight = 40;
            this.dgPlanilha.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(223)))));
            this.dgPlanilha.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgPlanilha.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgPlanilha.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(178)))));
            this.dgPlanilha.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgPlanilha.CurrentTheme.BackColor = System.Drawing.Color.Navy;
            this.dgPlanilha.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(178)))), ((int)(((byte)(216)))));
            this.dgPlanilha.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Navy;
            this.dgPlanilha.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgPlanilha.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgPlanilha.CurrentTheme.Name = null;
            this.dgPlanilha.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(229)))));
            this.dgPlanilha.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgPlanilha.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgPlanilha.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(178)))));
            this.dgPlanilha.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPlanilha.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPlanilha.EnableHeadersVisualStyles = false;
            this.dgPlanilha.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(178)))), ((int)(((byte)(216)))));
            this.dgPlanilha.HeaderBackColor = System.Drawing.Color.Navy;
            this.dgPlanilha.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgPlanilha.HeaderForeColor = System.Drawing.Color.White;
            this.dgPlanilha.Location = new System.Drawing.Point(3, 78);
            this.dgPlanilha.Name = "dgPlanilha";
            this.dgPlanilha.ReadOnly = true;
            this.dgPlanilha.RowHeadersVisible = false;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.dgPlanilha.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgPlanilha.RowTemplate.Height = 40;
            this.dgPlanilha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlanilha.Size = new System.Drawing.Size(882, 393);
            this.dgPlanilha.TabIndex = 6;
            this.dgPlanilha.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Navy;
            // 
            // dataInicio
            // 
            this.dataInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(53)))), ((int)(((byte)(170)))));
            this.dataInicio.BorderRadius = 0;
            this.dataInicio.ForeColor = System.Drawing.Color.White;
            this.dataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInicio.FormatCustom = "";
            this.dataInicio.Location = new System.Drawing.Point(367, 46);
            this.dataInicio.Name = "dataInicio";
            this.dataInicio.Size = new System.Drawing.Size(151, 26);
            this.dataInicio.TabIndex = 7;
            this.dataInicio.Value = new System.DateTime(2019, 7, 3, 0, 0, 0, 0);
            // 
            // dataFim
            // 
            this.dataFim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(53)))), ((int)(((byte)(170)))));
            this.dataFim.BorderRadius = 0;
            this.dataFim.ForeColor = System.Drawing.Color.White;
            this.dataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataFim.FormatCustom = null;
            this.dataFim.Location = new System.Drawing.Point(533, 46);
            this.dataFim.Name = "dataFim";
            this.dataFim.Size = new System.Drawing.Size(151, 26);
            this.dataFim.TabIndex = 8;
            this.dataFim.Value = new System.DateTime(2019, 7, 3, 0, 0, 0, 0);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.BackgroundImage")));
            this.btnPesquisar.ButtonText = "Pesquisar";
            this.btnPesquisar.ButtonTextMarginLeft = 0;
            this.btnPesquisar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnPesquisar.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnPesquisar.DisabledForecolor = System.Drawing.Color.White;
            this.btnPesquisar.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnPesquisar.IconPadding = 10;
            this.btnPesquisar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnPesquisar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(114)))));
            this.btnPesquisar.IdleBorderRadius = 1;
            this.btnPesquisar.IdleBorderThickness = 0;
            this.btnPesquisar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(114)))));
            this.btnPesquisar.IdleIconLeftImage = null;
            this.btnPesquisar.IdleIconRightImage = null;
            this.btnPesquisar.Location = new System.Drawing.Point(703, 46);
            this.btnPesquisar.Name = "btnPesquisar";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(53)))), ((int)(((byte)(170)))));
            stateProperties1.BorderRadius = 1;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(53)))), ((int)(((byte)(170)))));
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.btnPesquisar.onHoverState = stateProperties1;
            this.btnPesquisar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPesquisar.Size = new System.Drawing.Size(166, 26);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtFilial1
            // 
            this.txtFilial1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtFilial1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtFilial1.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFilial1.Cursor = System.Windows.Forms.Cursors.No;
            this.txtFilial1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFilial1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFilial1.HintForeColor = System.Drawing.Color.Empty;
            this.txtFilial1.HintText = "";
            this.txtFilial1.isPassword = false;
            this.txtFilial1.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txtFilial1.LineIdleColor = System.Drawing.Color.Gray;
            this.txtFilial1.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txtFilial1.LineThickness = 3;
            this.txtFilial1.Location = new System.Drawing.Point(4, 478);
            this.txtFilial1.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilial1.MaxLength = 32767;
            this.txtFilial1.Name = "txtFilial1";
            this.txtFilial1.Size = new System.Drawing.Size(174, 26);
            this.txtFilial1.TabIndex = 11;
            this.txtFilial1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFilial1.OnValueChanged += new System.EventHandler(this.bunifuMaterialTextbox1_OnValueChanged);
            // 
            // txtCaixa1
            // 
            this.txtCaixa1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCaixa1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCaixa1.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCaixa1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCaixa1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCaixa1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCaixa1.HintForeColor = System.Drawing.Color.Empty;
            this.txtCaixa1.HintText = "";
            this.txtCaixa1.isPassword = false;
            this.txtCaixa1.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txtCaixa1.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCaixa1.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txtCaixa1.LineThickness = 3;
            this.txtCaixa1.Location = new System.Drawing.Point(185, 478);
            this.txtCaixa1.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaixa1.MaxLength = 32767;
            this.txtCaixa1.Name = "txtCaixa1";
            this.txtCaixa1.Size = new System.Drawing.Size(174, 26);
            this.txtCaixa1.TabIndex = 12;
            this.txtCaixa1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCaixa1.OnValueChanged += new System.EventHandler(this.txtCaixa1_OnValueChanged);
            // 
            // txtCte1
            // 
            this.txtCte1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCte1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCte1.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCte1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCte1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCte1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCte1.HintForeColor = System.Drawing.Color.Empty;
            this.txtCte1.HintText = "";
            this.txtCte1.isPassword = false;
            this.txtCte1.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txtCte1.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCte1.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txtCte1.LineThickness = 3;
            this.txtCte1.Location = new System.Drawing.Point(367, 478);
            this.txtCte1.Margin = new System.Windows.Forms.Padding(4);
            this.txtCte1.MaxLength = 32767;
            this.txtCte1.Name = "txtCte1";
            this.txtCte1.Size = new System.Drawing.Size(174, 26);
            this.txtCte1.TabIndex = 13;
            this.txtCte1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCte1.OnValueChanged += new System.EventHandler(this.txtCte1_OnValueChanged);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.Transparent;
            this.btnExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.BackgroundImage")));
            this.btnExportar.ButtonText = "Exportar Planilha";
            this.btnExportar.ButtonTextMarginLeft = 0;
            this.btnExportar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnExportar.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnExportar.DisabledForecolor = System.Drawing.Color.White;
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnExportar.IconPadding = 10;
            this.btnExportar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnExportar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(114)))));
            this.btnExportar.IdleBorderRadius = 3;
            this.btnExportar.IdleBorderThickness = 0;
            this.btnExportar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(114)))));
            this.btnExportar.IdleIconLeftImage = null;
            this.btnExportar.IdleIconRightImage = null;
            this.btnExportar.Location = new System.Drawing.Point(703, 478);
            this.btnExportar.Name = "btnExportar";
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(53)))), ((int)(((byte)(170)))));
            stateProperties2.BorderRadius = 1;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(53)))), ((int)(((byte)(170)))));
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.btnExportar.onHoverState = stateProperties2;
            this.btnExportar.Size = new System.Drawing.Size(166, 36);
            this.btnExportar.TabIndex = 14;
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportar.Click += new System.EventHandler(this.bunifuButton2_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(407, 26);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(73, 17);
            this.bunifuCustomLabel2.TabIndex = 15;
            this.bunifuCustomLabel2.Text = "Período de";
            this.bunifuCustomLabel2.Click += new System.EventHandler(this.bunifuCustomLabel2_Click);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(595, 26);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(27, 17);
            this.bunifuCustomLabel3.TabIndex = 16;
            this.bunifuCustomLabel3.Text = "Até";
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.bunifuLabel1.Location = new System.Drawing.Point(4, 478);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(24, 9);
            this.bunifuLabel1.TabIndex = 17;
            this.bunifuLabel1.Text = "FILIAL";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.bunifuLabel2.Location = new System.Drawing.Point(185, 478);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(25, 9);
            this.bunifuLabel2.TabIndex = 18;
            this.bunifuLabel2.Text = "CAIXA";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.CursorType = null;
            this.bunifuLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.bunifuLabel3.Location = new System.Drawing.Point(367, 478);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(17, 9);
            this.bunifuLabel3.TabIndex = 19;
            this.bunifuLabel3.Text = "CTE";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            // 
            // Page2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.txtCte1);
            this.Controls.Add(this.txtCaixa1);
            this.Controls.Add(this.txtFilial1);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dataFim);
            this.Controls.Add(this.dataInicio);
            this.Controls.Add(this.dgPlanilha);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Name = "Page2";
            this.Size = new System.Drawing.Size(888, 535);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanilha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataInicio_onValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.UI.WinForms.BunifuDataGridView dgPlanilha;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnPesquisar;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtFilial1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCaixa1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCte1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnExportar;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        public Bunifu.Framework.UI.BunifuDatepicker dataInicio;
        public Bunifu.Framework.UI.BunifuDatepicker dataFim;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
