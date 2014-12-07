using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using WeatherApp.Logic.ViewModels;
using Assisticant.Binding;

namespace WeatherApp.iOS
{
    public partial class DetailViewController : UITableViewController
    {
        private CityViewModel _viewModel = ViewModelLocator.Instance.City;
        private BindingManager _bindings = new BindingManager();

        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
            
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _bindings.Initialize(this);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _viewModel.Refresh();

            _bindings.Bind(
                () => _viewModel.Name,
                value => this.Title = value);

            _bindings.BindItems(
                TableView,
                () => _viewModel.Forecasts,
                (cell, forecast, bindings) =>
                {
                    bindings.BindText(
                        cell.TextLabel,
                        () => forecast.Text);
                if (cell.DetailTextLabel != null)
                    bindings.BindText(
                        cell.DetailTextLabel,
                        () => forecast.Description);
                });
        }

        public override void ViewDidDisappear(bool animated)
        {
            _bindings.Unbind();

            base.ViewDidDisappear(animated);
        }
    }
}

