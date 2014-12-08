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
	[Activity(Label = "WeatherApp.Detail")]
	public class DetailActivity : Activity
	{
        private CityViewModel _viewModel;
        private BindingManager _bindings = new BindingManager();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Detail);

            _bindings.Initialize(this);

            _viewModel = ViewModelLocator.Instance.City;
            _viewModel.Refresh();

            _bindings.BindText(
                FindViewById<TextView>(Resource.Id.cityNameText),
                () => _viewModel.Name);
            _bindings.BindItems(
                FindViewById<ListView>(Resource.Id.forecastList),
                () => _viewModel.Forecasts,
                global::Android.Resource.Layout.SimpleListItem2,
                (row, forecast, bindings) =>
                {
                    bindings.BindText(
                        row.FindViewById<TextView>(global::Android.Resource.Id.Text1),
                        () => forecast.Text);
                    bindings.BindText(
                        row.FindViewById<TextView>(global::Android.Resource.Id.Text2),
                        () => forecast.Description);
                });
		}

        protected override void OnDestroy()
        {
            _bindings.Unbind();

            base.OnDestroy();
        }
	}
}


