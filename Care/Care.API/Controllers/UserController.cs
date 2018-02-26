using Care.Data;
using Care.Data.DataViewModels;
using Care.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Care.API.Controllers
{
    public class UserController
    {
        public async Task<int> RegisterUserAsync(string Name, string LastName, string Email,
                                                 string Password, int RoleTypeId)
        {
            
            User user = new User
            {
                Name = Name,
                LastName = LastName,
                Email = Email,
                Password = Password,
                RoleTypeId = RoleTypeId
            };

            using (BaseRepository<User> repo = new BaseRepository<User>())
            {
                return await repo.AddAsync(user);
            }
        }

        public User Authenticate(string Email, string Password)
        {
            using (BaseRepository<User> repo = new BaseRepository<User>())
            {
                return repo.Get(u => u.Password == Password && u.Email == Email)
                    .FirstOrDefault();
            }
        }
        public List<Job> GetAllJobs(int userId)
        {
            using (BaseRepository<Job> repo = new BaseRepository<Job>())
            {
                return repo.Get(u => u.UserId == userId).ToList();
            }            
        }
        public BitmapImage GetPhoto(int userId)
        {
            byte[] image;
            UserInfo user;
            using (BaseRepository<UserInfo> repo = new BaseRepository<UserInfo>())
            {
               user  = repo.GetOne(userId);
            }
            image = user.Photo;
            if (image != null)
            {
                using (MemoryStream ms = new MemoryStream(image))
                {
                    BitmapImage photo = new BitmapImage();
                    photo.BeginInit();
                    photo.CacheOption = BitmapCacheOption.OnLoad;
                    photo.StreamSource = ms;
                    photo.EndInit();
                    return photo;
                }
            }
          
            return new BitmapImage(new Uri("Img/default-user-image.png", UriKind.Relative));
        } 
    }

}

