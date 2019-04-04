using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentPlannerContext _context;

        public DetailsModel(SacramentPlanner.Models.SacramentPlannerContext context)
        {
            _context = context;
        }

        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Member.FirstOrDefaultAsync(m => m.MemberID == id);

            if (Member == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
