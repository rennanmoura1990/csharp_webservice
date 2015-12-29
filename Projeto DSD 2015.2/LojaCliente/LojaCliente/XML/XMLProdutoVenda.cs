using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace LojaCliente.XML
{
    public class XMLProdutoVenda
    {
        #region Cria o Arquivo XML da Venda Atual
        public void criaArquivo(string id,string fun,string cli,string formapag)
        {
            
            try
            {
                string pasta = @"C:\backupvendas"; //nome do diretorio a ser criado

                //Se o diretório não existir...

                if (!Directory.Exists(pasta))
                {

                    //Criamos um com o nome folder
                    Directory.CreateDirectory(pasta);

                }
              string caminho = @"c:\backupvendas\VendaID"+id+".xml";
              XmlDocument doc = new XmlDocument();
              XmlNode raiz = doc.CreateElement("Venda");
              string dia = Convert.ToString(DateTime.Now.Day);
              string mes = Convert.ToString(DateTime.Now.Month);
              string ano = Convert.ToString(DateTime.Now.Year);
              string hora = Convert.ToString(DateTime.Now.Hour);
              string minuto = Convert.ToString(DateTime.Now.Minute);
              XmlNode vendadata = doc.CreateElement("VendaID_" + id + "_Data_" + dia + "_" + mes + "_" + ano + "_Hora_"+hora+"-"+minuto+"");
              XmlNode info = doc.CreateElement("FuncionárioID_" + fun + "_ClienteID_" + cli + "_FormadePagamentoID_" + formapag + ""); 
              doc.AppendChild(raiz);
              raiz.AppendChild(vendadata);
              raiz.AppendChild(info);
              doc.Save(caminho);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao criar XML : " + ex.Message);
            }
        }
        #endregion
        public void AdicionaItens(string qtd,string vu,string id_produto,string id_venda)
        {
            
            try
            {
                //Abre o Arquivo
                string caminho = @"c:\backupvendas\VendaID"+id_venda+".xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(caminho);
                // Adiciona os Nós
                XmlNode Produtos = doc.CreateElement("lista_compras");
                XmlNode Quantidade = doc.CreateElement("quantidade");
                XmlNode ValorUnitario = doc.CreateElement("valor_unitario");
                XmlNode IdProduto = doc.CreateElement("id_produto");
                XmlNode IdVenda = doc.CreateElement("id_venda");
                //Colocando Valores
                Quantidade.InnerText = qtd;
                ValorUnitario.InnerText = vu;
                IdProduto.InnerText = id_produto;
                IdVenda.InnerText = id_venda;
                //Definindo a Hierarquia
                Produtos.AppendChild(Quantidade);
                Produtos.AppendChild(ValorUnitario);
                Produtos.AppendChild(IdProduto);
                Produtos.AppendChild(IdVenda);
                //adicionando elementos ao meú nó raiz
                doc.SelectSingleNode("/Venda").AppendChild(Produtos);
                doc.Save(caminho);
                //A Mensagem de Sucesso,coloco quando chamar o metódo no Form.
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao abrir arquivo XML! " +ex.Message);
            }  
        }

    }
}
