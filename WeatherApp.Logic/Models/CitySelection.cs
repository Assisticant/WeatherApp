using System;
using Assisticant.Fields;

namespace WeatherApp.Logic.Models
{
    public class CitySelection
    {
        private Observable<City> _selectedCity = new Observable<City>();

        public City SelectedCity
        {
            get
            {
                return _selectedCity.Value;
            }
            set
            {
                _selectedCity.Value = value;
            }
        }
    }
}

