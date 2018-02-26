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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Care.API;
using Care.API.Controllers;
using Care.Data.Models;

namespace Care.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserController userController;
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            userController = new UserController();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(EmailText.Text) && string.IsNullOrEmpty(PasswordText.Password)))
            {
                User user = userController.Authenticate(EmailText.Text, PasswordText.Password);

                if (user != null)
                {
                    if (user.RoleTypeId == 1)
                    {
                        ClientProfile profile = new ClientProfile(user.Id);
                        string jobs = string.Empty;
                        foreach (var job in userController.GetAllJobs(user.Id))
                        {
                            jobs += job.Description + "\n\n";
                        }
                        profile.jobList.ListItems.Add(new ListItem(new Paragraph(new Run(jobs))));
                        profile.userImage.Source = userController.GetPhoto(user.Id);
                        
                        profile.Show();
                    }
                    else
                    {
                        CareGiverProfile profile = new CareGiverProfile(user.Id);
                        string jobs = string.Empty;
                        foreach (var job in userController.GetAllJobs(user.Id))
                        {
                            jobs += job.Description + "\n\n";
                        }
                        profile.jobList.ListItems.Add(new ListItem(new Paragraph(new Run(jobs))));
                        profile.UserImage.Source = userController.GetPhoto(user.Id);
                        profile.userImageCircle.Source = userController.GetPhoto(user.Id);
                        profile.Show();
                    }
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Email or Password");
                }
            }
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            RegisterPage reg = new RegisterPage();
            reg.Show();
            this.Close();
        }
    }
}
