using System;
using WeatherApp.Logic.Services;
using System.Threading.Tasks;
using WeatherApp.Logic.Models;
using System.Collections.Generic;

namespace WeatherApp.Logic.Services
{
	public class ForecastRepository
	{
		private readonly IStorageService _storageService;
		private readonly WeatherServiceAgent _weatherServiceAgent;
		private readonly Document _document;

		public ForecastRepository(
			IStorageService storageService,
			WeatherServiceAgent weatherServiceAgent,
			Document document)
		{
			_weatherServiceAgent = weatherServiceAgent;
			_storageService = storageService;
			_document = document;
		}

		public async Task Refresh()
		{
			List<ForecastMemento> forecasts =
				_storageService.LoadForecasts();
			_document.LoadForecasts(forecasts);
			await _weatherServiceAgent.Refresh();
			forecasts = _document.SaveForecasts();
			_storageService.SaveForecasts(forecasts);
		}
	}
}

