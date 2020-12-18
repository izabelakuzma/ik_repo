using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkAggregatorProject.Models
{
    public class UserDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.Email, p.Password })
                .IsUnique(true);


            //  modelBuilder.Entity<LinkRatingViewModel>(eb =>
            //{
            //    eb.HasNoKey();
            //    eb.ToView("View_LinkRating");
            //    eb.Property(v => v.LinkAddress).HasColumnName("LinkAddress");
            //})
            modelBuilder.Entity<LinkRatingViewModel>().HasNoKey();
           
            //modelBuilder.Entity<LinkRatingViewModel>(eb =>
            //{
            //    eb.HasNoKey();
            //    eb.ToView("View_LinkRating");
            //    eb.Property(v => v.LinkAddress).HasColumnName("LinkAddress");
            //});
        }

        //public virtual DbSet<LinkRatingViewModel> LinkRatingViewModel { get; set; }


        [Obsolete]
        public DbQuery<LinkRatingViewModel> LinkRatingViewModel { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Link> Links { get; set; }

        public DbSet<Rating> Ratings { get; set; }
    }
}
