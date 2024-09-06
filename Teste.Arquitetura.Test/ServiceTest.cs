using Moq;
using Teste.Arquitetura.Server.Models.DTO;
using Teste.Arquitetura.Server.Services;
using Teste.Arquitetura.Server.Services.Interfaces;

namespace Teste.Arquitetura.Test
{
    public class ServiceTest
    {
        private readonly ICashFlowService _service;
        public ServiceTest()
        {
            _service = new Mock<CashFlowService>().Object;
        }
        [Fact]
        public void TestReport()
        {

            var date = DateTime.MinValue;
            DateTime.TryParse("2024-04-09", out date);
            Assert.NotEmpty(_service.ReportCashFlow(date).Result);
        }

        [Fact]
        public void TestTransaction()
        {

            var transaction = new CashFlow();
            Assert.True(_service.InsertCashFlow(transaction).Result);
        }
    }
}