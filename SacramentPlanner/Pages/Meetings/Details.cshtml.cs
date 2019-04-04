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
    public class DetailsModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentPlannerContext _context;

        public DetailsModel(SacramentPlanner.Models.SacramentPlannerContext context)
        {
            _context = context;
        }

        public Meeting Meeting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meeting
                                .Include(s => s.Members)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(m => m.ID == id);

            if (Meeting == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
