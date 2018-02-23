using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssetManager.Data;
using AssetManager.Model;
using AssetManager.Models;

namespace AssetManager.Controllers
{
    public class AssetController : Controller
    {
        [Route("asset/{assetId}")]
        public ActionResult View(int assetId)
        {
            var repo = new AssetRepository();
            var asset = repo.GetAsset(assetId);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(new AssetDetailsModel(asset) { GroupName = asset.Group.Name });
        }

        [Route("asset/add")]
        public ActionResult Add()
        {
            var model = AddEdit(0);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Edit", model);
        }

        [Route("asset/{assetId}/edit")]
        public ActionResult Edit(int assetId)
        {
            var model = AddEdit(assetId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        [Route("asset/delete/{assetId}")]
        public async Task<ActionResult> Delete(int assetId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            var repo = new AssetRepository();
            await repo.DeleteAssetAsync(assetId);
            return RedirectToAction("Index", "Home", new { assetId });
        }

        [Route("asset/save")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(AssetDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            var repo = new AssetRepository();
            var id = await repo.SaveAssetAsync(new Asset { Id = model.Id, Name = model.Name, Width = model.Width, Height = model.Height, Length = model.Length, GroupId = model.GroupId });
            return RedirectToAction("View", new { assetId = id });
        }
        private AssetDetailsModel AddEdit(int assetId)
        {
            var repo = new AssetRepository();
            var asset = assetId == 0 ? new Asset() : repo.GetAsset(assetId);
            if (asset == null)
            {
                return null;
            }
            var groups = repo.GetGroups();
            return new AssetDetailsModel(asset)
            {
                GroupName = asset.Group?.Name,
                Groups = groups.Select(g =>
                    new SelectListItem {Selected = asset.GroupId == g.Id, Text = g.Name, Value = g.Id.ToString()})
            };
        }
    }
}