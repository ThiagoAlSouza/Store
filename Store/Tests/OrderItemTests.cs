using Store.Entities;

namespace Store.Tests;

public class OrderItemTests
{
    #region Private

    private readonly OrderItem _orderItem;

    #endregion

    #region Constructor

    public OrderItemTests()
    {
        _orderItem = new OrderItem(null, 0);
    }

    #endregion

    #region Methods

    [Fact]
    public void ShouldReturnErrorWhenProductIsNull()
    {
        Assert.True(!_orderItem.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenQuantityIsMinorOrEqualThan0()
    {
        Assert.True(!_orderItem.IsValid);
    }

    #endregion
}