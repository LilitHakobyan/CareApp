using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Care.Data.DataViewModels
{
    
    public class UserInfo
    {
        public UserInfo()
        {
            Jobs = new ObservableCollection<Job>(new BaseRepository<Job>().GetAll());
            Contracts = new ObservableCollection<Contract>(new BaseRepository<Contract>().GetAll());
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public int CareTypeId { get; set; }

        public bool Gender { get; set; }

        public byte[] Photo { get; set; }

        public string AboutMe { get; set; }

        public double Rating { get; set; }

        public int? Age { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public ICollection<Job> Jobs { get; set; }     
    }
}
