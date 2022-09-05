

using Payment.Domain.Entities;
using Payment.Domain.Queries;
using System.Net.NetworkInformation;

namespace Payment.Domain.Tests.QueryTests;

[TestClass]
public class StatusSaleQueriesTests
{
    private readonly List<StatusSale> _status = new List<StatusSale>();

    public StatusSaleQueriesTests(List<StatusSale> status)
    {
        _status.Add(new StatusSale("Aguardando Pagamento", 0));
        _status.Add(new StatusSale("Pagamento Aprovado", 1));
        _status.Add(new StatusSale("Enviado Transportadora", 2));
        _status.Add(new StatusSale("Cancelado", 3));
        _status.Add(new StatusSale("Entregue", 4));

    }

    [TestMethod]
    public void Dada_a_consulta_deve_retornar_status_com_codigo_2()
    {
        var result = _status.AsQueryable().Where(StatusSaleQueries.GetByCodigo(2));
        Assert.AreEqual(1, result.Count());
    }


}