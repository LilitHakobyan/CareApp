using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Care.API.Controllers;
using Care.API.ViewModels;
using Care.Data.DataViewModels;
using Microsoft.Win32;

namespace Care.UI
{
    /// <summary>
    /// Interaction logic for CareGiverProfile.xaml
    /// </summary>
    public partial class CareGiverProfile : Window
    {
        private UserProfileViewModel viewModel;

        public CareGiverProfile(int userID)
        {
            InitializeComponent();
            //profileController = new ProfileController(userID);
            viewModel = new UserProfileViewModel(userID);
            this.DataContext = viewModel;
            Loaded += ClientProfile_Loaded;
        }

        private void ClientProfile_Loaded(object sender, RoutedEventArgs e)
        {
            //FName.Text = profileController.user.Name;
            //LastName.Text = profileController.user.LastName;
            ///Age.Text = profileController.profileInfo.Age.ToString();
            //Text = profileController.user.Email;
            //AddressCityCountry.Text = profileController.GetAdressFormated();
        }

        private void btnAddJob_Click(object sender, RoutedEventArgs e)
        {
            //JobDescription job = new JobDescription(profileController);
            //job.Show();
        }

       
        private void btnChangeACC_Click(object sender, RoutedEventArgs e)
        {
           // changeACC acc = new changeACC(profileController);
            //acc.Show();
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog { Filter = "Image files |*.jpg" };
            if (true == saveDlg.ShowDialog())
            {
                BitmapImage photo = new BitmapImage(new Uri(saveDlg.FileName));
                UserImage.Source = photo;
                userImageCircle.Source = photo;
                viewModel.AddPhoto(photo);
            }
        }

        private void btnChangePersonalInfo_Click(object sender, RoutedEventArgs e)
        {            
            PersonalInfoEditWin win = new PersonalInfoEditWin(viewModel);            
            win.Show();            
        }

        private void btnAnoutMe_Click(object sender, RoutedEventArgs e)
        {
                  
        }
    }
}
