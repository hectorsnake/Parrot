using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Exceptions
{
	public class ServiceUnauthorizedException : Exception
	{
		public ServiceUnauthorizedException(string pMessage)
			: base(pMessage)
		{
		}
	}

}
