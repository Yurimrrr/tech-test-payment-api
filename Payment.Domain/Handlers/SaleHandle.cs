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
using Payment.Domain.Enums;

namespace Payment.Domain.Handlers
{
    public class SaleHandle : 
        Notifiable,
        IHandler<CreateSaleCommand>,
        IHandler<UpdateSaleStatusCommand>
    {
        private readonly ISaleRepository _repository;
        private readonly IStatusSaleRepository _statusRepository;
        public SaleHandle(ISaleRepository repository, IStatusSaleRepository statusRepository)
        {
            _repository = repository;
            _statusRepository = statusRepository;
        }
        public ICommandResult Handle(CreateSaleCommand command)
        {
            // Criar user -- fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao salvar a venda!", command.Notifications);

            if(command.Products.Count == 0)
                return new GenericCommandResult(false, "A venda deve possuir pelo menos 1 produto!", command.Notifications);

            StatusSale status = _statusRepository.GetById(1);

            List<Product> products = new();
            
            foreach (var _product in command.Products)
            {
                Product newProduct = new (_product.Name);
                products.Add(newProduct);
            }

            Seller seller = new(
                command.Seller.Name, 
                command.Seller.Email, 
                command.Seller.CPF,
                command.Seller.PhoneNumber
            );

            var sale = new Sale(
                command.Date,
                seller,
                products,
                status.Id
            );

            //Salva
            _repository.Create(sale);

            return new GenericCommandResult(true, "Venda realizada!", sale);
            
        }

        public ICommandResult Handle(UpdateSaleStatusCommand command, Guid id)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao salvar a venda!", command.Notifications);

            Sale sale = _repository.GetById(id);

            if (sale == null)
                return new GenericCommandResult(false, "Venda não encontrada!", command.Notifications);

            StatusSale currentStatus = _statusRepository.GetById(sale.StatusId);

            StatusSale status = _statusRepository.GetById((int)command.Status);
            if (status == null)
                return new GenericCommandResult(false, "Status requisitado não existe!", command.Notifications);
           
            bool validaStatus = currentStatus.ValidaStatus(status.Id);
            if(!validaStatus)
                return new GenericCommandResult(false, $"Não se pode definir {status.Name} enquanto o status for {currentStatus.Name}!", command.Notifications);

            sale.UpdateStatus(status.Id);

            _repository.Update(sale);

            sale = _repository.GetById(id);

            return new GenericCommandResult(true, $"Status da venda atualizado para {status.Name}!", sale);
        }

        public ICommandResult Handle(UpdateSaleStatusCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
