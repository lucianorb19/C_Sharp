using System;


namespace ProjetoOO_6.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }

        //CONTRUTORES
        public Account()
        {
        }

        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        //DEMAIS MÉTODOS
        //SAQUE - CADA SAQUE TEM TAXA DE 5$
        public virtual void WithDraw(double ammount)
        {
            Balance -= ammount+5;
        }

        public void Deposit(double ammount)
        {
            Balance += ammount;
        }



    }
}
