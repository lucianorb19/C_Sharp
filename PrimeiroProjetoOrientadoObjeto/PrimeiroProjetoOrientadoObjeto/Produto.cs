using System;
using System.Globalization;

namespace PrimeiroProjetoOrientadoObjeto
{
    class Produto
    {
        public string Nome;
        public double Preco;
        public int Quantidade;

        public double ValorTotalEmEstoque()
        {
            return Preco* Quantidade;
        }

        public override string ToString()
        {
            return $"{Nome}, $ {Preco.ToString("f2",CultureInfo.InvariantCulture)}, " +
                $"quantidade em estoque: {Quantidade}, " +
                $"valor total em estoque: $ {ValorTotalEmEstoque().
                ToString("f2",CultureInfo.InvariantCulture)}";
        }

    }
}
