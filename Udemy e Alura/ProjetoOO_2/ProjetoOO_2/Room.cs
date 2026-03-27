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

        //MÉTODO ESTÁTICO PORQUE NÃO DEPENDE DE ATRIBUTOS DO OBJETO
        static internal void ShowBusyRooms(Room[] vector)
        {
            //SHOWING THE BUSY ROOMS
            Console.Write("Busy Rooms: ");
            int counter = 0;
            for (int x = 0; x < 10; x++)
            {
                if (vector[x] != null)//IF ROOM TAKEN, SHOW ITS NUMBER
                {
                    Console.Write($"{vector[x].RoomNumber} - ");
                    counter++;
                }
            }
            //IF ALL ROOMS AVAILABLE
            if (counter == 0)
            {
                Console.WriteLine("All rooms available!");
            }
            Console.WriteLine();
        }
        
        static internal void ShowBusyRoomsDetails(Room[] vector)
        {
            Console.WriteLine("Busy rooms:");
            for (int i = 0; i < 10; i++)
            {
                //SHOW ONLY THE POSITIONS WITH DATA
                if (vector[i] != null)
                {
                    Console.WriteLine($"{vector[i].RoomNumber}: {vector[i]}");
                }
            }
        }

        static internal void ReserveRoom(string name, string email, int roomNumber, Room[] vector)
        {
            //IF THE ROOM IS AVAILABLE
            if (vector[roomNumber] == null)
            {
                vector[roomNumber] = new Room();
                vector[roomNumber].RoomGuest = name;
                vector[roomNumber].GuestEmail = email;
                vector[roomNumber].RoomNumber = roomNumber;
            }
            else//IF NOT AVAILABLE - TRY AGAIN WITH ANOTHER ROOM NUMBER
            {
                Console.WriteLine("Room already taken. Try again!");
                //RESERVING ROOM
                Console.Write("Room Number: ");
                int newRoomNumber = int.Parse(Console.ReadLine());
                ReserveRoom(name, email, newRoomNumber, vector);
            }
        }






    }
}
