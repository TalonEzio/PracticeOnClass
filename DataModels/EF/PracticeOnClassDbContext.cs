using System.Data.Entity;

namespace DataModels.EF
{
    public partial class PracticeOnClassDbContext : DbContext
    {
        public PracticeOnClassDbContext()
            : base("name=PracticeOnClassDbContext")
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.ImageUrl)
                .IsFixedLength();
        }
    }
}
