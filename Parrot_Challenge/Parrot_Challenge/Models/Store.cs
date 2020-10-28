using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Models
{
	public class Store : BaseObject
	{
        public string AvailabilityState { get; set;}

        public List<Provider> Providers { get; set;}

        public string Config { get; set;}
	}
}
