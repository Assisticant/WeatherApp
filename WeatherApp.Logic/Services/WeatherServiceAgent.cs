using System;
using WeatherApp.Logic.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherApp.Logic.Services
{
	public class WeatherServiceAgent
	{
		private readonly Document _document;

		public WeatherServiceAgent(Document document)
		{
			_document = document;
		}

		public async Task Refresh()
		{
			await Task.Delay(2000);

			foreach (var city in _document.Cities)
			{
				city.ClearForecasts();
				var forecast = city.NewForecast();
				forecast.High = 82;
				forecast.Low = 64;
				forecast.DayOfWeek = DayOfWeek.Wednesday;
				forecast.Condition = "Partly cloudy";
			}
		}
	}
}

