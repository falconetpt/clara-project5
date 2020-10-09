using System.Collections.Generic;

namespace Domain.Recepies
{
    public class RecepieInfo
    {
        public List<string> Comments { get; set; }
        public int Rating { get; set; }
        public Recepie Recepie { get; set; }
        public int Duration { get; set; }
        public User CreatedBy { get; set; }
    }
}