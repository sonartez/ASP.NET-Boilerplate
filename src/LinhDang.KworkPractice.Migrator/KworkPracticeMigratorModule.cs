using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinhDang.KworkPractice.Configuration;
using LinhDang.KworkPractice.EntityFrameworkCore;
using LinhDang.KworkPractice.Migrator.DependencyInjection;

namespace LinhDang.KworkPractice.Migrator
{
    [DependsOn(typeof(KworkPracticeEntityFrameworkModule))]
    public class KworkPracticeMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public KworkPracticeMigratorModule(KworkPracticeEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(KworkPracticeMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                KworkPracticeConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KworkPracticeMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
