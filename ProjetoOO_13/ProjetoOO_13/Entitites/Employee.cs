using System;
using System.Globalization;

namespace ProjetoOO_13.Entitites
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        //CONSTRUTORES
        public Employee()
        {
        }
        public Employee(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }


        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"{Name} - {Email} - {Salary.ToString("f2", CultureInfo.InvariantCulture)}";
        }
    }
}
