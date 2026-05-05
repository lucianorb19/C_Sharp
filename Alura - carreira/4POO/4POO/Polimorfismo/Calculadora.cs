

namespace _4POO.Polimorfismo;

internal class Calculadora
{
    public static void Somar(int a, int b)
    {
        Console.WriteLine($"{a} + {b} = {a+b}");
    }
    public static void Somar(int a, int b, int c)
    {
        Console.WriteLine($"{a} + {b} + {c} = {a + b + c}");
    }
    public static void Somar(double a, double b)
    {
        Console.WriteLine($"{a} + {b} = {a + b}");
    }

}
