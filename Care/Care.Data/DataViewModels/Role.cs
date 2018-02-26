using Care.Data.DataViewModels;

namespace Care.Data.Models
{
    public class Role : EntityBase
    {
        public int UserId { get; set; }

        public RoleType RoleId { get; set; }
    }
}
