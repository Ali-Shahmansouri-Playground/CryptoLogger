using CryptoLogger.Models;
using Newtonsoft.Json;

namespace CryptoLogger.Utils
{
    public static class CurrencyLogger
    {
        private static readonly JsonSerializerSettings options = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
        };

        public static void Log(Currency currency, string fileName)
        {
            var jsonObject = new List<Currency>();
            if (File.Exists(fileName))
            {
                var data = File.ReadAllText(fileName);

                jsonObject = JsonConvert.DeserializeObject<List<Currency>>(data);
                jsonObject.Add(currency);

                SerilizeAndSave(jsonObject, fileName);
            }
            else
            {
                jsonObject.Add(currency);
                SerilizeAndSave(jsonObject, fileName);
            }

        }

        private static void SerilizeAndSave(List<Currency> list, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(list, Formatting.Indented, options);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
