using Store.Entities;

namespace Store.Repository;

public interface IDiscountRepository
{
    Discount Get(string code);
}