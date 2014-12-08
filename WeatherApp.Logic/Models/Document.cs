using System;
using Assisticant.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeatherApp.Logic.Models
{
	public class Document
	{
		private ObservableList<City> _cities = new ObservableList<City>();

		public IEnumerable<City> Cities
		{
			get { return _cities; }
		}

		public City NewCity()
		{
			var city = new City();
			_cities.Add(city);
			return city;
		}

		public void RemoveCity(City city)
		{
			_cities.Remove(city);
		}
	}
}

