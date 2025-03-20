using System;
using System.Text;
using System.Globalization;


namespace ProjetoOO_5.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; } = new Client();//ASSOCIAÇÃO CLIENT
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();//COMPOSIÇÃO ORDER-ORDERITEM

        //CONSTRUTORES 
        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
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

        public double Total()
        {
            double total = 0;
            foreach(OrderItem item in Items)
            {
                total += item.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMARY");
            sb.AppendLine($"Order moment: {Moment}\n" +
                          $"Order status: {Status}\n" +
                          $"Client: {Client}");

            sb.AppendLine("Order items");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine($"{item.Product.Name}, ${item.Price.ToString("f2",CultureInfo.InvariantCulture)}, " +
                          $"Quantity: {item.Quantity}, Subtotal: ${item.SubTotal()}");
            }
            sb.AppendLine($"Total price: ${this.Total()}");

            return sb.ToString();
        }




    }
}
