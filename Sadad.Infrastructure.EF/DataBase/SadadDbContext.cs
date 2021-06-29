using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sadad.Core.Entities.Model;

namespace Sadad.Infrastructure.EF.DataBase
{
   public class SadadDbContext : DbContext
    {
        public SadadDbContext()
        {

        }

        public SadadDbContext(DbContextOptions<SadadDbContext> options) : base(options)
        {

        }



        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(x => x.ToTable("User"));
        }

    }
}
