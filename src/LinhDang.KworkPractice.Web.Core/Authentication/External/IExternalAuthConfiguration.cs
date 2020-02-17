using System.Collections.Generic;

namespace LinhDang.KworkPractice.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
