
using Microsoft.Extensions.Options;
using SMSAPIs.Entities;
using SmsTwilioSemple.Helper.Dtos;
using System.Net;
using Twilio;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SmsTwilioSemple.Helper.Servicies;
public class SmsExecService : ISmsExecService
{  
    public async Task<Response<MessageResource>> SendAsync(string contentMessage, string to, SmsConfig _smsConfig)
    {
        try
        { 
            TwilioClient.Init(_smsConfig.AccountSID, _smsConfig.AuthToken);

            var responce = await MessageResource.CreateAsync(
                  body: contentMessage,
                  from: new PhoneNumber(_smsConfig.OriginPhoneNumber),
                  to: new PhoneNumber(to)
              );

            return new Response<MessageResource>() { status = true, data = responce, statusCode = (int)HttpStatusCode.Created };
        }
        catch (Exception ex)
        {
            return new Response<MessageResource>() { status = false, data = null, message = ex.Message, statusCode = (int)HttpStatusCode.InternalServerError };
        }
    }
}