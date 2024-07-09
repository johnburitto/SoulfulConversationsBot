using Newtonsoft.Json;

namespace SoulfulConversationsBot.Utils
{
    public class JsonDictionaryManager<TKey, TValue> where TKey : notnull
    {
        private Dictionary<TKey, TValue> _data;
        private string _filePath = Directory.GetCurrentDirectory();

        public Dictionary<TKey, TValue> Data => _data;

        public JsonDictionaryManager(string fileName)
        {
            _filePath += $"/{fileName}";
            _data = Read();
        }

        public void AddValue(TKey key, TValue value)
        {
            _data.TryAdd(key, value);
        }

        public void SaveChanges()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_data));
        }

        private Dictionary<TKey, TValue> Read()
        {
            CheckFile();

            return JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(File.ReadAllText(_filePath)) ?? new();
        }

        private void CheckFile()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }
    }
}
