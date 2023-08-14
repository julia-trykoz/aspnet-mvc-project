using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewsProject.Data.Entities
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        public string BusinessName { get; set; }

        public string UrlName { get; set; }
        
        public string Url { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

	    public virtual ICollection<VendorPhoto> VendorPhotos { get; set; }
    }

    public class VendorPhoto
    {
        [Key]
        public int Id { get; set; }

        public int VendorId { get; set; }

        public Vendor Vendor { get; set; }

        public string Folder { get; set; }

        public string Filename { get; set; }
    }
}