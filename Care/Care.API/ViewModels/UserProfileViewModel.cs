using Care.API.Controllers;
using Care.Data.DataViewModels;
using Care.Data.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Care.Data;

namespace Care.API.ViewModels
{
    //[AddINotifyPropertyChangedInterface]
    public class UserProfileViewModel
    {
        //public User user { get; private set; }
        //public UserInfo profileInfo { get; private set; }
        private int userId;

        public UserProfileViewModel(int userId)
        {
            this.userId = userId;
            MapUserToViewModel(GetUserById(userId), LoadOrCreateProfile(userId));
            LoadOrCreateProfile(userId);
            //this.profileInfo = pc.profileInfo;
        }

        private void MapUserToViewModel(User user, UserInfo profileInfo)
        {
            Name = user.Name;
            Email = user.Email;
            LastName = user.LastName;
            Age = profileInfo.Age.ToString();
            AboutMe = profileInfo.AboutMe;
            Photo = profileInfo.Photo;
        }

        public string Name{get; set;}

        public string LastName{get ; set;}

        public string Email { get; set; }

        public string Age{get; set ;}

        public string AboutMe { get; set; }

        public byte[] Photo  { get; set; }

        private User GetUserById(int userId)
        {
            User user;

            using (BaseRepository<User> repo = new BaseRepository<User>())
            {
                user = repo.GetOne(userId);
            }

            return user;
        }

        public UserInfo LoadOrCreateProfile(int userId)
        {
            using (BaseRepository<UserInfo> repo = new BaseRepository<UserInfo>())
            {
                UserInfo userInfo = repo.GetOne(userId);

                if (userInfo == null)
                {
                    userInfo = new UserInfo() { UserId = userId };
                    repo.Add(userInfo);
                }

                return userInfo;
            }
        }

        public void SaveChanges()
        {
            User user = GetUserById(userId);
            user.Name = Name;
            user.LastName = LastName;
            user.Email = Email;

            UserInfo profileInfo = LoadOrCreateProfile(userId);
            profileInfo.Age = int.Parse(Age);

            using (BaseRepository<UserInfo> repo = new BaseRepository<UserInfo>())
            {
                repo.Save(profileInfo);
            }
            using (BaseRepository<User> repo = new BaseRepository<User>())
            {
                repo.Save(user);
            }
        }

        public void AddPhoto(BitmapImage image)
        {

            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            Photo = data;
            using (BaseRepository<UserInfo> repo = new BaseRepository<UserInfo>())
            {
             //   repo.Save(profileInfo);
            }
        }

       

    }
}
