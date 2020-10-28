using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Models
{
	public class StoresResponse
	{
		public string Status { get; set;}
		public StoreUser Result { get; set;}

	}

	public class StoreUser
	{
		public Guid Uuid { get; set;}
		public string Email { get; set;}
		public string Username { get; set; }
		public List<Store> Stores { get; set;}
	}
}
