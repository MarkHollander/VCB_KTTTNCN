using System.Globalization;

namespace Qlud.KTTTNCN.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}