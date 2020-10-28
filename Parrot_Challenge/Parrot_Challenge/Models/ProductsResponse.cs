using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Models
{
	public class ProductsResponse
	{
		public string Status { get; set; }
		public List<Product> Results { get; set; }
	}
}
