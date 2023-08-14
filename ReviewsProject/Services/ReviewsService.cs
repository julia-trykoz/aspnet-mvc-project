using ReviewsProject.Data;
using ReviewsProject.Data.Entities;
using ReviewsProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ReviewsProject.Services
{
    public class ReviewsService : BaseService
    {
        public ReviewsService(DBReviewContext db) : base(db)
        {
        }

        internal int SaveReview(ReviewModel model, int currentUserId)
        {
            //Saving of review data
            var review = new Review();
            if (ConfigurationManager.AppSettings["ReplaceDecimalSeparator"] == "true")
                model.Spend = model.Spend.Replace(".", ",");
            AutoMapper.Mapper.Map(model, review);
            review.UserId = currentUserId;
            review.dateAdded = DateTime.Now;
            db.Reviews.Add(review);
            db.SaveChanges();
            return review.Id;
        }
    }
}