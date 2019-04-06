using Microsoft.EntityFrameworkCore;

namespace FactOff.Models.DB
{
    /// <summary>
    /// Allows work with the database.
    /// </summary>
    public class FactOffContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <c>FactOffContext class</c> using the default options.
        /// </summary>
        /// <param name="options"></param>
        public FactOffContext(DbContextOptions<FactOffContext> options)
            : base(options)
        { }

        /// <summary>
        /// Represents the facts table from the database.
        /// </summary>
        public virtual DbSet<Fact> Facts { get; set; }
        /// <summary>
        /// Represents the themes table from the database.
        /// </summary>
        public virtual DbSet<Theme> Themes { get; set; }
        /// <summary>
        /// Represents the tags table from the database.
        /// </summary>
        public virtual DbSet<Tag> Tags { get; set; }
        /// <summary>
        /// Represents the users table from the database.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Configures the model that was discovered by convention from the entity types exposed in Microsoft.EntityFrameworkCore.DbSet`1.
        /// </summary>
        /// <param name="modelBuilder">Used to construct the model for this context.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel))
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedFacts)
                .WithOne(f => f.Creator)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Theme>()
                .HasMany(t => t.Facts)
                .WithOne(f => f.Theme)
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

