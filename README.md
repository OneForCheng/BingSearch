
# BingSearch
一个控制台版本的必应在线搜索。

# Config
为了是程序具有更大的灵活性，将搜索时要用到的参数信息放在了App.config中，其中'Key'是Bing Search Api V5的秘钥，需要[申请][1]。

```
 <appSettings>
    <!--Application Link：https://azure.microsoft.com/zh-cn/try/cognitive-services/-->
    <!--string类型: Subscription key which provides access to this API. -->
    <add key="Key" value="" />
    <!--int类型: The number of search results to return in the response. The actual number delivered may be less than requested. -->
    <add key="Count" value="10" />
    <!--int类型: The zero-based offset that indicates the number of search results to skip before returning results. -->
    <add key="Offset" value="0" />
    <!--string类型: The market where the results come from. Typically, this is the country where the user is making the request from; however, it could be a different country if the user is not located in a country where Bing delivers results. The market must be in the form -. For example, en-US.-->
    <add key="Mkt" value="en-us" />
    <!--string类型: A filter used to filter results for adult content.-->
    <add key="SafeSearch" value="Moderate" />
    <!--string类型: Request Prefix URL-->
    <add key="PrefixUrl" value="https://api.cognitive.microsoft.com/bing/v5.0/search" />
  </appSettings>
```

# Usage
查看用法，命令行下输入'BingSearch /?'

```
Bing在线搜索。

BingSearch <Content>

    <Content>    待搜索内容。
```

 ![image](https://github.com/OneForCheng/BingSearch/blob/master/BingSearch/BingSearch.png)

# Tip
此程序属于在线调用接口获取搜索结果，所以需要连接网络才能使用。

[1]:https://azure.microsoft.com/zh-cn/try/cognitive-services
