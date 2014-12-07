using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Logic.Models;
using WeatherApp.Logic.Services;
using Assisticant.Fields;

namespace WeatherApp.Logic.ViewModels
{
    public class CityViewModel
    {
        private readonly City _city;
        private readonly WeatherServiceAgent _weatherServiceAgent;

        private Observable<string> _message = new Observable<string>();

        public CityViewModel(City city, WeatherServiceAgent weatherServiceAgent)
        {
            _city = city;
            _weatherServiceAgent = weatherServiceAgent;
        }

        public string Name
        {
            get { return _city.Name; }
        }

        public IEnumerable<ForecastViewModel> Forecasts
        {
            get
            {
                return
                    from forecast in _city.Forecasts
                    select new ForecastViewModel(forecast);
            }
        }

        public async void Refresh()
        {
            try
            {
                await _weatherServiceAgent.Refresh();
                _message.Value = null;
            }
            catch (Exception x)
            {
                _message.Value = x.Message;
            }
        }
    }
}
