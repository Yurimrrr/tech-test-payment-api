using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Enums
{
    public enum StatusVenda
    {
        AguardandoPagamento = 1,
        PagamentoAprovado = 2,
        EnviadoTransportadora = 3,
        Cancelado = 4,
        Entregue = 5,
    }
}
