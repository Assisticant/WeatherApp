using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace WeatherApp.IntegrationTests
{
	[TestFixture()]
	public class WeatherApiTest
	{
		[Test()]
		public async Task CanGetCurrentWeather()
		{
			var serviceAgent = new WeatherApp.Logic.WeatherServiceAgent();
		}
	}
}

