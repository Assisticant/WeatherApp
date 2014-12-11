using System;
using System.Runtime.Serialization;

namespace WeatherApp.Logic.Services
{
	[DataContract]
	public class CityMemento
	{
		[DataMember]
		public string Name { get; set; }
	}
}

