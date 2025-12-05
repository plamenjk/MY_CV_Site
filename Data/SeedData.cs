using MyCvSite.Models;

namespace MyCvSite.Data
{
    public static class SeedData
    {
        public static void EnsureSeedData(ApplicationDbContext db)
        {
            if (!db.Photos.Any())
            {
                db.Photos.AddRange(
                    new Photo
                    {
                        Title = "Снимка в асансьора",
                        ImageUrl = "/images/gallery1.jpg",
                        Description = "Вечерно излизане с човек до мен."
                    },
                    new Photo
                    {
                        Title = "Къщата и Mercedes-а",
                        ImageUrl = "/images/gallery2.jpg",
                        Description = "Мястото, където презареждам батериите."
                    },
                    new Photo
                    {
                        Title = "Зеленият Mercedes AMG",
                        ImageUrl = "/images/gallery3.jpg",
                        Description = "Комбинация от дизайн, звук и адреналин."
                    },
                    new Photo
                    {
                        Title = "Нощна среща с приятели и коли",
                        ImageUrl = "/images/gallery4.jpg",
                        Description = "Правилните хора, правилните автомобили и нощен град."
                    }
                );
            }

            if (!db.Comments.Any())
            {
              

              
            }

            db.SaveChanges();
        }
    }
}
