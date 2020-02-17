using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LinhDang.KworkPractice.Roles.Dto;
using LinhDang.KworkPractice.Users.Dto;

namespace LinhDang.KworkPractice.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
