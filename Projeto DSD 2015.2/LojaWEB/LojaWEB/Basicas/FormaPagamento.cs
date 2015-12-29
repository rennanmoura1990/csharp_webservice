using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWEB.Basicas
{
    public class FormaPagamento
    {
        public FormaPagamento()
        {

        }
        
        private int id_formapag;

        public int Id_formapag
        {
            get { return id_formapag; }
            set { id_formapag = value; }
        }
        private string tipo_formapag;

        public string Tipo_formapag
        {
            get { return tipo_formapag; }
            set { tipo_formapag = value; }
        }
    }
}