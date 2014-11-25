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

		public void Refresh()
		{
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
	}
}

