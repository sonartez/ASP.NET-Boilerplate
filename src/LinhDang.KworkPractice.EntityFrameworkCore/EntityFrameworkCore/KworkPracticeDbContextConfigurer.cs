using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LinhDang.KworkPractice.EntityFrameworkCore
{
    public static class KworkPracticeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<KworkPracticeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<KworkPracticeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
