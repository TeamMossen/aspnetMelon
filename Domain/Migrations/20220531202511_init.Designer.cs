// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220531202511_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Domain.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryDescription = "Mobiltillbehör av alla sorter!",
                            CategoryName = "Mobilt"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryDescription = "Allt för hemmanätverket!",
                            CategoryName = "Nätverk"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryDescription = "Allt från hörlurar till hemmabio!",
                            CategoryName = "Ljud & Bild"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryDescription = "Saftiga meloner från jordens alla hörn!",
                            CategoryName = "Meloner"
                        });
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnSale")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 3,
                            Description = "DT 770 PRO är en sluten dynamisk hörlurar av exceptionell kvalitet som lämpar sig för de mest krävande professionella och audiofiler applikationer. Komfort och exakt prestanda gör DT 770 PRO perfekt hörlurar för inspelningsstudior, produktion eller sändning.",
                            ImageThumbnailUrl = "\\Images\\dt770pro.jpg",
                            ImageUrl = "\\Images\\dt770pro.jpg",
                            IsOnSale = false,
                            Name = "Beyerdynamics DT770 Pro 80",
                            Price = 1749m,
                            SalePrice = 1400m,
                            Stock = 5
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3,
                            Description = "Arc utnyttjar Sonos kraftfulla nya mjukvaruplattform för att leverera Sonos mest omslutande hemmabioupplevelse hittills.",
                            ImageThumbnailUrl = "\\Images\\sonos-arc.jpg",
                            ImageUrl = "\\Images\\sonos-arc.jpg",
                            IsOnSale = false,
                            Name = "Sonos ARC Hemmabio paket",
                            Price = 18990m,
                            SalePrice = 0m,
                            Stock = 420
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            Description = "LG OLED TV är en glädje att se. Självlysande pixlar ger en häpnadsväckande bildkvalitet och en mängd designmöjligheter, och de senaste banbrytande teknikerna tar upplevelserna till nya oöverträffade höjder. Allt du redan älskar med TV - på en ny och högre nivå.",
                            ImageThumbnailUrl = "\\Images\\lg-tv.jpg",
                            ImageUrl = "\\Images\\lg-tv.jpg",
                            IsOnSale = true,
                            Name = "LG 65\" OLED 4K TV OLED65C1",
                            Price = 15790m,
                            SalePrice = 419m,
                            Stock = 55
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            Description = "Nas ur Synologys populära DS-serie som passar bra i både hemmiljö och mindre företag. Har plats för två hårddiskar med hot swap-stöd som kan konfigureras med bl.a. Raid 1 (ger dubbel lagringsäkerhet och påverkas inte om en disk fallerar).",
                            ImageThumbnailUrl = "\\Images\\synology-ds220.jpg",
                            ImageUrl = "\\Images\\synology-ds220.jpg",
                            IsOnSale = false,
                            Name = "Synology DS220+ Nas för 2 hårddiskar",
                            Price = 3890m,
                            SalePrice = 0m,
                            Stock = 99
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            Description = "TP-link Deco M5 är ett paket med Wireless AC-repeatrar som tillsammans kan täcka upp till 400 m² med ett enda wifi-nätverk. Ansluts direkt till fiberanslutning eller till ett befintligt modem eller router.",
                            ImageThumbnailUrl = "\\Images\\deco-m5.jpg",
                            ImageUrl = "\\Images\\deco-m5.jpg",
                            IsOnSale = true,
                            Name = "TP-link Deco M5 Mesh-system AC1300 3-pack",
                            Price = 2589m,
                            SalePrice = 419m,
                            Stock = 550
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 2,
                            Description = "Asus RT-AX55 är en Wifi 6-router som passar perfekt för dig som vill ha snabbt och stabilt wifi hemma med de senaste teknikerna. Genom att använda Wifi 6-standarden (802.11ax) kan routern ge upp till 1201 Mbps över 5 GHz bandet",
                            ImageThumbnailUrl = "\\Images\\rt-ax55.jpg",
                            ImageUrl = "\\Images\\rt-ax55.jpg",
                            IsOnSale = false,
                            Name = "Asus RT-AX55 Trådlös router AX1800",
                            Price = 1290m,
                            SalePrice = 0m,
                            Stock = 55
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            Description = "Kraftfullt extrabatteri för laddning av mobil, surfplatta och andra USB-enheter. Kapacitet på 16000 mAh som räcker för att ladda upp en mobil ca 6 gånger. Utrustat med ficklampa, två USB-portar (totalt 2,1 A) och laddningsindikator.",
                            ImageThumbnailUrl = "\\Images\\solcell-powerbank.jpg",
                            ImageUrl = "\\Images\\solcell-powerbank.jpg",
                            IsOnSale = false,
                            Name = "Linocell Powerbank med solcellsladdning 16000 mAh",
                            Price = 699m,
                            SalePrice = 0m,
                            Stock = 999
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 1,
                            Description = "Med data och erfarenheter från tusentals reparationsguider och demonteringar har iFixit sammanställt ett komplett vertygskit för alla typer av reparationer – från gamla vintage-konsoler till moderna Apple-datorer och surfplattor. Innehåller bland annat 64 bits i stål samt alla verktyg som behövs för att t.ex. lossa fastlimmade skärmar och batterier och byta ut olika komponenter. Inkluderar special-bits för bl.a. Apple-enheter, spelkonsoler och kaffemaskiner. Används av allt ifrån NASA till NSA och Edward Snowden.",
                            ImageThumbnailUrl = "\\Images\\ifixit.jpg",
                            ImageUrl = "\\Images\\ifixit.jpg",
                            IsOnSale = true,
                            Name = "Ifixit Pro Tech Toolkit Reparationskit",
                            Price = 599m,
                            SalePrice = 419m,
                            Stock = 5000
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 1,
                            Description = "Galaxy S21 FE med en magiskt 6.4”-disaplay med 120 Hz-bilduppdatering för en oslagbar upplevelse när du scrollar igenom hemsidor, appar och spel. Stänk- och vattentålig design och med Gorilla Glass Victus för ett ännu starkare skydd mot repor. Fingeravtrycksläsare för säker och smidig upplåsning av telefonen och inloggning i kompatibla appar.",
                            ImageThumbnailUrl = "\\Images\\galaxy-s21fe.jpg",
                            ImageUrl = "\\Images\\galaxy-s21fe.jpg",
                            IsOnSale = false,
                            Name = "Samsung Galaxy S21 FE 128 GB Svart",
                            Price = 8190m,
                            SalePrice = 0m,
                            Stock = 10000
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 4,
                            Description = "Jimbee Tropical är en helt ny variant av Piel de Sapo, Corazón de Oro, med ett orange fruktkött. Sorten har ett mycket sött, saftigt och krispigt fruktkött med en tropisk smak.",
                            ImageThumbnailUrl = "\\Images\\jimbee-tropical.jpg",
                            ImageUrl = "\\Images\\jimbee-tropical.jpg",
                            IsOnSale = false,
                            Name = "Jimbee Tropical",
                            Price = 49m,
                            SalePrice = 0m,
                            Stock = 1000000
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 4,
                            Description = "Limelon är en ny melonsort med en fräsch smak av lime. Skalet är grönrandigt och fruktköttet grönvitt. Den har en hög halt av askorbinsyra och citronsyra men är även hög i sötma vilket ger en spännande smak. Passar bra i sallader, juice och smoothies. Testa den ihop med jordgubbar!",
                            ImageThumbnailUrl = "\\Images\\limelon.jpg",
                            ImageUrl = "\\Images\\limelon.jpg",
                            IsOnSale = false,
                            Name = "Limelon",
                            Price = 39m,
                            SalePrice = 0m,
                            Stock = 5000
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 4,
                            Description = "Denna tjockskaliga, grågröna nätmelon som är lite klyftad i skalet har en alldeles ljuvlig smak! Fruktköttet är laxfärgat, mjukt och smältande, precis som hos cantaloupe melonen. Nätmelon har fått sitt namn efter det typiska nätmönstret på skalet.Det är en dessertfrukt med mycket söt, aromatisk smak.",
                            ImageThumbnailUrl = "\\Images\\nätmelon-italiensk.jpg",
                            ImageUrl = "\\Images\\nätmelon-italiensk.jpg",
                            IsOnSale = false,
                            Name = "Nätmelon italiensk",
                            Price = 59m,
                            SalePrice = 0m,
                            Stock = 543
                        });
                });

            modelBuilder.Entity("Domain.Models.ProductReview", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("ProductReviews");

                    b.HasData(
                        new
                        {
                            ProductId = 5,
                            ReviewUri = "https://www.amazon.com/TP-Link-Deco-Whole-Home-System/dp/B06WVCB862/ref=sr_1_3?keywords=deco+m5&qid=1654024122&sr=8-3"
                        });
                });

            modelBuilder.Entity("Domain.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartId"), 1L, 1);

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Domain.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartItemId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Models.AppUser", b =>
                {
                    b.HasOne("Domain.Models.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Domain.Models.OrderDetail", b =>
                {
                    b.HasOne("Domain.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.HasOne("Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Models.ProductReview", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithOne()
                        .HasForeignKey("Domain.Models.ProductReview", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Domain.Models.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
