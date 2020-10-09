using System.Collections.Generic;
using System.Linq;
using Domain;

namespace DAL.ingredients
{
    public class UserRespository
    {
        private Dictionary<int, User> database = new Dictionary<int, User>(); 

        //CRUD
        // Create
        public User Create(User user)
        {
            database.Add(user.Id, user);
            return user;
        }
        
        //Read
        public User GetById(int id)
        {
            return database[id];
        }
        
        public ISet<User> getAll()
        {
            return database.Values.ToHashSet();
        }
        
        public bool delete(int id)
        {
            return database.Remove(id);
        }
    }
}