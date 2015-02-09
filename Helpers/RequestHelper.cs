using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Helpers
{
	class RequestHelper
	{
		private const int TIMEOUT_SECONDS = 30;
		private const string USER_AGENT = "XamarinTD .NET v1.0";
		
	    private static readonly HttpClient _httpClient;

		static RequestHelper()
		{
			_httpClient = new HttpClient()
			{
				Timeout = TimeSpan.FromSeconds(TIMEOUT_SECONDS)
			};
		}

	    public static HttpRequestMessage SetupRequest(string endpoint, string method = "GET")
	    {
		    HttpMethod httpMethod = new HttpMethod(method);
		    HttpRequestMessage request = new HttpRequestMessage(httpMethod, endpoint);

		    return request;
	    }

	    public static async Task<string> ExecuteRequestAsync(HttpRequestMessage request)
	    {
		    HttpResponseMessage response = await _httpClient.SendAsync(request);

		    response.EnsureSuccessStatusCode();
		    string result = await response.Content.ReadAsStringAsync();

		    return result;
	    }
	}
}
