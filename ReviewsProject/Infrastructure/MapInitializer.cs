using System.Collections.Generic;
using System.Linq;
using ReviewsProject.Data.Entities;
using ReviewsProject.Models;

namespace ReviewsProject.Infrastructure
{
    public class MapInitializer
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(
                map =>
                {
                    map.CreateMap<ReviewModel, Review>()
                    .ForMember(el => el.VendorId, opt => opt.MapFrom(x => x.Vendor.Id));

                    map.CreateMap<Vendor, VendorModel>()
                   .ForMember(el => el.PhotoUrl, opt => opt.ResolveUsing(x => GetPhotoUrl(x.VendorPhotos)));
                });
        }

        private static string GetPhotoUrl(ICollection<VendorPhoto> vendorPhotos)
        {
            var photo = vendorPhotos?.FirstOrDefault();
            if (photo == null) return null;
            return photo.Folder + "/" + photo.Filename;
        }
    }
}