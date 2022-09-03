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


        [Route("")]
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody]CreateSaleCommand command,
            [FromServices]SaleHandle handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GenericCommandResult>> Update(
            [FromBody] UpdateSaleStatusCommand command,
            [FromServices] SaleHandle handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }



    }
}
