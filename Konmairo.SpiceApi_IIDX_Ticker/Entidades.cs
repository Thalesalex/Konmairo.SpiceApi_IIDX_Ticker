using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Konmairo.SpiceApi_IIDX_Ticker
{
    public class constModules 
    {
        public const string iidx = "iidx";
        public const string card = "card";
    }

    public class constFunctions 
    {
        //iidx
        public const string ticker_get = "ticker_get";

        //card
        public const string insert = "insert";

    }

    public class Request
    {
        //Objeto responsável para realizar o request na API
        public int id { get; set; }
        public string module { get; set; }
        public string function { get; set; }
        [JsonPropertyName("params")]
        public List<object> spiceparams { get; set; }

    }

    public class Response
    {
        //Objeto responsável pelo retorno da API
        public int íd { get; set; }
        public string[] errors { get; set; }
        public List<object> data { get; set; }
    }

    public enum enumStatus 
    {
        ALL,
        SpiceAPI,
        Ticker,
        CardReader
    }
}
