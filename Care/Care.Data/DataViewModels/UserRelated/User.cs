using Care.Data.DataViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Care.Data.Models
{
    public class User : EntityBase //,INotifyPropertyChanged
    {
        //private string lastname;
        //private string name;
        //private string email;

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
        


        //private void NotifyPropertyChanged(string info)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(info));
        //    }
        //}


        [Required]
        public string Email { get; set; }
       

        public string Password { get; set; }

        [Required]
        public int RoleTypeId { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
