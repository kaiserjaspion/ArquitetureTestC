using Teste.Arquitetura.Server.Models.DTO;

namespace Teste.Arquitetura.Server.Repositories.Interfaces
{
    public interface ICashFlowRepository
    {
        Task<bool> InsertCashFlow(CashFlow cashFlow);
        Task<List<CashFlow>> ReportCashFlow(DateTime date);
    }
}
