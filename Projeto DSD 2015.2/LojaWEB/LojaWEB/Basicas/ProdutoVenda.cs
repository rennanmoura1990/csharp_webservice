using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWEB.Basicas
{
    public class ProdutoVenda
    {
        public ProdutoVenda() { }
        public ProdutoVenda(int qtd_produtovenda,decimal vu_produtovenda,int id_produto,int id_venda)
        {
            this.qtd_produtovenda = Qtd_produtovenda;
            this.vu_produtovenda = Vu_produtovenda;
            this.id_produto = Id_produto;
            this.id_venda = Id_venda;
        }
        private int id_sequencial;

        public int Id_sequencial
        {
            get { return id_sequencial; }
            set { id_sequencial = value; }
        }
        private int qtd_produtovenda;

        public int Qtd_produtovenda
        {
            get { return qtd_produtovenda; }
            set { qtd_produtovenda = value; }
        }
        private decimal vu_produtovenda;

        public decimal Vu_produtovenda
        {
            get { return vu_produtovenda; }
            set { vu_produtovenda = value; }
        }
        private int id_produto;

        public int Id_produto
        {
            get { return id_produto; }
            set { id_produto = value; }
        }
        private int id_venda;

        public int Id_venda
        {
            get { return id_venda; }
            set { id_venda = value; }
        }
        /*private Produto produto;

        public Produto Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        private Venda venda;

        public Venda Venda
        {
            get { return venda; }
            set { venda = value; }
        }*/
    }
}