using StoreBook.Domain.Abstract;
using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private EFDbContext db = new EFDbContext();

        public IEnumerable<ShippingDetails> Orders => db.ShippingDetails;


        public void ProcessOrder(Cart cart, ShippingDetails order)
        {
              //add order section
              order.Status = "Delivered";

              db.ShippingDetails.Add(order);
              db.SaveChanges();
              //add product order section
              foreach (var line in cart.Lines)
              {
                  OrderProduct orderProduct = new OrderProduct() { OrderID = order.ShippingDetailsID, ProductID = line.Product.ProductID, Quantity = line.Quantity };
                  db.OrderProducts.Add(orderProduct);

              }
              db.SaveChanges();

        }

    }
}
