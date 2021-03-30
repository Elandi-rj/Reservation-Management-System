using System.Collections.Generic;

namespace T1RMSWS.Data
{
    public class Table
    {
       
        public int Id { get; set; }
        public string Description { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}