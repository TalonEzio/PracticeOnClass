using System.Data.Entity;

namespace DataModels.EF
{
    public partial class PracticeOnClassDbContext : DbContext
    {
        public PracticeOnClassDbContext()
            : base("name=PracticeOnClassDbContext")
        {
            var init =
                new MigrateDatabaseToLatestVersion<PracticeOnClassDbContext, Migrations.Configuration>();
            Database.SetInitializer(init);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.ImageUrl)
                .IsFixedLength();

            //1 category - n products
            modelBuilder.Entity<Product>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Products);
        }
    }
}
