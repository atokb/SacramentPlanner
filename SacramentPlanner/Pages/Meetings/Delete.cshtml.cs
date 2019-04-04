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
    public class DeleteModel : PageModel
    {
        private readonly SacramentPlannerContext _context;

        public DeleteModel(SacramentPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meeting Meeting { get; set; }
        public string ErrorMessage { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meeting
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);

            if (Meeting == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                   .AsNoTracking()
                   .FirstOrDefaultAsync(m => m.ID == id);

            if (meeting == null)
            {
                return NotFound();
            }

            try
            {
                _context.Meeting.Remove(meeting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
