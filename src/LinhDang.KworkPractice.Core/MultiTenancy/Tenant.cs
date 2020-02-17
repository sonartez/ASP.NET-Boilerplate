using Abp.MultiTenancy;
using LinhDang.KworkPractice.Authorization.Users;

namespace LinhDang.KworkPractice.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
