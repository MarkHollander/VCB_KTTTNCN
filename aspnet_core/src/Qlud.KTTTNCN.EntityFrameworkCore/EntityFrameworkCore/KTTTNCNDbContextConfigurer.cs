using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Qlud.KTTTNCN.EntityFrameworkCore
{
    public static class KTTTNCNDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<KTTTNCNDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<KTTTNCNDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}