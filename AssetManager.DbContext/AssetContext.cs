using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using AssetManager.Model;

namespace AssetManager.DbContext
{
    public class AssetContext: System.Data.Entity.DbContext
    {
        public AssetContext(): base("AssetConnection")
        {
            var forceDll = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asset>()
                .HasRequired(x => x.Group)
                .WithMany();
        }
    }
}
