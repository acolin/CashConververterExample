using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CashConverterPCL
{
	public class CurrencyConverter
	{
		string input;

		public CurrencyConverter (string input)
		{
			this.input = input;
		}

		public async Task<string> USDToGBP() {
			var invalidInputMessage = "Please enter a valid number";
			var output = "";

			if (input.Length < 1) {
				return invalidInputMessage;
			}

			try {
				var result = Convert.ToDouble(input) * await ConversionRate();

				output = $"${input} = £{result}";
			}
			catch (Exception e) {
				output = "Please enter a valid number";
				Debug.WriteLine ($"Error in conversion: {e.Message}");
			}

			return output;
		}

		private async Task<double> ConversionRate() {
			var jObject = JObject.Parse ("{}");
			var client = new HttpClient ();
			var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));
			var response = await client.GetAsync (uri);

			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();
				jObject = JObject.Parse (content);
				var rate = (double)jObject["rates"]["GBP"];

				return rate;
			}

			return 0.0;
		}
	}
}