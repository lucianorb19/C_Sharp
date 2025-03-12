using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroProjetoOrientadoObjeto
{
    class ConversorMoeda
    {
        public static double ConversorDolar(double cotacao, double dolares_a_comprar)
        {
            double total_em_reais = (cotacao * dolares_a_comprar);
            total_em_reais += total_em_reais * 0.06;//IOF
            return (total_em_reais);
        }
    }
}
