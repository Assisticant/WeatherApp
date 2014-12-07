using System;
using WeatherApp.Logic.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherApp.Logic.Services
{
	public class WeatherServiceAgent
	{
		private readonly Document _document;
		private readonly HttpClient _http;

		public WeatherServiceAgent(Document document, HttpClient http)
		{
			_document = document;
			_http = http;
		}

		public async Task Refresh()
		{
			foreach (var city in _document.Cities)
			{
				string location = city.Name;
				var query = String.Format(
					"api.php?location={0}",
					Uri.EscapeDataString(location));
				var response = await _http.GetStringAsync(query);
				var forecastRecords = JsonConvert.DeserializeObject<IEnumerable<ForecastRecord>>(
					response);

				city.ClearForecasts();
				foreach (var record in forecastRecords)
				{
					var forecast = city.NewForecast();
					forecast.DayOfWeek = ConvertDayOfWeek(record.day_of_week);
					forecast.High = record.high;
					forecast.Low = record.low;
					forecast.Condition = record.condition;
				}
			}
		}

		private DayOfWeek ConvertDayOfWeek(string shortName)
		{
			if (shortName == "Sun")
				return DayOfWeek.Sunday;
			if (shortName == "Mon")
				return DayOfWeek.Monday;
			if (shortName == "Tue")
				return DayOfWeek.Tuesday;
			if (shortName == "Wed")
				return DayOfWeek.Wednesday;
			if (shortName == "Thu")
				return DayOfWeek.Thursday;
			if (shortName == "Fri")
				return DayOfWeek.Friday;
			if (shortName == "Sat")
				return DayOfWeek.Saturday;

			throw new ArgumentException(String.Format(
				"Unknown day short name {0}.", shortName));
		}

		class ForecastRecord
		{
			public string day_of_week { get; set; }
			public decimal high { get; set; }
			public decimal low { get; set; }
			public int high_celsius { get; set; }
			public int low_celsius { get; set; }
			public string condition { get; set; }
		}
	}
}

