using System;
using WeatherApp.Logic.Models;
using System.Threading.Tasks;

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
			await Task.Delay(100);
		}
	}
}

