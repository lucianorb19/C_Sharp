using System;
using System.Globalization;
using System.Xml.Serialization;

namespace PrimeiroProjetoOrientadoObjeto
{
    class Produto
    {
        public string Nome;
        public double Preco;
        public int Quantidade;

        public double ValorTotalEmEstoque()
        {
            return Preco* Quantidade;
        }

        public void AdicionarProdutos(int quantidade)
        {
            Quantidade += quantidade;
            //ATRIBUTO Quantidade, QUE É DO OBJETO, É SOMADO AO VALOR quantidade, QUE É O PARÂMETRO
            //PASSADO NA FUNÇÃO
        }

        public void RemoverProdutos(int quantidade)
        {
            if (quantidade > Quantidade)//CASO TENTE RETIRAR MAIS PRODUTOS DO QUE TENHA NO ESTOQUE
            {
                Console.WriteLine("Quantidade acima do número em estoque! Operação não pode " +
                    "ser realizada.Tente novamente");
    
                Console.Write("Quantidade desse produto a ser removida: ");
                quantidade = int.Parse(Console.ReadLine());

                RemoverProdutos(quantidade);//OFEREÇO NOVAMENTE A OPÇÃO DE RETIRAR
            }
            else//CASO A QUANTIDADE A SER REMOCIDA SEJA IGUAL OU MAIOR A QUE ESTIVER NO ESTOQUE
            {
                Quantidade -= quantidade;
            }
        }

        public override string ToString()//FUNÇÃO SOBREPOSTA QUE MOSTRA OS DADOS DO OBJETO
        {
            return $"{Nome}, $ {Preco.ToString("f2",CultureInfo.InvariantCulture)}, " +
                $"quantidade em estoque: {Quantidade}, " +
                $"valor total em estoque: $ {ValorTotalEmEstoque().
                ToString("f2",CultureInfo.InvariantCulture)}";
        }

    }
}
