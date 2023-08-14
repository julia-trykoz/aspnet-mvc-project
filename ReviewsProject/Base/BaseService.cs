using ReviewsProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewsProject.Services
{
    public class BaseService
    {
        protected DBReviewContext db { get; set; }

        public BaseService(DBReviewContext _db)
        {
            db = _db;
        }
    }
}