using Store.Commands;

namespace Store.Tests.Commands;

public class CreateOrderCommandsTests
{
    #region Methods

    [Fact]
    public void WhenACommandIsInvalidTheOrderCantBeProcess()
    {
        var itemList = new List<CreateOrderItemCommand>
        {
            new CreateOrderItemCommand(Guid.NewGuid(), 1),
            new CreateOrderItemCommand(Guid.NewGuid(), 1)
        };

        var orderCommand = new CreateOrderCommand("Thiagoalve", "82739164", string.Empty, itemList);
        orderCommand.Validate();

        Assert.True(!orderCommand.IsValid);
    }

    [Fact]
    public void WhenACommandIsValidTheOrderCanBeProcess()
    {
        var itemList = new List<CreateOrderItemCommand>
        {
            new CreateOrderItemCommand(Guid.NewGuid(), 2),
            new CreateOrderItemCommand(Guid.NewGuid(), 3)
        };

        var orderCommand = new CreateOrderCommand("Thiagoalves", "82739164", string.Empty, itemList);
        orderCommand.Validate();

        Assert.True(orderCommand.IsValid);
    }

    #endregion
}