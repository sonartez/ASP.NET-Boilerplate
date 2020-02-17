using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LinhDang.KworkPractice.MultiTenancy.Dto;

namespace LinhDang.KworkPractice.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

