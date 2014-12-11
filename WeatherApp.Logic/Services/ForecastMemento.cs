using System;
using System.Runtime.Serialization;

namespace WeatherApp.Logic.Services
{
	[DataContract]
	public class ForecastMemento
	{
		[DataMember]
		public int High { get; set; }
		[DataMember]
		public int Low { get; set; }
		[DataMember]
		public string Condition { get; set; }
	}
}

