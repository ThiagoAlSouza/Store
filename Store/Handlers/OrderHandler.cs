using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Store.Commands;
using Store.Commands.Interfaces;
using Store.Entities;
using Store.Handlers.Interfaces;
using Store.Repository;
using Store.Utils;

namespace Store.Handlers
{
    internal class OrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>
    {
        #region Private

        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryFeeRepository _deliveryRepository;

        #endregion

        #region Constructor

        public OrderHandler(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IDiscountRepository discountRepository,
            IOrderRepository orderRepository,
            IDeliveryFeeRepository deliveryRepository
            )
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _discountRepository = discountRepository;
            _orderRepository = orderRepository;
            _deliveryRepository = deliveryRepository;
        }

        #endregion

        #region Methods

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Invalid order", command.Notifications);

            var customer = _customerRepository.Get(command.Customer);

            var deliveryFee = _deliveryRepository.GetFee(command.ZipCode);

            var discount = _discountRepository.Get(command.PromoCode);

            var products = _productRepository.Get(ExtractGuids.Extract(command.CreateOrderItemCommandsCommands)).ToList();
            var order = new Order(customer, discount, deliveryFee);
            foreach (var item in command.CreateOrderItemCommandsCommands)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            AddNotifications(order.Notifications);

            if (!command.IsValid)
                return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);

            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
        }

        #endregion
    }
}
