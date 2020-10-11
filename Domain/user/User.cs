using System.Collections.Generic;
using Domain.Recepies;

namespace Domain
{
    public class User
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public UserRole Role { get; set; }
        public UserStatus UserStatus { get; set; }
        public ISet<Recepie> FavoriteRecepies { get; set; }

        // how to generate toString automatically
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Pass)}: {Pass}, {nameof(Role)}: {Role}, {nameof(UserStatus)}: {UserStatus}";
        }
    }
}