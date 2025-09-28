using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace Nursia.Utilities
{
	internal static class JsonExtensions
	{
		public static JsonSerializerSettings CreateOptions()
		{
			var result = new JsonSerializerSettings
			{
				Culture = CultureInfo.InvariantCulture,
				Formatting = Formatting.Indented,
				TypeNameHandling = TypeNameHandling.Auto,
				DefaultValueHandling = DefaultValueHandling.Ignore,
			};

			return result;
		}

		public static void SerializeToFile<T>(string path, JsonSerializerSettings options, T data)
		{
			var s = JsonConvert.SerializeObject(data, options);
			File.WriteAllText(path, s);
		}

		public static T DeserializeFromString<T>(string data, JsonSerializerSettings options)
		{
			return JsonConvert.DeserializeObject<T>(data, options);
		}
	}
}