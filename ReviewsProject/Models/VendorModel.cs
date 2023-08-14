using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewsProject.Models
{
    public class VendorModel
    {
        public int Id { get; set; }

        public string BusinessName { get; set; }

        public string UrlName { get; set; }

        public string Url { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhotoUrl { get; set; }
    }
}