using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess
{
    public class PlatformContext : IdentityDbContext<User>
    {
        private IConfigurationRoot _config;

        public PlatformContext(DbContextOptions options, IConfigurationRoot config)
          : base(options)
        {
            _config = config;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestType> TestTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Brand>()
                .Property(x => x.Name)
                .IsRequired();
            builder.Entity<Brand>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["Data:ConnectionString"]);
        }
    }
}
