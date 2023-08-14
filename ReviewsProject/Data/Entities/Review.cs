using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewsProject.Data.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int UserId { get; set; }

        public short Quality { get; set; }

        public short Responsiveness { get; set; }

        public short Professionalism { get; set; }

        public short Value { get; set; }

        public short Flexibility { get; set; }

        public decimal OverallRating { get; set; }

        public string ReviewDescription { get; set; }

        public decimal Spend { get; set; }

        public string Email { get; set; }

        public bool bApprovedByModerator { get; set; }

        public DateTime dateAdded { get; set; }
    }
}