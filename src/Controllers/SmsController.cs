using Microsoft.AspNetCore.Mvc;
using SMSAPIs.Entities;
using SmsTwilioSemple.Helper.Dtos;
using SmsTwilioSemple.Helper.Servicies;

namespace SmsTwilioSemple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : Controller
    {
        private readonly ISmsExecService _smsExecService; 

        public SmsController(ISmsExecService smsExecService )
        {
            _smsExecService = smsExecService; 
        } 


        [HttpPost]
        [ActionName("Send")]
        public async Task<IActionResult> SendAsync(MessageDto model)
        {
            try
            {
                var result = await _smsExecService.SendAsync(model.Message, model.To);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
