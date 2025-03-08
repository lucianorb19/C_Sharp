// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;//REFERÊNCIA AO NAMESPACE SYSTEM - PADRÃO DO VISUAL STUDIO

namespace PrimeiroProjeto
{
    internal class Program
    {
        static void Main(string[] args)//ENTRY POINT - ONDE A APLICÃÇÃO COMEÇA A SER EXECUTADA
        {
            object x = 45.2f;
            float y = 50.5f;
            Console.WriteLine(x.GetType());
            Console.WriteLine(y.GetType());

        }
    }
}
