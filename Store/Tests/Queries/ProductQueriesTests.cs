using Store.Entities;
using Store.Queries;
using Store.Repository;

namespace Store.Tests.Queries;

public class ProductQueriesTests
{
    #region Private

    private readonly IList<Product> _products;

    #endregion

    #region Contructor

    public ProductQueriesTests()
    {
        _products = new List<Product>();

        _products.Add(new Product("Macarrão", 4, false));
        _products.Add(new Product("Açucar", 3, true));
        _products.Add(new Product("Óleo", 10, true));
        _products.Add(new Product("Café", 5, false));
        _products.Add(new Product("Farinha", 3, true));
    }

    #endregion

    #region Methods

    [Fact]
    public void WhenSearchProductsActivatesShouldReturn3()
    {
        var products = _products.AsQueryable().Where(ProductQueries.GetActivateProducts());

        Assert.Equal(3, products.Count());
    }

    [Fact]
    public void WhenSearchProductsInactivatesShouldReturn2()
    {
        var products = _products.AsQueryable().Where(ProductQueries.GetInactivateProducts());

        Assert.Equal(2, products.Count());
    }

    #endregion
}