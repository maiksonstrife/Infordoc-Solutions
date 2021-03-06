﻿using System;
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
        /*Classes publicas com método estaticos podem ser acessados de qualquer outra classe sem precisar instanciar um objeto
         * Para acessar use DBConnection.NomedoMetodo
         */ 

        //Variaveis globais
        public static string connString = @"Data Source=IP;Initial Catalog=DBTeste;User Id=sa;Password=ZXbnlz4N;Trusted_Connection=false;";
        public static SqlConnection conn = null; 
        public static SqlCommand command = null; 
        public static SqlDataAdapter adapter = new SqlDataAdapter();
        public static SqlDataReader dr = null; 

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
