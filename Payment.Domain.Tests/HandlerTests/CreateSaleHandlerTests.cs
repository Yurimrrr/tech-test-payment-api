using Newtonsoft.Json;
using Payment.Domain.Commands;
using Payment.Domain.Entities;
using Payment.Domain.Handlers;
using Payment.Domain.Tests.Repositories;

namespace Payment.Domain.Tests.HandlerTests;

[TestClass]
public class CreateSaleHandlerTests
{
    private readonly CreateSaleCommand _invalidCommand = new CreateSaleCommand(
        DateTime.Now,
        new CreateSellerCommand("Yuri", "yuriemail", "cpf", "33"),
        new List<CreateProductCommand>()
        );

    private readonly SaleHandle handler = new SaleHandle(new FakeSaleRepository(), new FakeStatusSaleRepository());

    private readonly List<CreateProductCommand> products = new List<CreateProductCommand>();

    public CreateSaleHandlerTests()
    {
        _invalidCommand.Validate();

        products.Add(new CreateProductCommand("teste1"));
        products.Add(new CreateProductCommand("teste2"));
        products.Add(new CreateProductCommand("teste3"));
    }

    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
        var result = (GenericCommandResult)handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_a_venda()
    {
        CreateSaleCommand _validCommand = new CreateSaleCommand(
        DateTime.Now,
        new CreateSellerCommand("Yuri", "yurimoreira@gmail.com", "15035287661", "31997219811"),
        products
        );

        _validCommand.Validate();

        var result = (GenericCommandResult)handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }

}