using System;
using System.Collections.Generic;

namespace WeatherApp.Logic.Services
{
	public interface IStorageService
	{
		List<CityMemento> LoadCities();
		void SaveCities(IEnumerable<CityMemento> cities);

		List<ForecastMemento> LoadForecasts();
		void SaveForecasts(IEnumerable<ForecastMemento> forecasts);
	}
}

