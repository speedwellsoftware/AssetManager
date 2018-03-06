using System.Collections.Generic;

namespace AssetManager.Models
{
    public class AssetListModel
    {
        public ICollection<AssetDetailsModel> Assets { get; set; }
    }
}