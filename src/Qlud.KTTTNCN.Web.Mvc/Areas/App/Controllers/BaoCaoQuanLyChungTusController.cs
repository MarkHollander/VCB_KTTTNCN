using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Web.Controllers;

namespace Qlud.KTTTNCN.Web.Areas.App.Controllers
{
    public class BaoCaoQuanLyChungTusController : KTTTNCNControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
