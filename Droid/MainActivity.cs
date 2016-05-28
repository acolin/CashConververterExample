using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace CashConverterPCL.Droid
{
	[Activity (Label = "Cash Converter PCL", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Main);

			Button convertButton = FindViewById<Button> (Resource.Id.ConvertButton);
			EditText amountEditText = FindViewById<EditText> (Resource.Id.AmountEditText);
			TextView resultTextView = FindViewById<TextView> (Resource.Id.ResultTextView);
			
			convertButton.Click += async (sender, e) => {
				var converter = new CurrencyConverter(amountEditText.Text);
				Task<string> resultTask = converter.USDToGBP();
				var result = await resultTask;

				resultTextView.Text = result;
			};
		}
	}
}


