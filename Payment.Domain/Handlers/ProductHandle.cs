using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Commands;
using Payment.Domain.Commands.Contracts;
using Payment.Domain.Entities;
using Payment.Domain.Handlers.Contracts;
using Payment.Domain.Repositores;

namespace Payment.Domain.Handlers
{
    public class ProductHandle : 
        Notifiable,
        IHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        public ProductHandle(IProductRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateProductCommand command)
        {
            // Criar user -- fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Alguma coisa errada", command.Notifications);

                //Gera
                var product = new Product(command.Name);

                //Salva
                _repository.Create(product);

                return new GenericCommandResult(true, "Usuario salvo", product);
            
        }
    }
}
