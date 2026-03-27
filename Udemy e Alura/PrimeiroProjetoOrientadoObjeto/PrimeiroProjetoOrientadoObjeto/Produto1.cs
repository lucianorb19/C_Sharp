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
        /*
        public string Nome;
        public double Preco;
        public int Quantidade;
        */

        /*
        private string _nome;
        private double _preco;
        private int _quantidade;
        */

        private string _nome;
        public double Preco { get; private set; }
        public int Quantidade { get; private set; }
        //private set DETERMINA QUE O MÉTODO set DESSES ATRIBUTOS SÓ É ACESSÍVEL NA CLASSE

        //CLASSE Produto AGORA COM CONSTRUTORES PERSONALIZADOS
        //CONSTRUTOR PADRÃO - SÓ PARA HABILITAR SEU USO
        public Produto1()
        {

        }

        //CONSTRUTOR COM TODOS OS DADOS
        public Produto1(string nome, double preco, int quantidade)
        {
            _nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        //CONTRUTOR COM NOME, PREÇO E QUANTIDADE 0
        public Produto1(string nome, double preco)
        {
            _nome = nome;
            Preco = preco;
            Quantidade = 0;//SEM ESSSA LINHA, POR PADRÃO, SERIA 0
        }

        //PROPERTIES
        public string Nome
        {
            get { return _nome; }
            set {
                if (value != null && value.Length > 1)//value VAI SER OQ ESTIVER SENDO ATRIBUÍDO AO NOME, NO PROGRAMA PRINCIPAL
                {
                    _nome = value;
                }
            }
        }

        /*
        public double Preco
        {
            get { return _preco; }
        }

        public int Quantidade
        {
            get { return _quantidade; }
        }
        */


        //GETS E SETS
        /*
        public string GetNome()
        {
            return _nome;
        }

        public void SetNome(string nome)
        {
            //NOME SÓ É MODIFICADO SE NÃO FOR VAZIO E TIVER MAIS QUE UMA LETRA
            if (nome != null && nome.Length > 1)
            {
                _nome = nome;
            }
        }

        public double GetPreco()
        {
            return _preco;
        }

        public int GetQuantidade()
        {
            return _quantidade;
        }

        */


        //DEMAIS MÉTODOS DA CLASSE
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
            return $"{_nome}, $ {Preco.ToString("f2", CultureInfo.InvariantCulture)}, " +
                $"quantidade em estoque: {Quantidade}, " +
                $"valor total em estoque: $ {ValorTotalEmEstoque().
                ToString("f2", CultureInfo.InvariantCulture)}";
        }

    }
}
