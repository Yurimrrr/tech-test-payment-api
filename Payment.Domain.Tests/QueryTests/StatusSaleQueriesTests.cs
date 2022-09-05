

using Payment.Domain.Entities;
using Payment.Domain.Queries;
using System.Net.NetworkInformation;

namespace Payment.Domain.Tests.QueryTests;

[TestClass]
public class StatusSaleQueriesTests
{
    private readonly List<StatusSale> _status = new();

    public StatusSaleQueriesTests()
    {
        _status.Add(new StatusSale(1, "Aguardando Pagamento"));
        _status.Add(new StatusSale(2, "Pagamento Aprovado"));
        _status.Add(new StatusSale(3, "Enviado Transportadora"));
        _status.Add(new StatusSale(4, "Cancelado"));
        _status.Add(new StatusSale(5, "Entregue"));
    }

    [TestMethod]
    public void Dada_a_consulta_deve_retornar_status_com_id_2()
    {
        var result = _status.AsQueryable().Where(StatusSaleQueries.GetById(2));
        Assert.AreEqual(1, result.Count());
    }


}