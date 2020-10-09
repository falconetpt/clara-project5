using System.Collections.Generic;
using Domain.Recepies;

namespace Domain
{
    public class User
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public UserStatus UserStatus { get; set; }
        public ISet<Recepie> FavoriteRecepies { get; set; }
    }
}