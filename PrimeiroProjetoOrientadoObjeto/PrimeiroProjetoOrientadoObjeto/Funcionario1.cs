using System;
using System.Globalization;

namespace PrimeiroProjetoOrientadoObjeto
{
    class Funcionario1
    {
        public string Nome;
        public double Salario_Bruto;
        public double Imposto;

        public double SalarioLiquido()
        {
            return Salario_Bruto - Imposto;
        }

        public void AumentarSalario(double porcentagem)
        {
            Salario_Bruto = Salario_Bruto + Salario_Bruto * (porcentagem / 100);
        }

        public override string ToString()
        {
            return $"{Nome}, $ {SalarioLiquido().ToString("f2", CultureInfo.InvariantCulture)}";
        }
    }
}
