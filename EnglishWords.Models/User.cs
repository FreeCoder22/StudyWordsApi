using System.ComponentModel.DataAnnotations;

namespace EnglishWords.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }
        public DateTime CreateAtDate { get; set; }
        public DateTime LastUpdateDate { get; set;}
        public List<Word>  Words { get; set; }  
    }
}
