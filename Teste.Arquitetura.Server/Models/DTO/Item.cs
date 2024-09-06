using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Arquitetura.Server.Models.DTO
{
    [Table("Item")]
    public class Item: BaseDto
    {
        [Column("Id"),Key,Required]
        public Guid Id { get; set; }
        [Column("Price"), Required]
        public decimal Price { get; set; }
        [Column("Name"), Required]
        public string Name { get; set; }
        [Column("Quantity"), Required]
        public int Quantity { get; set; }
        [Column("CashFlowId"), Required]
        public Guid CashFlowId { get; set; }
    }
}
