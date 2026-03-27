using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroProjetoOrientadoObjeto
{
    class Triangulo //PRECISA DO PUBLIC ?
    {
        public double A;
        public double B;
        public double C;

        public double Area_Triangulo()
        {
            //ÁREA DO TRIÂNGULO CALCULADA PELA FÓRMULA DE HERON
            //FUNÇÃO SEM PARÂMETROS PQ SÓ USA AS PRÓPRIAS INFORMAÇÕES DO OBJETO
            double p = (A + B + C)/2;
            double area_triangulo = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            return area_triangulo;
         }

    }
}
