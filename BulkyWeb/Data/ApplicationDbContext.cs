using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BulkyWeb.Data
{
	//ApplicationDbContext is the custom DbContext
	// DbContext inheritance from EF Core’s DbContext class -> allow EF Core functionality for querying and saving data
	public class ApplicationDbContext : DbContext
	{
		// cotr - constructor - takes DbContextOptions<ApplicationDbContext> as a parameter
		// update-database command in package manager console to apply migration and create the database
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
                
        }
		// DbSet<T> maps to a table in the database.
		// Categories name of the table in SQL
		// package manager console command to create migration: Add-Migration AddCategoryTableToDb
		// update-database 
		public DbSet<Category> Categories { get; set; }

		// OnModelCreating tells What tables to create, Relationships, Column rules,Seed data

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			// Seeding
			// add-migration SeedCategoryTable
			// update-database
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
				new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
				new Category { Id = 3, Name = "History", DisplayOrder = 3 }
		);

		}
	}
}
