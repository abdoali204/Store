using StoreBook.Domain.Abstract;
using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private EFDbContext db = new EFDbContext();

        public IEnumerable<Product> Products {
            get {  return db.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                db.Products.Add(product);
            }
            else
            {
                var EntryProduct = db.Products.Find(product.ProductID);
                EntryProduct.Name = product.Name;
                EntryProduct.Description = product.Description;
                EntryProduct.Category = product.Category;
                EntryProduct.Price = product.Price;
                EntryProduct.ImageData = product.ImageData;
                EntryProduct.ImageMimeType = product.ImageMimeType;
                db.Entry(EntryProduct).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
        public Product RemoveProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return product;
        }
    }
}
