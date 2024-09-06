using Teste.Arquitetura.Server.Models.DTO;
using Teste.Arquitetura.Server.Repositories.Interfaces;
using Teste.Arquitetura.Server.Services.Interfaces;

namespace Teste.Arquitetura.Server.Services
{
    public class CashFlowService : ICashFlowService
    {
        public readonly ICashFlowRepository _repository;
        public CashFlowService(ICashFlowRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> InsertCashFlow(CashFlow cashFlow)
        {
            return await _repository.InsertCashFlow(cashFlow);
        }

        public async Task<List<CashFlow>> ReportCashFlow(DateTime date)
        {
            return await _repository.ReportCashFlow(date);
        }
    }
}
