using Flunt.Notifications;
using Flunt.Validations;
using Store.Commands.Interfaces;

namespace Store.Commands;

public class CreateOrderCommand : Notifiable<Notification>, ICommand
{
    #region Contructor

    public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderCommand> createOrderCommands)
    {
        Customer = customer;
        ZipCode = zipCode;
        PromoCode = promoCode;
        CreateOrderCommands = createOrderCommands;
    }

    #endregion

    #region Properties

    public string Customer { get; set; }
    public string ZipCode { get; set; }
    public string PromoCode { get; set; }
    public IList<CreateOrderCommand> CreateOrderCommands { get; set; }

    #endregion

    #region Methods

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(Customer, 11, "Customer", " Invalid Customer")
            .IsGreaterThan(ZipCode, 8, "ZipCode", " Invalid CEP")
        );
    }

    #endregion
}