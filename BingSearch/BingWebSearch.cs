using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace BingSearch
{
    class BingWebSearch
    {
        readonly ConsoleColor _oldFgColor;

        public HttpStatusCode StatusCode { get; private set; }

        public SearchConfig SearchConfig { get; }

        public BingWebSearch(SearchConfig searchConfig)
        {
            SearchConfig = searchConfig;
            _oldFgColor = Console.ForegroundColor;
        }

        public  string SearchContent(string content)
        {
            var q = HttpUtility.UrlEncode(content);
            var url = $"{SearchConfig.PrefixUrl}?q={q}&count={SearchConfig.Count}&offset={SearchConfig.Offset}&mkt={SearchConfig.Mkt}&safesearch={SearchConfig.SafeSearch}";
            var request = WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", SearchConfig.Key);
            request.Timeout = 1000 * 5;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    StatusCode = response.StatusCode;
                    return reader.ReadToEnd();
                }
            }
        }

        public void PrintResult(string value)
        {
            if (StatusCode == HttpStatusCode.OK)
            {
                var result = GetQueryResult(value);
                var total = result.webPages.totalEstimatedMatches;
                var count = Math.Min(SearchConfig.Count, total);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Displaying {SearchConfig.Offset + 1} to {count} of {total} results");
                Console.ForegroundColor = _oldFgColor;
             
                foreach (var item in result.webPages.value)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(item.name);
                    Console.ForegroundColor = _oldFgColor;
                    Console.WriteLine(item.snippet);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(item.displayUrl);
                    Console.ForegroundColor = _oldFgColor;
                    Console.WriteLine("Last Crawled: {0}", item.dateLastCrawled);
                }
            }
            else
            {
                var result = GetErrorResult(value);
                Console.WriteLine("Http Error {0}",result.error.statusCode);
                Console.WriteLine(result.error.message);
            }
        }


        public QueryResult GetQueryResult(string value)
        {
            var result = JsonConvert.DeserializeObject<QueryResult>(value);
            return result;
        }

        public ErrorResult GetErrorResult(string value)
        {
            var result = JsonConvert.DeserializeObject<ErrorResult>(value);
            return result;
        }
    }

}
