
namespace _4POO
{
    internal class Consultoria : IServico
    {
        public Funcionario3 Funcionario { get;}
        public string TituloServico { get; set; }

        public Consultoria(string tituloServico, Funcionario3 funcionario)
        {
            TituloServico = tituloServico;
            Funcionario = funcionario;
        }

        public void ExecutarServico()
        {
            Console.WriteLine($"Executando serviço de consultoria: {TituloServico}\n" +
                          $"Responsável: {Funcionario.Nome} - {Funcionario.Departamento}\n");
        }
    }
}
