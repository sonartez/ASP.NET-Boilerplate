using System.Collections.Generic;
using LinhDang.KworkPractice.Roles.Dto;
using LinhDang.KworkPractice.Users.Dto;

namespace LinhDang.KworkPractice.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
