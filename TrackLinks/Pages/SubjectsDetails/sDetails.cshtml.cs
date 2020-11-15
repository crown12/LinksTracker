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
    public class sDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public sDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SubjectDetail> details;

        public int tagId { get; set; }

        public async Task OnGet(int id)
        {
           tagId = id;
            if (_context.subjectDetails == null)
            {
                return;
            }
            else
            {
                
                details = await _context.subjectDetails
                    .Include(c => c.Subject)
                    .Where(c => c.SubjectId == id).ToListAsync();

            }


        }

      
    }
}