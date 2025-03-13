using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_2
{
    class Room
    {
        internal int RoomNumber { get; set; }
        internal string RoomGuest { get; set; }
        internal string GuestEmail { get; set; }


        public override string ToString()
        {
            return $"Nome: {RoomGuest}, e-mail: {GuestEmail}";
        }
    }
}
