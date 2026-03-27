using System;
using System.Globalization;

namespace ProjetoOO_7.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public double ValuePerHour { get; set; }

        //CONSTRUTORES
        public Employee()
        {
        }
        public Employee(string name, int hours, double valuePerHour)
        {
            Name = name;
            Hours = hours;
            ValuePerHour = valuePerHour;
        }

        public virtual double Payment()
        {
            return (double)Hours * ValuePerHour;
        }

        public override string ToString()
        {
            return $"{Name} - ${Payment().ToString("f2", CultureInfo.InvariantCulture)}";
        }



    }
}
