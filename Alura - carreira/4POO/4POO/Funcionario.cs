class Funcionario
{

    public string Nome { get; }
    public string Cargo { get; set; }


    public Funcionario(string nome, string cargo)
    {
        Nome = nome;
        Cargo = cargo;
    }

    public void Promover(string cargoNovo)
    {
        if(!(cargoNovo.Equals(Cargo, StringComparison.OrdinalIgnoreCase)))
        {
            Cargo = cargoNovo;
        }
        else
        {
            Console.WriteLine("Promoção não pode ocorrer. Cargos iguais!");
        }
    }

}