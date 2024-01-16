using Twilio.Rest.Api.V2010.Account;

namespace SmsTwilioSemple.Helper.Servicies;
public interface ISmsExecService
{
    Task<MessageResource> SendAsync(string contentMessage, string to);
}