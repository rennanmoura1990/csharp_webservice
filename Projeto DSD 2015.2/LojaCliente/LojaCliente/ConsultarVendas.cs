using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaCliente.localhost;

namespace LojaCliente
{
    public partial class ConsultarVendas : Form
    {
        Service1 s = new Service1();
        public ConsultarVendas()
        {
            InitializeComponent();
            dataGridView1.DataSource = s.ListaVendas();
            comboBox1.DataSource = s.ListarFuncionarios();
            comboBox1.ValueMember = "id_funcionario";
            comboBox1.DisplayMember = "nome_funcionario";
            comboBox2.DataSource = s.ListarClientes();
            comboBox2.ValueMember = "id_cliente";
            comboBox2.DisplayMember = "nome_cliente";
            comboBox3.DataSource = s.ListarFormasPagamento();
            comboBox3.ValueMember = "id_formapag";
            comboBox3.DisplayMember = "tipo_formapag";
            /*comboBoxProdutos.DataSource = s.ListarProdutosDisponiveis();
            comboBoxProdutos.ValueMember = "id_produto";
            comboBoxProdutos.DisplayMember = "nome_produto";*/
        }
        //Como o DateTimePicker também copia a hora,tive que usar uma substring pra copiar somente a data.
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string data = Convert.ToString(dateTimePicker1.Value.Date).Substring(0, 10);
            dataGridView3.DataSource = s.BuscaVendaData(data);
            dataGridView8.DataSource = s.BuscaProdutosData(data).Tables[0];
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Funcionario f = (Funcionario)comboBox1.SelectedItem;
            int id = f.Id_funcionario;
            dataGridView4.DataSource = s.BuscaVendaFuncionario(id);
            dataGridView9.DataSource = s.BuscaProdutoFuncionario(id).Tables[0];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente c = (Cliente)comboBox2.SelectedItem;
            int id = c.Id_cliente;
            dataGridView5.DataSource = s.BuscaVendaCliente(id);
            dataGridView10.DataSource = s.BuscaProdutoCliente(id).Tables[0];
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormaPagamento fp = (FormaPagamento)comboBox3.SelectedItem;
            int id = fp.Id_formapag;
            dataGridView6.DataSource = s.BuscaVendaFormaPag(id);
            dataGridView11.DataSource = s.BuscaProdutosFormpag(id).Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Campo em Branco! Digite algum valor", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int id = Convert.ToInt32(txtID.Text);
            dataGridView2.DataSource = s.BuscaVendaID(id);
            dataGridView7.DataSource = s.BuscaProdutoVenda(id).Tables[0];//DataSet
        }
    }
}
