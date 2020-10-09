using System.Collections.Generic;
using System.Linq;
using Domain.ingredients;

namespace DAL.ingredients
{
    public class IngrendientsRepository
    {
        private Dictionary<int, Ingredient> database = new Dictionary<int, Ingredient>(); 

        //CRUD
        // Create
        public Ingredient Create(Ingredient ingredient)
        {
            database.Add(ingredient.id, ingredient);
            return ingredient;
        }
        
        //Read
        public Ingredient getById(int id)
        {
            return database[id];
        }
        
        public ISet<Ingredient> getAll()
        {
            return database.Values.ToHashSet();
        }
        
        public bool delete(int id)
        {
            return database.Remove(id);
        }
    }
}


