using System;
using System.Collections.Generic;
using DAL.ingredients;
using Domain.ingredients;

namespace Client.ingredients
{
    public class IngredientsService
    {
        private readonly IngrendientsRepository _repository = new IngrendientsRepository();

        
        public ISet<Ingredient> GetAll()
        {
            return _repository.getAll();
        }
        
        public void CreateIngredient(Ingredient ingredient)
        {
            if (ingredient.Quantity < 0)
            {
                Console.WriteLine("Invalid quantity");
            }
            else
            {
                _repository.Create(ingredient);
            }
        }
        
        public void DeleteIngredient(Ingredient ingredient)
        {
            if (_repository.delete(ingredient.id))
            {
                
            }
        }
    }
}