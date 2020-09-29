namespace hackernewsapi.Model{
    public class Story {
        public string title { get; set; }
        public string url { get; set; }
        public string by { get; set; }
        public string type { get; set; }
        public int time { get; set; }
        public int score { get; set; }
        public int descendants { get; set; }
    }
}