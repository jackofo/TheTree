using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TheTree_Core.Models;

namespace TheTree_Infrastructure
{
	public class Context : DbContext
	{
        public Context(DbContextOptions<Context> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Data source=thetreedb.db");
		}

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
        }
    }
}
