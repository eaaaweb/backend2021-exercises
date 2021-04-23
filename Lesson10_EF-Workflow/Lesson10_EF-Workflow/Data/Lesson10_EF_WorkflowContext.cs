using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lesson10_EF_Workflow.Models;

namespace Lesson10_EF_Workflow.Data
{
    public class Lesson10_EF_WorkflowContext : DbContext
    {
        public Lesson10_EF_WorkflowContext (DbContextOptions<Lesson10_EF_WorkflowContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }  
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Author>().ToTable("Author");

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .HasIndex(a => new { a.Name })
                .IsUnique();

        }
    }

  
}
