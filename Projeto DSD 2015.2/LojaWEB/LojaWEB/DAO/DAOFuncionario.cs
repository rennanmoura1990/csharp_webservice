using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWEB.Basicas;
using System.Data.SqlClient;

namespace LojaWEB.DAO
{
    public class DAOFuncionario : ConexaoSGBD
    {
        #region Cadastro de Funcionario
        public void InserirFuncionario(Funcionario f)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into funcionarios (id_funcionario,nome_funcionario,cargo_funcionario,rg_funcionario,cpf_funcionario)\n" +
                    "values("+f.Id_funcionario+",'" + f.Nome_funcionario + "','" + f.Cargo_funcionario + "','" + f.Rg_funcionario + "','" + f.Cpf_funcionario + "');";
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
        #region Alterar Funcionario
        public void AlterarFuncionario(Funcionario f)
        {
            try
            {
                this.abrirConexao();
                string sql = "update funcionarios set nome_funcionario='" + f.Nome_funcionario + "',cargo_funcionario='" + f.Cargo_funcionario + "',rg_funcionario='" + f.Rg_funcionario + "',\n" +
                "cpf_funcionario='" + f.Cpf_funcionario + "'\n" +
                "where id_funcionario =" + f.Id_funcionario + "";
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
        #region Excluir Funcionario por ID
        public void ExcluirFuncionario(int id)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from funcionarios where id_funcionario =" + id + "";
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
        #region Listar todos os Funcionários
        public List<Funcionario> ListarFuncionario()
        {
            List<Funcionario> lista = new List<Funcionario>();
            try
            {
                this.abrirConexao();
                string sql = "select id_funcionario,nome_funcionario,cargo_funcionario,rg_funcionario,cpf_funcionario from funcionarios";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Funcionario f = new Funcionario();
                    f.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    f.Nome_funcionario = dr.GetString(dr.GetOrdinal("nome_funcionario"));
                    f.Cargo_funcionario = dr.GetString(dr.GetOrdinal("cargo_funcionario"));
                    f.Rg_funcionario = dr.GetString(dr.GetOrdinal("rg_funcionario"));
                    f.Cpf_funcionario = dr.GetString(dr.GetOrdinal("cpf_funcionario"));
                    lista.Add(f);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Funcionários\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Buscar Funcionário pelo Nome
        public List<Funcionario> BuscaFuncionarioNome(String nome)
        {
            List<Funcionario> lista = new List<Funcionario>();
            try
            {
                this.abrirConexao();
                string sql = "select id_funcionario,nome_funcionario,cargo_funcionario,rg_funcionario,cpf_funcionario from funcionarios where nome_funcionario like\n"+
                    "'%"+nome+"%'";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Funcionario f = new Funcionario();
                    f.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    f.Nome_funcionario = dr.GetString(dr.GetOrdinal("nome_funcionario"));
                    f.Cargo_funcionario = dr.GetString(dr.GetOrdinal("cargo_funcionario"));
                    f.Rg_funcionario = dr.GetString(dr.GetOrdinal("rg_funcionario"));
                    f.Cpf_funcionario = dr.GetString(dr.GetOrdinal("cpf_funcionario"));
                    lista.Add(f);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Funcionário\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;

        }
        #endregion
        #region Busca Funcionário por ID
        public List<Funcionario> BuscaFuncionarioID(int id)
        {
            List<Funcionario> lista = new List<Funcionario>();
            try
            {
                this.abrirConexao();
                string sql = "select id_funcionario,nome_funcionario,cargo_funcionario,rg_funcionario,cpf_funcionario from funcionarios where id_funcionario=" + id + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Funcionario f = new Funcionario();
                    f.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    f.Nome_funcionario = dr.GetString(dr.GetOrdinal("nome_funcionario"));
                    f.Cargo_funcionario = dr.GetString(dr.GetOrdinal("cargo_funcionario"));
                    f.Rg_funcionario = dr.GetString(dr.GetOrdinal("rg_funcionario"));
                    f.Cpf_funcionario = dr.GetString(dr.GetOrdinal("cpf_funcionario"));
                    lista.Add(f);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Funcionário\n " + ex.Message);
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