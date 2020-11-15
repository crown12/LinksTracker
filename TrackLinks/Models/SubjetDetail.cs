using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackLinks.Models
{
    public class SubjectDetail
    {
        [Key]
        public int SubjectDetailId { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Range(1,9)]
        public int Priority { get; set; }

        [Required]
        public string Link { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }


    }
}
