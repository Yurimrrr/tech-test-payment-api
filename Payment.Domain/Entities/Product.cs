using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name)
        {
            Name = name;
        }

        public string? Name { get; private set; }


    }
}
