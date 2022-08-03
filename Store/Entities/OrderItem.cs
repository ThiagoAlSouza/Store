using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Entities;
public class OrderItem : BaseEntity
{
    #region Constructors

    public OrderItem(Product product, int quantity)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNull(product, "Product", "Product is null.")
            .IsGreaterThan(quantity, 0, "Quantity", "The quantity should be greater than zero."));


        Product = product;
        Price = product != null ? product.Price : 0;
        Quantity = quantity;
    }

    #endregion

    #region Properties

    public Product Product { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    #endregion

    #region Methods

    public decimal Total()
    {
        return Price * Quantity;
    }

    #endregion
}