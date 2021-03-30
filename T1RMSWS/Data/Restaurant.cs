using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1RMSWS.Data
{
    public class Restaurant
    {
        public Restaurant()
        {
            Sittings = new List<Sitting>();
            Areas = new List<Area>();
        }
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Sitting> Sittings { get; set; }
        public List<Area> Areas { get; set; }
        public int SittingCapacity { get; set; }
    }
}
