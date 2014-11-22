using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WeatherApp.Logic.Services;

namespace WeatherApp.IntegrationTests
{
	[TestFixture()]
	public class WeatherApiTest
	{
		[Test()]
		public async Task CanGetCurrentWeather()
		{
			var serviceAgent = new WeatherServiceAgent();
		}
	}
}

