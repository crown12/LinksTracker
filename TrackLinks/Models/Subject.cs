using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackLinks.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        
        [Required]
        public string Title { get; set; }
    }
}
