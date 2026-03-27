using System;
using System.Globalization;

namespace ProjetoOO_7.Entities
{
    class Individual : Person
    {
        public double HealthExpenses { get; set; }

        //CONSTRUTORES
        public Individual()
        {
        }
        public Individual(string name, double anualIncome, double healthExpenses)
        :base(name, anualIncome)
        {
            HealthExpenses = healthExpenses;
        }

        //DEMAIS MÉTODOS
        public override double Tax()
        {
            double tax = 0;
            double income_after_tax = 0;
            if(AnualIncome < 20000)
            {
                tax = AnualIncome * 0.15;//15% TAX
            }
            else//AnualIncome >= 20000
            {
                tax = AnualIncome * 0.25;//25% TAX
            }
            
            
            //HEALTH ALLOWANCE
            tax -= (HealthExpenses * 0.5);//50% ALLOWANCE OF HEALTH EXPENSES

            return tax;
        }


        public override string ToString()
        {
            return $"{Name}: ${Tax().ToString("f2", CultureInfo.InvariantCulture)}";
        }



    }
}
