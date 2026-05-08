namespace ProductClientHub.API.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public Guid ClientId { get; set; }

        //ASSOCIAÇÃO COM TABELA CLIENTES
        //1 PRODUTO ASSOCIADO A 1 CLIENTE
        //SÓ USAR ESSA LINHA CASO SEJA NECESSÁRIO 
        //ACESSAR OS CLIENTES USANDO UMA INSTÂNCIA DE PRODUTOS
        //public Client Client { get; set; } = default!;
    }
}
