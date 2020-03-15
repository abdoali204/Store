using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product RemoveProduct(int id);
    }
}
