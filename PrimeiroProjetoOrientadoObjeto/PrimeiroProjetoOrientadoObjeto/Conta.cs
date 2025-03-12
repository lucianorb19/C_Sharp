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
        internal string NumeroConta { get; private set; }
        //internal string _numeroConta;
        internal string TitularConta { get; set; }

        //CONSTRUTORES
        internal Conta()
        {

        }
        //CONSTRUTOR COM NÚMERO DA CONTA E TITULAR
        internal Conta(string numero_conta, string titular_conta)
        {
            TitularConta = titular_conta;
            _saldo = 0;
            
            //SÓ ACEITA NÚMERO DE CONTA COM 4 DÍGITOS NUMÉRICOS
            while (numero_conta.Length != 4 || numero_conta.All(char.IsDigit) == false)
            {
                Console.Write("Número da conta inválido. Tente novamente\n" +
                              "Digite o número da conta [4 dígitos numéricos]\n--> ");
                numero_conta = Console.ReadLine();
            }
            NumeroConta = numero_conta;
        }

        //CONSTRUTOR COMPLETO - COM SOBRECARGA
        internal Conta(string numero_conta, string titular_conta, double saldo) : this(numero_conta,titular_conta)
        {
            _saldo = saldo;
        }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"Conta: {NumeroConta}, " +
                   $"Titular: {TitularConta}, " +
                   $"Saldo:  $ {_saldo.ToString("f2",CultureInfo.InvariantCulture)}\n";
            
        }

        internal void PrimeiroDeposito()
        {
            
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
