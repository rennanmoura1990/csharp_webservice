using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaCliente.localhost;
using LojaCliente.XML;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace LojaCliente
{
    public partial class Realização_da_Venda : Form
    {
        Service1 s = new Service1();
        BindingList<ProdutoVenda> listaprodutos = new BindingList<ProdutoVenda>(); //o List só exibia o 1º item no datagrid,esse (BindingList),exibe normal
        //List<ProdutoVenda> listaprodutos = new List<ProdutoVenda>();
        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;
        private TcpClient tcpClient;
        private Thread thread;


        public Realização_da_Venda()
        {
            InitializeComponent();
            //Fica rodando o Socket Cliente
            thread = new Thread(new ThreadStart(RunClient));
            thread.Start();
        }
        #region Inicia a Venda
        /**
         * Ao clicar no botão :
         * Bloquea o adicionar venda,para não ficar autoincrementando
         * Seta o Groupbox da Venda como Visivel (ele está toda parte de comboxs e datagrid)
         * Seta o Botão Finalizar Venda como Visivel
         * Joga o código na venda no textbox da venda
         */
        private void BotaoIniciaVenda_Click(object sender, EventArgs e)
        {
            try
            {
                txtIDVenda.Text = Convert.ToString(s.ExibirVenda());
                BotaoIniciaVenda.Enabled = false;
                groupBoxVenda.Visible = true;
                BotaoFinalizaVenda.Visible = true;
                BotaoFinalizaVenda.Enabled = false;
                BotaoAutorizacao.Visible = true;
                /**
                 * Popular ComboBoxs (Bindsource = atualiza listas)
                 * */
                comboBoxCliente.DataSource = s.ListarClientes();
                comboBoxCliente.ValueMember = "id_cliente";
                comboBoxCliente.DisplayMember = "nome_cliente";
                comboBoxFuncionario.DataSource = s.ListarFuncionarios();
                comboBoxFuncionario.ValueMember = "id_funcionario";
                comboBoxFuncionario.DisplayMember = "nome_funcionario";
                comboBoxFormaPag.DataSource = s.ListarFormasPagamento();
                comboBoxFormaPag.ValueMember = "id_formapag";
                comboBoxFormaPag.DisplayMember = "tipo_formapag";
                comboBoxProdutos.DataSource = s.ListarProdutosDisponiveis();
                comboBoxProdutos.ValueMember = "id_produto";
                comboBoxProdutos.DisplayMember = "nome_produto";
            }
            catch
            {
                MessageBox.Show("Erro na Inicialização da Venda!\nVerifique a Conexão com o WebService e/ou com o Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region adicionando produtos
        private void BotaoAdicionarProduto_Click(object sender, EventArgs e)
        {
            int estoque = 0; //recebe a quantidade de estoque de um produto x
            Produto p = new Produto();
            ProdutoVenda pv = new ProdutoVenda();
            p = (Produto)comboBoxProdutos.SelectedItem; //Faz Cast com o objeto Produto
            if (txtQtd.Text == string.Empty)
            {
                MessageBox.Show("Digite a Quantidade!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQtd.Focus();
                return;
            }
            pv.Qtd_produtovenda = Convert.ToInt32(txtQtd.Text);
            pv.Vu_produtovenda = Convert.ToDecimal(txtPreco.Text);
            pv.Id_venda = Convert.ToInt32(txtIDVenda.Text);
            pv.Id_produto = p.Id_produto;
            //insere o id do produto que será adicionado no metódo.
            estoque = s.VerificarEstoque(pv.Id_produto);
            //verifica se a quantidade digitada do produto é maior com a existente em estoque
            if (pv.Qtd_produtovenda > estoque)
            {
                MessageBox.Show("A quantidade digitada é maior do que há no estoque!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("O produto " + p.Nome_produto + ",possue a quantidade de " + p.Estoque_produto + " em estoque!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQtd.Focus();
                return;

            }
            listaprodutos.Add(pv);
            dataGridView1.DataSource = listaprodutos;
            CalculaValor();
        }
        #endregion
        #region Calcula o Valor total da venda
        //Faz a soma de todos os produtos da lista e joga para um label
        private void CalculaValor()
        {
            Decimal valorvenda = 0.00M;
            Decimal multiplica = 0.00M;
            foreach (ProdutoVenda produtos in listaprodutos)
            {
                multiplica = produtos.Vu_produtovenda * produtos.Qtd_produtovenda;
                valorvenda = valorvenda + multiplica;
            }
            labelvalor.Text = Convert.ToString(valorvenda);
        }
        #endregion
        #region Joga o valor e quantidade em estoque do produto em uma textbox
        //preenche textbox do preço com o preço do produto selecionado na combobox de produtos
		//preenche textbox da quantidade de estoque com o estoque do produto selecionado da combobox de produtos
        private void comboBoxProdutos_SelectedIndexChanged(object sender, EventArgs e) //Joga o valor do produto na textbox do preço
        {
            Produto p = new Produto();
            p = (Produto)comboBoxProdutos.SelectedItem;
            txtPreco.Text = Convert.ToString(p.Valor_produto);
            txtEstoque.Text = Convert.ToString(p.Estoque_produto);
        }
        #endregion
        #region Exclui produtos da venda
        //Exclui Produto da Lista
        private void BotaoExcluirProduto_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                try
                {
                    int indice = dataGridView1.SelectedRows[0].Index;
                    //MessageBox.Show(""+indice+""); Verifica o indice do datagrid
                    listaprodutos.Remove(listaprodutos[indice]);
                    CalculaValor();
                }
                catch
                {
                    MessageBox.Show("Para excluir,uma linha inteira deve ser selecionada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion
        #region Finalizando a Venda
        private void BotaoFinalizaVenda_Click(object sender, EventArgs e)
        {
            //Verifica se DataGrid dos produtos da venda,está vazio
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Lista de Produtos Vazia!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Desabilita Botões de Adicionar e Excluir Produto,para não dá erro no Label do valor final
            BotaoAdicionarProduto.Enabled = false;
            BotaoExcluirProduto.Enabled = false;
            try
            {
                //Instâncias e Casts necessários
                XMLProdutoVenda xpv = new XMLProdutoVenda();
                Funcionario f = new Funcionario();
                f = (Funcionario)comboBoxFuncionario.SelectedItem;
                Cliente c = new Cliente();
                c = (Cliente)comboBoxCliente.SelectedItem;
                FormaPagamento fp = new FormaPagamento();
                fp = (FormaPagamento)comboBoxFormaPag.SelectedItem;
                ProdutoVenda pv = new ProdutoVenda();
                Produto p = new Produto();
                //Cria Arquivo XML de Backup
                xpv.criaArquivo(txtIDVenda.Text, Convert.ToString(f.Id_funcionario), Convert.ToString(c.Id_cliente), Convert.ToString(fp.Id_formapag));
                Venda v = new Venda();
                v.Id_venda = Convert.ToInt32(txtIDVenda.Text);
                v.Data_venda = Convert.ToString(DateTime.Now);
                v.Valor_venda = Convert.ToDecimal(labelvalor.Text);
                v.Id_funcionario = f.Id_funcionario;
                v.Id_cliente = c.Id_cliente;
                v.Id_formapag = fp.Id_formapag;
                //insere a venda
                s.InserirVenda(v);
                //insere os itens da venda de acordo com o pecorrimento do List listaprodutos.
                foreach (ProdutoVenda produto in listaprodutos)
                {
                    pv.Qtd_produtovenda = produto.Qtd_produtovenda;
                    pv.Vu_produtovenda = produto.Vu_produtovenda;
                    pv.Id_produto = produto.Id_produto;
                    pv.Id_venda = produto.Id_venda;
                    //Salvando no XML
                    xpv.AdicionaItens(Convert.ToString(pv.Qtd_produtovenda), Convert.ToString(pv.Vu_produtovenda), Convert.ToString(pv.Id_produto), Convert.ToString(pv.Id_venda));
                    //Salvando no Banco
                    s.InserirProdutoVenda(pv);
                    //Agora dou baixa no estoque
                    s.DarBaixaEstoque(pv.Qtd_produtovenda, pv.Id_produto);
                    s.AtualizaVenda();
                }
                MessageBox.Show("Venda Realizada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Realizar Venda!\n" + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region socket

        string mensagem = "";
        public void RunClient()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect("127.0.0.1", 2001); //conecta no servidor
                networkStream = tcpClient.GetStream();
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);
                //receber mensagem do servidor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Conectar ao Servidor! \nFavor Fechar o Programa e Reiniciar o Servidor\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region pedir autorização
        private void BotaoAutorizacao_Click(object sender, EventArgs e)
        {
            string message = "";
            Funcionario f = new Funcionario();
            f = (Funcionario)comboBoxFuncionario.SelectedItem;
            try
            {
                binaryWriter.Write("Funcionário : " + f.Nome_funcionario + ",requer autorização para finalizar venda " + txtIDVenda.Text + "");
                //Neste Laço Do While,o programa fica aguardando pela resposta do gerente (LojaSever)
				do
                {
                    try
                    {
                        message = binaryReader.ReadString();
                        mensagem = message;
                        MessageBox.Show(message, "Mensagem do Gerente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (mensagem == "Autorizado")
                        {
                            BotaoFinalizaVenda.Enabled = true;
                            linkLabel1.Enabled = true;
                            message = "FIM";
                            return;
                        }
                        if (mensagem == "Desautorizado")
                        {
                            //BotaoFinalizaVenda.Enabled = false;
                            MessageBox.Show("Venda não autorizada!\nFormulário será fechado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            message = "FIM";
                            ActiveForm.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Conexão com o Servidor interrompida de forma abrupta!\n" + ex.Message, "Erro");
                        message = "FIM";
                        ActiveForm.Close();
                    }
                } while (message != "FIM");
                binaryWriter.Close();
                binaryReader.Close();
                networkStream.Close();
                tcpClient.Close();
            }
            catch (SocketException sex)
            {
                MessageBox.Show("Erro na Comunicação!\n" + sex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcpClient.Close();

            }
            catch (ObjectDisposedException odex)
            {
                MessageBox.Show("Verifique a Conectividade com o Programa Server e Reinicie a Venda!\n" + odex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcpClient.Close();
                ActiveForm.Close();

            }
            catch (NullReferenceException nrex)
            {
                MessageBox.Show("Verifique a Conectividade com o Programa Server e Reinicie a Venda!\n" + nrex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcpClient.Close();
                ActiveForm.Close();
            }
        }
        #endregion
        #region indo para o cadastro de cliente
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCliente cc = new CadastroCliente();
            cc.Show();
        }
        #endregion
        #region Abre a Consulta de Vendas
        private void BotaoConsultarVendas_Click(object sender, EventArgs e)
        {
            ConsultarVendas cv = new ConsultarVendas();
            cv.Show();
        }
        #endregion
        #region atualiza minha combobox de clientes
		//Depois de cadastrar o cliente,e necessário fazer essa operação,de clicar no botão de atualizar
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            comboBoxCliente.DataSource = null;
            comboBoxCliente.DataSource = s.ListarClientes();
            comboBoxCliente.ValueMember = "id_cliente";
            comboBoxCliente.DisplayMember = "nome_cliente";
        }
        #endregion
    }
}


