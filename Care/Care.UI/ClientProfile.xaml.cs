using Care.API.Controllers;
using System;
using System.Collections.Generic;
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

namespace Care.UI
{
    /// <summary>
    /// Interaction logic for ClientProfile.xaml
    /// </summary>
    public partial class ClientProfile : Window
    {
        private ProfileController profileController;
       
        public ClientProfile(int userID)
        {
            InitializeComponent();
            profileController = new ProfileController(userID);
            Loaded += ClientProfile_Loaded;
        }

        private void ClientProfile_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeUserFields();
            AddressCityCountry.Text = profileController.GetAdressFormated();
        }

        private void btnAddJob_Click(object sender, RoutedEventArgs e)
        {
            //JobDescription job = new JobDescription(profileController);
            //job.Show();
        }

        private void btnChangeACC_Click(object sender, RoutedEventArgs e)
        {
            changeACC acc = new changeACC(profileController);
            acc.Show();
        }


        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

                
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            profileController.SaveProfileChanges();
        }
        
        #region ViewTextChangedEvents

        private void FNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            profileController.user.Name = FName.Name;
        }

        private void LNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            profileController.user.LastName = LName.Name;
        }

        private void AgeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(Age.Text, out int result);

            if (result != 0)
            {
                profileController.profileInfo.Age = result;
            }
        }

        private void EmailText_TextChanged(object sender, TextChangedEventArgs e)
        {
            profileController.user.Email = Email.Text;
        }

        private void AboutMeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            profileController.profileInfo.AboutMe = AboutMeBox.Text;
        }
        #endregion

        private void InitializeUserFields()
        {
            FName.Text = profileController.user.Name;
            LName.Text = profileController.user.LastName;
            Email.Text = profileController.user.Email;
            Age.Text = profileController.profileInfo.Age.ToString();
            AboutMeBox.Text = profileController.profileInfo.AboutMe;
        }


    }

}
