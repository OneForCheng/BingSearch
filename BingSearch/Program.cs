using System;
using System.Configuration;
using System.Net;

namespace BingSearch
{
    class Program
    {
        static void Usage(string fileName)
        {
            var spaces = new string(' ', 4);
            if (fileName != string.Empty)
            {
                if (fileName.EndsWith("_"))
                {
                    fileName = fileName.Substring(0, fileName.Length - 1);
                }
            }
            Console.WriteLine("{0}Bing在线搜索。{1}", Environment.NewLine, Environment.NewLine);
            Console.WriteLine("{0} <Content>{1}", fileName, Environment.NewLine);
            Console.WriteLine("{0}<Content>    待搜索内容。", spaces);

        }

        static SearchConfig GetSearchConfig()
        {
            int count, offset;
            var config = new SearchConfig
            {
                Key = ConfigurationManager.AppSettings["Key"],
                Count = int.TryParse(ConfigurationManager.AppSettings["Count"], out count) ? (count < 0 ? 10 : count) : 10,
                Offset = int.TryParse(ConfigurationManager.AppSettings["Offset"], out offset) ? (offset < 0 ? 0 : offset) : 0,
                Mkt = ConfigurationManager.AppSettings["Mkt"],
                SafeSearch = ConfigurationManager.AppSettings["SafeSearch"],
                PrefixUrl = ConfigurationManager.AppSettings["PrefixUrl"]
            };
            return config;
        }

    

        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0 || args[0] == "/?")
                {
                    var fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
                    fileName = fileName.Substring(0, fileName.LastIndexOf('.')).ToUpper();
                    Usage(fileName);
                }
                else
                {
                    var str = string.Empty;
                    for (var i = 0; i < args.Length; i++)
                    {
                        if (i > 0) str += " ";
                        str += args[i];
                    }
                    var config = GetSearchConfig();
                    if (string.IsNullOrWhiteSpace(config.Key))
                    {
                        Console.WriteLine("配置文件中'Key'值不能为空.");
                        return 1;
                    }
                    else if (string.IsNullOrWhiteSpace(config.PrefixUrl))
                    {
                        Console.WriteLine("配置文件中'PrefixUrl'值不能为空.");
                        return 1;
                    }
                    else
                    {
                        var bing = new BingWebSearch(config);
                        var result = bing.SearchContent(str);
                        if (result != null)
                        {
                            bing.PrintResult(result);
                        }
                        else
                        {
                            Console.WriteLine("搜索结果为空!");
                        }
                    }
                }
            }
            catch (WebException)
            {
                Console.WriteLine("网络连接超时!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 1;
            }
            return 0;

        }
    }
}
