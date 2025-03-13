using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_2
{
    class Point
    {
        internal double X;
        internal double Y;

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
