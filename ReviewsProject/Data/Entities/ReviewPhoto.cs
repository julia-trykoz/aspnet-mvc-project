using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewsProject.Data.Entities
{
    public class ReviewPhoto
    {
        [Key]
        public int Id { get; set; }

        public int ReviewId { get; set; }

        public string Folder { get; set; }

        public string FileName { get; set; }

        public bool ApprovedByModerator { get; set; }

        public DateTime dateAdded { get; set; }
    }
}