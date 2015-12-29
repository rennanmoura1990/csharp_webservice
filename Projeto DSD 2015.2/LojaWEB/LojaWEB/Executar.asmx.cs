using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LojaWEB.DAO;
using LojaWEB.Basicas;
using System.Data;

namespace LojaWEB
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        #region Metódos dos Clientes
        DAOCliente dc = new DAOCliente();
        [WebMethod]
        public void InserirCliente(Cliente c)
        {
            dc.InserirCliente(c);
        }
        [WebMethod]
        public void AlterarCliente(Cliente c)
        {
            dc.AlterarCliente(c);
        }
        [WebMethod]
        public void ExcluirCliente(int id)
        {
            dc.ExcluirCliente(id);
        }
        [WebMethod]
        public List<Cliente> ListarClientes()
        {
            return dc.ListarClientes();
        }
        [WebMethod]
        public List<Cliente> BuscarClienteNome(string nome)
        {
            return dc.BuscaCliente(nome);
        }
        [WebMethod]
        public List<Cliente> BuscarClienteID(int id)
        {
            return dc.BuscaCliente(id);
        }
        [WebMethod]
        public int IDClienteGera()
        {
            return dc.GeraIDCliente();
        }
        [WebMethod]
        public void AtualizaIDCliente()
        {
            dc.AtualizaIDCliente();
        }
        [WebMethod]
        public string VerificaNome(string nome)
        {
            return dc.VerificarNome(nome);
        }
        [WebMethod]
        public string VerificaCPF(string cpf)
        {
            return dc.VerificarCPF(cpf);
        }
        [WebMethod]
        public string VerificaRG(string rg)
        {
            return dc.VerificarRG(rg);
        }
        [WebMethod]
        public string VerificaEmail(string email)
        {
            return dc.VerificarEmail(email);
        }
        # endregion
        #region Metódos dos Funcionários
        DAOFuncionario df = new DAOFuncionario();
        [WebMethod]
        public List<Funcionario> ListarFuncionarios()
        {
            return df.ListarFuncionario();
        }
        #endregion
        #region Metódos das Formas de Pagamento
        DAOFormaPagamento dfp = new DAOFormaPagamento();
        [WebMethod]
        public List<FormaPagamento> ListarFormasPagamento() 
        {
            return dfp.ListarFormaPagamento();
        }
        #endregion
        #region Metódos dos Produtos
        DAOProduto dp = new DAOProduto();
        [WebMethod]
        public List<Produto> ListarProdutos()
        {
            return dp.ListarProduto();
        }
        [WebMethod]
        public List<Produto> ListarProdutosDisponiveis()
        {
            return dp.ListarProdutoDisponiveis();
        }
        [WebMethod]
        public int VerificarEstoque(int id)
        {
            return dp.VerificaEstoque(id);
        }
        [WebMethod]
        public void DarBaixaEstoque(int baixa, int id)
        {
            dp.BaixaEstoque(baixa, id);
        }
        [WebMethod]
        public string DetalharProduto(int id)
        {
            return dp.DetalharProduto(id);
        }
        #endregion
        #region Metódos da Venda
        DAOVenda dv = new DAOVenda();
        [WebMethod]
        public void InserirVenda(Venda v)
        {
            dv.InserirVenda(v);
        }
        [WebMethod]
        public int ExibirVenda()
        {
            return dv.PegarNumeroVenda();
        }
        [WebMethod]
        public void AtualizaVenda()
        {
            dv.AtualizaNumeroVenda();
        }
        [WebMethod]
        public List<Venda>ListaVendas()
        {
            return dv.ListaVendas();
        }
        [WebMethod]
        public List<Venda>BuscaVendaID(int id)
        {
            return dv.BuscaVendas(id);
        }
        [WebMethod]
        public List<Venda> BuscaVendaData(string data)
        {
            return dv.BuscaVendasData(data);
        }
        [WebMethod]
        public List<Venda> BuscaVendaFuncionario(int id)
        {
            return dv.BuscaVendasFuncionario(id);
        }
        [WebMethod]
        public List<Venda> BuscaVendaCliente(int id)
        {
            return dv.BuscaVendasCliente(id);
        }
        [WebMethod]
        public List<Venda> BuscaVendaFormaPag(int id)
        {
            return dv.BuscaVendasFormaPag(id);
        }
        [WebMethod]
        public DataSet BuscaProdutoVenda(int id)
        {
            return dv.BuscaProdutosdeVenda(id);
        }
        [WebMethod]
        public DataSet BuscaProdutoCliente(int id)
        {
            return dv.BuscaProdutosdeCliente(id);
        }
        [WebMethod]
        public DataSet BuscaProdutoFuncionario(int id)
        {
            return dv.BuscaProdutosFuncionario(id);
        }
        [WebMethod]
        public DataSet BuscaProdutosFormpag(int id)
        {
            return dv.BuscaProdutosFormaPag(id);
        }
        [WebMethod]
        public DataSet BuscaProdutosData(string data)
        {
            return dv.BuscaProdutosData(data);
        }
        #endregion 
        #region Metódos de Produtos da Venda
        DAOProdutoVenda dpv = new DAOProdutoVenda();
        [WebMethod]
        public void InserirProdutoVenda(ProdutoVenda pv)
        {
            dpv.InserirProdutoVenda(pv);
        }
        
        #endregion
        

    }
}