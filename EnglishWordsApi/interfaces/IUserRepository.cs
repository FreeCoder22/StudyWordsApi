using EnglishWords.Models;

namespace EnglishWordsApi.interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(string id);
        Task<User> GetUserByEmail(string email);
    }
}
