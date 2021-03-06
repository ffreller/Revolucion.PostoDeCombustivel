using System;
using System.IO;
using System.Text;

namespace Dominio
{
    public class Vendas : IAcao
    {
        
        public string Produto { get; set; }
        public double Volume { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }

        public Vendas(string Produto, double Volume, double Valor, DateTime Data, string Cliente)
        {
            this.Produto = Produto;
            this.Volume = Volume;
            this.Valor = Valor;
            this.Data = Data;
            this.Cliente = Cliente;
        } 
        
        public string Cadastro()
        {
            string efetuado = "";
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("Vendas.csv", true);
                arquivo.WriteLine(Produto + ";" + Volume + ";" + Valor + ";" + Data + ";" + Cliente);
                efetuado = "Produto: " + Produto +
                           "\nVolume: " + Volume +
                           "\nValor: " + Valor +
                           "\nData do cadastro: " + Data +
                           "\nCliente: " + Cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar gravar o arquivo." + ex.Message);
            }
            finally
            {
                arquivo.Close();
            }
            return efetuado;
        }

        public string Consulta()
        {
            string resultado = "Título não encontrado.";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("Vendas.csv", Encoding.Default);
                string linha = "";
                while((linha = ler.ReadLine()) != null){
                    string[] dados = linha.Split(';');
                    if(dados[0].ToUpper() == Produto.ToUpper()){
                        resultado = "Produto: " + linha[0] +
                                    "\nVolume: " + linha[1] +
                                    "\nValor: " + linha[2] +
                                    "\nData do cadastro: " + linha[3] +
                                    "\nCliente: " + linha[4] ;
                        break;
                    }
                }
            }
            catch(Exception ex){
                resultado = "Erro ao tentar ler o arquivo." + ex.Message;
            }
            finally{
                ler.Close();
            }
            return resultado;
        }
    }   
}