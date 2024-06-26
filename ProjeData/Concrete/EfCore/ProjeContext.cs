using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjeData.Concrete.Configuration;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete
{
    public class ProjeContext : IdentityDbContext<ProjeUser, ProjeRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            
                    // MsSqlServer PC
                // .UseSqlServer(@"Server=.\SQLEXPRESS;Database=e-ticaret;Integrated Security=True;");

                    // MsSqlServer HOSTİNG
                // .UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019;database=blog;user=e-ticaret;password=hw45l?44H");

                    // PC
                .UseMySql("server=localhost;port=3306;database=e-ticaret;user=root;password=Ot962962;",
                        new MySqlServerVersion(new Version(10, 3, 36)
                    )
                );

                    // HOSTING
                // .UseMySql("server=localhost;port=3306;database=sablon5soft;user=sablon5soft;password=fVo6t58#7;",
                //         new MySqlServerVersion(new Version(10, 6, 9)
                //     )
                // );
        }

        // ENTİTY/CONCRETE içinde oluşturulan tabloların isimlerini, buraya ekliyoruz.
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Category2> Category2s { get; set; }
        public DbSet<Category3> Category3s { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<HomeDesignType> HomeDesignTypes { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<SizeType> SizeTypes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<FooterAlt> FooterAlts { get; set; }
        public DbSet<Adres> Adreses { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<OrderIade> OrderIades { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<SepetLine> SepetLines { get; set; }
        public DbSet<EftHavale> EftHavales { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<SupportLine> SupportLines { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // JUNCTION tablo düzenlemesi. Çoka Çok Tabloların ID'lerini ProductCategory adında tek bir tabloda birleştireceğimizi belirtiyoruz.
            modelBuilder.Entity<ProductCategory>()
                        .HasKey(c => new {c.CategoryId, c.ProductId});

            modelBuilder.Entity<ProductCategory2>()
                        .HasKey(c2 => new {c2.Category2Id, c2.ProductId});

            modelBuilder.Entity<ProductCategory3>()
                        .HasKey(c3 => new {c3.Category3Id, c3.ProductId});
            
            modelBuilder.Entity<ProductHomeDesignType>()
                        .HasKey(h => new {h.ProductId, h.HomeDesignTypeId});

            modelBuilder.Entity<ProductList>()
                        .HasKey(p => new {p.ProductId, p.ListId});

            modelBuilder.Entity<FavoriteProduct>()
                        .HasKey(f => new {f.FavoriteId, f.ProductId});

            modelBuilder.Entity<GiftCardUser>()
                        .HasKey(gf => new {gf.GiftCardId, gf.ProjeUserId});

            base.OnModelCreating(modelBuilder); // IDentityUserLogin hatasını engeller

            modelBuilder.ApplyConfiguration(new SliderConfiguration());
            modelBuilder.ApplyConfiguration(new BannerConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new SubscribeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Category2Configuration());
            modelBuilder.ApplyConfiguration(new Category3Configuration());
            modelBuilder.ApplyConfiguration(new PopupConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new HomeDesignTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductHomeDesignTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategory2Configuration());
            modelBuilder.ApplyConfiguration(new ProductCategory3Configuration());
            modelBuilder.ApplyConfiguration(new ProductListConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeConfiguration());
            modelBuilder.ApplyConfiguration(new DescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new ListConfiguration());
            modelBuilder.ApplyConfiguration(new VariantConfiguration());
            modelBuilder.ApplyConfiguration(new SizeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new CargoConfiguration());
            modelBuilder.ApplyConfiguration(new GiftCardConfiguration());
            modelBuilder.ApplyConfiguration(new FooterConfiguration());
            modelBuilder.ApplyConfiguration(new FooterAltConfiguration());
        }
    }

}