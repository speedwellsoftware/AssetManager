using System.Collections.Generic;
using AssetManager.Model;

namespace AssetManager.Models
{
    public class AssetListModel
    {
        public ICollection<Asset> Assets { get; set; }
    }
}