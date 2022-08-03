namespace Store.Repository;

public interface IDeliveryFeeRepository
{
    decimal GetFee(decimal zipCode);
}