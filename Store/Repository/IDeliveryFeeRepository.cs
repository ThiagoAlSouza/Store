namespace Store.Repository;

public interface IDeliveryFeeRepository
{
    decimal GetFee(string zipCode);
}