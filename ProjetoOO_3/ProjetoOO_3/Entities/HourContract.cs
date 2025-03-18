using System;

namespace ProjetoOO_3.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour{ get; set; }
        public int Hours { get; set; }


        //CONSTRUTORES
        public HourContract()
        {

        }
        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }


        //DEMAIS MÉTODOS
        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }


    }
}
