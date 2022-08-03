using Store.Entities;

namespace Store.Tests.Entities;

public class DiscountTests
{
    #region Methods

    [Theory]
    [InlineData("2022, 08, 02")]
    public void ShouldReturnErrorWhenDiscountIsNotValid(DateTime date)
    {
        var discount = new Discount(60, new DateTime(2022, 08, 02));

        Assert.True(!discount.IsValid());
    }

    [Fact]
    public void ShouldReturnSucessWhenDiscountIsValid()
    {
        var discount = new Discount(60, new DateTime(2022, 08, 25));

        Assert.True(discount.IsValid());
    }

    #endregion
}