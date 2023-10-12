using CryptoLogger.Models;
using CryptoLogger.Services;
using CryptoLogger.Utils;


// TODO: Implement error handling


var apiWrapper = await RequestHandler<ApiResponse>.GetDataAsync();

Dictionary<string, Currency> CurrenciesById = new();

foreach (var i in apiWrapper.Data)
{
    CurrenciesById.Add(i.Id, i);
    Console.WriteLine(i.Name);
}

CurrencyLogger.Log(CurrenciesById["BTC"], "Logs.json");
CurrencyLogger.Log(CurrenciesById["ETH"], "Logs.json");
CurrencyLogger.Log(CurrenciesById["BTC"], "Logs.json");

