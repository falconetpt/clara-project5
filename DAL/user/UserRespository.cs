using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Recepies;

namespace DAL.ingredients
{
    public class UserRespository
    {
        private Dictionary<string, User> database = new Dictionary<string, User>();

        public UserRespository()
        {
            database.Add("admin", new User()
            {
                Id = 1,
                FavoriteRecepies = new HashSet<Recepie>(),
                Name = "admin",
                Role = UserRole.Admin,
                UserStatus = UserStatus.Accepted
            });
        }

        //CRUD
        // Create
        public User Create(User user)
        {
            database.Add(user.Name, user);
            return user;
        }
        
        //Read
        public User GetById(string id)
        {
            return database.GetValueOrDefault(id, new User());
        }
        
        public ISet<User> getAll()
        {
            return database.Values.ToHashSet();
        }
        
        public bool delete(string username)
        {
            return database.Remove(username);
        }
    }
}