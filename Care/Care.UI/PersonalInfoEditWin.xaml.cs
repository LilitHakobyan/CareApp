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
using Care.API.ViewModels;

namespace Care.UI
{
    /// <summary>
    /// Interaction logic for PersonalInfoEditWin.xaml
    /// </summary>
    public partial class PersonalInfoEditWin : Window
    {
        UserProfileViewModel viewModel;

        public PersonalInfoEditWin(UserProfileViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.DataContext = viewModel;
            Loaded += PersonalInfoEditWin_Loaded;
        }

        private void PersonalInfoEditWin_Loaded(object sender, RoutedEventArgs e)
        {
            //FName.Text = viewModel.Name;
            //LastName.Text = viewModel.LastName;
            //Age.Text = viewModel.Age.ToString();
            //EMail.Text = viewModel.Email;

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
           viewModel.SaveChanges();
           this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
