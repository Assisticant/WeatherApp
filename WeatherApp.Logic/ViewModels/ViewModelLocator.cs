using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Logic.Models;
using WeatherApp.Logic.Services;
using System.Net.Http;

namespace WeatherApp.Logic.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; }

        public static void Initialize(string mashapeKey)
        {
            if (Instance == null)
                Instance = new ViewModelLocator(mashapeKey);
        }

        private readonly Document _document;
        private readonly WeatherServiceAgent _weatherServiceAgent;

        private ViewModelLocator(string mashapeKey)
        {
            _document = new Document();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Mashape-Key", mashapeKey);
            httpClient.BaseAddress = new Uri("https://george-vustrey-weather.p.mashape.com/", UriKind.Absolute);
            _weatherServiceAgent = new WeatherServiceAgent(_document, httpClient);

            // For now, initialize the document to one city.
            _document.NewCity().Name = "Dallas";
        }

        public CityViewModel City
        {
            get
            {
                return new CityViewModel(_document.Cities.Single(), _weatherServiceAgent);
            }
        }
    }
}
