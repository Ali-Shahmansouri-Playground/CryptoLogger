using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLogger.Models
{
    public sealed class ApiResponse
    {
        [JsonProperty("result")]
        public List<Currency> Data { get; set; }
    }
}
