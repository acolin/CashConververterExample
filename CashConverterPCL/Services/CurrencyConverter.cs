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
				var rate = await ConversionRate();
				var result = Convert.ToDouble(input) * rate;

				output = $"${input} = £{result}";
			}
			catch (Exception e) {
				output = "Please enter a valid number";
				Debug.WriteLine ($"Error in conversion: {e.Message}");
			}

			return output;
		}

		private async Task<double> ConversionRate() {
			var service = new RestService ();
			var rates = await service.GetConversionRatesAsync ();

			try {
				return (double)rates["rates"]["GBP"];
			}
			catch (Exception e) {
				Debug.WriteLine ($"Error retrieving rate: {e.Message}");
			}

			return 0.0;
		}
	}
}