using System.Collections.Generic;
using System.Linq;
using Domain.ingredients;
using Domain.Recepies;

namespace DAL.recepie
{
    public class RecepieRepository
    {
        private readonly Dictionary<int, Recepie> _database = new Dictionary<int, Recepie>(); 
        private readonly Dictionary<int, RecepieInfo> _databaseInfo = new Dictionary<int, RecepieInfo>(); 

        //CRUD
        // Create
        public Recepie Create(Recepie recepie)
        {
            recepie.Id = _database.Count + 1;
            _database.Add(recepie.Id, recepie);
            return recepie;
        }
        
        public RecepieInfo saveInfo(RecepieInfo recepieInfo)
        {
            _databaseInfo.Add(_databaseInfo.Count + 1, recepieInfo);
            return recepieInfo;
        }
        
        //Read
        public Recepie GetById(int id)
        {
            return _database[id];
        }

        public List<Recepie> GetAllPending()
        {
            return GetAllInStatus(RecepieStatus.Pending);
        }
        
        public List<Recepie> GetAllAccepted()
        {
            return GetAllInStatus(RecepieStatus.Accepted);
        }

        private List<Recepie> GetAllInStatus(RecepieStatus recepieStatus)
        {
            var result = new List<Recepie>();
            var values = _database.Values.ToList();
            
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Status == recepieStatus)
                {
                    result.Add(values[i]);
                }
            }

            return result;
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