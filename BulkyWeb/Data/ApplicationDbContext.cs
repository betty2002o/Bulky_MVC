using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
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
	}
}
