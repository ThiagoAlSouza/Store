using Store.Repository;

namespace Store.Mocks;

public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
{
    public decimal GetFee(string zipCode)
    {
        if (zipCode.Equals("4321"))
            return 10;

        return 0;
    }
}