using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WeatherApp.Logic.ViewModels;
using Assisticant.Binding;

namespace WeatherApp.Android
{
	[Activity(Label = "WeatherApp.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private CityViewModel _viewModel;
        private BindingManager _bindings;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

            _bindings.Initialize(this);

            ViewModelLocator.Initialize(Resources.GetString(Resource.String.MashapeKey));
		}
	}
}


