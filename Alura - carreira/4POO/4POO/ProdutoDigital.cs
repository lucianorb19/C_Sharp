class ProdutoDigital
{

    public string Nome { get; set; }
    public double Preco { get; set; }
    public InformacaoTecnica InfoTecnica { get; set; }


    public ProdutoDigital(string nome, double preco, InformacaoTecnica infoTecnica)
    {
        Nome = nome;
        Preco = preco;
        InfoTecnica = infoTecnica;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Produto: {Nome}\nPreço: {Preco.ToString("C2")}\n" +
                          $"Tamanho: {InfoTecnica.TamanhoMB}MB\nCompatível com: {InfoTecnica.SistemaOperacional}");
    }


}