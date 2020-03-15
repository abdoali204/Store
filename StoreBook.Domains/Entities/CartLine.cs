using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Entities
{
    public class CartLine
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
