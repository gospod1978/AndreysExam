namespace Andreys.Services
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Andreys.Data;
    using Andreys.Models;
    using SIS.MvcFramework;

    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext db;

        public UsersService(AndreysDbContext db)
        {
            this.db = db;
        }

        public bool EmailExsist(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        public string GetUserId(string username, string password)
        {
            var hasPassword = this.Hash(password);

            var user = this.db.Users.FirstOrDefault(
                u => u.Username == username &&
                u.Password == hasPassword);

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public string GetUsername(string id)
        {
            var userName = this.db.Users
                .Where(u => u.Id == id)
                .Select(x => x.Username)
                .FirstOrDefault();

            return userName;
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Role = IdentityRole.User,
                Username = username,
                Email = email,
                Password = this.Hash(password),
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
