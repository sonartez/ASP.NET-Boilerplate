using System.Collections.Generic;
using System.Linq;
using LinhDang.KworkPractice.Roles.Dto;
using LinhDang.KworkPractice.Users.Dto;

namespace LinhDang.KworkPractice.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
