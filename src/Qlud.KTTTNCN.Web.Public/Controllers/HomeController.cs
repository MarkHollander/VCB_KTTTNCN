using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Web.Controllers;

namespace Qlud.KTTTNCN.Web.Public.Controllers
{
    public class HomeController : KTTTNCNControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}