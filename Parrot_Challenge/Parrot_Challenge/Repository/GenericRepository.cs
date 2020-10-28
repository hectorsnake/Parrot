using Newtonsoft.Json;
using Parrot_Challenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Repository
{
	public class GenericRepository : IGenericRepository
	{
		public async Task<T> GetAsync<T>(string pURI, string pToken = "")
		{
			try {
				HttpClient httpClient = CreateHttpClient(pToken);
				string jsonResult = string.Empty;

				//if (!String.IsNullOrEmpty(pToken))
				//	httpClient.he .DefaultRequestHeaders.Add(ApiConstants.AuthenticationCookieName, pToken);
				//httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConstants.AuthenticationCookieName, pToken);

				//var responseMessage = await Policy
				//	.Handle<WebException>(ex =>
				//	{
				//		Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
				//		return true;
				//	})
				//	.WaitAndRetryAsync
				//	(
				//		5,
				//		retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
				//	)
				//	.ExecuteAsync(async () => await httpClient.GetAsync(uri));
				var responseMessage = await httpClient.GetAsync(pURI);

				if (responseMessage.IsSuccessStatusCode) {
					jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
					T result = JsonConvert.DeserializeObject<T>(jsonResult);
					return result;
				}

				if (responseMessage.StatusCode == HttpStatusCode.NotFound)
					return default(T);

				if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
					throw new ServiceUnauthorizedException("Sesión agotada");

				if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
					throw new ServiceAuthenticationException(jsonResult);

				throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
			}
			catch (Exception e) {
				Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
				throw;
			}
		}

		public async Task<TResponse> PostAsync<T, TResponse>(string uri, T data, string authToken = "")
		{
			try {
				HttpClient httpClient = CreateHttpClient(authToken);

				var serializedItem = JsonConvert.SerializeObject(data);
				var buffer = Encoding.UTF8.GetBytes(serializedItem);
				var byteContent = new ByteArrayContent(buffer);
				var content = new StringContent(serializedItem, Encoding.UTF8, "application/json"); //new StringContent(JsonConvert.SerializeObject(data));
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				string jsonResult = string.Empty;
				//var responseMessage = await Policy
				//	.Handle<WebException>(ex =>
				//	{
				//		Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
				//		return true;
				//	})
				//	.WaitAndRetryAsync
				//	(
				//		5,
				//		retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
				//	)
				//	.ExecuteAsync(async () => await httpClient.PostAsync(uri, content));
				var responseMessage = await httpClient.PostAsync(uri, content);

				//? responseMessage.Headers.GetValues("Set-Cookie")
				//{ string[2]}

				//	[0]: ".AspNetCore.Identity.Application=CfDJ8KeGUvcAZUFMrns6Qascotrqst5QiU_OSTpIQiBwpV-Vi0fj0urTzJAIYL3UEYmoZN7E1bJ3q5muBDnoOO6CaTow2M9eJfiA01RUefxeuT-A2ESyTYuFCKwp5SWcBIJx4gjObw_2CBUyD48fxqwqCqMNw6eOHvQE-Vz9V_ZKEtIG8q1Tq7z-VX50llkFKzVXm76a9ahhwMdj0WAuIUOEpG__CndhIZjqWPh2kezdgo8XHNdhM9eLjDFfnJ-sJnRERlv_8RjpvTvSGywPZ86BpdSQaTzkTpiEcG5_F3Ym_qs_KB5vFy7m6B0jORrBzYZYtFiBan8_YV7lihPOny72rCjPBWbz8dWA3OvORyt_qKYCBGgrXtJYx_ZIFhTDEsP_sxWLZD_V6iruycsksVgbQQpXUSpCa8l-tyIjj0gSarPBuQ-_gET_UuNiBJaAmH1LBXM3X6rFx-CMmVpDpzdxa3DCk1LBQk8gO-KP7TGRUu5Cfc3CVnh7TXD7spfFF0QIta0N82jUBk-1iLgmD5jpENl_cLgeIj970dgePBv6W2kjfuQhLf-HR2cnDgx-vHxGDx2zHFaRyoTKulEeXAOVjDrWUJy6wQBu2FLq6d7iE8ySrnIZsGNa0OrYmP0dnwgt5UqcyI7eVQuEXX3tVOREhRPll7-WVm-9Qm3C0ZD0P-o7g1rGZzmQ_Sj3JCfFZUlpUAojxRZQVbrgCwSDskIyoRE; path=/; samesite=lax; httponly"
				//    [1]: ".AspNetCore.Mvc.CookieTempDataProvider=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/; samesite=strict"


				if (responseMessage.IsSuccessStatusCode) {
					jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
					TResponse result = JsonConvert.DeserializeObject<TResponse>(jsonResult);

					/*
					if (result is IAuthenticationCookie) {
						string temp = responseMessage.Headers.GetValues("Set-Cookie").FirstOrDefault()?.ToString();
						//if (temp.IndexOf("=") > 0)
						//	temp = temp.Substring(temp.IndexOf("=") + 1);
						//if (temp.IndexOf(";") > 0)
						//	temp = temp.Substring(0, temp.IndexOf(";"));
						((IAuthenticationCookie)result).AuthenticationCookie = temp;
					}*/

					return result;
				}

				if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
					throw new ServiceUnauthorizedException("Sesión agotada");

				if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
					throw new ServiceAuthenticationException(jsonResult);

				throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
			}
			catch (Exception e) {
				Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
				throw;
			}
		}

		public async Task<T> PostArrayAsync<T>(string uri, string pFileName, byte[] pDataArray, string authToken = "")
		{
			try {
				HttpClient httpClient = CreateHttpClient(authToken, null);

				MultipartFormDataContent content = new MultipartFormDataContent();
				ByteArrayContent baContent = new ByteArrayContent(pDataArray);

				content.Add(baContent, "pFile", pFileName);
				//content.Add(new StringContent(Guid.NewGuid().ToString()), "pAuditCompletionId");
				//content.Add(new StringContent("12345"), "pClauseId");


				//upload MultipartFormDataContent content async and store response in response var
				string jsonResult = string.Empty;
				var responseMessage = await httpClient.PostAsync(uri, content);

				if (responseMessage.IsSuccessStatusCode) {
					jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
					T result = JsonConvert.DeserializeObject<T>(jsonResult);

					//if (json is IAuthenticationCookie) {
					//	string temp = responseMessage.Headers.GetValues("Set-Cookie").FirstOrDefault()?.ToString();
					//	if (temp.IndexOf("=") > 0)
					//		temp = temp.Substring(temp.IndexOf("=") + 1);
					//	if (temp.IndexOf(";") > 0)
					//		temp = temp.Substring(0, temp.IndexOf(";"));
					//	((IAuthenticationCookie)json).AuthenticationCookie = temp;
					//}

					return result;
				}

				if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
					throw new ServiceUnauthorizedException("Sesión agotada");

				if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
					throw new ServiceAuthenticationException(jsonResult);

				throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
			}
			catch (Exception e) {
				Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
				throw;
			}
		}

		public async Task<TResponse> DeleteAsync<TResponse>(string pURI, string authToken = "")
		{
			try {
				HttpClient httpClient = CreateHttpClient(authToken);
				string jsonResult = string.Empty;
				var responseMessage = await httpClient.DeleteAsync(pURI);

				if (responseMessage.IsSuccessStatusCode) {
					jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
					TResponse result = JsonConvert.DeserializeObject<TResponse>(jsonResult);

					//if (result is IAuthenticationCookie)
					//{
					//	string temp = responseMessage.Headers.GetValues("Set-Cookie").FirstOrDefault()?.ToString();
					//	if (temp.IndexOf("=") > 0)
					//		temp = temp.Substring(temp.IndexOf("=") + 1);
					//	if (temp.IndexOf(";") > 0)
					//		temp = temp.Substring(0, temp.IndexOf(";"));
					//	((IAuthenticationCookie)result).AuthenticationCookie = temp;
					//}

					return result;
				}

				if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
					throw new ServiceUnauthorizedException("Sesión agotada");

				if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
					throw new ServiceAuthenticationException(jsonResult);

				throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
			}
			catch (Exception e) {
				Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
				throw;
			}
		}

		public async Task<R> PutAsync<T, R>(string uri, T data, string authToken = "")
		{
			try {
				HttpClient httpClient = CreateHttpClient(authToken);

				var serializedItem = JsonConvert.SerializeObject(data);
				var buffer = Encoding.UTF8.GetBytes(serializedItem);
				var byteContent = new ByteArrayContent(buffer);
				var content = new StringContent(serializedItem, Encoding.UTF8, "application/json"); //new StringContent(JsonConvert.SerializeObject(data));
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				string jsonResult = string.Empty;
				var responseMessage = await httpClient.PutAsync(uri, content);

				if (responseMessage.IsSuccessStatusCode) {
					jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
					R result = JsonConvert.DeserializeObject<R>(jsonResult);

					return result;
				}

				if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
					throw new ServiceUnauthorizedException("Sesión agotada");

				if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
					throw new ServiceAuthenticationException(jsonResult);

				throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);


			}
			catch (Exception e) {
				Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
				throw;
			}
		}

		public async Task DeleteAsync(string uri, string authToken = "")
		{
			HttpClient httpClient = CreateHttpClient(authToken);
			await httpClient.DeleteAsync(uri);
		}

		private HttpClient CreateHttpClient(string authToken, string mediaType = "application/json")
		{
			HttpClient httpClient = null;

			if (String.IsNullOrEmpty(authToken)) {
				httpClient = new HttpClient();
			}
			else {
				//var cookieContainer = new CookieContainer();
				//var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
				//cookieContainer.Add(new Uri(ApiConstants.AuthenticationCookieDomain), new Cookie(ApiConstants.AuthenticationCookieName, authToken));
				//httpClient = new HttpClient(handler);
				httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
			}

			if (!String.IsNullOrEmpty(mediaType)) {
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
			}

			return httpClient;
		}


	}
}
