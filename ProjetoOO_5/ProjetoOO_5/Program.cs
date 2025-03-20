using System;
using System.Globalization;
using ProjetoOO_5.Entities;

namespace ProjetoOO_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date [DD/MM/YYYY]: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            Client client = new Client(name, email, birthDate);
            //Console.WriteLine($"{name} - {email} - {birthDate.ToShortDateString()}");

            Console.WriteLine("Enter order data");

            bool continuar = true;
            string status_string = "";
            while (continuar)
            {
                Console.Write("Status: ");
                status_string = Console.ReadLine();
                if (status_string == "PendingPayment" || 
                    status_string == "Processing" ||
                    status_string == "Shipped" ||
                    status_string == "Delivered")
                {
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("Invalid Status.");
                    Console.WriteLine("Valid Entrys:\n" +
                                      "PendingPayment\n" +
                                      "Processing\n" +
                                      "Shipped\n" +
                                      "Delivered");
                    Console.WriteLine("Try again.");
                }
            }
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(status_string);

            //Console.WriteLine(orderStatus);

            Order order = new Order();
            order.Moment = DateTime.Now;
            order.Status = orderStatus;
            order.Client = client;

            Console.Write("How many item to this order: ");
            int numero_itens = int.Parse(Console.ReadLine());
            for(int i = 0; i < numero_itens; i++)
            {
                Console.WriteLine($"Enter #{i+1} item data");
                Console.Write("Product name: ");
                string product_name = Console.ReadLine();
                Console.Write("Product price: ");
                double product_price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(product_name, product_price);
                OrderItem order_item = new OrderItem(quantity, product);

                order.AddItem(order_item);
                Console.WriteLine();
            }

            Console.WriteLine(order);
            




        }
    }

}
