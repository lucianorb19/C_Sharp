﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_6.Entities
{
    sealed class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        //CONSTRUTORES
        public SavingsAccount()
        {
        }

        public SavingsAccount(int number, string holder, double balance, double interestRate)
        : base(number, holder, balance)
        {
            InterestRate = interestRate;
        }


        //DEMAIS MÉTODOS

        //MÉTODO QUE INCREMENTA O VALOR DA POUPANÇA PELOS JUROS InterestRate
        public void UpdateBalance()
        {
            Balance += Balance * InterestRate;
        }

        //MÉTODO SOBRESCRITO - CONTA POUPANÇA NÃO TEM DESCONTO PARA SAQUE
        public sealed override void WithDraw(double ammount)
        {
            Balance -= ammount;
        }


    }
}
