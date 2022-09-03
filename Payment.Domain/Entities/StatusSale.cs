using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class StatusSale : Entity
    {
        public StatusSale(string name, int codigo)
        {
            Name = name;
            Codigo = codigo;
        }


        public string? Name { get; private set; }
        public int? Codigo { get; private set; }


    }
}
