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
    public class CreateSellerCommand : Notifiable, ICommand
    {
        public CreateSellerCommand()
        {
        }

        public CreateSellerCommand(string name, string email, string cpf, string phoneNumber)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            PhoneNumber = phoneNumber;
        }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string? PhoneNumber { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 2, "Name", "Nome deve ter mais caracteres")
                    .IsEmail(Email, "Email", "Nome deve ter mais caracteres")
                    .HasMinLen(CPF, 11, "CPF", "Digite um CPF valido")
                    .HasMinLen(PhoneNumber, 11, "PhoneNumber", "Digite um CPF valido")
            );
        }
    }
}
