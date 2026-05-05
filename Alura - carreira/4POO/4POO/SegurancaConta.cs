
namespace _4POO;

internal class SegurancaConta
{
    public static bool ValidarSaque(double valor)
    {
        return valor <= 1000;
    }
}
