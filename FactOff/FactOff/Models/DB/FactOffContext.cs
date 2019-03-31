using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FactOff.Models.DB
{
    public class FactOffContext : DbContext
    {
        public FactOffContext(DbContextOptions<FactOffContext> options)
            : base(options)
        { }

        public DbSet<Fact> Facts { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedFacts)
                .WithOne(f => f.Creator)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserFavoritesFacts>()
                .HasKey(uff => new { uff.UserId, uff.FactId });
            modelBuilder.Entity<UserFavoritesFacts>()
                .HasOne(uff => uff.User)
                .WithMany(u => u.FavoriteFacts)
                .HasForeignKey(uff => uff.UserId);
            modelBuilder.Entity<UserFavoritesFacts>()
                .HasOne(uff => uff.Fact)
                .WithMany(f => f.Users)
                .HasForeignKey(uff => uff.FactId);

            modelBuilder.Entity<UserFavoriteThemes>()
                .HasKey(uft => new { uft.UserId, uft.ThemeId });
            modelBuilder.Entity<UserFavoriteThemes>()
                .HasOne(uft => uft.User)
                .WithMany(u => u.FavoriteThemes)
                .HasForeignKey(uft => uft.UserId);
            modelBuilder.Entity<UserFavoriteThemes>()
                .HasOne(uft => uft.Theme)
                .WithMany(t => t.Users)
                .HasForeignKey(uft => uft.ThemeId);

            modelBuilder.Entity<FactsTags>()
                .HasKey(ft => new { ft.FactId, ft.TagId });
            modelBuilder.Entity<FactsTags>()
                .HasOne(ft => ft.Fact)
                .WithMany(f => f.Tags)
                .HasForeignKey(ft => ft.FactId);
            modelBuilder.Entity<FactsTags>()
                .HasOne(ft => ft.Tag)
                .WithMany(f => f.Facts)
                .HasForeignKey(ft => ft.TagId);
        }

    }
}

