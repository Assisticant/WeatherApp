using System;
using Assisticant.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using WeatherApp.Logic.Services;

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

		public void Load(IEnumerable<CityMemento> cities)
		{
			foreach (var cityMemento in cities)
			{
				var city = new City();
				city.Name = cityMemento.Name;
				_cities.Add(city);
			}
		}

		public List<CityMemento> Save()
		{
			return _cities
				.Select(city => new CityMemento
				{
					Name = city.Name
				})
				.ToList();
		}

		public void LoadForecasts(IEnumerable<ForecastMemento> forecastMementos)
		{
		}

		public List<ForecastMemento> SaveForecasts()
		{
			return new List<ForecastMemento>();
		}
	}
}

