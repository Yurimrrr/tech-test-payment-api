using Flunt.Validations;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Commands.Contracts;
using System.Xml.Linq;

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
                    .IsNotNullOrEmpty(Date.ToString(), "Date", "Data não pode ser vazia!")
                    .HasMinLen(Seller.Name, 2, "Seller.Name", "Nome deve ter mais caracteres")
                    .IsEmail(Seller.Email, "Seller.Email", "Digite um Email valido!")
                    .HasMinLen(Seller.CPF, 11, "Seller.CPF", "Digite um CPF valido!")
                    .HasMinLen(Seller.PhoneNumber, 11, "Seller.PhoneNumber", "Digite um numero valido!")
            );
        }
    }
}
