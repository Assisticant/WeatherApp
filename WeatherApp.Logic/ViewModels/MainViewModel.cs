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

        public MainViewModel(Document document)
        {
            _document = document;
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
	}
}
