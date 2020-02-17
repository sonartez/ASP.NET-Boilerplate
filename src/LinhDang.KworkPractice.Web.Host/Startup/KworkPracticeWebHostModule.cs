using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinhDang.KworkPractice.Configuration;

namespace LinhDang.KworkPractice.Web.Host.Startup
{
    [DependsOn(
       typeof(KworkPracticeWebCoreModule))]
    public class KworkPracticeWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public KworkPracticeWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KworkPracticeWebHostModule).GetAssembly());
        }
    }
}
