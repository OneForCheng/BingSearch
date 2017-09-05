namespace BingSearch
{
    class SearchConfig
    {
        public string Key { get; set; }
        public int Count { get; set; }
        public int Offset { get; set; }
        public string Mkt { get; set; }
        public string SafeSearch { get; set; }
        public string PrefixUrl { get; set; }
    }
}