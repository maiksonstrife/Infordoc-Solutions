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
    public class PlanilhaDAO
    {

        public static void Insert(Planilha planilha)
        {
            string _sqlcommand = "INSERT INTO tbDadosPlan (Data, Filial, Ano, Caixa, Cte) values (@Data, @Filial, @Ano, @Caixa, @Cte)";

            DBConnection.ExecuteQueries(_sqlcommand, new SqlParameter("@Data", planilha.Data), 
                                                     new SqlParameter("@Filial", planilha.Filial), 
                                                     new SqlParameter("@Ano", planilha.Ano), 
                                                     new SqlParameter("@Caixa", planilha.Caixa), 
                                                     new SqlParameter("@Cte", planilha.Protocolo));
        }

        public static SqlDataReader  readPlanilha (string data1, string data2)
        {
            string _sqlcommand = "Select * from tbDadosPlan where Data between @Data1 and @Data2 order by Data";
            SqlDataReader dr = DBConnection.ReadDatabase(_sqlcommand, new SqlParameter("@Data1", data1), new SqlParameter("@Data2", data2));
            return dr;
        }
    }
}