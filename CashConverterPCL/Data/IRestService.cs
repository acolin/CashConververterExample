using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CashConverterPCL
{
	public interface IRestService
	{
		Task<JObject> GetConversionRatesAsync ();
	}
}

