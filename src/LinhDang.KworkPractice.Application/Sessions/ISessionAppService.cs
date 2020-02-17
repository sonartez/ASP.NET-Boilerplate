using System.Threading.Tasks;
using Abp.Application.Services;
using LinhDang.KworkPractice.Sessions.Dto;

namespace LinhDang.KworkPractice.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
