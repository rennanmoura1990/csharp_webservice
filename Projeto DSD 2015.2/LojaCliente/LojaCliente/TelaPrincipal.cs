using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LojaCliente
{
    public partial class TelaPrincipal : Form
    {
        
        public TelaPrincipal()
        {
            InitializeComponent();            
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCliente cc = new CadastroCliente();
            cc.Show();
        }

        private void realizarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Realização_da_Venda rv = new Realização_da_Venda();
            rv.Show();
        }

        private void consultarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarVendas cv = new ConsultarVendas();
            cv.Show();
        }
    }
}
