using System.Collections.Generic;
using System.Linq;
using Domain.ingredients;
using Domain.Recepies;

namespace DAL.recepie
{
    public class RecepieRepository
    {
        private Dictionary<int, Recepie> _database = new Dictionary<int, Recepie>(); 

        //CRUD
        // Create
        public Recepie Create(Recepie recepie)
        {
            _database.Add(recepie.Id, recepie);
            return recepie;
        }
        
        //Read
        public Recepie GetById(int id)
        {
            return _database[id];
        }
        
        public ISet<Recepie> getAll()
        {
            return _database.Values.ToHashSet();
        }
        
        public bool delete(int id)
        {
            return _database.Remove(id);
        }
    }
}