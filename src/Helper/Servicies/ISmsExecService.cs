using SMSAPIs.Entities;
using SmsTwilioSemple.Helper.Dtos;
using Twilio.Rest.Api.V2010.Account;

namespace SmsTwilioSemple.Helper.Servicies;
public interface ISmsExecService
{
    Task<Response<MessageResource>> SendAsync(string contentMessage, string to, SmsConfig config);
}