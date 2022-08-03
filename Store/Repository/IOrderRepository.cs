using Store.Entities;

namespace Store.Repository;

public interface IOrderRepository
{
    void Save(Order order);
}