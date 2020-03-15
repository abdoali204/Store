using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Abstract
{
    public interface IOrderRepository
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
        IEnumerable<ShippingDetails> Orders { get; }
    }
}
