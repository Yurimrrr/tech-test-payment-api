using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Commands;
using Payment.Domain.Entities;
using Payment.Domain.Repositores;
using Payment.Domain.Handlers;

namespace Payment.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/sale")]
    public class SaleController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices]ISaleRepository repository
        )
        {
            var sales = repository.GetAll();
            return sales.Any() ? Ok(sales) : NotFound("Não foi encontrada nenhuma venda.");
        }

        [Route("getstatus")]
        [HttpGet]
        public async Task<IActionResult> GetAllStatus(
            [FromServices] IStatusSaleRepository repository
        )
        {
            var status = repository.GetAll();
            return status.Any() ? Ok(status) : NotFound("Não foi encontrada nenhum status.");
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody]CreateSaleCommand command,
            [FromServices]SaleHandle handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<GenericCommandResult>> Update(
            Guid id,
            [FromBody] UpdateSaleStatusCommand command,
            [FromServices] SaleHandle handler
            )
        {
            return (GenericCommandResult)handler.Handle(command, id);
        }



    }
}
