using System.Collections.Generic;
using LinhDang.KworkPractice.Roles.Dto;

namespace LinhDang.KworkPractice.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}