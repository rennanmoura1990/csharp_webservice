using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWEB.Basicas
{
    public class Funcionario
    {
        public Funcionario() { }
       
        private int id_funcionario;

        public int Id_funcionario
        {
            get { return id_funcionario; }
            set { id_funcionario = value; }
        }
        private string nome_funcionario;

        public string Nome_funcionario
        {
            get { return nome_funcionario; }
            set { nome_funcionario = value; }
        }
        private string cargo_funcionario;

        public string Cargo_funcionario
        {
            get { return cargo_funcionario; }
            set { cargo_funcionario = value; }
        }
        private string rg_funcionario;

        public string Rg_funcionario
        {
            get { return rg_funcionario; }
            set { rg_funcionario = value; }
        }
        private string cpf_funcionario;

        public string Cpf_funcionario
        {
            get { return cpf_funcionario; }
            set { cpf_funcionario = value; }
        }
    }
}