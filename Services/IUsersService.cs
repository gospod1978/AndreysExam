namespace Andreys.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Register(string username, string email, string password);

        bool UsernameExists(string username);

        bool EmailExsist(string email);

        string GetUsername(string id);
    }
}
