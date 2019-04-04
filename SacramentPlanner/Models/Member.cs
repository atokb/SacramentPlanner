using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Calling { get; set; }
        public int MeetingID { get; set; }

        public Meeting Meeting{ get; set; }


    }
}
