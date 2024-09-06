using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Arquitetura.Server.Models.DTO
{
    public class BaseDto
    {
        [Column("DtChange")]
        public DateTime DtChanged { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
