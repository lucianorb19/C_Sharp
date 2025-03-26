using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_11.Entities
{
    class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }

        //CONSTRUTOR
        public Client(string name, string email)
        {
            Name = name;
            Email = email;
        }

        //DEMAIS MÉTODOS
        public override bool Equals(object? obj)
        {
            //VERIFICAÇÃO SE O PARÂMETRO É UM CLIENTE
            if(!(obj is Client))
            {
                return false;//SE NÃO FOR, JÁ É FALSE
            }

            Client other = obj as Client;//obj PASSADO PARA other - COMO CLIENT(DOWNCASTING)
            //NESSA REGRA DE NEGÓCIO, OS CLIENTES SÃO IGUAIS SE TIVEREM O E-MAIL IGUAL
            return Email.Equals(other.Email);
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode();//MESMA LÓGICA DE NEGÓCIO
        }





    }
}
