using System;
using System.Globalization;

namespace ProjetoOO_12.Extensions
{
    static class DateTimeExtension
    {
        //this DateTime thisObj - SIGNIFICA QUE NO CÓDIGO PRINCIPAL, QUANDO FOR CHAMADA,
        //A FUNÇÃO VAI USAR A VARIÁVEL DateTime QUE CHAMOU O MÉTODO
        public static string ElapsedTime(this DateTime thisObj)
        {
            TimeSpan duration = DateTime.Now.Subtract(thisObj);

            Console.WriteLine("Time elapsed: ");
            if(duration.TotalHours < 24)
            {
                return duration.TotalHours.ToString("f1", CultureInfo.InvariantCulture)+" hours";
            }
            else
            {
                return duration.TotalDays.ToString("f1", CultureInfo.InvariantCulture)+" days";
            }
        }
    }
}
