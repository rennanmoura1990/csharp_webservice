using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LojaWEB
{
    public class ConexaoSGBD
    {
        #region connection string
        //http://www.connectionstrings.com/
        #region variáveis
        public SqlConnection sqlConn;
        #endregion
        //string de conexão obtida para o sql sever
        /*string connectionStringSqlServer = @"Server =PC-589;database=lojadb;user id=aluno;Password=aluno;";*/
        string connectionStringSqlServer = @"Server =RENNAN\SQLEXPRESS;database= lojadb;user id= sa;Password= 12345;";
        public void abrirConexao()
        {
            try
            {
                //iniciando uma conexão com o sql server, utilizando os parâmetros da string de conexão
                this.sqlConn = new SqlConnection(connectionStringSqlServer);
                //abrindo a conexão com a base de dados
                this.sqlConn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Conectar ao Banco de Dados!" + ex.Message);
            }
        }
        public void fecharConexao()
        {
            //fechando a conexao com a base de dados
            sqlConn.Close();
            //liberando a conexao da memoria
            sqlConn.Dispose();
        }
        #endregion
    }
}