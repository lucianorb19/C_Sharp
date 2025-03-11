using System;
using System.Globalization;

namespace PrimeiroProjetoOrientadoObjeto
{
    class Aluno
    {
        public string Nome;
        public double Nota1;
        public double Nota2;
        public double Nota3;


        public void StatusAluno()
        {
            double nota_final = Nota1 + Nota2 + Nota3;

            Console.WriteLine($"Nota Final: {nota_final}");
            
            if (nota_final >= 60)//APROVADO
            {
                Console.WriteLine("Aprovado!");
            }
            else
            {
                Console.WriteLine($"Reprovado! :(\n" +
                                  $"Faltaram {(60-nota_final).ToString("f2", CultureInfo.InvariantCulture)} pontos");
            }
        }

    }
}
