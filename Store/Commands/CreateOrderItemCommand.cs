using Flunt.Notifications;
using Flunt.Validations;
using Store.Commands.Interfaces;

namespace Store.Commands;

public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
{
    #region Constructor

    public CreateOrderItemCommand(Guid product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    #endregion

    #region Properties

    public Guid Product { get; set; }
    public int Quantity { get; set; }

    #endregion

    #region Methods

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(Product.ToString(), 32, "Product", " Invalid Product.")
            .IsGreaterThan(Quantity, 0, "Quantity", " Invalid Quantity.")
        );
    }

    #endregion
}