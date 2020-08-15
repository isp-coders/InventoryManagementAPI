using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Reporting.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Designer() {
            Models.ReportsModel model = new Models.ReportsModel();
            return View(model);
        }

        public IActionResult Viewer() {
            return View();
        }
    }
}