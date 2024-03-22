using EnglishWords.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishWords.Context
{
    public class DataSeed
    {
        private ApplicationDbContext _context {  get; set; }
        public DataSeed(ApplicationDbContext context) {
            _context = context;
        }

        public void CreateUser()
        {
            if (_context.User.Any()) return;
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "user@study.com",
                    Password = "password",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                };
                _context.Add(user);
                _context.SaveChanges();
         


        }
        public void CreateWords()
        {
            var user = _context.User.FirstOrDefault(u => u.Email == "user@study.com");
            if (user == null) throw new Exception("user is null");
            var userId = user.Id;
            if (userId == null) throw new Exception("userId is null");

            if (_context.Word.Any(u => !u.IsLearned)) return;

            var words = new List<Word>
            {
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Be",
                    WordTranslate = "Être",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Become",
                    WordTranslate = "Devenir",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Begin",
                    WordTranslate = "Commencer",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Bid",
                    WordTranslate = "Offrir",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Bleed",
                    WordTranslate = "Saigner",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Break",
                    WordTranslate = "Casser",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Bring",
                    WordTranslate = "Apporter",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Build",
                    WordTranslate = "Construire",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Burn",
                    WordTranslate = "Brûler",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Buy",
                    WordTranslate = "Acheter",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                }
            };
            _context.AddRange(words);
            _context.SaveChanges();

        }

        public void CreateWordsLearned()
        {
            var user = _context.User.FirstOrDefault(u => u.Email == "user@study.com");
            if (user == null) throw new Exception("user is null");
            var userId = user.Id;
            if (userId == null) throw new Exception("userId is null");

            if (_context.Word.Any(u => u.IsLearned)) return;

            var words = new List<Word>
            {
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Sleep",
                    WordTranslate = "Dormir",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Send",
                    WordTranslate = "Envoyer",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Sell",
                    WordTranslate = "Vendre",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "See",
                    WordTranslate = "Voir",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Say",
                    WordTranslate = "Dire",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Run",
                    WordTranslate = "Courir",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Bring",
                    WordTranslate = "Apporter",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Rent",
                    WordTranslate = "Louer",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "Put",
                    WordTranslate = "Mettre",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "pay",
                    WordTranslate = "Payer",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                }
            };
            _context.AddRange(words);
            _context.SaveChanges();

        }

    }
}
