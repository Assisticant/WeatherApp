using System;
using Assisticant.Fields;
using Assisticant.Collections;
using System.Collections.Generic;

namespace WeatherApp.Logic.Models
{
	public class City
	{
		private Observable<string> _name = new Observable<string>();
		private ObservableList<Forecast> _forecasts = new ObservableList<Forecast>();

		public string Name
		{
			get { return _name.Value; }
			set { _name.Value = value; }
		}

		public IEnumerable<Forecast> Forecasts
		{
			get { return _forecasts; }
		}

		public Forecast NewForecast()
		{
			var forecast = new Forecast();
			_forecasts.Add(forecast);
			return forecast;
		}

		public void RemoveForecast(Forecast forecast)
		{
			_forecasts.Remove(forecast);
		}
	}
}

