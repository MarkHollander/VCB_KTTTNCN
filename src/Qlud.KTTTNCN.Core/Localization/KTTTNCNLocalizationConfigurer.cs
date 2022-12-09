using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Qlud.KTTTNCN.Localization
{
    public static class KTTTNCNLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    KTTTNCNConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(KTTTNCNLocalizationConfigurer).GetAssembly(),
                        "Qlud.KTTTNCN.Localization.KTTTNCN"
                    )
                )
            );
        }
    }
}