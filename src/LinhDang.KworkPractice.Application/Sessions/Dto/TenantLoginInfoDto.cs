using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LinhDang.KworkPractice.MultiTenancy;

namespace LinhDang.KworkPractice.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
