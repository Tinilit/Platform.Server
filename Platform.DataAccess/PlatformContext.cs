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
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<UserTest> UserTests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Brand
            builder.Entity<Brand>()
                .HasKey(x => x.BrandId);
            builder.Entity<Brand>()
                .Property(x => x.Name)
                .IsRequired();
            builder.Entity<Brand>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();
            

            //Profile
            builder.Entity<Profile>()
                .HasKey(x => x.ProfileId);
            builder.Entity<Profile>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            //Test
            builder.Entity<Test>()
                .HasKey(x => x.TestId);
            builder.Entity<Test>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            //TestType
            builder.Entity<TestType>()
                .HasKey(x => x.TestTypeId);
            builder.Entity<TestType>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            //UserTest
            builder.Entity<UserTest>()
                .HasKey(x => x.UserTestId);
            builder.Entity<UserTest>()
                .Property(x=>x.UserProfileId)
                .IsRequired();
            builder.Entity<UserTest>()
                .Property(x => x.TestId)
                .IsRequired();
            builder.Entity<UserTest>()
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
