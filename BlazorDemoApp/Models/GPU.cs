using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Components.Routing;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace BlazorDemoApp.Models
{
	[BsonIgnoreExtraElements]
	public class GPU
	{
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; } = MongoDB.Bson.BsonType.ObjectId.ToString();
		public string GPUName { get; set; }
		public string MetricName { get; set; }
		public string Expression { get; set; }
		public string Description { get; set; }
	}
}
