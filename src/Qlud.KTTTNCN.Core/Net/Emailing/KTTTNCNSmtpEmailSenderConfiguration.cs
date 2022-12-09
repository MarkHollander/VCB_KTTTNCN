using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace Qlud.KTTTNCN.Net.Emailing
{
    public class KTTTNCNSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public KTTTNCNSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}