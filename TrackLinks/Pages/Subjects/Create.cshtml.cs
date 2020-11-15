using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackLinks.Models;

namespace TrackLinks
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Subject subject { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                await _context.subjects.AddAsync(subject);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}