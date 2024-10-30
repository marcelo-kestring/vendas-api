namespace Vendas.Dominio.Entities
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public string ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; }
    }
}
