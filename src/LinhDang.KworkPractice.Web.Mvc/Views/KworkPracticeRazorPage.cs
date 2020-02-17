using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace LinhDang.KworkPractice.Web.Views
{
    public abstract class KworkPracticeRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected KworkPracticeRazorPage()
        {
            LocalizationSourceName = KworkPracticeConsts.LocalizationSourceName;
        }
    }
}
