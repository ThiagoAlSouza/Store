using Store.Repository;

namespace Store.Mocks;

public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
{
    #region Methods

    public decimal GetFee(string zipCode)
    {
        if (zipCode.Equals("10203040"))
            return 10;

        return 0;
    }

    #endregion
}