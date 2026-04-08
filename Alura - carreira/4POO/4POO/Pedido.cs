class Pedido
{

    public string NumeroPedido { get; set; }
    public string NomeCliente { get; set; }
    public string Status { get; set; }


    public Pedido(string numeroPedido, string nomeCliente, string status)
    {
        NumeroPedido = numeroPedido;
        NomeCliente = nomeCliente;
        Status = status;
    }


    public void AtualizarStatus(string novoStatus)
    {
        if(Status == novoStatus)
        {
            Console.WriteLine($"Status pedido já é {novoStatus}!");
        }
        else
        {
            string statusAnterior = Status;
            Status = novoStatus;
            Console.WriteLine($"Status pedido {NumeroPedido} atualizado de {statusAnterior} para {novoStatus}.");
        }
    }

    public void ExibirPedido()
    {
        Console.WriteLine($"Pedido nº {NumeroPedido}\nCliente: {NomeCliente}\nStatus: {Status}\n");
    }



}