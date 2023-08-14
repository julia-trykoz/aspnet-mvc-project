using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReviewsProject.Data;
using ReviewsProject.Models;

namespace ReviewsProject.Services
{
    public class VendorsService : BaseService
    {
        public VendorsService(DBReviewContext _db) : base(_db)
        {
        }

        internal VendorModel GetVendor(string sVendorUrl)
        {
            var vendorModel = new VendorModel();

            if (string.IsNullOrWhiteSpace(sVendorUrl))
                return vendorModel;
            var vendor = db.Vendors
                             .Where(v => v.Url == sVendorUrl)
                             .FirstOrDefault();
            if (vendor != null)
                AutoMapper.Mapper.Map(vendor, vendorModel);

            return vendorModel;
        }
    }
}