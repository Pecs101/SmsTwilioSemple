using Microsoft.AspNetCore.Mvc;

namespace SmsTwilioSemple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}
