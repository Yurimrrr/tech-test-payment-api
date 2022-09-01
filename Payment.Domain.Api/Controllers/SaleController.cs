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
        public IEnumerable<Sale> GetAll(
            [FromServices]ISaleRepository repository
        )
        {
            return repository.GetAll();
        }


        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody]CreateSaleCommand command,
            [FromServices]SaleHandle handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] CreateSaleCommand command,
            [FromServices] SaleHandle handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


    }
}
