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
    public class SaleHandle : 
        Notifiable,
        IHandler<CreateSaleCommand>,
        IHandler<UpdateSaleStatusCommand>
    {
        private readonly ISaleRepository _repository;
        public SaleHandle(ISaleRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateSaleCommand command)
        {
            // Criar user -- fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao salvar a venda!", command.Notifications);

            List<Product> products = new List<Product>();

            foreach (var _product in command.Products)
            {
                Product newProduct = new Product(_product.Name);
                products.Add(newProduct);
            }

            Seller seller = new Seller(
                command.Seller.Name, 
                command.Seller.Email, 
                command.Seller.CPF,
                command.Seller.PhoneNumber
                );

            var sale = new Sale(
                command.Date,
                seller,
                products
                );

            //Salva
            _repository.Create(sale);

            return new GenericCommandResult(true, "Venda realizada!", sale);
            
        }

        public ICommandResult Handle(UpdateSaleStatusCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao salvar a venda!", command.Notifications);

            Sale sale = _repository.GetById(command.Id);

            if(sale == null)
            {
                return new GenericCommandResult(false, "Venda não encontrada!", command.Notifications);
            }

            


            throw new NotImplementedException();
        }
    }
}
