using Abp.Authorization;
using LinhDang.KworkPractice.Authorization.Roles;
using LinhDang.KworkPractice.Authorization.Users;

namespace LinhDang.KworkPractice.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
