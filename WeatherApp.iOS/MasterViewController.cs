﻿using System;
using System.Drawing;
using System.Collections.Generic;
using WeatherApp.Logic.ViewModels;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Assisticant.Binding;

namespace WeatherApp.iOS
{
    public partial class MasterViewController : UITableViewController
    {
        private MainViewModel _viewModel = ViewModelLocator.Instance.Main;
        private BindingManager _bindings = new BindingManager();

        public MasterViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Master", "Master");

            // Custom initialization
        }

        void AddNewItem(object sender, EventArgs args)
        {
            PerformSegue("newCity", this);
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
            
            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.LeftBarButtonItem = EditButtonItem;

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
            NavigationItem.RightBarButtonItem = addButton;

            _bindings.Initialize(this);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _viewModel.SelectedCityHeader = null;

            _bindings.BindItems(
                TableView,
                () => _viewModel.CityHeaders,
                () => _viewModel.SelectedCityHeader,
                value => _viewModel.SelectedCityHeader = value,
                (cell, city, bindings) =>
                {
                    bindings.BindText(
                        cell.TextLabel,
                        () => city.Name);
                });

            _bindings.Bind(
                () => _viewModel.SelectedCityHeader,
                cityHeader => OnSelected(cityHeader));
        }

        public override void ViewDidDisappear(bool animated)
        {
            _bindings.Unbind();

            base.ViewDidDisappear(animated);
        }

        [Action("UnwindToMaster:")]
        public void UnwindToMaster(UIStoryboardSegue segue)
        {
        }

        private void OnSelected(CityHeaderViewModel cityHeader)
        {
            if (cityHeader != null)
                PerformSegue("showDetail", this);
        }
    }
}

