using System.Collections.Generic;
using Domain.ingredients;

namespace Domain.Recepies
{
    public class Recepie
    {
        public RecepieStatus Status { get; set; }
        public string Description { get; set; }
        public IList<Ingredient> Ingredients { get; set; }
        public ISet<string> Categories { get; set; }
        public int Difficulty { get; set; }
        
    }
}