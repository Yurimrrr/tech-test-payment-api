using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Enums
{
    public enum StatusVenda
    {
        AguardandoPagamento = 0,
        PagamentoAprovado = 1,
        EnviadoTransportadora = 2,
        Cancelado = 3,
        Entregue = 4,
    }
}
