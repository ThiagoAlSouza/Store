using Store.Repository;

namespace Store.Mocks;

public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
{
    public decimal GetFee(string zipCode)
    {
        if (zipCode.Equals("10203040"))
            return 10;

        return 0;
    }
}