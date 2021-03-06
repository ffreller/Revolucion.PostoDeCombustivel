using System;
using System.IO;
using System.Text;

namespace Dominio
{
    public class Produtos : IAcao
    {
        public string produto { get; set; }
        public double preco { get; set; }
        public int estoque { get; set; }

        public Produtos()
        {}
        public Produtos(string produto, double preco, int estoque)
        {
            this.produto = produto;
            this.preco = preco;
            this.estoque = estoque;
        }

        public string Cadastro()
        {
            StreamWriter arquivo = new StreamWriter("Produtos.csv",true);
            string msg = "";
            string composicao = "";
            try
            {
                composicao = "Produto: " + produto + "\nPreço: " + preco + "\nQuantidade em Estoque: " + estoque;
                if(arquivo==null)
                {
                    arquivo.WriteLine("Nome do Produto;Preço;Estoque");
                }
                arquivo.WriteLine(produto + ";" + preco + ";" + estoque);
                msg = "Produto salvo com sucesso!";
            }
            catch(Exception ex)
            {
                msg = "Erro ao tentar salvar o arquivo "+ ex.Message;
            }
            finally
            {
                arquivo.Close();
            }
            Console.WriteLine(msg);
            return composicao;
        }

        public string Consulta()
        {
            StreamReader arquivo = new StreamReader("Produtos.csv", Encoding.Default);
            string linha = "";
            string msg = "";
            string composicao = "";
            try
            {
                while((linha=arquivo.ReadLine())!=null)
                {
                    string[] dados=linha.Split(';');
                    if(dados[0]==produto)
                    {
                        produto = dados[0];
                        preco = Convert.ToDouble(dados[1]);
                        estoque = Convert.ToInt16(dados[2]);
                        msg = "Pesquisa concluída com sucesso!";
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                msg = "Erro na pesquisa "+ ex.Message;
            }
            finally
            {
                arquivo.Close();
            }
            
            composicao = "Produto: " + produto + "\nPreço: " + preco + "\nQuantidade em Estoque: " + estoque;
            Console.WriteLine(msg);
            return composicao;
        }
    }
}
