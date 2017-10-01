using System.Linq;
using System.Web.Mvc;
using AssetManager.Data;
using AssetManager.Models;

namespace AssetManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var assetRepository = new AssetRepository();
            return View(new AssetListModel { Assets = assetRepository.GetAssets().ToList() });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var model = new AboutModel();
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}