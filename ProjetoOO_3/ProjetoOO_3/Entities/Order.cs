using System;
using ProjetoOO_3.Entities.Enums;

namespace ProjetoOO_3.Entities
{
    class Order
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public OrderStatus Status{ get; set; }

        public override string ToString()
        {
            return $"{Id}, {Moment}, {Status}";
        }

    }
}
