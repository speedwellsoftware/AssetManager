using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.DbContext;
using AssetManager.Model;

namespace AssetManager.Data
{
    public class AssetRepository
    {
        public IEnumerable<Asset> GetAssets()
        {
            var context = new AssetContext();
            var assets = context.Assets.Include(nameof(Asset.Group)).AsEnumerable();
            return assets;
        }

        public Asset GetAsset(int assetId)
        {
            var context = new AssetContext();
            var asset = context.Assets.Include(nameof(Asset.Group)).FirstOrDefault(x => x.Id == assetId);
            return asset;
        }

        public IEnumerable<Group> GetGroups()
        {
            var context = new AssetContext();
            return context.Groups.AsEnumerable();
       }

        public async Task<int> SaveAssetAsync(Asset model)
        {
            var context = new AssetContext();
            if (model.Id == 0)
            {
                context.Assets.Add(model);
            }
            else
            {
                context.Assets.Attach(model);
                context.Entry(model).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return model.Id;
        }

        public async Task DeleteAssetAsync(int assetId)
        {
            var context = new AssetContext();
            var asset = new Asset {Id = assetId};
            context.Assets.Attach(asset);
            context.Entry(asset).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
