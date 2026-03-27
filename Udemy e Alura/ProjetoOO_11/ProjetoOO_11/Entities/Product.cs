using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_11.Entities
{
    //: IComparable PORQUE IMPLEMENTA O MÉTODO CompareTo
    class Product : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        //CONSTRUTORES
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}, {Price}";
        }

        public int CompareTo(object? obj)
        {
            //VERIFICAÇÃO SE O QUE ESTÁ SENDO COMPARADO É PRODUTO
            if (!(obj is Product))//SE NÃO FOR UM PRODUTO
            {
                throw new ArgumentException("Can't compare. Object is not a Product!");
            }

            //COMPARAÇÃO ENTRE PRODUTOS BASEADA NO PREÇO
            //JÁ USANDO O MÉTODO CompareTo DO PRÓPRIO PREÇO - QUE É DOUBLE
            Product other = obj as Product;
            return Price.CompareTo(other.Price);
        }

    }
}
