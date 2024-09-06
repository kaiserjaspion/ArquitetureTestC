using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Arquitetura.Server.Models.DTO
{
    [Table("CashFlow")]
    public class CashFlow: BaseDto
    {
        [Column("Id"),Key,Required]
        public Guid Id { get; set; }
        [Column("Value"), Required]
        public decimal Value { get; set; }
        [Column("Cpf")]
        public string Cpf { get; set; }
        [Column("Date"), Required]
        public DateTime Date { get; set; }
        [ForeignKey("Item")]
        public List<Item> Itens { get; set; }

    }
}
