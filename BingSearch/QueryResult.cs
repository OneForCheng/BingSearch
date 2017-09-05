namespace BingSearch
{

    #region ErrorResult

    class ErrorResult
    {
         public Error error { get; set; }
    }

    class Error
    {
         public int statusCode { get; set; }
         public string message { get; set; }

    }

    #endregion

    #region QueryResult

    class QueryResult
    {
        public string _type { get; set; }
        public QueryContext queryContext { get; set; }
        public WebPages webPages { get; set; }
        public Images images { get; set; }
        public Videos videos { get; set; }
        public RankingResponse rankingResponse { get; set; }
    }

    #region QueryContext
    public class QueryContext
    {
        public string originalQuery { get; set; }
        public bool adultIntent { get; set; }
    }
    #endregion

    #region WebPages
    public class WebPages
    {
        public string webSearchUrl { get; set; }
        public int totalEstimatedMatches { get; set; }
        public WebPageValues[] value { get; set; }
    }

    public class WebPageValues
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string displayUrl { get; set; }
        public string snippet { get; set; }
        public DeepLink[] deepLinks { get; set; }
        public string dateLastCrawled { get; set; }
        public string thumbnailUrl { get; set; }
        public About[] about { get; set; }
    }

    public class DeepLink
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class About
    {
        public string name { get; set; }
    }

    #endregion

    #region Images
    public class Images
    {
        public string id { get; set; }
        public string readLink { get; set; }
        public string webSearchUrl { get; set; }
        public bool isFamilyFriendly { get; set; }
        public ImageValues[] value { get; set; }
        public bool displayShoppingSourcesBadges { get; set; }
        public bool displayRecipeSourcesBadges { get; set; }
    }

    public class ImageValues
    {
        public string name { get; set; }
        public string webSearchUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string datePublished { get; set; }
        public string contentUrl { get; set; }
        public string hostPageUrl { get; set; }
        public string contentSize { get; set; }
        public string encodingFormat { get; set; }
        public string hostPageDisplayUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class Thumbnail
    {
        public int width { get; set; }
        public int height { get; set; }
    }
    #endregion

    #region Videos
    public class Videos
    {
        public string id { get; set; }
        public string readLink { get; set; }
        public string webSearchUrl { get; set; }
        public bool isFamilyFriendly { get; set; }
        public VideoValues[] value { get; set; }
        public string scenario { get; set; }
    }

    public class VideoValues
    {
        public string name { get; set; }
        public string description { get; set; }
        public string webSearchUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string datePublished { get; set; }
        public Publisher[] publisher { get; set; }
        public string contentUrl { get; set; }
        public string hostPageUrl { get; set; }
        public string encodingFormat { get; set; }
        public string hostPageDisplayUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string duration { get; set; }
        public string motionThumbnailUrl { get; set; }
        public string embedHtml { get; set; }
        public bool allowHttpsEmbed { get; set; }
        public int viewCount { get; set; }
        public Thumbnail thumbnail { get; set; }
        public bool allowMobileEmbed { get; set; }
    }

    public class Publisher
    {
        public string name { get; set; }
    }
    #endregion

    #region RankingResponse
    public class RankingResponse
    {
        public Mainline mainline { get; set; }
    }

    public class Mainline
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string answerType { get; set; }
        public ItemValues value { get; set; }
        public int resultIndex { get; set; }
    }

    public class ItemValues
    {

        public string id { get; set; }
    }
    #endregion

    #endregion
}
