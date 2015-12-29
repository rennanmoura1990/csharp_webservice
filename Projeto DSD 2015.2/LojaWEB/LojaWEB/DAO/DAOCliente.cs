using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWEB.Basicas;
using System.Data.SqlClient;

namespace LojaWEB.DAO
{
    public class DAOCliente : ConexaoSGBD
    {
        #region Cadastro de Clientes
        public void InserirCliente(Cliente c)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into clientes (id_cliente,nome_cliente,cpf_cliente,rg_cliente,tel_cliente,logradouro_cliente,email_cliente)\n" +
                    "values(" + c.Id_cliente + ",'" + c.Nome_cliente + "','" + c.Cpf_cliente + "','" + c.Rg_cliente + "','" + c.Tel_cliente + "','" + c.Logradouro_cliente + "','" + c.Email_cliente + "')";
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
        #region Alterar Cliente
        public void AlterarCliente(Cliente c)
        {
            try
            {
                this.abrirConexao();
                string sql = "update clientes set nome_cliente='" + c.Nome_cliente + "',cpf_cliente='" + c.Cpf_cliente + "',rg_cliente='" + c.Rg_cliente + "',\n" +
                "tel_cliente='" + c.Tel_cliente + "',logradouro_cliente='" + c.Logradouro_cliente + "',email_cliente='" + c.Email_cliente + "'\n" +
                "where id_cliente =" + c.Id_cliente + "";
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
        #region Excluir Cliente por ID
        public void ExcluirCliente(int id)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from clientes where id_cliente=" + id + "";
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
        #region Listar todos os clientes
        public List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                this.abrirConexao();

                string sql = "select id_cliente,nome_cliente,cpf_cliente,rg_cliente,tel_cliente,logradouro_cliente,email_cliente from clientes";

                SqlCommand comando = new SqlCommand(sql, sqlConn);

                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    Cliente c = new Cliente();

                    c.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    c.Nome_cliente = dr.GetString(dr.GetOrdinal("nome_cliente"));
                    c.Cpf_cliente = dr.GetString(dr.GetOrdinal("cpf_cliente"));
                    c.Rg_cliente = dr.GetString(dr.GetOrdinal("rg_cliente"));
                    c.Tel_cliente = dr.GetString(dr.GetOrdinal("tel_cliente"));
                    c.Logradouro_cliente = dr.GetString(dr.GetOrdinal("logradouro_cliente"));
                    c.Email_cliente = dr.GetString(dr.GetOrdinal("email_cliente"));

                    lista.Add(c);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Clientes " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Busca Clientes pelo Nome
        public List<Cliente> BuscaCliente(String nome)
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                this.abrirConexao();
                string sql = "select id_cliente,nome_cliente,cpf_cliente,rg_cliente,tel_cliente,logradouro_cliente,email_cliente from clientes where nome_cliente like\n" +
                    "'%" + nome + "%'";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Cliente c = new Cliente();
                    c.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    c.Nome_cliente = dr.GetString(dr.GetOrdinal("nome_cliente"));
                    c.Cpf_cliente = dr.GetString(dr.GetOrdinal("cpf_cliente"));
                    c.Rg_cliente = dr.GetString(dr.GetOrdinal("rg_cliente"));
                    c.Tel_cliente = dr.GetString(dr.GetOrdinal("tel_cliente"));
                    c.Logradouro_cliente = dr.GetString(dr.GetOrdinal("logradouro_cliente"));
                    c.Email_cliente = dr.GetString(dr.GetOrdinal("email_cliente"));
                    lista.Add(c);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Cliente\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;

        }
        #endregion
        #region Busca Cliente por ID
        public List<Cliente> BuscaCliente(int id)
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                this.abrirConexao();
                string sql = "select id_cliente,nome_cliente,cpf_cliente,rg_cliente,tel_cliente,logradouro_cliente,email_cliente from clientes where id_cliente=" + id + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Cliente c = new Cliente();
                    c.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    c.Nome_cliente = dr.GetString(dr.GetOrdinal("nome_cliente"));
                    c.Cpf_cliente = dr.GetString(dr.GetOrdinal("cpf_cliente"));
                    c.Rg_cliente = dr.GetString(dr.GetOrdinal("rg_cliente"));
                    c.Tel_cliente = dr.GetString(dr.GetOrdinal("tel_cliente"));
                    c.Logradouro_cliente = dr.GetString(dr.GetOrdinal("logradouro_cliente"));
                    c.Email_cliente = dr.GetString(dr.GetOrdinal("email_cliente"));
                    lista.Add(c);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Cliente\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;

        }
        #endregion
        #region Gera o id do cliente
        /**
         * Nesse metódo,eu pego o código atual da tabela código e depois ele autoincrementa
         * 
         */
        public int GeraIDCliente()
        {
            int retorno = 0;
            try
            {
                this.abrirConexao();
                string sql = "select cliente from codigos;";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {

                    if (dr.IsDBNull(dr.GetOrdinal("cliente")) == false) //se o DataReader nulo for falso
                    {
                        retorno = dr.GetInt32(dr.GetOrdinal("cliente")); //retorna o venda
                    }

                }
                dr.Close(); //fecha o datareader
                dr.Dispose(); //tira ele da memória
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Gerar um ID para o Cliente!\n" + ex.Message);
            }
            finally
            {
                this.fecharConexao();

            }
            return retorno;
        }
        #endregion
        #region Atualiza Geração de ID de Clientes
        public void AtualizaIDCliente()
        {
            try
            {
                this.abrirConexao();
                string sql = "update codigos set cliente = cliente + 1;"; //autoincremento
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
        #region Validações
        /*
         * Verifica o Nome passado.
         * */
        public string VerificarNome(string nome)
        {
            string retorno = null;
            try
            {
                this.abrirConexao();
                Cliente c = new Cliente();
                SqlCommand comando = new SqlCommand("SELECT nome_cliente FROM clientes where nome_cliente = @nome_cliente", sqlConn);
                comando.Parameters.AddWithValue("@nome_cliente",nome);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("nome_cliente")) == false) //se o DataReader nulo for falso
                    {
                        retorno = dr.GetString(dr.GetOrdinal("nome_cliente")); //retorna o venda
                    }

                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar Nome! " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return retorno;
        }
        /**
         * Verifica o CPF passado 
         */
        public string VerificarCPF(string cpf)
        {
            string retorno = null;
            try
            {
                this.abrirConexao();
                Cliente c = new Cliente();
                SqlCommand comando = new SqlCommand("SELECT cpf_cliente FROM clientes where cpf_cliente = @cpf_cliente", sqlConn);
                comando.Parameters.AddWithValue("@cpf_cliente", cpf);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("cpf_cliente")) == false) //se o DataReader nulo for falso
                    {
                        retorno = dr.GetString(dr.GetOrdinal("cpf_cliente")); //retorna o venda
                    }

                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar CPF! " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return retorno;
        }
        /**
         * Verifica o RG passado 
         */
        public string VerificarRG(string rg)
        {
            string retorno = null;
            try
            {
                this.abrirConexao();
                Cliente c = new Cliente();
                SqlCommand comando = new SqlCommand("SELECT rg_cliente FROM clientes where rg_cliente = @rg_cliente", sqlConn);
                comando.Parameters.AddWithValue("@rg_cliente", rg);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("rg_cliente")) == false) //se o DataReader nulo for falso
                    {
                        retorno = dr.GetString(dr.GetOrdinal("rg_cliente")); //retorna o venda
                    }

                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar RG ! " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return retorno;
        }
        /**
         * Verifica Email Passado.
         * */
        public string VerificarEmail(string email)
        {
            string retorno = null;
            try
            {
                this.abrirConexao();
                Cliente c = new Cliente();
                SqlCommand comando = new SqlCommand("SELECT email_cliente FROM clientes where email_cliente = @email_cliente", sqlConn);
                comando.Parameters.AddWithValue("@email_cliente", email);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("email_cliente")) == false) //se o DataReader nulo for falso
                    {
                        retorno = dr.GetString(dr.GetOrdinal("email_cliente")); //retorna o venda
                    }

                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar Email ! " + ex.Message);
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