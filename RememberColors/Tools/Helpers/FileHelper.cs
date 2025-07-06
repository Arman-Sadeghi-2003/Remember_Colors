using System.IO;
using System.Text.Json;

namespace RememberColors.Tools.Helpers
{
	/// <summary>
	/// Provides static methods for saving and loading objects to and from files using JSON serialization.
	/// </summary>
	public static class FileHelper
	{
		/// <summary>
		/// Serializes the given object and saves it to the specified file path as JSON.
		/// </summary>
		/// <param name="filePath">The file path to save the object to.</param>
		/// <param name="obj">The object to serialize and save.</param>
		public static void SaveToFile(string filePath, object obj)
		{
			try
			{
				var dir = Path.GetDirectoryName(filePath);
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir!);

				var options = new JsonSerializerOptions { WriteIndented = true };
				string json = JsonSerializer.Serialize(obj, obj.GetType(), options);
				File.WriteAllText(filePath, json);
			}
			catch (Exception ex)
			{
				// Handle or log exception as needed
				throw new IOException($"Failed to save file: {filePath}", ex);
			}
		}

		/// <summary>
		/// Loads and deserializes an object of type T from the specified file path.
		/// </summary>
		/// <typeparam name="T">The type of object to load.</typeparam>
		/// <param name="filePath">The file path to load the object from.</param>
		/// <returns>The deserialized object, or default(T) if the file does not exist or deserialization fails.</returns>
		public static T OpenFromFile<T>(string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
					return default!;

				string json = File.ReadAllText(filePath);
				return JsonSerializer.Deserialize<T>(json)!;
			}
			catch (Exception ex)
			{
				// Handle or log exception as needed
				throw new IOException($"Failed to open file: {filePath}", ex);
			}
		}
	}
}