using Microsoft.EntityFrameworkCore;
using Teste.Arquitetura.Server.Contexts;
using Teste.Arquitetura.Server.Models.DTO;
using Teste.Arquitetura.Server.Repositories.Interfaces;

namespace Teste.Arquitetura.Server.Repositories
{
    public class CashFlowRepository : ICashFlowRepository
    {
        private readonly CashFlowContext _context;
        public CashFlowRepository(CashFlowContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertCashFlow(CashFlow cashFlow)
        {
            _context.Add(cashFlow);
            var result = await _context.SaveChangesAsync();
            return (result > 0);
        }

        public async Task<List<CashFlow>> ReportCashFlow(DateTime date)
        {
            return await _context.cashflow
                    .Where(x => DateOnly.FromDateTime(x.Date) == DateOnly.FromDateTime(date))
                    .ToListAsync();
        }
    }
}
