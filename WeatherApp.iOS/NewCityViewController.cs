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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _bindings.Initialize(this);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _viewModel.CityName = null;

            _bindings.BindText(
                CityName,
                () => _viewModel.CityName,
                value => _viewModel.CityName = value);

            _bindings.BindCommand(
                OkButton,
                () => _viewModel.AddCity(),
                () => _viewModel.CanAddCity);
        }
	}
}
