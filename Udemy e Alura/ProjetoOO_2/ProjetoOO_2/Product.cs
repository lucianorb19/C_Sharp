using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_2
{
    class Product
    {
        internal string Nome { get; set; }
        internal double Preco { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, preço: {Preco}";
        }
    }
}
