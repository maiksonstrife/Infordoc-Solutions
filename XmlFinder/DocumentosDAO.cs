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
    class DocumentosDAO
    {

        public static void Insert(Documentos documento)
        {
            string _sqlcommand = "INSERT INTO tbdocumentos (NomeIndexador1, NomeIndexador2, NomeIndexador3, NomeIndexador4, NomeIndexador5, NomeIndexador6, NomeArquivo, URL, DataEnvio) values (@NomeIndexador1, @NomeIndexador2, @NomeIndexador3, @NomeIndexador4, @NomeIndexador5, @NomeIndexador6, @NomeArquivo, @URL, @DataEnvio)";
            DBConnection.ExecuteQueries(_sqlcommand, new SqlParameter("@NomeIndexador1", documento.GetIndice(0)), new SqlParameter("@NomeIndexador2", documento.GetIndice(1)), new SqlParameter("@NomeIndexador3", documento.GetIndice(2)), new SqlParameter("@NomeIndexador4", documento.GetIndice(3)), new SqlParameter("@NomeIndexador5", documento.GetIndice(4)), new SqlParameter("@NomeIndexador6", documento.GetIndice(5)), new SqlParameter("@NomeArquivo", documento.nomeDocumento), new SqlParameter("@URL", documento.url), new SqlParameter("@DataEnvio", documento.data));
        }

        public static SqlDataReader Read(string data1, string data2)
        {
            string _sqlcommand = "Select * from tbdocumentos";
            SqlDataReader dr = DBConnection.ReadDatabase(_sqlcommand, new SqlParameter("@Data1", data1), new SqlParameter("@Data2", data2));
            return dr;
        }

    }
}
