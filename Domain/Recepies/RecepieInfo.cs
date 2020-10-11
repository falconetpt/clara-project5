using System.Collections.Generic;

namespace Domain.Recepies
{
    public class RecepieInfo
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Recepie Recepie { get; set; }
        public User CreatedBy { get; set; }
    }
}