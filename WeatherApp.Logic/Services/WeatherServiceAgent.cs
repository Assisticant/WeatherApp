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
		}
	}
}

