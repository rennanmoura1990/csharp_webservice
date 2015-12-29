using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWEB.Basicas;
using System.Data.SqlClient;
using System.Data;

namespace LojaWEB.DAO
{
    public class DAOVenda : ConexaoSGBD
    {
        #region Insere a Venda no Banco
        public void InserirVenda(Venda v)
        {
            try
            {
                this.abrirConexao();
                /*string sql = "insert into venda (id_venda,data_venda,valor_venda,id_funcionario,id_cliente,id_formapag) values("+v.Id_venda+",'"+v.Data_venda+"',"+v.Valor_venda+","+ v.Id_funcionario+","+ v.Id_cliente+","+ v.Id_formapag + ");";
                SqlCommand comando = new SqlCommand(sql,sqlConn);*/
                string sql = "insert into venda (id_venda,data_venda,valor_venda,id_funcionario,id_cliente,id_formapag)";
                sql += "values(@id_venda,@data_venda,@valor_venda,@id_funcionario,@id_cliente,@id_formapag)";
                SqlCommand comando = sqlConn.CreateCommand();
                comando.Parameters.AddWithValue("@id_venda", v.Id_venda);
                comando.Parameters.AddWithValue("@data_venda", v.Data_venda);
                comando.Parameters.AddWithValue("@valor_venda", v.Valor_venda);
                comando.Parameters.AddWithValue("@id_funcionario", v.Id_funcionario);
                comando.Parameters.AddWithValue("@id_cliente", v.Id_cliente);
                comando.Parameters.AddWithValue("@id_formapag", v.Id_formapag);
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na Finalização da Venda!\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }

        }
        #endregion
        #region Gera o id da venda atual
        /**
         * Nesse metódo,eu pego o código atual da tabela código e depois ele autoincrementa
         * 
         */
        public int PegarNumeroVenda()
        {
            int retorno = 0;
            try
            {
                this.abrirConexao();
                string sql = "select venda from codigos;";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {

                    if (dr.IsDBNull(dr.GetOrdinal("venda")) == false) //se o DataReader nulo for falso
                    {
                        retorno = dr.GetInt32(dr.GetOrdinal("venda")); //retorna o venda
                    }

                }
                dr.Close(); //fecha o datareader
                dr.Dispose(); //tira ele da memória
                

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Retornar Número da Venda! " + ex.Message);
            }
            finally
            {
                this.fecharConexao();

            }
            return retorno;
        }
        #endregion
        #region Atualizar Número Venda
        public void AtualizaNumeroVenda()
        {
            try
            {
                this.abrirConexao();
                string sql = "update codigos set venda = venda + 1;"; //autoincremento
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.ExecuteNonQuery();
                comando.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Retornar Número da Venda! " + ex.Message);
            }
            finally
            {
                this.fecharConexao();

            }
        }
        
