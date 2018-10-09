using AspNetMvc.QuickStart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc.QuickStart.Controllers
{
    public class SoftwareController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Software
        public ActionResult Index()
        {
            return View(db.Softwares.ToList());
        }

        [HttpPost]
        public JsonResult ToTest(List<Software> software)
        {
            if (software != null)
                return Json(new { ok = true, msg = software[1].Name });
            else
                return Json(new { ok = false, msg = "---false---" });
        }
    }
}