using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineTest.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int No { get; set; }
        [Required(ErrorMessage = "Please Enter Question")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter option1")]
        public string Option1 { get; set; }
        [Required(ErrorMessage = "Please Enter option2")]
        public string Option2 { get; set; }
        [Required(ErrorMessage = "Please Enter option3")]
        public string Option3 { get; set; }
        [Required(ErrorMessage = "Please Enter option4")]
        public string Option4 { get; set; }
        [Required(ErrorMessage = "Please Enter Answer")]
        public string Answer { get; set; }
    }

    public class QuestionDBContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
