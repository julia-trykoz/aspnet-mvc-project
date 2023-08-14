using ReviewsProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewsProject.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        public VendorModel Vendor{ get; set; }

        public short Quality { get; set; }

        public short Responsiveness { get; set; }

        public short Professionalism { get; set; }

        public short Value { get; set; }

        public short Flexibility { get; set; }

        public double OverallRating {
            get {
                return (Quality + Responsiveness + Professionalism + Value + Flexibility) / 5.0;
            } 
         }

        [Required(ErrorMessage ="Description is required")]
        public string ReviewDescription { get; set; }

        [Required(ErrorMessage ="Amount is required")]
        [Range(0, double.MaxValue,ErrorMessage = "Value should be only digit and more then 0.00")]
        public string Spend { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        public List<string> Files { get; set; }

        public ReviewModel()
        {
            Files = new List<string>();
        }
    }
}