using System;


namespace ProjetoOO_5.Entities
{
    class Order
    {
        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }
        public Client Client { get; set; } = new Client();//ASSOCIAÇÃO CLIENT
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();//COMPOSIÇÃO ORDER-ORDERITEM

        //CONSTRUTORES 
        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            this.moment = moment;
            this.status = status;
            Client = client;
        }

        //DEMAIS MÉTODOS
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }




    }
}
