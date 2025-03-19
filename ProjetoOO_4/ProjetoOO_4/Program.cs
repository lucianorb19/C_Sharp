using System;
using ProjetoOO_4.Entities;

namespace ProjetoOO_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //POST1
            Comment c1 = new Comment("Have a nice trip!");
            Comment c2 = new Comment("Wow, tha's awesome!");
            Post p1 = new Post(
                DateTime.Parse("19/03/2025 14:20:35"),
                "Traveling to New Zeland",
                "I'm going to visit this wondeful country!",
                75
                );

            p1.AddComment(c1);
            p1.AddComment(c2);

            //POST2
            Comment c3 = new Comment("Good night!");
            Comment c4 = new Comment("May the force be with you!");
            Post p2 = new Post(
                DateTime.Parse("15/02/2025 23:14:19"),
                "Good night guys",
                "See you tomorrow",
                25
                );

            p2.AddComment(c3);
            p2.AddComment(c4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);








        }
    }
}
