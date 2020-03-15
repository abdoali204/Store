using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> cartLines = new List<CartLine>();

        //add
        public void AddItem(Product p, int q)
        {
            CartLine line = cartLines.Where(cl => cl.Product.ProductID == p.ProductID).FirstOrDefault();
            if (line == null)
            {
                line = new CartLine() { Product = p, Quantity = 1 };
                cartLines.Add(line);
            }
            else
                line.Quantity++;
        }

        public void RemoveLine(int id)
        {
            CartLine line = cartLines.Where(cl => cl.Product.ProductID == id).FirstOrDefault();
            if (line != null)
            {
                if (line.Quantity > 1)
                    line.Quantity--;
                else
                    cartLines.Remove(line);
            }
        }
        public void Clear()
        {
            cartLines.Clear();
        }
        public decimal ComputeTotalValue()
        {
            return (decimal)cartLines.Sum(cl => cl.Product.Price * cl.Quantity);
        }
        public IEnumerable<CartLine> Lines
        {
            get { return cartLines; }
        }
    }
}
