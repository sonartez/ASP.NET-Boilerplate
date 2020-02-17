using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace LinhDang.KworkPractice.Localization
{
    public static class KworkPracticeLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(KworkPracticeConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(KworkPracticeLocalizationConfigurer).GetAssembly(),
                        "LinhDang.KworkPractice.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
