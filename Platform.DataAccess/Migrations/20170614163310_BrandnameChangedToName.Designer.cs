using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Platform.DataAccess;

namespace Platform.DataAccess.Migrations
{
    [DbContext(typeof(PlatformContext))]
    [Migration("20170614163310_BrandnameChangedToName")]
    partial class BrandnameChangedToName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.BuyOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateListed");

                    b.Property<string>("EUSize");

                    b.Property<bool>("Live");

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UKSize");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("BuyOffers");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.MessageLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BuyOfferId");

                    b.Property<string>("MessageContent");

                    b.Property<int?>("ProductId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("SellOfferId");

                    b.Property<int?>("TransactionId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BuyOfferId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SellOfferId");

                    b.HasIndex("TransactionId");

                    b.HasIndex("UserId");

                    b.ToTable("MessageLogs");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrandId");

                    b.Property<string>("Code");

                    b.Property<string>("Colour");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("ProductName");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.SellOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateListed");

                    b.Property<string>("EUSize");

                    b.Property<bool>("Live");

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UKSize");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("SellOffers");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BuyOfferId");

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("SellOfferId");

                    b.HasKey("Id");

                    b.HasIndex("BuyOfferId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SellOfferId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.TransactionEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Event");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("TransactionId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionEvents");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.UserCommunication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommunicationType");

                    b.Property<bool>("OptIn");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCommunications");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.WantList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTimeAdded");

                    b.Property<string>("EUSize");

                    b.Property<int?>("ProductId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UKSize");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("WantLists");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser");

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("Country");

                    b.Property<string>("CreditCardIdentifier");

                    b.Property<string>("FirstName");

                    b.Property<string>("Surname");

                    b.Property<string>("Town");

                    b.Property<string>("Zipcode");

                    b.ToTable("User");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.BuyOffer", b =>
                {
                    b.HasOne("Platform.DataAccess.Entities.Product", "Product")
                        .WithMany("BuyOffers")
                        .HasForeignKey("ProductId");

                    b.HasOne("Platform.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.MessageLog", b =>
                {
                    b.HasOne("Platform.DataAccess.Entities.BuyOffer", "BuyOffer")
                        .WithMany()
                        .HasForeignKey("BuyOfferId");

                    b.HasOne("Platform.DataAccess.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Platform.DataAccess.Entities.SellOffer", "SellOffer")
                        .WithMany()
                        .HasForeignKey("SellOfferId");

                    b.HasOne("Platform.DataAccess.Entities.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");

                    b.HasOne("Platform.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("Platform.DataAccess.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.SellOffer", b =>
                {
                    b.HasOne("Platform.DataAccess.Entities.Product", "Product")
                        .WithMany("SellOffers")
                        .HasForeignKey("ProductId");

                    b.HasOne("Platform.DataAccess.Entities.User", "User")
                        .WithMany("SellOffers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.Transaction", b =>
                {
                    b.HasOne("Platform.DataAccess.Entities.BuyOffer", "BuyOffer")
                        .WithMany()
                        .HasForeignKey("BuyOfferId");

                    b.HasOne("Platform.DataAccess.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Platform.DataAccess.Entities.SellOffer", "SellOffer")
                        .WithMany()
                        .HasForeignKey("SellOfferId");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.TransactionEvent", b =>
                {
                    b.HasOne("Platform.DataAccess.Entities.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.UserCommunication", b =>
                {
                    b.HasOne("Platform.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Platform.DataAccess.Entities.WantList", b =>
                {
                    b.HasOne("Platform.DataAccess.Entities.Product", "Product")
                        .WithMany("WantLists")
                        .HasForeignKey("ProductId");

                    b.HasOne("Platform.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
