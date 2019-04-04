using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SacramentPlanner.Models
{
    public class Hymn
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HymnID { get; set; }

        public string HymnTitle { get; set; }
        public int HymnNumber { get; set; }
       // public int MeetingID { get; set; }

        //public Meeting Meeting { get; set; }

        //public ICollection<Meeting> Meetings { get; set; }

    }
}
