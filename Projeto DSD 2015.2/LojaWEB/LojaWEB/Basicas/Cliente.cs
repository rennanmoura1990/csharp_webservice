using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWEB.Basicas
{
    public class Cliente
    {
        public Cliente()
        {

        }
        private int id_cliente;

        public int Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        private string nome_cliente;

        public string Nome_cliente
        {
            get { return nome_cliente; }
            set { nome_cliente = value; }
        }
        private string cpf_cliente;

        public string Cpf_cliente
        {
            get { return cpf_cliente; }
            set { cpf_cliente = value; }
        }
        private string rg_cliente;

        public string Rg_cliente
        {
            get { return rg_cliente; }
            set { rg_cliente = value; }
        }
        private string tel_cliente;

        public string Tel_cliente
        {
            get { return tel_cliente; }
            set { tel_cliente = value; }
        }
        private string logradouro_cliente;

        public string Logradouro_cliente
        {
            get { return logradouro_cliente; }
            set { logradouro_cliente = value; }
        }
        private string email_cliente;

        public string Email_cliente
        {
            get { return email_cliente; }
            set { email_cliente = value; }
        }
    
    }
}