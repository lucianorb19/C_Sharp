using System;
using System.Globalization;

namespace ProjetoOO_7.Entities
{
    class LegalEntity : Person
    {
        public int EmployeeNumber { get; set; }

        //CONSTRUTORES
        public LegalEntity()
        {
        }

        public LegalEntity(string name, double anualIncome, int employeeNumber)
        :base(name, anualIncome)
        {
            EmployeeNumber = employeeNumber;
        }

        //DEMAIS MÉTODOS
        public override double Tax()
        {
            double tax = 0;
            
            if(EmployeeNumber <= 10)
            {
                tax = AnualIncome * 0.16;
            }
            else//EmployeeNumber >=10
            {
                tax = AnualIncome * 0.14;
            }

            return tax;
        }

        public override string ToString()
        {
            return $"{Name}: ${Tax().ToString("f2", CultureInfo.InvariantCulture)}";
        }





    }
}
