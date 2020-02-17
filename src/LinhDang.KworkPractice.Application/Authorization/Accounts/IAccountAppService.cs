using System.Threading.Tasks;
using Abp.Application.Services;
using LinhDang.KworkPractice.Authorization.Accounts.Dto;

namespace LinhDang.KworkPractice.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
