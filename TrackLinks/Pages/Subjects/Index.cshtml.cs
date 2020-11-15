using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackLinks.Models;

namespace TrackLinks
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public IList<Subject> subjects { get; set; }
        public async Task OnGet()
        {
            if (_context.subjects == null)
            {
                return;
            }

            subjects = await _context.subjects.ToListAsync();
        }

    
    }
}