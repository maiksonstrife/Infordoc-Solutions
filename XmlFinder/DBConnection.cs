using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.IO;

namespace XmlFinder
{
    public class DBConnection
    {
        #region objetos sql
        //README: BDConnection.Membro, não usar em escopo global
        //todos objetos SQL precisam de uma conexão aberta "public static SqlConnection obterConexao()", quando fechada eles perdem a referencia pórtanto ficam vazios.
        //no caso do ReadDatabase, ele devolve um sql, esse sql devera ser usado e só depois fechado, caso fechado dentro do metodo ele ficara vazio antes de retornar a quem chamou.
        #endregion

        //Variaveis globais
        public static string connString = @"Data Source=srv2.infordoc.com;Initial Catalog=FolderDoc;User Id=sa;Password=ZXbnlz4N;Trusted_Connection=false;";
        public static SqlConnection conn = null; //Objeto que faz ponte entre c# e sql, possui comandos basicos como UPDATE, INSERT e DELETE
        public static SqlCommand command = null; //objeto que segura comando sql
        public static SqlDataAdapter adapter = new SqlDataAdapter(); //objeto que faz UPDATE (*trocado por using)
        public static SqlDataReader dr = null; //objeto que faz leitura ao banco

        //CRUD
        public static SqlConnection ExecuteQueries(string sqlcommand, params SqlParameter[] parameters)
        {
            Exception erro = null;
            try { 
            conn = obterConexao();
                #region com adapter
                /*command = new SqlCommand(sqlcommand); //Instancio novo comando
                adapter.InsertCommand = new SqlCommand(sqlcommand, conn); //coloco o comando no adaptador
                adapter.InsertCommand.ExecuteNonQuery(); // executa a transacao*/
                #endregion
                using (command = new SqlCommand(sqlcommand, conn))
                {
                    command.CommandType = CommandType.Text;
                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    command.ExecuteNonQuery();
                    MessageBox.Show("Transação efetuada");
                    command.Dispose(); //limpa instancia comando
                    fecharConexao();  //fecha conexão
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fecharConexao();
            }

            if (erro != null)
            {
                throw erro;
            }
            command.Dispose(); //limpa instancia comando
            fecharConexao();  //fecha conexão
            return conn;
        }

        public static SqlDataReader ReadDatabase (string sqlCommand, params SqlParameter[] parameters)
        {
            Exception erro = null;
            try
            {
                conn = obterConexao();
                using (command = new SqlCommand(sqlCommand, conn)) //Armazena comando e realiza conexão
                {
                    command.CommandType = CommandType.Text;
                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    dr = command.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                MessageBox.Show(ex.Message);
            }

            if (erro != null)
            {
                throw erro;
            }

            return dr;
        }

        //HELPERS
        public static SqlConnection obterConexao()
        {
            // vamos criar a conexão
            conn = new SqlConnection(connString);

            // a conexão foi feita com sucesso?
            try
            {
                // abre a conexão e a devolve ao chamador do método
                conn.Open();
            }
            catch (SqlException sqle)
            {
                conn = null;
                // ops! o que aconteceu?
                // uma boa idéia aqui é gravar a exceção em um arquivo de log
            }

            return conn;
        }

        public static void fecharConexao()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static SqlConnection testeConexao()
        {
            if (DBConnection.conn == null)
            {
                MessageBox.Show("Não foi possível obter a conexão. Veja o log de erros.");
            }
            else
            {
                MessageBox.Show("A conexão foi obtida com sucesso.");
            }
            return conn;
        }

    }
}
