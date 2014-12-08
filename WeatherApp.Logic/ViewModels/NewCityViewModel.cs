using System;
using WeatherApp.Logic.Models;

namespace WeatherApp.Logic.ViewModels
{
    public class NewCityViewModel
    {
        private readonly Document _document;
        private readonly CitySelection _selection;

        public NewCityViewModel(Document document, CitySelection selection)
        {
            _document = document;
            _selection = selection;
        }

        public string CityName
        {
            get
            {
                return _selection.CityName;
            }
            set
            {
                _selection.CityName = value;
            }
        }

        public void AddCity()
        {
            _document.NewCity().Name = _selection.CityName;
        }

        public bool CanAddCity
        {
            get
            {
                return !String.IsNullOrEmpty(_selection.CityName);
            }
        }
    }
}

