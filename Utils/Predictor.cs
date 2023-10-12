using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLogger.Utils
{
    public static class Predictor
    {
        private static readonly float smoothingFactor = 0.2f;
        public static void PredictTheNextPrice(float[] prices)
        {
            float lastPrice = prices[^1];
            float nextDayPrice = lastPrice + smoothingFactor * (lastPrice - prices[^2]);

            Console.WriteLine($"The Next Day's Price Prediction: {nextDayPrice}");
        }

        public static float CalcutePriceBasedOnChange(float basePrice, float changePercent)
        {
            return (basePrice * 100) / (100 + changePercent);
        }
    }
}
