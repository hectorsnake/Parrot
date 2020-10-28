using Parrot_Challenge.Constants;
using Parrot_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Repository
{
	public class DataService : IDataService
	{
		private readonly IGenericRepository _genericRepository;
		private readonly Session _session;

		public DataService(IGenericRepository genericRepository,
								Session pSession) : base()
		{
			_genericRepository = genericRepository;
			_session = pSession;
		}

		public async Task<LoginResponse> Login(User pUser)
		{
			UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl) {
				Path = ApiConstants.PostLogintEndpoint
			};

			return await _genericRepository.PostAsync<User, LoginResponse>(builder.ToString(), pUser, _session.Token);
		}

		public async Task<StoresResponse> GetMyStores()
		{
			UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl) {
				Path = ApiConstants.GetMyStoresEndpoint
			};

			return await _genericRepository.GetAsync<StoresResponse>(builder.ToString(), _session.Token);
		}

		public async Task<ProductsResponse> GetProducts(Guid pStoreId)
		{
			UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl) {
				Path = ApiConstants.GetAllProductsEndpoint
			};
			builder.Query = "store=" + pStoreId.ToString();

			return await _genericRepository.GetAsync<ProductsResponse>(builder.ToString(), _session.Token);
		}

		public async Task<ProductResponse> UpdateProductAvailability(Guid pProductId, string pValue)
		{
			UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl) {
				Path = ApiConstants.PutUpdateProduct + pProductId + "/availability"
			};

			UpdateProductAvailability updateProductAvailability = new UpdateProductAvailability() {
				availability = pValue
			};

			return await _genericRepository.PutAsync<UpdateProductAvailability, ProductResponse>(builder.ToString(), updateProductAvailability, _session.Token);
		}

		public async Task<ValidateTokenResponse> ValidateToken()
		{
			UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl) {
				Path = ApiConstants.GetValidateTokenEndpoint
			};

			return await _genericRepository.GetAsync<ValidateTokenResponse>(builder.ToString(), _session.Token);
		}
	}
}
