using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Repository
{
	public interface IGenericRepository
	{
		Task<T> GetAsync<T>(string uri, string authToken = "");
		Task<R> PostAsync<T, R>(string uri, T data, string authToken = "");
		Task<T> PostArrayAsync<T>(string uri, string pFileName, byte[] pDataArray, string authToken = "");
		Task<R> PutAsync<T, R>(string uri, T data, string authToken = "");
		Task DeleteAsync(string uri, string authToken = "");
		Task<T> DeleteAsync<T>(string uri, string authToken = "");
	}
}
