using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LinhDang.KworkPractice.Authorization.Roles;
using LinhDang.KworkPractice.Authorization.Users;
using LinhDang.KworkPractice.MultiTenancy;
using LinhDang.KworkPractice.Core.Notebooks;

namespace LinhDang.KworkPractice.EntityFrameworkCore
{
    public class KworkPracticeDbContext : AbpZeroDbContext<Tenant, Role, User, KworkPracticeDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<Notebook> Notebooks { get; set; }
        public virtual DbSet<Note> Notes { get; set; }

        public KworkPracticeDbContext(DbContextOptions<KworkPracticeDbContext> options)
            : base(options)
        {
        }
    }
}
