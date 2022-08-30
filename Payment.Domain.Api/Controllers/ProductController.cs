using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Commands;
using Payment.Domain.Entities;
using Payment.Domain.Repositores;
using Payment.Domain.Handlers;

namespace Payment.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public IEnumerable<Product> GetAll(
            [FromServices]IProductRepository repository
        )
        {
            return repository.GetAll();
        }


        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody]CreateProductCommand command,
            [FromServices]ProductHandle handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] CreateProductCommand command,
            [FromServices] ProductHandle handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


    }
}
