using HrMatch.Models;
using HrMatchApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrMatch
{
    class HrMatchContext : DbContext
    {
        public HrMatchContext()
            : base("MyConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<WorkersAnnouncements> workersAnnouncements { get; set; }
    }
}
