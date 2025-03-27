using System;


namespace ProjetoOO_13.Entitites
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        //CONSTRUTORES
        public Product()
        {
        }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - ${Price}";
        }
    }
}
