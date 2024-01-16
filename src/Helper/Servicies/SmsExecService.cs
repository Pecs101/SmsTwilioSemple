
using Microsoft.Extensions.Options;
using SMSAPIs.Entities;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SmsTwilioSemple.Helper.Servicies;
public class SmsExecService : ISmsExecService
{
    private readonly SmsConfig _smsConfig;

    public SmsExecService(IOptions<SmsConfig> smsSetting)
    {
        _smsConfig = smsSetting.Value;
    } 

    public async Task<MessageResource> SendAsync(string contentMessage, string to)
    {
        TwilioClient.Init(_smsConfig.AccountSID, _smsConfig.AuthToken);

        var responce = await MessageResource.CreateAsync(
              body: contentMessage,
              from: new PhoneNumber(_smsConfig.OriginPhoneNumber),
              to: new PhoneNumber(to)
          );

        return responce;
    }
}