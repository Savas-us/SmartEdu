using SmartEdu.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace SmartEdu.Models.ORM.Context
{
    public class SiteContext : DbContext
    {

        public SiteContext()
        {
            Database.Connection.ConnectionString = @"server=01ozelders.com;Initial Catalog=ozelders_SmartDB;User ID=ozelders_OZEL;
        Password=g7Fy1Ca9F;";
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<İmage> İmages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<İletisim> İletisims { get; set; }
        public DbSet<Zamanlayıcı> Zamanlayıcıs { get; set; }
        
    }


}
