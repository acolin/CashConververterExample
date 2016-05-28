using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace CashConverterPCL
{
	public class RestService
	{
		HttpClient client;
		public JObject Rates;

		public RestService ()
		{
			client = new HttpClient ();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<JObject> GetConversionRatesAsync ()
		{
			Rates = JObject.Parse ("{}");
			var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));

			try {
				var response = await client.GetAsync (uri);

				if (response.IsSuccessStatusCode) {
					var content = await response.Content.ReadAsStringAsync ();
					Rates = JObject.Parse(content);
				}
			}
			catch (Exception e) {
				Debug.WriteLine (@"					ERROR {0}", e.Message);
			}

			return Rates;
		}
	}
}

