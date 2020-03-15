using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Entities
{
    public class OrderProduct
    {
        [Key]
        [ForeignKey("Order")]
        [Column(Order = 1)]
        public int OrderID { get; set; }
        [Key]
        [ForeignKey("Product")]
        [Column(Order =2 )]
        public int ProductID { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "0:{yyyy-mm-dd}")]
        public DateTime Date = DateTime.Today.Date;
        public int Quantity { get; set; }
        public virtual ShippingDetails Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
