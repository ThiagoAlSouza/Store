
using Flunt.Notifications;
using Flunt.Validations;
using Store.Entities.Enums;

namespace Store.Entities;

public class Order : BaseEntity
{
    #region Private

    private IList<OrderItem> _ordersItems;

    #endregion

    #region Contructors

    public Order(Customer customer, Discount discount, decimal deliveryFee)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNull(customer, "Custommer", "Customer is null.")
            .IsNotNull(discount, "Discount", "discount is null."));

        Customer = customer;
        Date = DateTime.Now;
        Number = Guid.NewGuid().ToString().Substring(0, 8);
        Status = EOrderStatus.WaitingPayment;
        Discount = discount;
        DeliveryFee = deliveryFee;
        _ordersItems = new List<OrderItem>();
    }

    #endregion

    #region Properties

    public Customer Customer { get; private set; }
    public DateTime Date { get; private set; }
    public string Number { get; private set; }
    public IEnumerable<OrderItem> OrderItems { get { return _ordersItems; } }
    public EOrderStatus Status { get; private set; }
    public Discount Discount { get; private set; }
    public decimal DeliveryFee { get; private set; }

    #endregion

    #region Methods

    public void AddItem(Product product, int quantity)
    {
        var oderItem = new OrderItem(product, quantity);

        if (oderItem.IsValid)
            _ordersItems.Add(oderItem);
    }

    public decimal Total()
    {
        decimal total = 0;

        foreach (var item in OrderItems)
        {
            total += item.Total();
        }

        total += DeliveryFee;
        total -= Discount != null ? Discount.Value() : 0;

        return total;
    }

    public void Pay(decimal amount)
    {
        if (amount == Total())
            Status = EOrderStatus.WaitingDelivery;
    }

    public void Cancel()
    {
        Status = EOrderStatus.Canceled;
    }

    #endregion
}