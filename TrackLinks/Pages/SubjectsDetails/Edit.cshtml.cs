using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrackLinks.Models;

namespace TrackLinks.Pages.SubjectsDetails
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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
            

            ViewData["SubjectId"] = new SelectList(_context.subjects, "SubjectId", "Title");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var subjectInDb = await _context.subjectDetails.Include(c => c.Subject)
                                                           .FirstOrDefaultAsync(s => s.SubjectDetailId == id);
            subjectInDb.Description = SubjectDetail.Description;
            subjectInDb.Priority = SubjectDetail.Priority;
            subjectInDb.Link = SubjectDetail.Link;

                await _context.SaveChangesAsync();


            return RedirectToPage("sDetails", new { id = subjectInDb.SubjectId });
        }

        
    }
}
