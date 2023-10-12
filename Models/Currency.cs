using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLogger.Models
{
    public sealed class Currency
    {
        [JsonProperty("key")]
        public string? Id { get; set; }

        [JsonProperty("name_en")]
        public string? Name { get; set; }

        [JsonProperty("price")]
        public float? CurrentPrice { get; set; }

        [JsonProperty("percent_change_1h")]
        public float? LastHourPrecentChange { get; set; }

        [JsonProperty("percent_change_24h")]
        public float? LastDayPrecentChange { get; set; }
        [JsonProperty("percent_change_7d")]
        public float? LastWeekPrecentChange { get; set; }
        [JsonProperty("percent_change_30d")]
        public float? LastMonthPrecentChange { get; set; }
    }
}
