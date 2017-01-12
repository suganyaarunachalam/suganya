using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineTest.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter UserName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
