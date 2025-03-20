using System;
using System.Text;


namespace ProjetoOO_5.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; } = new Product();//ASSOCIAÇÃO PRODUCT

        //CONSTRUTORES
        public OrderItem()
        {

        }
        public OrderItem(int quantity, Product item)
        {
            Product = item;
            Quantity = quantity;
            Price = (double)Product.Price;//PREÇO DO PRODUTO PASSADO PARA O ITEM
            
        }

        //DEMAIS MÉTODOS
        public double SubTotal()
        {
            double valor = (double)Quantity * Price;
            return valor;
        }

        




    }
}
