using StudyWords.Models;

namespace StudyWordsApi.interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(string id);
        Task<User> GetUserByEmail(string email);
    }
}
