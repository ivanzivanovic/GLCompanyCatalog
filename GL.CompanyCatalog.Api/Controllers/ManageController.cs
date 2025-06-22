using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GL.CompanyCatalog.Api.Controllers
{
    [AllowAnonymous]
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("info")]
        public IActionResult Info()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return Ok(new
                {
                    UserName = User.Identity.Name,
                });
            }
            return Ok(new
            {
                UserName = "Ljubisa",
            });
        }
    }
}
