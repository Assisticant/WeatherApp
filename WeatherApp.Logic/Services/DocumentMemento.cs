using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace WeatherApp.Logic.Services
{
	[DataContract]
	public class DocumentMemento
	{
		[DataMember]
		public List<CityMemento> Cities { get; set; }
	}
}

