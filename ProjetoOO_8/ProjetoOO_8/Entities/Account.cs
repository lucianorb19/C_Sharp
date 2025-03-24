using System;
using ProjetoOO_8.Exceptions;

namespace ProjetoOO_8.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithDrawLimit { get; set; }

        //CONSTRUTORES
        public Account()
        {
        }
        public Account(int number, string holder, double balance, double withDrawLimit)
        {
            if(balance == 0)
            {
                throw new DomainException("Error! Balance 0");
            }

            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        //DEMAIS MÉTODOS
        public void Depositar(double ammount)
        {
            Balance += ammount;
        }

        public void WithDraw(double ammount)
        {
            if(Balance == 0)
            {
                throw new DomainException("Error! Balance 0");
            }
            if(ammount > WithDrawLimit)
            {
                throw new DomainException("Error! Withdraw over limit.");
            }
            if ((Balance - ammount) < 0)
            {
                throw new DomainException("Error! Not enough balance.");
            }

            Balance -= ammount;

        }

    }
}
