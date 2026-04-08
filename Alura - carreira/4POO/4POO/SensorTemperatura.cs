

namespace _4POO;

internal class SensorTemperatura : ISensor
{
    public void Ativar()
    {
        Console.WriteLine("Sensor de temperatura ativado.");
    }

    public void Desativar()
    {
        Console.WriteLine("Sensor de temperatura desativado.");
    }
}
