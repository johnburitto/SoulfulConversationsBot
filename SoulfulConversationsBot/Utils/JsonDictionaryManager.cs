using Newtonsoft.Json;

namespace SoulfulConversationsBot.Utils
{
	/// <summary>
	/// Json Dictionary Manager
	/// </summary>
	/// <typeparam name="TKey">Key type.</typeparam>
	/// <typeparam name="TValue">Value type.</typeparam>
	public class JsonDictionaryManager<TKey, TValue> where TKey : notnull
	{
		#region Private Fields

		/// <summary>
		/// Data dictionary.
		/// </summary>
		private readonly Dictionary<TKey, TValue> _data;

		/// <summary>
		/// Base file path.
		/// </summary>
		private readonly string _filePath = Directory.GetCurrentDirectory();

		#endregion

		#region Public Properties

		/// <summary>
		/// Data dictionary.
		/// </summary>
		public Dictionary<TKey, TValue> Data => _data;

		#endregion

		#region Constructor

		/// <summary>
		/// Creates a new instance of <see cref="JsonDictionaryManager{TKey, TValue}"/> class.
		/// </summary>
		/// <param name="fileName"></param>
		public JsonDictionaryManager(string fileName)
		{
			_filePath += $"/{fileName}";
			_data = Read();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Adds value to dictionary.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="value">Value/</param>

		public void AddValue(TKey key, TValue value)
			=> _data.TryAdd(key, value);

		/// <summary>
		/// Saves changes to file.
		/// </summary>
		public void SaveChanges()
			=> File.WriteAllText(_filePath, JsonConvert.SerializeObject(_data));

		#endregion

		#region Private Methods

		/// <summary>
		/// Reads data from file.
		/// </summary>
		/// <returns>Readed data.</returns>
		private Dictionary<TKey, TValue> Read()
		{
			CheckFile();

			return JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(File.ReadAllText(_filePath)) ?? new();
		}

		/// <summary>
		/// Checks if file exists, if not creates it.
		/// </summary>
		private void CheckFile()
		{
			if (!File.Exists(_filePath))
			{
				File.Create(_filePath).Close();
			}
		}

		#endregion
	}
}
