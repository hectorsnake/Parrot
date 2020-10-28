using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Constants
{
	public class ApiConstants
	{
		public const string BaseApiUrl = "http://api-staging.parrot.rest/";

		public const string PostLogintEndpoint = "api/auth/token";
		public const string PostRefreshEndpoint = "api/auth/token/refresh";
		public const string GetMyStoresEndpoint = "api/v1/users/me";
		public const string GetAllProductsEndpoint = "api/v1/products/";
		public const string PutUpdateProduct = "api/v1/products/";

		public const string GetValidateTokenEndpoint = "api/auth/token/test";
	}
}
