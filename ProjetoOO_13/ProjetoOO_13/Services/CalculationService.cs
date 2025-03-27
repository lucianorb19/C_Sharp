using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_13.Services
{
    class CalculationService
    {
        public static void ShowMax(double x, double y)
        {
            double max = (x > y) ? x : y;
            Console.WriteLine($"Max: {max}");
        }

        //FUNÇÃO QUE VAI USAR O DELEGATE
        public static void ShowSum(double x, double y)
        {
            Console.WriteLine($"Sum: {x + y}");
        }
    }
}
