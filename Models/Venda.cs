using System.Text.Json.Serialization;

namespace SistemaDeVenda.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        // Relacionamentos
        [JsonIgnore]
        public List<Contrato>? Contratos { get; set; }

        [JsonIgnore]
        public List<Fatura>? Faturas { get; set; }
    }
}