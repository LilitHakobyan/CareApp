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
    /// Interaction logic for changeACC.xaml
    /// </summary>
    public partial class changeACC : Window
    {
        private ProfileController profileController;

        public changeACC(ProfileController profileController)
        {
            InitializeComponent();
            this.profileController = profileController;
            this.DataContext = profileController.profileInfo;
            Loaded += ChangeACC_Loaded;
        }

        private void ChangeACC_Loaded(object sender, RoutedEventArgs e)
        {
            AddressText.Text = profileController.profileInfo.Address;
            CountryText.Text = profileController.profileInfo.Country;
            CityText.Text = profileController.profileInfo.City;          
        }      

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            profileController.profileInfo.Address = AddressText.Text;
            profileController.profileInfo.City = CityText.Text;
            profileController.profileInfo.Country = CountryText.Text;
            profileController.SaveProfileChanges();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
