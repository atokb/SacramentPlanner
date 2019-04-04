using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Meetings
{
    public class IndexModel : PageModel
    {
        private readonly SacramentPlannerContext _context;

        public IndexModel(SacramentPlannerContext context)
        {
            _context = context;
        }

        public string ConductorSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<Meeting> Meeting { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            ConductorSort = String.IsNullOrEmpty(sortOrder) ? "conductor_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Meeting> meetingIQ = from s in _context.Meeting
                                            select s;

            switch (sortOrder)
            {
                case "conductor_desc":
                    meetingIQ = meetingIQ.OrderByDescending(s => s.Conductor);
                    break;
                case "Date":
                    meetingIQ = meetingIQ.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    meetingIQ = meetingIQ.OrderByDescending(s => s.Date);
                    break;
                default:
                    meetingIQ = meetingIQ.OrderBy(s => s.Conductor);
                    break;
            }

            Meeting = await meetingIQ.AsNoTracking().ToListAsync();
        }
    }
}
