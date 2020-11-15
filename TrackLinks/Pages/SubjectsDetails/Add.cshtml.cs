using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackLinks.Models;

namespace TrackLinks
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubjectDetail subjectDetail { get; set; }

        public int Val { get; set; }

        public void OnGet(int id)
        {
            Val = id;

        }

        public async Task<IActionResult> OnPost(int id)
        {
            if(ModelState.IsValid)
            {

                var subject = await _context.subjects.FindAsync(id);
                subjectDetail.Subject = subject;
                await _context.subjectDetails.AddAsync(subjectDetail);
                await _context.SaveChangesAsync();

                return RedirectToPage("sDetails",new {id= subjectDetail.SubjectId });
                
            }
            else
            {
                return Page();
            }
        }
    }
}