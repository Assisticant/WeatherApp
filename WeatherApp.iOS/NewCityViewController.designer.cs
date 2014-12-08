// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace WeatherApp.iOS
{
	[Register ("NewCityViewController")]
	partial class NewCityViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CityName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton OkButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CityName != null) {
				CityName.Dispose ();
				CityName = null;
			}
			if (OkButton != null) {
				OkButton.Dispose ();
				OkButton = null;
			}
		}
	}
}
