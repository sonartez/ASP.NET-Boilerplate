using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinhDang.KworkPractice.Authorization;

namespace LinhDang.KworkPractice
{
    [DependsOn(
        typeof(KworkPracticeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class KworkPracticeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<KworkPracticeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(KworkPracticeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
