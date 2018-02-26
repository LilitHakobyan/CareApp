using Care.API.Controllers;
using Care.Data.DataViewModels;
using Care.Data.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for JobDescription.xaml
    /// </summary>
    public partial class JobDescription : Window
    {
        CareTypesEnum type;
        ProfileController profileController;

        public JobDescription()
        {
           //this.profileController = profileController;
            InitializeComponent();
            Loaded += AddEnumElements;
            // user.Jobs = new ObservableCollection<Job>(); 
        }

        private void AddEnumElements(object sender, RoutedEventArgs e)
        {
           foreach(var item in Enum.GetValues(typeof(CareTypesEnum)))
            {
                Types.Items.Add(item);
            }

            Types.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = (CareTypesEnum)Types.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            profileController.AddJob(new Job()
            {
                Description = JobDescriptionText.Text,
                CareType = type,
                UserId = profileController.user.Id
            });
            
            this.Close();
        }
    }
}
