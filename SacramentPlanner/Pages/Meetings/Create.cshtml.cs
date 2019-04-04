using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Meetings
{
    public class CreateModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentPlannerContext _context;

        public CreateModel(SacramentPlanner.Models.SacramentPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Meeting Meeting { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyMeeting = new Meeting();

            if (await TryUpdateModelAsync<Meeting>(
                emptyMeeting,
                "meeting",   // Prefix for form value.
                s => s.Conductor, s => s.Date))
            {
                _context.Meeting.Add(emptyMeeting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}