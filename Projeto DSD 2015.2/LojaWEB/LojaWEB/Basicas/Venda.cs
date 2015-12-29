using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWEB.Basicas
{
    public class Venda
    {
       
        public Venda() { }
        private int id_venda;

        public int Id_venda
        {
            get { return id_venda; }
            set { id_venda = value; }
        }
        private string data_venda;

        public string Data_venda
        {
            get { return data_venda; }
            set { data_venda = value; }
        }
        private decimal valor_venda;

        public decimal Valor_venda
        {
            get { return valor_venda; }
            set { valor_venda = value; }
        }
       
        private int id_cliente;

        public int Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        private int id_funcionario;

        public int Id_funcionario
        {
            get { return id_funcionario; }
            set { id_funcionario = value; }
        }
        private int id_formapag;

        public int Id_formapag
        {
            get { return id_formapag; }
            set { id_formapag = value; }
        }
        /* private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private Funcionario funcionario;

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set { funcionario = value; }
        }
        private FormaPagamento formapag;

        public FormaPagamento Formapag
        {
            get { return formapag; }
            set { formapag = value; }
        }*/
    }
}