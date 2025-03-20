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
        public void WithDraw(double ammount)
        {
            Balance -= ammount;
        }

        public void Deposit(double ammount)
        {
            Balance += ammount;
        }



    }
}
