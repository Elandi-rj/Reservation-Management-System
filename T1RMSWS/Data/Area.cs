using System.Collections.Generic;

namespace T1RMSWS.Data
{
    public class Area
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        
    }
}