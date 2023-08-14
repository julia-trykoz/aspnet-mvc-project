using ReviewsProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewsProject.Controllers
{
    public class BaseController : Controller
    {
        protected DBReviewContext db { get; set; }

        public BaseController(DBReviewContext dbContext)
        {
            db = dbContext;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}