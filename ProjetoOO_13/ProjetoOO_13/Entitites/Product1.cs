using System;
using System.Globalization;

namespace ProjetoOO_13.Entitites
{
    class Product1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }


        //CONSTRUTOR
        public Product1()
        {
        }
        public Product1(int id, string name, double price, Category category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"{Id}, " +
                   $"{Name}, " +
                   $"{Price.ToString("f2", CultureInfo.InvariantCulture)}, " +
                   $"{Category.Name}, " +
                   $"{Category.Tier}";
        }








    }
}
