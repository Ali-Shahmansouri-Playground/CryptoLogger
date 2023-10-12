using CryptoLogger.Models;
using CryptoLogger.Services;


// TODO: Implement error handling


var apiWrapper = await RequestHandler<ApiResponse>.GetDataAsync();

Dictionary<string, Currency> CurrenciesById = new();

foreach (var i in apiWrapper.Data)
{
    CurrenciesById.Add(i.Id, i);
    Console.WriteLine(i.Name);
}

