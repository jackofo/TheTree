using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TheTree_Core.Models;

namespace TheTree_Infrastructure
{
	public class ProjectContext : DbContext
	{
		public ProjectContext() : base()
		{

		}

		public ProjectContext(DbContextOptions<ProjectContext> options)
		: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=LEGION\\TREEDB;Database=thetreedb;Trusted_Connection=True;");
			//options.UseSqlServer("Data source=thetreedb.db");
		}

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Person>()
				.HasKey(k => k.Id);
        }
    }
}
