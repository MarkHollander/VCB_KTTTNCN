using System.Threading.Tasks;

namespace Qlud.KTTTNCN.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
