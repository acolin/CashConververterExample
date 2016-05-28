// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CashConverterPCL.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton Button { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AmountTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ConvertButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ResultLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AmountTextField != null) {
				AmountTextField.Dispose ();
				AmountTextField = null;
			}
			if (ConvertButton != null) {
				ConvertButton.Dispose ();
				ConvertButton = null;
			}
			if (ResultLabel != null) {
				ResultLabel.Dispose ();
				ResultLabel = null;
			}
		}
	}
}
