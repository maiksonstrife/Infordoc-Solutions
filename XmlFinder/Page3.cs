using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlFinder.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace XmlFinder
{
    public partial class Page3 : UserControl
    {
        public Page3()
        {
            InitializeComponent();

            if (Settings.Default.standardPdfPath != "" && Settings.Default.standardXmlPath != "" && Settings.Default.standardPdfPath != null & Settings.Default.standardXmlPath != null)
            {
                isStandardDirectory.Checked = Convert.ToBoolean(Settings.Default["isStandardChecked"]);
                TextBoxPDF.Text = Settings.Default["standardPdfPath"].ToString();
                TextBoxXML.Text = Settings.Default["standardXmlPath"].ToString();
            }
        }

        private void Page3_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {

        }

        private void isStandardDirectory_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            btnPastaPadraoPDF.Visible = isStandardDirectory.Checked;
            btnPastaPadraoXML.Visible = isStandardDirectory.Checked;
            TextBoxPDF.Visible = isStandardDirectory.Checked;
            TextBoxXML.Visible = isStandardDirectory.Checked;

        }

        private void btnPastaPadraoPDF_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Settings.Default["standardPdfPath"] = dialog.FileName;
                TextBoxPDF.Text = Settings.Default["standardPdfPath"].ToString();
                new alerta("Clique em SALVAR para completar",alerta.AlertType.atencao).Show();
            }
        }

        private void btnPastaPadraoXML_Click(object sender, EventArgs e)
        {
            Settings.Default["isStandardChecked"] = isStandardDirectory.Checked;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Settings.Default["standardXmlPath"] = dialog.FileName;
                TextBoxXML.Text = Settings.Default["standardXmlPath"].ToString();
                new alerta("Clique em SALVAR para completar", alerta.AlertType.atencao).Show();
            }
        }

        private void btnSalvarStandard_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            new alerta("Configuração SALVA", alerta.AlertType.atencao).Show();
            if (isStandardDirectory.Checked == false)
            {
                Settings.Default["standardPdfPath"] = null;
                Settings.Default["standardXmlPath"] = null;
                Settings.Default["isStandardChecked"] = false;
                new alerta("Configuração APAGADA", alerta.AlertType.erro).Show();
            }
        }
    }
}
