using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace XmlFinder
{
    public partial class Page2 : UserControl
    {
        DataTable dataT = new DataTable(); //objeto DataTable => armazena informações do dataread, que descarregará na UI (datagridview)

        public Page2()
        {
            InitializeComponent();
            dataInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); //Setando default primeiro dia do mes no primeiro datepicker
            dataFim.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)); //Setando default ultimo dia do mes no ultimo datepicker
        }

        //METODOS UI
        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e) //BOTAO PESQUISA
        {
            exibeDatagrid();
        }

        private void bunifuButton2_Click(object sender, EventArgs e) //BOTAO EXPORTAR
        {
            exportarPlanilha();
        }

        //FILTROS
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e) //FILTRO FILIAL
        {
            if (dataT.Rows.Count > 0)
            {
                filtrarDataGrid();
            }

        }

        private void txtCaixa1_OnValueChanged(object sender, EventArgs e) //FILTRO CAIXA
        {
            if (dataT.Rows.Count > 0)
            {
                filtrarDataGrid();
            }
        }

        private void txtCte1_OnValueChanged(object sender, EventArgs e) //FILTRO CTE
        {
            if (dataT.Rows.Count > 0)
            {
                filtrarDataGrid();
            }
        }


        //HELPERS
        private void exibeDatagrid()
        {
            #region converte data e salva data1 = datainicio ; data2 = dataFim
            //converte dd/mm/aaaa para aaaa-mm-dd
            string data1 = dataInicio.Value.Year.ToString() + "-" + dataInicio.Value.Month.ToString() + "-" + dataInicio.Value.Day.ToString();
            string data2 = dataFim.Value.Year.ToString() + "-" + dataFim.Value.Month.ToString() + "-" + dataFim.Value.Day.ToString();
            #endregion
            #region EXIBE DATAGRID
            dataT.Rows.Clear();  //limpo o objeto
            dataT.Load(DocumentosDAO.Read(data1, data2)); //carrega dataread
            dgPlanilha.DataSource = dataT; //joga DataTable(backend) no Datagrid(UI)
            #region //esconder colunas]
            dgPlanilha.Columns[0].Visible = false; dgPlanilha.Columns[1].Visible = false; dgPlanilha.Columns[2].Visible = false;
            dgPlanilha.Columns[3].Visible = false; dgPlanilha.Columns[4].Visible = false; dgPlanilha.Columns[5].Visible = false;
            dgPlanilha.Columns[6].Visible = false;
            #endregion

            DBConnection.fecharConexao(); //Posso fechar a conexão, o dataread foi descarreado
            //MessageBox.Show(dataT.Rows.Count.ToString()); Teste verificar dataTable
            #endregion
        }

        private void filtrarDataGrid()
        {
            DataView dv = dataT.DefaultView; //DataView = visao customizada do dataTable, comparavel ao VIEW do sql => DataView  dv = dataT.DefaultView -(reutiliza o objeto atual) => DataView dv = new DefaultView(dataT) -(cria uma copia do objeto atual)
            string filtro = "0=0";
            filtro += " AND Filial like '" + txtFilial1.Text + "%' ";
            filtro += " and Caixa like '%" + txtCaixa1.Text + "%' ";     //Strings de VIEW do DataView
            filtro += " and Cte like '%" + txtCte1.Text + "%' ";
            dv.RowFilter = filtro;   //completa o comando de filtro ao dataview
            dgPlanilha.DataSource = dv.ToTable();  //descarrega o dataview(backend) ao datagridview(UI)
            dgPlanilha.Refresh(); //atualiza o datagridview
        }

        private void exportarPlanilha()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))  //System.IO.Streamwriter -> importei "System.IO" então posso pular direto pro StreamWriter com "using"
                {
                    foreach (DataGridViewRow row in dgPlanilha.Rows) //a cada linha do datagrid
                    {
                        string data = row.Cells[1].Value.ToString().Replace(" 00:00:00", null); //converte data do datagridview para data simples (18/07/1988 00:00:00 -> 18/07/1988)

                        sw.Write(data + ";" + row.Cells[2].Value + ";" + row.Cells[3].Value + ";" + row.Cells[4].Value + ";" + row.Cells[5].Value); //escreve no arquivo o conteudo das celulas nesta linha
                        sw.WriteLine(); //pula linha
                    }
                }
            }
        }

        private void dgPlanilha_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = dgPlanilha.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
            System.Diagnostics.Process.Start(value);
        }
    }
}



