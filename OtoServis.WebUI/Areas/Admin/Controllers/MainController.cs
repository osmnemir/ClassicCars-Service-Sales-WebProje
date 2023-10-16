using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]// bu controller area içinde çalışacak ve ismi admin.  Authorize ise admin girebilir sadece.
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
