using System.Linq.Expressions;
using Store.Entities;

namespace Store.Queries;

public static class ProductQueries
{
    public static Expression<Func<Product, bool>> GetActivateProducts()
    {
        return x => x.Active;
    }

    public static Expression<Func<Product, bool>> GetInativeProducts()
    {
        return x => !x.Active;
    }
}