using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess
{
    public class PlatformContext : IdentityDbContext
    {
        private IConfigurationRoot _config;

        public PlatformContext(DbContextOptions options, IConfigurationRoot config)
          : base(options)
        {
            _config = config;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BuyOffer> BuyOffers { get; set; }
        public DbSet<SellOffer> SellOffers { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionEvent> TransactionEvents { get; set; }
        public DbSet<UserCommunication> UserCommunications { get; set; }
        public DbSet<WantList> WantLists { get; set; }

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

            builder.Entity<Product>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Entity<BuyOffer>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Entity<SellOffer>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Entity<MessageLog>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Entity<Transaction>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Entity<TransactionEvent>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Entity<UserCommunication>()
                .Property(x => x.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Entity<WantList>()
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
