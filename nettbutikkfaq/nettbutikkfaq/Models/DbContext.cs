namespace nettbutikkfaq
{
    using nettbutikkfaq.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class DatabaseContext : DbContext
    {
        // Your context has been configured to use a 'DbModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'nettbutikkfaq.DbModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbModel' 
        // connection string in the application configuration file.
        public DatabaseContext()
            : base("name=nettbutikkfaq")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

    public class Questions
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Categories {get; set; }
    }

    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public String Name { get; set; }
        public virtual Question Questions { get; set; }
    }
}