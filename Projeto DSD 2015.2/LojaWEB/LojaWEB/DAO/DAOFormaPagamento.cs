using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWEB.Basicas;
using System.Data.SqlClient;

namespace LojaWEB.DAO
{
    public class DAOFormaPagamento : ConexaoSGBD
    {
        #region Insere a Forma de Pagamento
        public void InserirFormaPagamento(FormaPagamento fp)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into formapag (id_formapag,tipo_formapag)\n" +
                    "values("+fp.Id_formapag+",'" + fp.Tipo_formapag + "')";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na Inserção\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }

        }
        #endregion
        #region Alterar Forma de Pagamento
        public void AlterarFormaPagamento(FormaPagamento fp)
        {
            try
            {
                this.abrirConexao();
                string sql = "update formapag set tipo_formapag='" + fp.Tipo_formapag + "'where id_formapag =" + fp.Id_formapag + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na Alteração\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
        }
        #endregion
        #region Excluir Forma de Pagamento por ID
        public void ExcluirFormaPagamento(int id)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from formapag where id_formapag=" + id + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na Exclusão\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
        }
        #endregion
        #region Listar todos as Formas de Pagamento
        public List<FormaPagamento> ListarFormaPagamento()
        {
            List<FormaPagamento> lista = new List<FormaPagamento>();
            try
            {
                this.abrirConexao();
                string sql = "select id_formapag,tipo_formapag from formapag";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    FormaPagamento fp = new FormaPagamento();
                    fp.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    fp.Tipo_formapag = dr.GetString(dr.GetOrdinal("tipo_formapag"));
                    lista.Add(fp);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Formas de Pagamento\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Busca Forma de Pagamento pelo Tipo
        public List<FormaPagamento> BuscaFormaPagamentoTipo(String nome)
        {
            List<FormaPagamento> lista = new List<FormaPagamento>();
            try
            {
                this.abrirConexao();
                string sql = "select id_formapag,tipo_formapag from formapag where tipo_formapag like\n" +
                    "'%" + nome + "%'";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    FormaPagamento fp = new FormaPagamento();
                    fp.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    fp.Tipo_formapag = dr.GetString(dr.GetOrdinal("tipo_formapag"));
                    lista.Add(fp);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Forma de Pagamento\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;

        }
        #endregion
        #region Busca Forma de Pagamento pelo ID
        public List<FormaPagamento> BuscaFormaPagamentoID(int id)
        {
            List<FormaPagamento> lista = new List<FormaPagamento>();
            try
            {
                this.abrirConexao();
                string sql = "select id_formapag,tipo_formapag from formapag where id_formapag=" + id + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    FormaPagamento fp = new FormaPagamento();
                    fp.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    fp.Tipo_formapag = dr.GetString(dr.GetOrdinal("tipo_formapag"));
                    lista.Add(fp);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Forma de Pagamento\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;

        }
        #endregion

    }
}