using Care.API;
using Care.API.Controllers;
using Care.Data.Models;
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
    /// Interaction logic for RegisteChoose.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private int roleType;
        private UserController userController;

        public RegisterPage()
        {
            InitializeComponent();
            grdSelectRoleType.Visibility = Visibility.Visible;
            grdRegistration.Visibility = Visibility.Hidden;
            Loaded += RegisterPage_Loaded;
        }

        private void RegisterPage_Loaded(object sender, RoutedEventArgs e)
        {
            userController = new UserController(); 
        }

        private void btnRoleType_Click(object sender, RoutedEventArgs e)
        {
            roleType = (sender as Button).Name == "btnCare" ? 1 : 2;//????
            grdSelectRoleType.Visibility = Visibility.Hidden;
            grdRegistration.Visibility = Visibility.Visible;
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            int result = await userController.RegisterUserAsync(FNameText.Text, LNameText.Text,
                                                   EmailText.Text, PasswordBox.Password, roleType);
            if (result != 0)
            {
                User user = userController.Authenticate(EmailText.Text, PasswordBox.Password);
                    ClientProfile profile = new ClientProfile(user.Id);
                profile.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
           
        }

        
        
    }
}
