using EnglishWords.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishWordsApi.interfaces
{
    public interface IWordsRepository
    {
        Task<IEnumerable<Word>> GetWords();
        Task<IEnumerable<Word>> GetWordsByUserId(string userId);
        Task<IEnumerable<Word>> GetWordRandomByUserId(string userId);
        Task<Word> GetWordById(string id);
        Task<Word> PutWord(string id, Word word);

        Task<Word> PostWord(Word word);
        Task<string> DeleteWord(string id);

    }
}
