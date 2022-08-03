using Store.Entities;
using Store.Repository;

namespace Store.Mocks;

public class FakeProductRepository : IProductRepository
{
    public IEnumerable<Product> Get(IEnumerable<Product> ids)
    {
        IList<Product> products = new List<Product>();

        products.Add(new Product("Arroz", 16, true));
        products.Add(new Product("Fejião", 5, true));
        products.Add(new Product("Leite", 7, true));
        products.Add(new Product("Macarrão", 4, false));
        products.Add(new Product("Açucar", 3, true));
        products.Add(new Product("Óleo", 10, true));
        products.Add(new Product("Café", 5, false));
        products.Add(new Product("Sal", 2, false));
        products.Add(new Product("Farinha", 3, true));

        return products;
    }
}