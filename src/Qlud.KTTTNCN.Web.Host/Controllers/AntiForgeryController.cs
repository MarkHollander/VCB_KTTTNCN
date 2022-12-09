using Microsoft.AspNetCore.Antiforgery;

namespace Qlud.KTTTNCN.Web.Controllers
{
    public class AntiForgeryController : KTTTNCNControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
