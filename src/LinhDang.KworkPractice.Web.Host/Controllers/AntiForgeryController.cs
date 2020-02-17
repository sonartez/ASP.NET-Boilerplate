using Microsoft.AspNetCore.Antiforgery;
using LinhDang.KworkPractice.Controllers;

namespace LinhDang.KworkPractice.Web.Host.Controllers
{
    public class AntiForgeryController : KworkPracticeControllerBase
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
