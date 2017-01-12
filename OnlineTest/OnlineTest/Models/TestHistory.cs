using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineTest.Models
{
    public class TestHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastAttendDate { get; set; }
        public int score { get; set; }
    }

    public class TestHistoryDBContext : DbContext
    {
        public DbSet<TestHistory> TestHistorys { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
