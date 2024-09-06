using Microsoft.AspNetCore.Mvc;
using Teste.Arquitetura.Server.Models.DTO;
using Teste.Arquitetura.Server.Services.Interfaces;

namespace Teste.Arquitetura.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashFlowController : ControllerBase
    {
        

        private readonly ILogger<CashFlowController> _logger;
        private readonly ICashFlowService _service;

        public CashFlowController(ILogger<CashFlowController> logger,ICashFlowService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{Date}")]
        public async Task<IActionResult> Get(DateTime Date)
        {
            try
            {
               return Ok(await _service.ReportCashFlow(Date));
            }catch(Exception ex)
            {
                _logger.LogError(new EventId(),ex,ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("Manually")]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CashFlow Transaction)
        {
            try
            {
                return Ok( await _service.InsertCashFlow(Transaction));
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, ex.Message);
                return StatusCode(500);
            }
        }

    }
}
