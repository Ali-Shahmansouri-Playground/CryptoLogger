using CryptoLogger.Models;
using CryptoLogger.Services;
using CryptoLogger.Utils;

const string CURRENCY_KEY = "BTC";

var apiWrapper = await RequestHandler<ApiResponse>.GetDataAsync();

Dictionary<string, Currency> CurrenciesById = new();

foreach (var i in apiWrapper.Data)
{
    CurrenciesById.Add(i.Id, i);
}

var currency = CurrenciesById[CURRENCY_KEY];

CurrencyLogger.Log(currency, "Logs.json");

Predictor.PredictTheNextPrice(new float[]
{
    Predictor.CalcutePriceBasedOnChange(currency.CurrentPrice.GetValueOrDefault(), currency.LastMonthPrecentChange.GetValueOrDefault()),
    Predictor.CalcutePriceBasedOnChange(currency.CurrentPrice.GetValueOrDefault(), currency.LastWeekPrecentChange.GetValueOrDefault()),
    Predictor.CalcutePriceBasedOnChange(currency.CurrentPrice.GetValueOrDefault(), currency.LastDayPrecentChange.GetValueOrDefault()),
    Predictor.CalcutePriceBasedOnChange(currency.CurrentPrice.GetValueOrDefault(), currency.LastHourPrecentChange.GetValueOrDefault()),
    currency.CurrentPrice.GetValueOrDefault(),
});

