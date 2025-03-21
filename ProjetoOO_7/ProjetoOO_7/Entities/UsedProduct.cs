using System;
using System.Globalization;

namespace ProjetoOO_7.Entities
{
    class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        //CONSTRUTORES
        public UsedProduct()
        {
        }

        public UsedProduct(string name, double price, DateTime manufactureDate)
        :base (name, price)
        {
            ManufactureDate = manufactureDate;
        }

        //DEMAIS MÉTODOS
        public override string PriceTag()
        {
            return $"{base.Name} (used) ${(base.Price).ToString("f2", CultureInfo.InvariantCulture)} " +
                   $"(Manufacture date: {ManufactureDate.ToShortDateString()})";
        }

    }
}
