using Abp.AutoMapper;
using LinhDang.KworkPractice.Roles.Dto;
using LinhDang.KworkPractice.Web.Models.Common;

namespace LinhDang.KworkPractice.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
