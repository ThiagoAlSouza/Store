using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities
{
    public class OrderItem : BaseEntity
    {
        #region Constructors

        public OrderItem(Product product, int quantity)
        {
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
}
