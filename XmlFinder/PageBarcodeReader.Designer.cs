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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.CarregaOnloadRenomear = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.SuspendLayout();
            // 
            // CarregaOnloadRenomear
            // 
            this.CarregaOnloadRenomear.BackColor = System.Drawing.Color.Transparent;
            this.CarregaOnloadRenomear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CarregaOnloadRenomear.BackgroundImage")));
            this.CarregaOnloadRenomear.ButtonText = "Bunifu Button";
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
            this.CarregaOnloadRenomear.Location = new System.Drawing.Point(317, 245);
            this.CarregaOnloadRenomear.Name = "CarregaOnloadRenomear";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties1.BorderRadius = 1;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.CarregaOnloadRenomear.onHoverState = stateProperties1;
            this.CarregaOnloadRenomear.Size = new System.Drawing.Size(210, 45);
            this.CarregaOnloadRenomear.TabIndex = 0;
            this.CarregaOnloadRenomear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CarregaOnloadRenomear.Click += new System.EventHandler(this.CarregaOnloadRenomear_Click);
            // 
            // PageBarcodeReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CarregaOnloadRenomear);
            this.Name = "PageBarcodeReader";
            this.Size = new System.Drawing.Size(888, 535);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuButton.BunifuButton CarregaOnloadRenomear;
    }
}
