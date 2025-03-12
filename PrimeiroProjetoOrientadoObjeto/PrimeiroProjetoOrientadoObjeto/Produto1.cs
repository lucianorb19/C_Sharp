using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroProjetoOrientadoObjeto
{
    class Produto1
    {
        //CLASSE Produto AGORA COM CONSTRUTORES PERSONALIZADOS
        public string Nome;
        public double Preco;
        public int Quantidade;

        //CONSTRUTOR PADRÃO - SÓ PARA HABILITAR SEU USO
        public Produto1()
        {

        }

        //CONSTRUTOR COM TODOS OS DADOS
        public Produto1(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        //CONTRUTOR COM NOME, PREÇO E QUANTIDADE 0
        public Produto1(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = 0;//SEM ESSSA LINHA, POR PADRÃO, SERIA 0
        }


        public double ValorTotalEmEstoque()
        {
            return Preco * Quantidade;
        }

        //USO DE this
        public void AdicionarProdutos(int Quantidade)
        {
            this.Quantidade += Quantidade;
            //ATRIBUTO Quantidade, QUE É DO OBJETO, É SOMADO AO VALOR Quantidade, QUE É O PARÂMETRO
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
            return $"{Nome}, $ {Preco.ToString("f2", CultureInfo.InvariantCulture)}, " +
                $"quantidade em estoque: {Quantidade}, " +
                $"valor total em estoque: $ {ValorTotalEmEstoque().
                ToString("f2", CultureInfo.InvariantCulture)}";
        }

    }
}
