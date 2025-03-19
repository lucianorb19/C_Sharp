using System;


namespace ProjetoOO_5.Entities
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        //CONTRUTORES
        public Product()
        {

        }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }


    }
}
