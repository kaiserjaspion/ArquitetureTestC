using Microsoft.EntityFrameworkCore;
using Teste.Arquitetura.Server.Models.DTO;

namespace Teste.Arquitetura.Server.Contexts
{
    public class CashFlowContext : DbContext 
    {
        public CashFlowContext(DbContextOptions<CashFlowContext> options) : base(options)
        {
            
        }
        public DbSet<CashFlow> cashflow { get; set; }
        public DbSet<Item> itens { get; set; }
    }
}
