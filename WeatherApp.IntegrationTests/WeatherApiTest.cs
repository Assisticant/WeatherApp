using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WeatherApp.Logic.Services;
using WeatherApp.Logic.Models;
using System.Linq;

namespace WeatherApp.IntegrationTests
{
	[TestFixture()]
	public class WeatherApiTest
	{
		[Test()]
		public async Task CanGetCurrentWeather()
		{
			var document = new Document();
			var serviceAgent = new WeatherServiceAgent(document);

			var dallas = document.NewCity();
			dallas.Name = "Dallas";
			await serviceAgent.Refresh();

			Assert.AreEqual(7, dallas.Forecasts.Count());
		}
	}
}

