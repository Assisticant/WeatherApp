using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Logic.Models;
using WeatherApp.Logic.Services;
using System.Net.Http;

namespace WeatherApp.Logic.ViewModels
{
	public class MainViewModel
	{
        private readonly Document _document;
        private readonly CitySelection _selection;

        public MainViewModel(Document document, CitySelection selection)
        {
            _document = document;
            _selection = selection;
        }

        public IEnumerable<CityHeaderViewModel> CityHeaders
        {
            get
            {
                return
                    from city in _document.Cities
                    select new CityHeaderViewModel(city);
            }
        }

        public CityHeaderViewModel SelectedCityHeader
        {
            get
            {
                if (_selection.SelectedCity == null)
                    return null;

                return new CityHeaderViewModel(_selection.SelectedCity);
            }
            set
            {
                if (value == null)
                    _selection.SelectedCity = null;
                else
                    _selection.SelectedCity = value.City;
            }
        }
	}
}
