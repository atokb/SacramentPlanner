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
        private readonly SacramentPlanner.Models.SacramentPlannerContext _context;

        public IndexModel(SacramentPlanner.Models.SacramentPlannerContext context)
        {
            _context = context;
        }

        public IList<Meeting> Meeting { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        //public SelectList MeetingConductor { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Conductor { get; set; }

        public async Task OnGetAsync()
        {
            var meetings = from m in _context.Meeting
                           select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                meetings = meetings.Where(s => s.Conductor.Contains(SearchString));
            }
            Meeting = await meetings.ToListAsync();
        }
    }
}
