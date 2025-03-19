using System;


namespace ProjetoOO_5.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Item { get; set; } = new Product();//ASSOCIAÇÃO PRODUCT

        //CONSTRUTORES
        public OrderItem()
        {

        }
        public OrderItem(int quantity, Product item)
        {
            Quantity = quantity;
            Price = Item.Price;//PREÇO DO PRODUTO PASSADO PARA O ITEM
            Item = item;
        }

        //DEMAIS MÉTODOS
        public double SubTotal()
        {
            return Quantity * Price;
        }




    }
}
