using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LinhDang.KworkPractice.Configuration;
using LinhDang.KworkPractice.Web;

namespace LinhDang.KworkPractice.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class KworkPracticeDbContextFactory : IDesignTimeDbContextFactory<KworkPracticeDbContext>
    {
        public KworkPracticeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<KworkPracticeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            KworkPracticeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(KworkPracticeConsts.ConnectionStringName));

            return new KworkPracticeDbContext(builder.Options);
        }
    }
}
