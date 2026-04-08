

namespace _4POO;

internal class Computador
{
    public  Processador Processador { get;}
    public PlacaMae PlacaMae { get; set; }

    public Computador(Processador processador, PlacaMae placaMae)
    {
        Processador = processador;
        PlacaMae = placaMae;
    }

    public void ExibirConfiguracoes()
    {
        Console.WriteLine($"Computador configurado com\nProcessador: {Processador.Marca} - {Processador.Modelo}\n" +
                          $"Placa-mãe: {PlacaMae.Fabricante} - {PlacaMae.Socket}\n");
    }

}
