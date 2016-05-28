using System;
using System.Threading.Tasks;
		
using UIKit;

namespace CashConverterPCL.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ConvertButton.AccessibilityIdentifier = "ConvertButton";
			ConvertButton.TouchUpInside += async (sender, e) =>  {
				var converter = new CurrencyConverter(AmountTextField.Text);
				Task<string> resultTask = converter.USDToGBP();
				var result = await resultTask;

				ResultLabel.Text = result;
			};
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
