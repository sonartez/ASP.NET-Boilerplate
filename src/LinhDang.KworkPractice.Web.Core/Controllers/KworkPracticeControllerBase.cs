using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LinhDang.KworkPractice.Controllers
{
    public abstract class KworkPracticeControllerBase: AbpController
    {
        protected KworkPracticeControllerBase()
        {
            LocalizationSourceName = KworkPracticeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
