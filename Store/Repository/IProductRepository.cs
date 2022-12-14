using Store.Entities;

namespace Store.Repository;

public interface IProductRepository
{
    IEnumerable<Product> Get(IEnumerable<Guid> ids);
}