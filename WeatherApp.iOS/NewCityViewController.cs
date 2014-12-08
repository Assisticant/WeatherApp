using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using WeatherApp.Logic.ViewModels;
using Assisticant.Binding;

namespace WeatherApp.iOS
{
    partial class NewCityViewController : UIViewController
	{
        NewCityViewModel _viewModel = ViewModelLocator.Instance.NewCity;
        BindingManager _bindings = new BindingManager();

		public NewCityViewController (IntPtr handle) : base (handle)
		{
		}
	}
}
