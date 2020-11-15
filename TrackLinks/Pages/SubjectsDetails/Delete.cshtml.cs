using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackLinks.Models;

namespace TrackLinks.Pages.SubjectsDetails
{
    public class DeleteModel : PageModel
    {
        private readonly TrackLinks.Models.ApplicationDbContext _context;

        public DeleteModel(TrackLinks.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubjectDetail SubjectDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubjectDetail = await _context.subjectDetails
                .Include(s => s.Subject).FirstOrDefaultAsync(m => m.SubjectDetailId == id);

            if (SubjectDetail == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubjectDetail = await _context.subjectDetails.FindAsync(id);

            if (SubjectDetail != null)
            {
                _context.subjectDetails.Remove(SubjectDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
