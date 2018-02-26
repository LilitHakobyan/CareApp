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
using Care.API.Controllers;

namespace Care.UI
{
    /// <summary>
    /// Interaction logic for AboutMeEditWin.xaml
    /// </summary>
    public partial class AboutMeEditWin : Window
    {
        private ProfileController profileController;

        public AboutMeEditWin(ProfileController profileController)
        {
            InitializeComponent();
            this.profileController = profileController;
            Loaded += ChangeAboutMe_Loaded;
        }

        private void ChangeAboutMe_Loaded(object sender, RoutedEventArgs e)
        {
            AboutMe.Text = profileController.profileInfo.AboutMe;
            AboutMe.TextChanged += aboutMe_TextChanged;
        }

        private void aboutMe_TextChanged(object sender, TextChangedEventArgs e)
        {
            profileController.profileInfo.AboutMe = AboutMe.Text;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {            
            profileController.SaveProfileChanges();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
