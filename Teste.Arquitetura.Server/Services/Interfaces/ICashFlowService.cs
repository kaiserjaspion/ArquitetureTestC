using Teste.Arquitetura.Server.Models.DTO;

namespace Teste.Arquitetura.Server.Services.Interfaces
{
    public interface ICashFlowService
    {
        Task<bool> InsertCashFlow(CashFlow cashFlow);
        Task<List<CashFlow>> ReportCashFlow(DateTime date);
    }
}
