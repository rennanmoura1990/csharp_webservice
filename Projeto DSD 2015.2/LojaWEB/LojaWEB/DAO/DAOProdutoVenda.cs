using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWEB.Basicas;
using System.Data.SqlClient;
using System.Data;

namespace LojaWEB.DAO
{
    public class DAOProdutoVenda : ConexaoSGBD
    {
        #region Inserção de Produtos da Venda
        public void InserirProdutoVenda(ProdutoVenda pv)
        {
            try
            {
                this.abrirConexao();
                /*string sql = "insert into produto_venda (qtd_produtovenda,vu_produtovenda,vt_produtovenda,id_produto,id_venda)\n" +
                    "values("+pv.Qtd_produtovenda+"," + pv.Vu_produtovenda + "," + pv.Vt_produtovenda + "," + pv.Id_produto + "," + pv.Id_venda + ")";*/
                string sql = "insert into produto_venda (qtd_produtovenda,vu_produtovenda,id_produto,id_venda)";
                sql += "values(@qtd_produtovenda,@vu_produtovenda,@id_produto,@id_venda)";
                SqlCommand comando = sqlConn.CreateCommand();
                comando.CommandText = sql;
                comando.Parameters.AddWithValue("@qtd_produtovenda", pv.Qtd_produtovenda);
                comando.Parameters.AddWithValue("@vu_produtovenda", pv.Vu_produtovenda);
                comando.Parameters.AddWithValue("@id_produto", pv.Id_produto);
                comando.Parameters.AddWithValue("@id_venda",pv.Id_venda);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na Inserção dos Produtos da Venda\n " + ex.Message);
            }
            finally
            {
                this.fecharConexao();
            }

        }
        #endregion
        

    }
}