using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWEB.Basicas;
using System.Data.SqlClient;

namespace LojaWEB.DAO
{
    public class DAOProduto : ConexaoSGBD
    {
        #region Cadastro de Produtos
        public void InserirProduto(Produto p)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into produtos (id_produto,nome_produto,marca_produto,tipo_produto,valor_produto,estoque_produto,detalhe_produto)";
                sql += "values(@id_produto,@nome_produto,@marca_produto,@tipo_produto,@valor_produto,@estoque_produto,@detalhe_produto)";
                SqlCommand comando = sqlConn.CreateCommand();
                comando.Parameters.AddWithValue("@id_produto",p.Id_produto);
                comando.Parameters.AddWithValue("@nome_produto",p.Nome_produto);
                comando.Parameters.AddWithValue("@marca_produto",p.Marca_produto);
                comando.Parameters.AddWithValue("@tipo_produto",p.Tipo_produto);
                comando.Parameters.AddWithValue("@valor_produto",p.Valor_produto);
                comando.Parameters.AddWithValue("@estoque_produto",p.Estoque_produto);
                comando.Parameters.AddWithValue("@detalhe_produto",p.Detalhe_produto);
                comando.CommandText = sql;
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
        #region Altera Produto
        public void AlterarProduto (Produto p)
        {
            try
            {
                this.abrirConexao();
                string sql = "update produtos set nome_produto='"+p.Nome_produto+"',marca_produto='" + p.Marca_produto + "',tipo_produto='" + p.Tipo_produto + "',valor_produto=" + p.Valor_produto + ",\n" +
                "estoque_produto="+ p.Estoque_produto+",detalhe_produto = "+p.Detalhe_produto+"\n" +
                "where id_produto =" + p.Id_produto + "";
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
        #region Excluir Produto por ID
        public void ExcluirProduto(int id)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from produtos where id_produto =" + id + "";
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
        #region Listar todos os Produtos (Independente de Disponivéis,ou não)
        public List<Produto> ListarProduto()
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                this.abrirConexao();
                string sql = "select id_produto,nome_produto,marca_produto,tipo_produto,valor_produto,estoque_produto,detalhe_produto from produtos";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Produto p = new Produto();
                    p.Id_produto = dr.GetInt32(dr.GetOrdinal("id_produto"));
                    p.Nome_produto = dr.GetString(dr.GetOrdinal("nome_produto"));
                    p.Marca_produto = dr.GetString(dr.GetOrdinal("marca_produto"));
                    p.Tipo_produto = dr.GetString(dr.GetOrdinal("tipo_produto"));
                    p.Valor_produto = dr.GetDecimal(dr.GetOrdinal("valor_produto"));
                    p.Estoque_produto = dr.GetInt32(dr.GetOrdinal("estoque_produto"));
                    p.Detalhe_produto = dr.GetString(dr.GetOrdinal("detalhe_produto"));
                    lista.Add(p);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Produtos\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Buscar Produto por Nome
        public List<Produto> BuscarProdutoNome(string nome)
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                this.abrirConexao();
                string sql = "select id_produto,nome_produto,marca_produto,tipo_produto,valor_produto,estoque_produto,detalhe_produto from produtos where nome_produto like\n" +
                    "'%"+nome+"%'";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Produto p = new Produto();
                    p.Id_produto = dr.GetInt32(dr.GetOrdinal("id_produto"));
                    p.Nome_produto = dr.GetString(dr.GetOrdinal("nome_produto"));
                    p.Marca_produto = dr.GetString(dr.GetOrdinal("marca_produto"));
                    p.Tipo_produto = dr.GetString(dr.GetOrdinal("tipo_produto"));
                    p.Valor_produto = dr.GetDecimal(dr.GetOrdinal("valor_produto"));
                    p.Estoque_produto = dr.GetInt32(dr.GetOrdinal("estoque_produto"));
                    p.Detalhe_produto = dr.GetString(dr.GetOrdinal("detalhe_produto"));
                    lista.Add(p);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Produtos\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Buscar Produto por id
        public List<Produto> BuscarProdutoID(int id)
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                this.abrirConexao();
                string sql = "select id_produto,nome_produto,marca_produto,tipo_produto,valor_produto,estoque_produto,detalhe_produto from produtos where id_produto=" + id + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Produto p = new Produto();
                    p.Id_produto = dr.GetInt32(dr.GetOrdinal("id_produto"));
                    p.Nome_produto = dr.GetString(dr.GetOrdinal("nome_produto"));
                    p.Marca_produto = dr.GetString(dr.GetOrdinal("marca_produto"));
                    p.Tipo_produto = dr.GetString(dr.GetOrdinal("tipo_produto"));
                    p.Valor_produto = dr.GetDecimal(dr.GetOrdinal("valor_produto"));
                    p.Estoque_produto = dr.GetInt32(dr.GetOrdinal("estoque_produto"));
                    p.Detalhe_produto = dr.GetString(dr.GetOrdinal("detalhe_produto"));
                    lista.Add(p);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Produtos\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Listar todos os Produtos Disponíveis
        public List<Produto> ListarProdutoDisponiveis()
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                this.abrirConexao();
                string sql = "select id_produto,nome_produto,marca_produto,tipo_produto,valor_produto,estoque_produto,detalhe_produto from produtos where estoque_produto > 0";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Produto p = new Produto();
                    p.Id_produto = dr.GetInt32(dr.GetOrdinal("id_produto"));
                    p.Nome_produto = dr.GetString(dr.GetOrdinal("nome_produto"));
                    p.Marca_produto = dr.GetString(dr.GetOrdinal("marca_produto"));
                    p.Tipo_produto = dr.GetString(dr.GetOrdinal("tipo_produto"));
                    p.Valor_produto = dr.GetDecimal(dr.GetOrdinal("valor_produto"));
                    p.Estoque_produto = dr.GetInt32(dr.GetOrdinal("estoque_produto"));
                    p.Detalhe_produto = dr.GetString(dr.GetOrdinal("detalhe_produto"));
                    lista.Add(p);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Produtos\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Dar baixa no estoque
        public void BaixaEstoque(int baixa,int id)
        {
            try
            {
                this.abrirConexao();
                string sql = "update produtos set estoque_produto = estoque_produto-" + baixa + "where id_produto = "+id+"";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao dar baixa no estoque!\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
        }
        #endregion
        #region Verifica Estoque (Para que não se digite uma quantidade de produto maior que o estoque)
        public int VerificaEstoque(int id)
        {
            int retorno = 0;
            try
            {
                this.abrirConexao();
                string sql = "select estoque_produto from produtos where id_produto = "+id+"";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("estoque_produto")) == false)
                    {
                        retorno = dr.GetInt32(dr.GetOrdinal("estoque_produto"));
                    }
                }
                dr.Close();
                dr.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Não foi possivel Retornar quantidade do produto no estoque!" +ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return retorno;
        }
        #endregion
        #region Volta do Produto ao Estoque
        public void VoltaEstoque(int volta, int id)
        {
            try
            {
                this.abrirConexao();
                string sql = "update produtos set estoque_produto = estoque_produto +" + volta + "where id_produto = " + id + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao voltar produto ao estoque!\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
        }
        #endregion
        #region Detalhar Produto
        public string DetalharProduto(int id)
        {
            string retorno="";
            try
            {
                this.abrirConexao();
                string sql = "select detalhe_produto from produtos where id_produto = " + id + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("detalhe_produto")) == false) //se o DataReader nulo for falso
                    {
                        retorno = dr.GetString(dr.GetOrdinal("detalhe_produto")); //retorna o venda
                    }
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Detalhar o Produto\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return retorno;
        }
        #endregion
    }
}