using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Logic.Models;
using WeatherApp.Logic.Services;

namespace WeatherApp.Logic.ViewModels
{
	public class CityHeaderViewModel
	{
        private readonly City _city;

        public CityHeaderViewModel(City city)
        {
            _city = city;
        }

        public City City
        {
            get
            {
                return _city;
            }
        }

        public string Name
        {
            get
            {
                return _city.Name;
            }
        }
	}

}
