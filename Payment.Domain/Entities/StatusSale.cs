using Payment.Domain.Commands;
using Payment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class StatusSale : Entity
    {
        public StatusSale(int id)
        {
            Id = id;
        }

        public StatusSale(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public StatusSale()
        {
        }
        [Key()]
        public int Id { get; set; }
        public string? Name { get; set; }

        public bool ValidaStatus(int newStatus)
        {
            if (this.Id == newStatus)
            {
                return false;
            }

            if (this.Id == (int)StatusVenda.AguardandoPagamento
                && (newStatus != (int)StatusVenda.PagamentoAprovado
                    && newStatus != (int)StatusVenda.Cancelado))
            {
                return false;
            }
            else if (this.Id == (int)StatusVenda.PagamentoAprovado
                && (newStatus != (int)StatusVenda.EnviadoTransportadora
                    && newStatus != (int)StatusVenda.Cancelado))
            {
                return false;
            }
            else if (this.Id == (int)StatusVenda.EnviadoTransportadora
                && (newStatus != (int)StatusVenda.Entregue))
            {
                return false;
            }

            return true;
        }
    }
}
