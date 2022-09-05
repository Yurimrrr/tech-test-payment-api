using Payment.Domain.Entities;
using Payment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Tests.EntityTests
{
    [TestClass]
    public class StatusSaleTests
    {
        [TestMethod]
        [DataRow((int)StatusVenda.AguardandoPagamento, (int)StatusVenda.EnviadoTransportadora)]
        [DataRow((int)StatusVenda.AguardandoPagamento, (int)StatusVenda.Entregue)]
        [DataRow((int)StatusVenda.PagamentoAprovado, (int)StatusVenda.AguardandoPagamento)]
        [DataRow((int)StatusVenda.PagamentoAprovado, (int)StatusVenda.Entregue)]
        [DataRow((int)StatusVenda.EnviadoTransportadora, (int)StatusVenda.AguardandoPagamento)]
        [DataRow((int)StatusVenda.EnviadoTransportadora, (int)StatusVenda.PagamentoAprovado)]
        [DataRow((int)StatusVenda.EnviadoTransportadora, (int)StatusVenda.Cancelado)]
        public void Validacao_status_deve_retornar_false_em_casos_incorretos(int currentStatus, int newStatus)
        {
            StatusSale statusSale = new StatusSale(currentStatus);

            bool retorno = statusSale.ValidaStatus(newStatus);

            Assert.AreEqual(retorno, false);
        }

        [TestMethod]
        [DataRow((int)StatusVenda.AguardandoPagamento, (int)StatusVenda.PagamentoAprovado)]
        [DataRow((int)StatusVenda.AguardandoPagamento, (int)StatusVenda.Cancelado)]
        [DataRow((int)StatusVenda.PagamentoAprovado, (int)StatusVenda.EnviadoTransportadora)]
        [DataRow((int)StatusVenda.PagamentoAprovado, (int)StatusVenda.Cancelado)]
        [DataRow((int)StatusVenda.EnviadoTransportadora, (int)StatusVenda.Entregue)]
        public void Validacao_status_deve_retornar_true_em_casos_corretos(int currentStatus, int newStatus)
        {
            StatusSale statusSale = new StatusSale(currentStatus);

            bool retorno = statusSale.ValidaStatus(newStatus);

            Assert.AreEqual(retorno, true);
        }
    }
}
