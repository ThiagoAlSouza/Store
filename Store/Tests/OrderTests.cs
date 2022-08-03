using Store.Entities;

namespace Store.Tests;

public class OrderTests
{
    [Fact]
    public void WhenCreatedAOrderShouldReturnNumberWith8Characters()
    {
        var customer = new Customer("Thiago", "thiagoalsouza98@outlook.com.br");
        var discount = new Discount(50, new DateTime(2022, 08, 03));
        var order = new Order(customer, discount, 10);

        Assert.Equal(8, order.Number.Length);
    }
}