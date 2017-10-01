using System.ComponentModel.DataAnnotations;

namespace AssetManager.Model
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
