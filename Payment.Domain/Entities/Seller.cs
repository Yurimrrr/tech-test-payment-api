using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class Seller : Entity
    {
        public Seller(string name, string email, string cpf, string phoneNumber)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            PhoneNumber = phoneNumber;
        }

        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? CPF { get; private set; }
        public string? PhoneNumber { get; private set; }

    }
}
