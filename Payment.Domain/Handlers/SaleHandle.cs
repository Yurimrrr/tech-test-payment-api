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

            if (sale == null)
            {
                return new GenericCommandResult(false, "Venda não encontrada!", command.Notifications);
            }

            StatusSale status = _statusRepository.GetByCodigo(command.Status.GetHashCode());

            if (status == null)
            {
                return new GenericCommandResult(false, "Status requisitado não existe!", command.Notifications);
            }

            if (sale.Status.Codigo == status.Codigo)
            {
                return new GenericCommandResult(false, $"Status da venda já está em {status.Name}!", command.Notifications);
            }

            if (sale.Status.Codigo == (int)StatusVenda.AguardandoPagamento
                && (status.Codigo != (int)StatusVenda.PagamentoAprovado
                    && status.Codigo != (int)StatusVenda.Cancelado))
            {
                return new GenericCommandResult(false, $"Status da venda já está em {status.Name}!", command.Notifications);
            }
            else if (sale.Status.Codigo == (int)StatusVenda.PagamentoAprovado
                && (status.Codigo != (int)StatusVenda.EnviadoTransportadora
                    && status.Codigo != (int)StatusVenda.Cancelado))
            {
                return new GenericCommandResult(false, $"Status da venda já está em {status.Name}!", command.Notifications);
            }
            else if (sale.Status.Codigo == (int)StatusVenda.EnviadoTransportadora
                && (status.Codigo != (int)StatusVenda.Entregue))
            {
                return new GenericCommandResult(false, $"Status da venda já está em {status.Name}!", command.Notifications);
            }

            sale.UpdateStatus(status);

            return new GenericCommandResult(true, $"Status da venda atualizado para {status.Name}!", command.Notifications);
        }
    }
}
