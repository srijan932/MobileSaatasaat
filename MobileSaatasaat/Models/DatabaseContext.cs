using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MobileSaatasaat.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("mobilesaatasaat")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public System.Data.Entity.DbSet<MobileSaatasaat.ViewModel.PostVM> PostVMs { get; set; }
    }
    
}
