using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Models
{
	public abstract class BaseObject
	{
		public Guid Uuid { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return $"[{Uuid}] {Name}";
		}
	}
}
