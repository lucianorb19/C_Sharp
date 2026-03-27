using System;


namespace ProjetoOO_5.Entities
{
    class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        //CONSTRUTORES 
        public Client()
        {

        }
        public Client(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"{Name} ({BirthDate.ToShortDateString()}) - {Email}";
        }


    }
}
