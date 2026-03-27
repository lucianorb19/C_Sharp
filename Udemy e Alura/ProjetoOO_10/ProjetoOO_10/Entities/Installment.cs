using System;


namespace ProjetoOO_10.Entities
{
    class Installment
    {
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }

        //CONSTRUTORES
        public Installment()
        {
        }
        public Installment(DateTime dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }



    }
}
