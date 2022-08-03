using Store.Entities;
using Store.Repository;

namespace Store.Mocks;

public class FakeDiscountRepository : IDiscountRepository
{
    public Discount Get(string code)
    {
        if (code.Equals("4321"))
            return new Discount(10, DateTime.Now.AddDays(3));

        if (code.Equals("1234"))
            return new Discount(10, DateTime.Now.AddDays(-3));

        return null;
    }
}