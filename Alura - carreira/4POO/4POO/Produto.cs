class Produto
{
    private int quantidadeEstoque;

    public string Nome { get; set; }

    public Produto(int quantidadeEstoque, string nome)
    {
        this.quantidadeEstoque = quantidadeEstoque;
        Nome = nome;
    }

    public void Retirar(int quantidadeARetirar)
    {
        if(this.quantidadeEstoque >= quantidadeARetirar)
        {
            this.quantidadeEstoque -= quantidadeARetirar;
            Console.WriteLine($"Retirada de {quantidadeARetirar} unidades realizada com sucesso.");
        }
        else
        {
            Console.WriteLine($"Quantidade insuficiente para retirada de {quantidadeARetirar} unidades.");
        }

    }

    public void ExibirEstoque()
    {
        Console.WriteLine($"Produto: {Nome}\nQuantidade: {this.quantidadeEstoque}\n");
    }
}