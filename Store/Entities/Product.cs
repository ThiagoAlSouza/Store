namespace Store.Entities;

public class Product : BaseEntity
{
    #region Constructors

    public Product(string title, decimal price, bool active)
    {
        Title = title;
        Price = price;
        Active = active;
    }

    #endregion

    #region properties

    public string Title { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }

    #endregion
}