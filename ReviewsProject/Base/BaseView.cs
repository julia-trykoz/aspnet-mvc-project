using ReviewsProject.Data;
using ReviewsProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewsProject.Base
{
    public abstract class BaseView<T> : WebViewPage<T>
    {
        private DBReviewContext DbContext
        {
            get { return DependencyResolver.Current.GetService<DBReviewContext>(); }
        }

        public List<Vendor> VendorsList
        {
            get
            {
                return DbContext.Vendors.Take(10).ToList();
            }
        }
    }

}