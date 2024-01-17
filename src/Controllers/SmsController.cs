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
        private readonly IConfiguration _configuration;

        public SmsController(ISmsExecService smsExecService, IConfiguration configuration)
        {
            _smsExecService = smsExecService;
            _configuration = configuration;
        }


        //private SmsConfig Init()
        //{
        //    var cnfig = new SmsConfig(); 
        //    cnfig.AccountSID = _configuration.GetValue<string>("TwilioSetting:AccountSID");
        //    cnfig.AuthToken = _configuration.GetValue<string>("TwilioSetting:AuthToken");
        //    cnfig.OriginPhoneNumber = _configuration.GetValue<string>("TwilioSetting:OriginPhoneNumber");

        //    return cnfig;
        //}


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
