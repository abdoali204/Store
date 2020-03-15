using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Entities
{
    public class ShippingDetails
    {
        public int ShippingDetailsID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")] 
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")] 
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")] 
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date = DateTime.Today.Date;
        public string Status { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
