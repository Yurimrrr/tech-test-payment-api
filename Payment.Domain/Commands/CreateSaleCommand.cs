using Flunt.Validations;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Commands.Contracts;

namespace Payment.Domain.Commands
{
    public class CreateSaleCommand : Notifiable, ICommand
    {
        public CreateSaleCommand()
        {
        }

        public CreateSaleCommand(DateTime date, CreateSellerCommand seller, List<CreateProductCommand> products)
        {
            Date = date;
            Seller = seller;
            Products = products;
        }

        public DateTime Date { get; set; }
        public CreateSellerCommand? Seller { get; set; }
        public List<CreateProductCommand>? Products { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Date,"Date", "Data não pode ser vazia!")
            );;
        }
    }
}
