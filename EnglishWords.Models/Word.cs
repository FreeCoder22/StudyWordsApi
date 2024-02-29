namespace EnglishWords.Models
{
    public class Word
    {
        public string Id { get; set; }
        public string WordText { get; set; }
        public string WordTranslate { get; set; }
        public bool IsLearning { get; set; }
        public DateTime? CreateAtDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public User User { get; set; }
    }
}
