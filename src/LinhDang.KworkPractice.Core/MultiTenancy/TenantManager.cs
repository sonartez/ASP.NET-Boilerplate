using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using LinhDang.KworkPractice.Authorization.Users;
using LinhDang.KworkPractice.Editions;

namespace LinhDang.KworkPractice.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
