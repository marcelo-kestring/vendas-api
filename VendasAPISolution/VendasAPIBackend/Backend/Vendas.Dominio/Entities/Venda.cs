namespace Vendas.Dominio.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }
        public List<ItemVenda> Itens { get; set; }
        public bool Cancelada { get; set; }
    }
}
