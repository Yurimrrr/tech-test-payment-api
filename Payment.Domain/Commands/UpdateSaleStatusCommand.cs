using Flunt.Validations;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Commands.Contracts;
using Payment.Domain.Enums;

namespace Payment.Domain.Commands
{
    public class UpdateSaleStatusCommand : Notifiable, ICommand
    {
        public UpdateSaleStatusCommand()
        {
        }

        public UpdateSaleStatusCommand(StatusVenda status)
        {
            Status = status;
        }

        public StatusVenda Status { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Status, "Status", "Status não pode ser vazio!")
            );;
        }
    }
}
