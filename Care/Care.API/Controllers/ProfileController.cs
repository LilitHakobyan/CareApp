using Care.Data;
using Care.Data.DataViewModels;
using Care.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;

namespace Care.API.Controllers
{
    public class ProfileController
    {
        public User user { get; private set; }

        public UserInfo profileInfo { get; private set; }

        public ProfileController(User user)
        {
            this.user = user;
        }

        public ProfileController(User user, UserInfo profileInfo) : this(user)
        {
            this.profileInfo = profileInfo;
        }

        public ProfileController(int userId)
        {
            user = GetUserById(userId) ?? null;
            LoadOrCreateProfile(userId);
        }

        private User GetUserById(int userId)
        {
            User user;

            using (BaseRepository<User> repo = new BaseRepository<User>())
            {
                user = repo.GetOne(userId);
            }
 
            return user;
        }

        public void SaveProfileChanges()
        {
            using(BaseRepository<UserInfo> repo =  new BaseRepository<UserInfo>())
            {
               repo.Save(profileInfo);
            }
        }
        public void SaveUserChanges()
        {
            using (BaseRepository<User> repo = new BaseRepository<User>())
            {
                repo.Save(user);
            }
        }

        public void LoadOrCreateProfile(int userId)
        {
             using(BaseRepository<UserInfo> repo = new BaseRepository<UserInfo>())
             {
                this.profileInfo = repo.GetOne(userId);

                if (profileInfo == null)
                {
                    profileInfo = new UserInfo() { UserId = userId };
                    repo.Add(profileInfo);
                }
             }
        }

        public async void AddJob(Job job)
        {
            using(BaseRepository<Job> repo = new BaseRepository<Job>())
            {
                await repo.AddAsync(job);
            }
        }

        public string GetAdressFormated()
        {
          return $"{this.profileInfo.Address} {this.profileInfo.City} {this.profileInfo.Country}";
        }

     /*   public void AddPhoto(BitmapImage image)
        {
            
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            profileInfo.Photo = data;
            using (BaseRepository<UserInfo> repo = new BaseRepository<UserInfo>())
            {
                repo.Save(profileInfo);
            }      
        }*/
        
    }
}
