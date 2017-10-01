using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Web.Mvc;
using AssetManager.Model;

namespace AssetManager.Models
{
    public class AssetDetailsModel
    {
        public int Id { get; set; }

        [Display(Name = "Asset name")]
        [Required, StringLength(20, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Display(Name="Group")]
        public string GroupName { get; set; }

        public int GroupId { get; set; }

        public IEnumerable<SelectListItem> Groups { get; set; }

        public AssetDetailsModel() { }

        public AssetDetailsModel(Asset asset)
        {
            Id = asset.Id;
            Name = asset.Name;
            GroupId = asset.GroupId;
        }
    }
}