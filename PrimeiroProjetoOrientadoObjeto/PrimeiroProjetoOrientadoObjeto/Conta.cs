using System;
using System.Globalization;


namespace PrimeiroProjetoOrientadoObjeto
{
    class Conta
    {
        //ATRIBUTO PRIVADO PARA SALDO DA CONTA
        //PRIVADO PARA NÃO SER DIRETAMENTE MODIFICADO
        private double _saldo;

        //AUTOPROPERTIES PARA NÚMERO DA CONTA E TITULAR DA CONTA
        //internal int NumeroConta { get; set; }
        internal string _numeroConta;
        internal string TitularConta { get; set; }

        //CONSTRUTORES
        //PADRÃO
        internal Conta()
        {

        }

        //CONSTRUTOR COM NÚMERO DA CONTA E TITULAR
        internal Conta(string numero_conta, string titular_conta)
        {
            _numeroConta = numero_conta;
            TitularConta = titular_conta;
        }

        //CONSTRUTOR COMPLETO
        internal Conta(string numero_conta, string titular_conta, double saldo)
        {
            _numeroConta = numero_conta;
            TitularConta = titular_conta;
            _saldo = saldo;
        }
        //PROPERTIE - _numeroConta
        internal string NumeroConta
        {
            get { return _numeroConta; }
            set
            {
                //SÓ ACEITA NÚMERO DE CONTA COM 4 DÍGITOS NUMÉRICOS
                while (value.Length !=4 || value.All(char.IsDigit)==false)
                {
                    Console.Write("Entrada inválida. Tente novamente\n" +
                                  "Digite o número da conta [4 dígitos numéricos]\n--> ");
                    value = Console.ReadLine();
                }
                _numeroConta = value;
            }
        }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"Conta: {_numeroConta}, " +
                   $"Titular: {TitularConta}, " +
                   $"Saldo:  $ {_saldo.ToString("f2",CultureInfo.InvariantCulture)}\n";
            
        }

        internal void PrimeiroDeposito()
        {
            Console.Write("Digite o valor do depósito inicial: $ ");
            _saldo += double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();
        }
        internal void Depositar()
        {
            Console.Write("Digite um valor para depósito: $");
            _saldo += double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();
            Console.WriteLine($"Dados atualizados da conta\n" +
                              $"{this}");//MOSTRA OS DADOS DA CONTA ATUALIZADOS
            Console.WriteLine();
        }

        internal void Saque()
        {
            Console.WriteLine("Taxa de saque: $5.00");
            Console.Write("Digite um valor para sacar: $");
            _saldo -= double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            _saldo -= 5; //TAXA DE SAQUE
            Console.WriteLine("Taxa de $5.00 aplicada.");
            Console.WriteLine();
            Console.WriteLine($"Dados atualizados da conta\n" +
                              $"{this}");//MOSTRA OS DADOS DA CONTA ATUALIZADOS
            Console.WriteLine();
        }


        /*
        -ATRIBUTOS PRIVADOS
        -AUTOPROPERTIES
        -CONSTRUTORES
        -PROPERTIES MANUAIS
        -DEMAIS MÉTODOS
        */
    }
}
