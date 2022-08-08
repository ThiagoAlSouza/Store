using Store.Commands;
using Store.Handlers;
using Store.Mocks;
using Store.Repository;

namespace Store.Tests.Handlers;

public class OrderHandlerTests
{
    #region Private

    private readonly ICustomerRepository _customerRepository;
    private readonly IDeliveryFeeRepository _deliveryFeeRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    #endregion

    #region Constructor
    public OrderHandlerTests()
    {
        _customerRepository = new FakeCustomerRepository();
        _deliveryFeeRepository = new FakeDeliveryFeeRepository();
        _discountRepository = new FakeDiscountRepository();
        _orderRepository = new FakeOrderRepository();
        _productRepository = new FakeProductRepository();
    }

    #endregion

    #region Methods

    [Fact]
    public void WhenACustomerNotExistTheOrderCantBeProcess()
    {
        var itemList = new List<CreateOrderItemCommand>
        {
            new CreateOrderItemCommand(Guid.NewGuid(), 1),
            new CreateOrderItemCommand(Guid.NewGuid(), 2)
        };

        var orderCommand = new CreateOrderCommand("Thiagoalve", "82739164", string.Empty, itemList);
        orderCommand.Validate();

        Assert.True(!orderCommand.IsValid);
    }

    [Fact]
    public void WhenACepInvalidTheOrderCantBeProcess()
    {
        var itemList = new List<CreateOrderItemCommand>
        {
            new CreateOrderItemCommand(Guid.NewGuid(), 1)
        };

        var orderCommand = new CreateOrderCommand("Thiago alves", "8273916", string.Empty, itemList);
        orderCommand.Validate();

        Assert.True(!orderCommand.IsValid);
    }

    [Fact]
    public void WhenACommandIsInvalidTheOrderCantBeProcess()
    {
        var itemList = new List<CreateOrderItemCommand>
        {
            new CreateOrderItemCommand(Guid.NewGuid(), 1),
            new CreateOrderItemCommand(Guid.NewGuid(), 2)
        };

        var orderCommand = new CreateOrderCommand("Thiagoalve", "82739164", string.Empty, itemList);
        orderCommand.Validate();

        Assert.True(!orderCommand.IsValid);
    }

    [Fact]
    public void WhenACommandIsValidTheOrderCanBeProcess()
    {
        var itemList = new List<CreateOrderItemCommand>
        {
            new CreateOrderItemCommand(Guid.NewGuid(), 3),
            new CreateOrderItemCommand(Guid.NewGuid(), 6)
        };

        var orderCommand = new CreateOrderCommand("Thiagoalves", "10203040", string.Empty, itemList);
        orderCommand.Validate();

        var handler = new OrderHandler(
            _customerRepository,
            _productRepository,
            _discountRepository,
            _orderRepository,
            _deliveryFeeRepository);

        handler.Handle(orderCommand);
        Assert.True(handler.IsValid);
    }

    [Fact]
    public void WhenAPromoCodeIsInvalidTheOrderCantBeProcess()  
    {
        var itemList = new List<CreateOrderItemCommand>
        {
            new CreateOrderItemCommand(Guid.NewGuid(), 3),
            new CreateOrderItemCommand(Guid.NewGuid(), 6)
        };

        var orderCommand = new CreateOrderCommand("Thiagoalves", "10203040", "1454", itemList);
        orderCommand.Validate();

        var handler = new OrderHandler(
            _customerRepository,
            _productRepository,
            _discountRepository,
            _orderRepository,
            _deliveryFeeRepository);

        handler.Handle(orderCommand);
        Assert.True(!handler.IsValid);
    }
    #endregion
}