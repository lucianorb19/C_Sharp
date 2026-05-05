
namespace _4POO;

internal class Funcionario4
{
    private double salario;
    public double Salario { get { return salario; } }
    public string Nome { get;}

 
    public Funcionario4(string nome, double salarioInicial)
    {
        this.salario = salarioInicial;
        Nome = nome;
    }

    public void ReajustarSalario(double novoValor)
    {
        if (novoValor < Salario)
        {
            Console.WriteLine("Erro. Novo salário deve ser maior que o atual.");
        }
        else
        {
            Console.WriteLine($"Funcionário: {Nome}\nSalário atual: {Salario}");
        }

    }
}
