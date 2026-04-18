namespace SistemaDeVenda.Models
{
    public class Fatura
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }


        // Esta ligando Fatura/Venda
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
    }
}
