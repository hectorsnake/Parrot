using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Models
{
	public class Product : BaseObject
    {
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string LegacyId { get; set; }

        public decimal Price { get; set;}
        public decimal AlcoholCount { get; set;}
        public bool SoldAlone { get; set;}
        public string Availability { get; set;}

        public string ProviderAvailability { get; set;}

        public Category Category { get; set;}

        public delegate void DOnAvailabilityChanged(Product pProduct, string pAvailability);

        public event DOnAvailabilityChanged OnAvailabilityChanged;

        public void RaiseAvailabilityChanged(string pAvailability)
		{
            if (OnAvailabilityChanged != null)
                OnAvailabilityChanged(this, pAvailability);
        }
    }
}
