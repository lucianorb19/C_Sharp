﻿using ProjetoOO_6.Entities;
using System;

namespace ProjetoOO_6
{
    class Program
    {
        static void Main(string[] args)
        {

            Account a = new BusinnesAccount(1, "Luciano", 400,1200);
            Account b = new SavingsAccount(2, "Ana", 400, 0.05);

            a.WithDraw(10);
            b.WithDraw(10);

            Console.WriteLine($"{a.Balance}\n{b.Balance}");








            //RASCUNHOS
            /*
            //UPCASTING E DOWNCASTING
            Account a = new Account(1, "Luciano", 10500);
            BusinnesAccount b = new BusinnesAccount(2, "Comercial Luciano", 35000, 12000);
            
            Account c = new SavingsAccount(3, "Lara", 12000, 0.05);//UPCASTING
            
            //CASTING USANDO as
            //Account d = (BusinnesAccount)b;
            //Account d = b as BusinnesAccount;

            SavingsAccount e = (SavingsAccount)c; //DOWN CASTING
            //c É SavingAccount - COMPATÍVEL COM e

            //BusinnesAccount e = (BusinnesAccount)a;//DOWNCASTING DEFEITUOSO - NÃO COMPATÍVEL 
            //BusinnesAccount f = (BusinnesAccount)c;//DOWNCASTING DEFEITUOSO - NÃO COMPATÍVEL 

            //PARA TESTAR ANTES DE FAZER O CASTING
            if (c is BusinnesAccount)
            {
                BusinnesAccount f = (BusinnesAccount)c;//DOWNCASTING DEFEITUOSO - NÃO COMPATÍVEL 

            }
            else
            {
                Console.WriteLine("NÃO COMPATÍVEL");
            }
            */


        }
    }
}
