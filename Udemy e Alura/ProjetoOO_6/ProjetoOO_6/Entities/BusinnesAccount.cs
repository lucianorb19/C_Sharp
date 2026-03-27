using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_6.Entities
{
    class BusinnesAccount : Account //BusinessAccount HERDA DE Account
    {
        public double LoanLimit { get; set; }


        //CONSTRUTORES
        public BusinnesAccount()
        {
        }

        //CONSTRUTOR COM HERANÇA DO CONSTRUTOR DA CLASSE BASE (Account)
        public BusinnesAccount(int number, string holder, double balance, double loanLimit) 
        : base(number, holder, balance)
        {
            LoanLimit = loanLimit;
        }

        //FUNÇÃO DE PEGAR EMPRÉSTIMO NA CONTA - LIMITADO PELO LoanLimit
        public void Loan(double ammount)
        {
            if (ammount <= LoanLimit)
            {
                Balance += ammount;
            }
        }


    }
}
