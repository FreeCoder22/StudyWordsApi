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
                    WordText = "être",
                    WordTranslate = "be",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "devenir",
                    WordTranslate = "become",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "commencer",
                    WordTranslate = "begin",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "offrir",
                    WordTranslate = "bid",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "saigner",
                    WordTranslate = "bleed",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "casser",
                    WordTranslate = "break",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "apporter",
                    WordTranslate = "Bring",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "construire",
                    WordTranslate = "Build",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "brûler",
                    WordTranslate = "burn",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = false,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "acheter",
                    WordTranslate = "buy",
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
                    WordText = "dormir",
                    WordTranslate = "sleep",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "envoyer",
                    WordTranslate = "send",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "vendre",
                    WordTranslate = "sell",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "voir",
                    WordTranslate = "see",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "dire",
                    WordTranslate = "say",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "courir",
                    WordTranslate = "run",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "apporter",
                    WordTranslate = "Bring",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "louer",
                    WordTranslate = "rent",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "mettre",
                    WordTranslate = "put",
                    CreateAtDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    IsLearned = true,
                    UserId = userId
                },
                new Word
                {

                    Id = Guid.NewGuid().ToString(),
                    WordText = "payer",
                    WordTranslate = "pay",
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
