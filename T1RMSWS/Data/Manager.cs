using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1RMSWS.Data
{
    public class Manager : Person
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
