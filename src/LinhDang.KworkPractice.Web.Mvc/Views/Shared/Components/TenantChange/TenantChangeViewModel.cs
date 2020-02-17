using Abp.AutoMapper;
using LinhDang.KworkPractice.Sessions.Dto;

namespace LinhDang.KworkPractice.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
