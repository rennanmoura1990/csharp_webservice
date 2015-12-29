using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWEB.Basicas
{
    public class Produto
    {
        public Produto()
        {

        }
        private int id_produto;

        public int Id_produto
        {
            get { return id_produto; }
            set { id_produto = value; }
        }
        private string nome_produto;

        public string Nome_produto
        {
            get { return nome_produto; }
            set { nome_produto = value; }
        }
        private string marca_produto;

        public string Marca_produto
        {
            get { return marca_produto; }
            set { marca_produto = value; }
        }
        private string tipo_produto;

        public string Tipo_produto
        {
            get { return tipo_produto; }
            set { tipo_produto = value; }
        }
        private decimal valor_produto;

        public decimal Valor_produto
        {
            get { return valor_produto; }
            set { valor_produto = value; }
        }
        private int estoque_produto;

        public int Estoque_produto
        {
            get { return estoque_produto; }
            set { estoque_produto = value; }
        }
        private string detalhe_produto;

        public string Detalhe_produto
        {
            get { return detalhe_produto; }
            set { detalhe_produto = value; }
        }
    }
}