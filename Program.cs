using CryptoLogger.Models;
using CryptoLogger.Services;
using CryptoLogger.Utils;

const string CURRENCY_KEY = "BTC";
const int REFRESH_INTERVAL_SECONDS = 5;

int prevTick = 0;

while (true)
{
    int curTick = DateTime.Now.Second;

    if (curTick != prevTick)
    {
        await InitAsync();
        prevTick = curTick;
    }

    Thread.Sleep(REFRESH_INTERVAL_SECONDS * 1000);
}

static async Task InitAsync()
{
    Dictionary<string, Currency> CurrenciesById = new();
    ApiResponse apiWrapper = await RequestHandler<ApiResponse>.GetDataAsync();

    foreach (var i in apiWrapper.Data)
    {
        CurrenciesById.Add(i.Id, i);
    }

    Currency currency = CurrenciesById[CURRENCY_KEY];

    CurrencyLogger.Log(currency, "Logs.json");

    Predictor.PredictTheNextPrice(new float[]
    {
    Predictor.CalcutePriceBasedOnChange(currency.CurrentPrice.GetValueOrDefault(), currency.LastMonthPrecentChange.GetValueOrDefault()),
    Predictor.CalcutePriceBasedOnChange(currency.CurrentPrice.GetValueOrDefault(), currency.LastWeekPrecentChange.GetValueOrDefault()),
    Predictor.CalcutePriceBasedOnChange(currency.CurrentPrice.GetValueOrDefault(), currency.LastDayPrecentChange.GetValueOrDefault()),
    Predictor.CalcutePriceBasedOnChange(currency.CurrentPrice.GetValueOrDefault(), currency.LastHourPrecentChange.GetValueOrDefault()),
    currency.CurrentPrice.GetValueOrDefault(),
    });
}
