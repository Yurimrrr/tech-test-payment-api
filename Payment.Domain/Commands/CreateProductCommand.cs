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
    public class CreateProductCommand : Notifiable, ICommand
    {
        public CreateProductCommand()
        {
        }

        public CreateProductCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 2, "Name", "Nome deve ter mais caracteres")
            );
        }
    }
}
