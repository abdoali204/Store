using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreBook.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
