using Parrot_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Repository
{
	public interface IDataService
	{
		Task<LoginResponse> Login(User pUser);

		Task<StoresResponse> GetMyStores();

		Task<ProductsResponse> GetProducts(Guid pStoreId);

		Task<ProductResponse> UpdateProductAvailability(Guid pProductId, string pValue);
		Task<ValidateTokenResponse> ValidateToken();
	}
}
