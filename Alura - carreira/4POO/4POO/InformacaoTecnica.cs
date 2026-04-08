class InformacaoTecnica
{

    public double TamanhoMB { get; set; }
    public string SistemaOperacional { get; set; }

    public InformacaoTecnica(double tamanhoMB, string sistemaOperacional)
    {
        TamanhoMB = tamanhoMB;
        SistemaOperacional = sistemaOperacional;
    }


}