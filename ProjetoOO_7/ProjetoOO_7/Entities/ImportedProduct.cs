using System;
using System.Globalization;


namespace ProjetoOO_7.Entities
{
    class ImportedProduct : Product
    {
        public double CustomFee { get; set; }

        //CONSTRUTORES
        public ImportedProduct()
        {
        }

        public ImportedProduct(string name, double price, double customFee)
        : base(name, price)
        {
            CustomFee = customFee;
        }

        //DEMAIS MÉTODOS
        public override string PriceTag()
        {
            return $"{base.Name} ${TotalPrice().ToString("f2", CultureInfo.InvariantCulture)} " +
                   $"(Custom fee: {CustomFee})";
        }

        public double TotalPrice()
        {
            return Price + CustomFee;    
        }

    }
}
