using Microsoft.AspNet.Identity;
using ReviewsProject.Data;
using ReviewsProject.Data.Entities;
using ReviewsProject.Models;
using ReviewsProject.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewsProject.Controllers
{
    public class ReviewController : BaseController
    {
        private ReviewsService _reviews;
        private VendorsService _vendors;

        public ReviewController(DBReviewContext dbContext) : base(dbContext)
        {
            _reviews = new ReviewsService(dbContext);
            _vendors = new VendorsService(dbContext);
        }

        // GET: Review
        public ActionResult Index(string sVendorUrl)
        {
            var model = new ReviewModel() { Vendor = _vendors.GetVendor(sVendorUrl) };
            return View(model);
        }

        [HttpPost]
        public ActionResult Upload()
        {
            bool isUploaded = false;
            HttpPostedFileBase file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string filename = file.FileName;
                    file.SaveAs(Server.MapPath("~") + "images/temp/" + filename);
                    isUploaded = true;
                    string filePath = "images/temp/" + filename;
                    return Json(new { isUploaded, filePath, filename }, "text/html");
                }
                catch (Exception exc)
                {
                    return Json(new { isUploaded, error = exc.Message });
                }
            }
            return Json(new { isUploaded });
        }

        [HttpPost]
        [Authorize]
        public ActionResult SendReview(ReviewModel model)
        {
            var reviewId = _reviews.SaveReview(model, User.Identity.GetUserId<int>());
            if (reviewId > 0)
            {
                //Saving Photos
                foreach (var file in model.Files)
                {
                    var tempFile = Server.MapPath("~/images/temp/") + file;
                    var newFile = Server.MapPath("~/images/reviews/") + reviewId.ToString() + file;
                    if (System.IO.File.Exists(tempFile))
                    {
                        System.IO.File.Move(tempFile, newFile);
                        var photo = new ReviewPhoto()
                        {
                            Folder = "images/reviews/",
                            FileName = reviewId.ToString() + file,
                            dateAdded = DateTime.Now,
                            ReviewId = reviewId
                        };
                        db.Photos.Add(photo);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}