using Store.Entities;
using Store.Entities.Enums;

namespace Store.Tests.Entities;

public class OrderTests
{
    #region Private

    private readonly Customer _customer;
    private readonly Discount _discount;
    private readonly Order _order;
    private readonly Order _orderWithoutCustomer;
    private readonly Product _product;

    #endregion

    #region Constructor

    public OrderTests()
    {
        _customer = new Customer("Thiago", "thiagoalsouza98@outlook.com.br");
        _discount = new Discount(10, new DateTime(2022, 08, 05));
        _order = new Order(_customer, _discount, 0);
        _orderWithoutCustomer = new Order(null, _discount, 0);
        _product = new Product("Arroz", 15, true);
    }

    #endregion

    #region Methods

    [Fact]
    public void WhenCreatedAOrderShouldReturnNumberWith8Characters()
    {
        Assert.Equal(8, _order.Number.Length);
    }

    [Fact]
    public void WhenCreatedAOrderShouldStatusBeWaitingPayment()
    {
        Assert.Equal(EOrderStatus.WaitingPayment, _order.Status);
    }

    [Fact]
    public void WhenPaiedAOrderShouldStatusBeWaitingDelivery()
    {
        _order.AddItem(_product, 2);
        _order.Pay(20);

        Assert.Equal(EOrderStatus.WaitingDelivery, _order.Status);
    }

    [Fact]
    public void WhenCancelAOrderShouldStatusBeWaitingCancelled()
    {
        _order.Cancel();

        Assert.Equal(EOrderStatus.Canceled, _order.Status);
    }

    [Fact]
    public void WhenCreatedAOrderWithoutProductShouldReturnError()
    {
        _order.AddItem(null, 0);

        Assert.Empty(_order.OrderItems);
    }

    [Fact]
    public void WhenCreatedAOrderWithProductQuantityMinorThan0ShouldReturnError()
    {
        _order.AddItem(_product, 0);

        Assert.Empty(_order.OrderItems);
    }

    [Fact]
    public void WhenCreatedAOrderYourTotalShouldBe50()
    {
        _order.AddItem(_product, 4);

        Assert.Equal(50, _order.Total());
    }

    [Fact]
    public void WhenCreatedAOrderWithoutCustomerShouldReturnError()
    {
        Assert.True(!_orderWithoutCustomer.IsValid);
    }

    #endregion
}