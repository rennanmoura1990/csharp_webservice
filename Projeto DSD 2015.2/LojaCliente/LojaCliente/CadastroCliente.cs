using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaCliente.localhost;
using System.Text.RegularExpressions;

namespace LojaCliente
{
    public partial class CadastroCliente : Form
    {
        Service1 s = new Service1();
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            Service1 s = new Service1 ();
            dataGridView1.DataSource = s.ListarClientes();
            
        }
        #region validações
        /**
         * Aceita Nome e Nome_Nome_...,mas não aceita Nome_ ou Números.
         * */
        public bool Validanome(string nome)
        {
            Regex rgx = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+((\s[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+)+)?$");
            if (rgx.IsMatch(nome))
            {

                return true;
            }
            else
            {
                return false;
            }
                
        }
        /**
         *  No Caso,só validação de formato,usando o regex
         *  Dígito verificador,teria que colocar CPF de verdade...
         * */
        public bool ValidaCpf(string cpf)
        {
                Regex rgx = new Regex(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
                if (rgx.IsMatch(cpf))
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        /**
         * Valida somente o formato de rg.
         * */
        public bool ValidaRg(string rg)
        {
            Regex rgx = new Regex(@"^\d{1}\.\d{3}\.\d{3}$");
            if (rgx.IsMatch(rg))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /**
         * Aceita os dois formatos (00)00000-0000 e (00)0000-0000
         * */
        public bool ValidaTelefone(string telefone)
        {
            Regex rgx1 = new Regex(@"^(\([0-9]{2}\))([9]{1})([0-9]{4})-([0-9]{4})$");
            Regex rgx2 = new Regex(@"^(\([0-9]{2}\))([0-9]{4})-([0-9]{4})$");
            if ((rgx1.IsMatch(telefone)) || (rgx2.IsMatch(telefone)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /**
         * Metodo de Validaçãod e Logradouro (como não há logradouros uniformes,o metódo só verifica se é nulo ou não)
         * */
        public bool ValidaLogradouro(string logradouro)
        {
            if (logradouro == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /**
         * Metodo de Validação de Email
         * */
        public bool ValidaEmail(string email)
        {
            Regex rgx = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (rgx.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region inicia cadastro
        private void BotaoGeraID_Click(object sender, EventArgs e)
        {
            txtIDCliente.Text = Convert.ToString(s.IDClienteGera());
        }
        #endregion
        #region Cadastra Cliente
        private void BotaoCadastrar_Click(object sender, EventArgs e)
        {
            if (Validanome(txtNome.Text) == false)
            {
                MessageBox.Show("Nome Inválido");
                return;
            }
            if (ValidaCpf(txtCPF.Text) == false)
            {
                MessageBox.Show("CPF Inválido! Digite no fomato XXX.XXX.XXX-XX");
                return;
            }
            if (ValidaRg(txtRG.Text) == false)
            {
                MessageBox.Show("RG Inválido! Digite no fomato X.XXX.XXX");
                return;
            }
            if (ValidaTelefone(txtTelefone.Text) == false)
            {
                MessageBox.Show("Telefone Inválido! Digite no Formato (XX)9XXXX-XXXX ou (XX)XXXX-XXXX");
                return;
            }
            if (ValidaLogradouro(txtLogradouro.Text) == false)
            {
                MessageBox.Show("Logradouro inválido!");
                return;
            }
            if (ValidaEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Email Inválido! Digite no Formato");
                return;
            }
            Cliente c = new Cliente();
            c.Id_cliente = Convert.ToInt32(txtIDCliente.Text);
            c.Nome_cliente = txtNome.Text;
            c.Cpf_cliente = txtCPF.Text;
            c.Rg_cliente = txtRG.Text;
            c.Tel_cliente = txtTelefone.Text;
            c.Logradouro_cliente = txtLogradouro.Text;
            c.Email_cliente = txtEmail.Text;
            if (s.VerificaNome(txtNome.Text) !=null)
            {
                MessageBox.Show("Nome Já existe!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (s.VerificaCPF(txtCPF.Text) != null)
            {
                MessageBox.Show("CPF Já existe!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (s.VerificaRG(txtRG.Text) != null)
            {
                MessageBox.Show("RG Já existe!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (s.VerificaEmail(txtEmail.Text) != null)
            {
                MessageBox.Show("Email Já existe!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            s.InserirCliente(c);
            MessageBox.Show("Cliente Cadastrado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            s.AtualizaIDCliente();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = s.ListarClientes();
            BotaoGeraID.Enabled = true;
        }
        #endregion
        #region indicadores de validação
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (Validanome(txtNome.Text) == false)
            {
                txtValidaNome.BackColor = Color.Red;
            }
            else
            {
                txtValidaNome.BackColor = Color.Green;
            }
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            if (ValidaCpf(txtCPF.Text) == false)
            {
                txtValidaCPF.BackColor = Color.Red;
            }
            else
            {
                txtValidaCPF.BackColor = Color.Green;
            }
        }

        private void txtRG_TextChanged(object sender, EventArgs e)
        {
            if (ValidaRg(txtRG.Text) == false)
            {
                txtValidaRG.BackColor = Color.Red;
            }
            else
            {
                txtValidaRG.BackColor = Color.Green;
            }
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            if (ValidaTelefone(txtTelefone.Text) == false)
            {
                txtValidaTelefone.BackColor = Color.Red;
            }
            else
            {
                txtValidaTelefone.BackColor = Color.Green;
            }
        }

        private void txtLogradouro_TextChanged(object sender, EventArgs e)
        {
        if (ValidaLogradouro(txtLogradouro.Text) == false)
            {
                txtValidaLogradouro.BackColor = Color.Red;
            }
            else
            {
                txtValidaLogradouro.BackColor = Color.Green;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
         if (ValidaEmail(txtEmail.Text) == false)
            {
                txtValidaEmail.BackColor = Color.Red;
            }
            else
            {
                txtValidaEmail.BackColor = Color.Green;
            }
        }
        #endregion
        #region passa o valor da linha selecionada pras textboxs
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                if (indice >= 0)
                {
                    txtIDCliente.Text = Convert.ToString(s.ListarClientes()[indice].Id_cliente);
                    txtNome.Text = s.ListarClientes()[indice].Nome_cliente;
                    txtCPF.Text = s.ListarClientes()[indice].Cpf_cliente;
                    txtRG.Text = s.ListarClientes()[indice].Rg_cliente;
                    txtTelefone.Text = s.ListarClientes()[indice].Tel_cliente;
                    txtLogradouro.Text = s.ListarClientes()[indice].Logradouro_cliente;
                    txtEmail.Text = s.ListarClientes()[indice].Email_cliente;
                }
            }
        }
        #endregion
        #region Altera Dados de Cliente Cadastrado
        private void BotaoAlterar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();

            try
            {
                c.Id_cliente = Convert.ToInt32(txtIDCliente.Text);
                c.Nome_cliente = txtNome.Text;
                c.Cpf_cliente = txtCPF.Text;
                c.Rg_cliente = txtRG.Text;
                c.Tel_cliente = txtTelefone.Text;
                c.Logradouro_cliente = txtLogradouro.Text;
                c.Email_cliente = txtEmail.Text;
                s.AlterarCliente(c);
                MessageBox.Show("Cliente Alterado com Sucesso!","Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = s.ListarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Alterar Cliente!\n"+ex.Message+"", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = s.BuscarClienteNome(textBox1.Text);
        }
    }
}
