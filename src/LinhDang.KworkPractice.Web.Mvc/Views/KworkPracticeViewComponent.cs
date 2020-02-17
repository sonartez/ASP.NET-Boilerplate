using Abp.AspNetCore.Mvc.ViewComponents;

namespace LinhDang.KworkPractice.Web.Views
{
    public abstract class KworkPracticeViewComponent : AbpViewComponent
    {
        protected KworkPracticeViewComponent()
        {
            LocalizationSourceName = KworkPracticeConsts.LocalizationSourceName;
        }
    }
}