        #endregion
        #region Listagem de Todas as Vendas
        public List<Venda> ListaVendas()
        {
            List<Venda> lista = new List<Venda>();
            try
            {
                this.abrirConexao();
                string sql = "select id_venda,data_venda,valor_venda,id_funcionario,id_cliente,id_formapag from venda";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Venda v = new Venda();
                    v.Id_venda = dr.GetInt32(dr.GetOrdinal("id_venda"));
                    v.Data_venda = dr.GetString(dr.GetOrdinal("data_venda"));
                    v.Valor_venda = dr.GetDecimal(dr.GetOrdinal("valor_venda"));
                    v.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    v.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    v.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    lista.Add(v);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Vendas\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;

        }
        #endregion
        #region Busca Venda por ID
        public List<Venda> BuscaVendas(int id)
        {
            List<Venda> lista = new List<Venda>();
            try
            {
                this.abrirConexao();
                string sql = "select id_venda,data_venda,valor_venda,id_funcionario,id_cliente,id_formapag from venda where id_venda=" + id + "";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Venda v = new Venda();
                    v.Id_venda = dr.GetInt32(dr.GetOrdinal("id_venda"));
                    v.Data_venda = dr.GetString(dr.GetOrdinal("data_venda"));
                    v.Valor_venda = dr.GetDecimal(dr.GetOrdinal("valor_venda"));
                    v.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    v.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    v.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    lista.Add(v);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Venda\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Busca Venda por Data
        public List<Venda> BuscaVendasData(string data)
        {
            List<Venda> lista = new List<Venda>();
            try
            {
                this.abrirConexao();
                string sql = "select id_venda,data_venda,valor_venda,id_funcionario,id_cliente,id_formapag from venda where data_venda like\n"+
                "'%" + data + "%'";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Venda v = new Venda();
                    v.Id_venda = dr.GetInt32(dr.GetOrdinal("id_venda"));
                    v.Data_venda = dr.GetString(dr.GetOrdinal("data_venda"));
                    v.Valor_venda = dr.GetDecimal(dr.GetOrdinal("valor_venda"));
                    v.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    v.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    v.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    lista.Add(v);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Venda\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Busca Venda por Funcionário
        public List<Venda> BuscaVendasFuncionario(int id)
        {
            List<Venda> lista = new List<Venda>();
            try
            {
                this.abrirConexao();
                string sql = "select id_venda,data_venda,valor_venda,id_funcionario,id_cliente,id_formapag from venda where id_funcionario = "+id+"";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Venda v = new Venda();
                    v.Id_venda = dr.GetInt32(dr.GetOrdinal("id_venda"));
                    v.Data_venda = dr.GetString(dr.GetOrdinal("data_venda"));
                    v.Valor_venda = dr.GetDecimal(dr.GetOrdinal("valor_venda"));
                    v.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    v.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    v.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    lista.Add(v);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Vendas por Funcionário\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Busca Venda por Cliente
        public List<Venda> BuscaVendasCliente(int id)
        {
            List<Venda> lista = new List<Venda>();
            try
            {
                this.abrirConexao();
                string sql = "select id_venda,data_venda,valor_venda,id_funcionario,id_cliente,id_formapag from venda where id_cliente = "+id+"";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Venda v = new Venda();
                    v.Id_venda = dr.GetInt32(dr.GetOrdinal("id_venda"));
                    v.Data_venda = dr.GetString(dr.GetOrdinal("data_venda"));
                    v.Valor_venda = dr.GetDecimal(dr.GetOrdinal("valor_venda"));
                    v.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    v.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    v.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    lista.Add(v);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Vendas por Cliente\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Busca Venda por Forma de Pagamento
        public List<Venda> BuscaVendasFormaPag(int id)
        {
            List<Venda> lista = new List<Venda>();
            try
            {
                this.abrirConexao();
                string sql = "select id_venda,data_venda,valor_venda,id_funcionario,id_cliente,id_formapag from venda where id_formapag = "+id+"";
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Venda v = new Venda();
                    v.Id_venda = dr.GetInt32(dr.GetOrdinal("id_venda"));
                    v.Data_venda = dr.GetString(dr.GetOrdinal("data_venda"));
                    v.Valor_venda = dr.GetDecimal(dr.GetOrdinal("valor_venda"));
                    v.Id_funcionario = dr.GetInt32(dr.GetOrdinal("id_funcionario"));
                    v.Id_cliente = dr.GetInt32(dr.GetOrdinal("id_cliente"));
                    v.Id_formapag = dr.GetInt32(dr.GetOrdinal("id_formapag"));
                    lista.Add(v);
                }
                dr.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Vendas por Cliente\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return lista;
        }
        #endregion
        #region Exibe Produtos de um Venda
        public DataSet BuscaProdutosdeVenda(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                this.abrirConexao();
                string sql = "select produtos.nome_produto,produtos.id_produto,produto_venda.qtd_produtovenda,produto_venda.vu_produtovenda\n" +
                    "from produtos inner join produto_venda on produtos.id_produto = produto_venda.id_produto inner join\n" +
                    "venda on produto_venda.id_venda=venda.id_venda GROUP BY produtos.nome_produto,produtos.id_produto,produto_venda.qtd_produtovenda,produto_venda.vu_produtovenda,\n" +
                    "venda.id_venda HAVING venda.id_venda = " + id + "";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlConn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Informações extras da Venda\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return ds;
        }
        #endregion
        #region Exibe Todos Produtos adquiridos por um Cliente
        public DataSet BuscaProdutosdeCliente(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                this.abrirConexao();
                string sql = "select produtos.nome_produto,produto_venda.id_produto,venda.id_venda,venda.data_venda\n" + 
                "from produtos inner join produto_venda on produtos.id_produto = produto_venda.id_produto inner join venda on produto_venda.id_venda = venda.id_venda inner join clientes\n"+
                "on venda.id_cliente = clientes.id_cliente group by produtos.nome_produto,produto_venda.id_produto,venda.id_venda,venda.data_venda,nome_cliente,clientes.id_cliente having clientes.id_cliente = " + id + ";";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlConn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Informações extras de Cliente\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return ds;
        }
        #endregion
        #region Exibe Todos Produtos Vendidos por um Funcionário
        public DataSet BuscaProdutosFuncionario(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                this.abrirConexao();
                string sql = "select produtos.nome_produto,produto_venda.qtd_produtovenda,produto_venda.id_produto,venda.id_venda,venda.data_venda\n" + 
                "from produtos inner join produto_venda on produtos.id_produto = produto_venda.id_produto inner join venda on produto_venda.id_venda = venda.id_venda\n"+
                "inner join funcionarios on venda.id_funcionario = funcionarios.id_funcionario group by produtos.nome_produto,produto_venda.qtd_produtovenda,produto_venda.id_produto,venda.id_venda,venda.data_venda,\n" +
                "funcionarios.nome_funcionario,funcionarios.id_funcionario having funcionarios.id_funcionario = "+id+";";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlConn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Informações extras de Funcionário\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return ds;
        }
        #endregion
        #region Exibe Quando aquela Forma de Pagamento foi Usada
        public DataSet BuscaProdutosFormaPag(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                this.abrirConexao();
                string sql = "select produtos.nome_produto,produto_venda.qtd_produtovenda,produto_venda.id_produto,venda.id_venda,venda.data_venda from produtos\n" + 
                "inner join produto_venda on produtos.id_produto = produto_venda.id_produto inner join venda on produto_venda.id_venda = venda.id_venda inner join formapag on venda.id_formapag = formapag.id_formapag\n"+
                "group by produtos.nome_produto,produto_venda.qtd_produtovenda,produto_venda.id_produto,venda.id_venda,venda.data_venda,formapag.tipo_formapag,formapag.id_formapag having formapag.id_formapag = " + id + ";";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlConn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Informações extras de Forma de Pagamento\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return ds;
        }
        #endregion
        #region Todos os Produtos Vendidos naquele Dia
        public DataSet BuscaProdutosData(string data)
        {
            DataSet ds = new DataSet();
            try
            {
                this.abrirConexao();
                //venda.data_venda,venda.id_venda,
                string sql = "select produtos.nome_produto,produto_venda.id_produto,venda.id_venda,funcionarios.nome_funcionario\n,"+
                "funcionarios.id_funcionario,clientes.nome_cliente,clientes.id_cliente,formapag.tipo_formapag,formapag.id_formapag from produtos\n"+ 
                "inner join produto_venda on produtos.id_produto = produto_venda.id_produto inner join venda on produto_venda.id_venda = venda.id_venda\n"+ 
                "inner join funcionarios on venda.id_funcionario = funcionarios.id_funcionario inner join clientes on venda.id_cliente=clientes.id_cliente\n"+ 
                "inner join formapag on venda.id_formapag = formapag.id_formapag group by produtos.nome_produto,produto_venda.id_produto,venda.data_venda,venda.id_venda,\n"+
                "funcionarios.nome_funcionario,funcionarios.id_funcionario,clientes.nome_cliente,clientes.id_cliente,formapag.tipo_formapag,formapag.id_formapag having data_venda like '%"+data+"%';";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlConn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Buscar Informações extras de Data\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }
            return ds;
        }
        #endregion
    }
}