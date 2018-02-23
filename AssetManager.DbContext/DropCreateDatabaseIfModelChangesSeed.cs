using System.Data.Entity;
using System.Linq;
using AssetManager.Model;

namespace AssetManager.DbContext
{
    internal class DropCreateDatabaseIfModelChangesSeed : DropCreateDatabaseIfModelChanges<AssetContext>
    {
        protected override void Seed(AssetContext context)
        {
            if (!context.Groups.Any())
            {
                context.Groups.Add(new Group { Name = "Desks" });
                context.Groups.Add(new Group { Name = "Cabinets" });
                context.Groups.Add(new Group { Name = "Chairs" });
                context.Groups.Add(new Group { Name = "Wardrobes" });
                context.SaveChanges();
            }
        }
    }
}
