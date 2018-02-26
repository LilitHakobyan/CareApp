using Care.Data.DataViewModels;
using Care.Data.Models;
using System.Data.Entity;

namespace Care.Data
{
     class CareDbContext : DbContext
    {
        public CareDbContext() : base("name=CareConnection") { }

        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<CareType> CareTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Contract> Contracts {get;set;}
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
    }
}

