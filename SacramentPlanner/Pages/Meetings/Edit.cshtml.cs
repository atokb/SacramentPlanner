using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Meetings
{
    public class EditModel : PageModel
    {
        private readonly SacramentPlannerContext _context;

        public EditModel(SacramentPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meeting Meeting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meeting.FindAsync(id);

            if (Meeting == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var meetingToUpdate = await _context.Meeting.FindAsync(id);

            if (await TryUpdateModelAsync<Meeting>(
                meetingToUpdate,
                "student",
                s => s.Conductor, s => s.Date))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
