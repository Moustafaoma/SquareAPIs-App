using Microsoft.EntityFrameworkCore;
using Square.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.EFCore
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }    
        public DbSet<Posts> Posts { get; set; }        
        public DbSet<Likes> Likes { get; set; }      
        public DbSet<Comments> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Users table
            modelBuilder.Entity<Users>()
                .HasKey(u => u.Id);

            // Configure Posts table
            modelBuilder.Entity<Posts>()
                .HasKey(p => p.Id);

            // Configure Likes table
            modelBuilder.Entity<Likes>()
                .HasKey(l => l.Id);

            // Configure Comments table
            modelBuilder.Entity<Comments>()
                .HasKey(c => c.Id);

            // Add any additional configurations here

            base.OnModelCreating(modelBuilder);
        }

    }

}
