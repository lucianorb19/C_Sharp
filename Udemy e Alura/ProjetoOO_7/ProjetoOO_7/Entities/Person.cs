using System;


namespace ProjetoOO_7.Entities
{
    abstract class Person
    {
        public string Name { get; set; }
        public double AnualIncome { get; set; }

        //CONSTRUTORES
        public Person()
        {
        }
        protected Person(string name, double anualIncome)
        {
            Name = name;
            AnualIncome = anualIncome;
        }

        //DEMAIS MÉTODOS
        public abstract double Tax();


    }
}
