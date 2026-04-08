class Consulta
{

    public string NomePaciente { get; set; }
    public string NomeMedico { get; set; }
    public DateTime DataConsulta { get; set; }

    private bool foiReagendada;

    public Consulta(string nomePaciente, string nomeMedico, DateTime dataConsulta)
    {
        NomePaciente = nomePaciente;
        NomeMedico = nomeMedico;
        DataConsulta = dataConsulta;
        foiReagendada = false;
    }

    public void Reagendar(DateTime novaData)
    {
        if(novaData >= DateTime.Today)
        {
            DataConsulta = novaData;
            foiReagendada = true;
        }
        else
        {
            Console.WriteLine("Por favor, agendar para uma data futura.");
        }
    }

    public void ExibirResumo()
    {
        Console.WriteLine($"Consulta maracada com {NomeMedico} para paciente {NomePaciente}.");
        if (foiReagendada)
        {
            Console.WriteLine($"Nova data: {DataConsulta}\n");
        }
        else
        {
            Console.WriteLine($"Data: {DataConsulta}\n");
        }
    }


}