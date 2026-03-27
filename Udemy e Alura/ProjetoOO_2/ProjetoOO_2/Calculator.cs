using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_2
{
    class Calculator
    {
        /*
        internal static double Sum(params int[] numbers)
        {
            double sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        


        //------------------------------------------------
        internal static void Triple(ref int x)
        {
            x = x * 3;
        }
        */

        internal static void Triple(int origin, out int result)
        {
            result = origin * 3;
        }








    }
}
