using System.Collections.Generic;
using LinhDang.KworkPractice.Roles.Dto;

namespace LinhDang.KworkPractice.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
