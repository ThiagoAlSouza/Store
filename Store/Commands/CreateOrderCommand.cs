using Flunt.Notifications;
using Flunt.Validations;
using Store.Commands.Interfaces;

namespace Store.Commands;

public class CreateOrderCommand : Notifiable<Notification>, ICommand
{
    #region Contructor

    public CreateOrderCommand()
    {
        CreateOrderItemCommandsCommands = new List<CreateOrderItemCommand>();
    }

    public CreateOrderCommand(string customer, string zipCode, string promoCode,
        IList<CreateOrderItemCommand> createOrderItemCommandsCommands)
    {
        Customer = customer;
        ZipCode = zipCode;
        PromoCode = promoCode;
        CreateOrderItemCommandsCommands = createOrderItemCommandsCommands;
    }

    #endregion

    #region Properties

    public string Customer { get; set; }
    public string ZipCode { get; set; }
    public string PromoCode { get; set; }
    public IList<CreateOrderItemCommand> CreateOrderItemCommandsCommands { get; set; }

    #endregion

    #region Methods

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterOrEqualsThan(Customer.Length, 11, "Customer", " Invalid Customer")
            .IsGreaterOrEqualsThan(ZipCode.Length, 8, "ZipCode", " Invalid CEP")
        );
    }

    #endregion
}