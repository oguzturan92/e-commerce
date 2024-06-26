using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeData.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserAdi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserSoyadi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserCinsiyet = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserBirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserRegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SeciliAdresId = table.Column<int>(type: "int", nullable: false),
                    SeciliAdresIdFatura = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BankAccountName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankAccountIban = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankAccountSort = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.BankAccountId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CargoName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CargoFreePrice = table.Column<double>(type: "double", nullable: false),
                    CargoPrice = table.Column<double>(type: "double", nullable: false),
                    CargoApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CargoSort = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CategoryVisibility = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategorySort = table.Column<int>(type: "int", nullable: true),
                    CategoryListType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategorySeoTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategorySeoDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategorySeoKeyword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EftHavales",
                columns: table => new
                {
                    EftHavaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EftHavaleOrderNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EftHavaleOrderPrice = table.Column<double>(type: "double", nullable: false),
                    EftHavaleContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EftHavaleBankName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EftHavaleDateTime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EftHavales", x => x.EftHavaleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    FooterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FooterTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FooterApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FooterSort = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.FooterId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GiftCards",
                columns: table => new
                {
                    GiftCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GiftCardTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GiftCardOran = table.Column<int>(type: "int", nullable: false),
                    GiftCardMiktar = table.Column<double>(type: "double", nullable: false),
                    GiftCardApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GiftCardDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GiftCardLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCards", x => x.GiftCardId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HomeDesignTypes",
                columns: table => new
                {
                    HomeDesignTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HomeDesignTypeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomeDesignTypeOption = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomeDesignTypeBannerList = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomeDesignTypeProductList = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomeDesignTypeApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HomeDesignTypeSort = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeDesignTypes", x => x.HomeDesignTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ListTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ListLocation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ListType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ListApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ListColumn = table.Column<int>(type: "int", nullable: true),
                    ListSort = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.ListId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MessageName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MessageSurname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MessagePhone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MessageMail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MessageContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MessageDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderAdres",
                columns: table => new
                {
                    OrderAdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderAdresTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderAdresNameSurname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderAdresTcNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderAdresContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderAdresCounty = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderAdresCity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderAdresPostCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderAdresPhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderAdresFaturaType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAdres", x => x.OrderAdresId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderKdv = table.Column<double>(type: "double", nullable: false),
                    OrderGenelPrice = table.Column<double>(type: "double", nullable: false),
                    OrderTotalPrice = table.Column<double>(type: "double", nullable: false),
                    OrderGiftCard = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderGiftCardContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderNote = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OrderState = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderPaymentId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderConversationId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderPaymentType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CargoPrice = table.Column<double>(type: "double", nullable: false),
                    CargoName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Popup",
                columns: table => new
                {
                    PopupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PopupTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PopupDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PopupImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PopupLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PopupSort = table.Column<int>(type: "int", nullable: true),
                    PopupApproval = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popup", x => x.PopupId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductCode = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductShortName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductColor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductStock = table.Column<int>(type: "int", nullable: false),
                    ProductKdv = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "double", nullable: false),
                    ProductSalePrice = table.Column<double>(type: "double", nullable: false),
                    ProductUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProductSort = table.Column<int>(type: "int", nullable: true),
                    ProductNew = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProductSale = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProductSeoTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductSeoDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductSeoKeyword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SettingFavicon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SettingLogo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SettingKvkk = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SettingSeoTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SettingSeoDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SettingSeoKeyword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SizeTypes",
                columns: table => new
                {
                    SizeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SizeTypeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SizeTypeSort = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeTypes", x => x.SizeTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SliderName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SliderDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SliderLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SliderTime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SliderImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SliderApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SliderSort = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.SliderId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    SubscribeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SubscribeMail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubscribeToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubscribeMailApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SubscribeContactApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SubscribeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.SubscribeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adreses",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdresTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresNameSurname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresTcNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresCounty = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresCity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresPostCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresPhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresFaturaType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adreses", x => x.AdresId);
                    table.ForeignKey(
                        name: "FK_Adreses_AspNetUsers_ProjeUserId",
                        column: x => x.ProjeUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FavoriteTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_ProjeUserId",
                        column: x => x.ProjeUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sepets",
                columns: table => new
                {
                    SepetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjeUserId = table.Column<int>(type: "int", nullable: false),
                    SiparisKdv = table.Column<double>(type: "double", nullable: false),
                    SiparisToplam = table.Column<double>(type: "double", nullable: false),
                    GenelToplam = table.Column<double>(type: "double", nullable: false),
                    CargoPrice = table.Column<double>(type: "double", nullable: false),
                    GiftCardTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GiftCardContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepets", x => x.SepetId);
                    table.ForeignKey(
                        name: "FK_Sepets_AspNetUsers_ProjeUserId",
                        column: x => x.ProjeUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    SupportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupportSubject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupportState = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupportDateTime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.SupportId);
                    table.ForeignKey(
                        name: "FK_Supports_AspNetUsers_ProjeUserId",
                        column: x => x.ProjeUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category2s",
                columns: table => new
                {
                    Category2Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category2Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2Approval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Category2Visibility = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2Sort = table.Column<int>(type: "int", nullable: true),
                    Category2ListType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2SeoTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2SeoDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2SeoKeyword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category2s", x => x.Category2Id);
                    table.ForeignKey(
                        name: "FK_Category2s_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FooterAlts",
                columns: table => new
                {
                    FooterAltId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FooterAltTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FooterAltLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FooterAltApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FooterAltSort = table.Column<int>(type: "int", nullable: true),
                    FooterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterAlts", x => x.FooterAltId);
                    table.ForeignKey(
                        name: "FK_FooterAlts_Footers_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footers",
                        principalColumn: "FooterId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GiftCardUser",
                columns: table => new
                {
                    GiftCardId = table.Column<int>(type: "int", nullable: false),
                    ProjeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCardUser", x => new { x.GiftCardId, x.ProjeUserId });
                    table.ForeignKey(
                        name: "FK_GiftCardUser_AspNetUsers_ProjeUserId",
                        column: x => x.ProjeUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftCardUser_GiftCards_GiftCardId",
                        column: x => x.GiftCardId,
                        principalTable: "GiftCards",
                        principalColumn: "GiftCardId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    BannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BannerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BannerDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BannerLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BannerImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BannerApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BannerSort = table.Column<int>(type: "int", nullable: true),
                    HomeDesignTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.BannerId);
                    table.ForeignKey(
                        name: "FK_Banners_HomeDesignTypes_HomeDesignTypeId",
                        column: x => x.HomeDesignTypeId,
                        principalTable: "HomeDesignTypes",
                        principalColumn: "HomeDesignTypeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderAndAdresJunc",
                columns: table => new
                {
                    OrderAndAdresJuncId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderAdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAndAdresJunc", x => x.OrderAndAdresJuncId);
                    table.ForeignKey(
                        name: "FK_OrderAndAdresJunc_OrderAdres_OrderAdresId",
                        column: x => x.OrderAdresId,
                        principalTable: "OrderAdres",
                        principalColumn: "OrderAdresId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAndAdresJunc_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderIades",
                columns: table => new
                {
                    OrderIadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderIadeNedeni = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderIadeNot = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderIadeOkundu = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrderIadeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OrderIadeApproval = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankIban = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IadeUrunId = table.Column<int>(type: "int", nullable: false),
                    IadeUrunKodu = table.Column<int>(type: "int", nullable: false),
                    IadeUrunAdi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IadeUrunImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IadeUrunUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IadeUrunOzellik = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IadeUrunAdet = table.Column<int>(type: "int", nullable: false),
                    IadeUrunBirimFiyati = table.Column<double>(type: "double", nullable: false),
                    IadeUrunIndirimFiyati = table.Column<double>(type: "double", nullable: false),
                    OrderLineId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderIades", x => x.OrderIadeId);
                    table.ForeignKey(
                        name: "FK_OrderIades_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductSize = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductCode = table.Column<int>(type: "int", nullable: false),
                    IadeEdilebilirAdet = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderLineQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderLineKdv = table.Column<double>(type: "double", nullable: false),
                    OrderLineProductPrice = table.Column<double>(type: "double", nullable: false),
                    OrderLineCampaignPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderLineId);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    DescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescriptionName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionSort = table.Column<int>(type: "int", nullable: true),
                    DescriptionApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_Descriptions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductHomeDesignType",
                columns: table => new
                {
                    HomeDesignTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductHomeDesignType", x => new { x.ProductId, x.HomeDesignTypeId });
                    table.ForeignKey(
                        name: "FK_ProductHomeDesignType_HomeDesignTypes_HomeDesignTypeId",
                        column: x => x.HomeDesignTypeId,
                        principalTable: "HomeDesignTypes",
                        principalColumn: "HomeDesignTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductHomeDesignType_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductImageName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductImageSort = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductList",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductList", x => new { x.ProductId, x.ListId });
                    table.ForeignKey(
                        name: "FK_ProductList_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "ListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductList_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VariantSecond = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SizeTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SizeWriteOrImg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SizeWrite = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SizeImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SizeSort = table.Column<int>(type: "int", nullable: true),
                    SizeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                    table.ForeignKey(
                        name: "FK_Sizes_SizeTypes_SizeTypeId",
                        column: x => x.SizeTypeId,
                        principalTable: "SizeTypes",
                        principalColumn: "SizeTypeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FavoriteProduct",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProduct", x => new { x.FavoriteId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_Favorites_FavoriteId",
                        column: x => x.FavoriteId,
                        principalTable: "Favorites",
                        principalColumn: "FavoriteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SepetLines",
                columns: table => new
                {
                    SepetLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SepetId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductSizeId = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductKdv = table.Column<double>(type: "double", nullable: false),
                    ProductPrice = table.Column<double>(type: "double", nullable: false),
                    ProductCampaignPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepetLines", x => x.SepetLineId);
                    table.ForeignKey(
                        name: "FK_SepetLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SepetLines_Sepets_SepetId",
                        column: x => x.SepetId,
                        principalTable: "Sepets",
                        principalColumn: "SepetId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SupportLines",
                columns: table => new
                {
                    SupportLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupportLineContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupportLineDateTime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupportLineAnswering = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportLines", x => x.SupportLineId);
                    table.ForeignKey(
                        name: "FK_SupportLines_Supports_SupportId",
                        column: x => x.SupportId,
                        principalTable: "Supports",
                        principalColumn: "SupportId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category3s",
                columns: table => new
                {
                    Category3Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category3Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category3Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category3Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category3Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category3Approval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Category3Visibility = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category3Sort = table.Column<int>(type: "int", nullable: true),
                    Category3ListType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category3SeoTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category3SeoDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category3SeoKeyword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category3s", x => x.Category3Id);
                    table.ForeignKey(
                        name: "FK_Category3s_Category2s_Category2Id",
                        column: x => x.Category2Id,
                        principalTable: "Category2s",
                        principalColumn: "Category2Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCategory2",
                columns: table => new
                {
                    Category2Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory2", x => new { x.Category2Id, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategory2_Category2s_Category2Id",
                        column: x => x.Category2Id,
                        principalTable: "Category2s",
                        principalColumn: "Category2Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory2_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductSizePrice = table.Column<double>(type: "double", nullable: false),
                    ProductSizeStock = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.ProductSizeId);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCategory3",
                columns: table => new
                {
                    Category3Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory3", x => new { x.Category3Id, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategory3_Category3s_Category3Id",
                        column: x => x.Category3Id,
                        principalTable: "Category3s",
                        principalColumn: "Category3Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory3_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "BankAccountId", "BankAccountIban", "BankAccountName", "BankAccountSort" },
                values: new object[] { 1, "TR11 2222 3333 4444 66", "X Bankası", 1 });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "CargoId", "CargoApproval", "CargoFreePrice", "CargoName", "CargoPrice", "CargoSort" },
                values: new object[] { 1, true, 3000.0, "X Kargo", 25.0, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryApproval", "CategoryDescription", "CategoryImage", "CategoryListType", "CategoryName", "CategorySeoDescription", "CategorySeoKeyword", "CategorySeoTitle", "CategorySort", "CategoryUrl", "CategoryVisibility" },
                values: new object[,]
                {
                    { 1, true, "", "category-image.jpg", "Urun", "GİYİM", null, null, null, 1, "giyim", "MenuTrue" },
                    { 2, true, "", null, "Urun", "AYAKKABI", null, null, null, 2, "ayakkabi", "MenuTrue" },
                    { 3, true, "", null, "Urun", "AKSESUAR", null, null, null, 3, "aksesuar", "MenuTrue" },
                    { 4, true, "<p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p><p>&nbsp;</p><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p>", null, "Icerik", "KAMPANYALAR", null, null, null, 4, "kampanyalar", "MenuTrue" },
                    { 5, true, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis", null, "Icerik", "HAKKIMIZDA", null, null, null, 5, "hakkimizda", "MenuFalse" },
                    { 6, false, "", null, "Icerik", "FOOTER SAYFALARI", null, null, null, 6, "footer-sayfalari", "Link" }
                });

            migrationBuilder.InsertData(
                table: "Footers",
                columns: new[] { "FooterId", "FooterApproval", "FooterSort", "FooterTitle" },
                values: new object[,]
                {
                    { 1, true, 1, "KURUMSAL" },
                    { 2, true, 2, "YARDIM" },
                    { 3, true, 3, "ALIŞVERİŞ" }
                });

            migrationBuilder.InsertData(
                table: "GiftCards",
                columns: new[] { "GiftCardId", "GiftCardApproval", "GiftCardDateTime", "GiftCardLimit", "GiftCardMiktar", "GiftCardOran", "GiftCardTitle" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 10, 1, 15, 35, 33, 0, DateTimeKind.Unspecified), 100, 0.0, 20, "HDY1" },
                    { 2, false, new DateTime(2023, 10, 23, 15, 35, 33, 0, DateTimeKind.Unspecified), 50, 100.0, 0, "HDY2" }
                });

            migrationBuilder.InsertData(
                table: "HomeDesignTypes",
                columns: new[] { "HomeDesignTypeId", "HomeDesignTypeApproval", "HomeDesignTypeBannerList", "HomeDesignTypeName", "HomeDesignTypeOption", "HomeDesignTypeProductList", "HomeDesignTypeSort" },
                values: new object[,]
                {
                    { 1, true, "Uclu", "Banner 1", "Banner", "", 1 },
                    { 2, true, "Tekli", "Banner 2", "Banner", "", 2 },
                    { 3, true, "", "Haftanın Ürünleri", "List", "Standart", 3 },
                    { 4, true, "", "En Çok Satanlar", "List", "Kaydirmali", 4 }
                });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "ListId", "ListApproval", "ListColumn", "ListLocation", "ListSort", "ListTitle", "ListType", "ProductId" },
                values: new object[,]
                {
                    { 1, true, 4, "Ozel", 1, "Kombin Ürünler", "Standart", 1 },
                    { 2, true, 4, "Genel", 2, "Haftanın Ürünleri", "Kaydirmali", 1 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "MessageContent", "MessageDate", "MessageMail", "MessageName", "MessagePhone", "MessageSurname" },
                values: new object[,]
                {
                    { 1, "Merhaba ben Ahmet YILMAZ. Daha önce de iletişim kurduk. Proje hakkında bilgi almak istiyorum.", new DateTime(2023, 2, 27, 12, 28, 0, 0, DateTimeKind.Unspecified), "ahmetyilmaz@gmail.com", "Ahmet", "0312 123 45 67", "YILMAZ" },
                    { 2, "Merhaba ben Ayşe AYDIN. Göndereceğim mail ile ilgili daha fazla bilgi alabilir miyim.", new DateTime(2023, 3, 1, 9, 7, 0, 0, DateTimeKind.Unspecified), "ayseaydin@gmail.com", "Ayşe", "0312 345 67 89", "AYDIN" }
                });

            migrationBuilder.InsertData(
                table: "Popup",
                columns: new[] { "PopupId", "PopupApproval", "PopupDescription", "PopupImage", "PopupLink", "PopupSort", "PopupTitle" },
                values: new object[] { 1, true, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Vero dolore debitis nulla ullam ratione aperiam!", "popup.jpg", "/iletisim", 1, "Hoşgeldiniz" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductApproval", "ProductCode", "ProductColor", "ProductImage", "ProductKdv", "ProductName", "ProductNew", "ProductPrice", "ProductSale", "ProductSalePrice", "ProductSeoDescription", "ProductSeoKeyword", "ProductSeoTitle", "ProductShortName", "ProductSort", "ProductStock", "ProductUrl" },
                values: new object[,]
                {
                    { 1, true, 0, "Krem", "product-1-1.jpg", 10, "Takım Elbise", false, 7999.0, false, 4999.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Takım elbise Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 1, 10, "takim-elbise" },
                    { 2, true, 0, "", "product-2-1.jpg", 10, "Siyah Tişört.", false, 4999.0, false, 3999.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Siyah Tişört Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 2, 10, "siyah-tisort" },
                    { 3, true, 0, "Standart", "product-4-1.jpg", 10, "Kahverengi Atkı", false, 499.0, false, 349.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Kahverengi atkı. Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 3, 10, "kahverengi-atki" },
                    { 4, false, 0, "", "product-5-1.jpg", 10, "Beyaz Basic Tişört", false, 999.0, false, 899.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Beyaz basic tişört. Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 4, 10, "beyaz-basic-tisort" },
                    { 5, true, 0, "", "product-3-1.jpg", 10, "Bej Renk Kalın Tulum", false, 3999.0, false, 2999.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Bej Renk Kaln Tulum Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 5, 10, "bej-renk-kalin-tulum" },
                    { 6, true, 0, "Standart", "product-6-1.jpg", 10, "Yüzük ve Kolye", false, 299.0, false, 0.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Yüzük ve Kolye Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 6, 10, "yuzuk-ve-kolye" },
                    { 7, true, 0, "", "product-7-1.jpg", 10, "Uzun Palto", false, 12999.0, false, 9999.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Uzun Palto Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 7, 10, "uzun-palto" },
                    { 8, true, 0, "", "product-8-1.jpg", 10, "Figürlü Gömlek", false, 1999.0, false, 999.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Figürlü Gömlek Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 8, 10, "figurlu-gomlek" },
                    { 9, true, 0, "", "product-9-1.jpg", 10, "Kare Desenli Gömlek", false, 2499.0, false, 0.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Kare Desenli Gömlek Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 9, 10, "kare-desenli-gomlek" },
                    { 10, true, 0, "", "product-10-1.jpg", 10, "Koşu Ayakkabısı", false, 14999.0, false, 7499.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Koşu Ayakkabısı Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 10, 10, "kosu-ayakkabisi" },
                    { 11, true, 0, "", "product-11-1.jpg", 10, "Kırmızı Triko", false, 14999.0, false, 7499.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Kırmızı Triko Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 11, 10, "kirmizi-triko" },
                    { 12, true, 0, "", "product-12-1.jpg", 10, "Mevsimlik Bot", false, 7999.0, false, 6999.0, "Seo açıklama", "Seo anahtar kelime", "Seo başlık", "Mevsimlik Bot Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!", 12, 10, "mevsimlik-bot" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "SettingId", "SettingFavicon", "SettingKvkk", "SettingLogo", "SettingSeoDescription", "SettingSeoKeyword", "SettingSeoTitle" },
                values: new object[] { 1, "favicon.ico", "<p>Diğer zamanlarda ne kadar akıllıca. Acı ile, zamanla daha sert sözler kimileri için affedilir ve bilgelere faydalı olmak, suçlayanların olaylarını def eder ve kim zahmetli, daha az acı ile sonuçlanır? Burada sıradan zevkler sağlayarak, yol gösteriyoruz. Gerçek daha fazla seçildiğinde sağladıkları acıları yapmak için doğdular mı? Sırf bu yüzden acı çeken herkes, bilge bir hakla açıklayacağım, bu nedenle büyüklerin büyük seçimini nefret ve açgözlülükle açıklayacağım, ancak sıklıkla söylendiği gibi, egzersizin daha az olduğu yerde onu terk ediyorlar! Gerçekten de şehvet, sanki kendilerininmiş gibi acıyı arzular ve acı, emek ya da zevk anında acı tarafından gevşek tutulur, bu hakkı akıllı olan hiç kimseye açıklamayacağım, bundan daha şiddetli bir şey geri çevrilemez. Bu nedenle, itilmek için onu takip etmeye yönlendiririz, zahmetli olanı zahmetten yararlanan kolay olanla iter. Suçlayıcıların doğumu, olduğu gibi mi? Bir seçenek, ruhun büyük zevkleri arasında bir ayrım, yalnızca ona borçlu olanların başına gelir ve onlar, elde edilemeyecek olan kaçışın ne olduğunu bilmiyorlar mı?</p>", "logo.png", "Site seo açıklama", "Site seo anahtar kelime", "Site seo başlık" });

            migrationBuilder.InsertData(
                table: "SizeTypes",
                columns: new[] { "SizeTypeId", "SizeTypeName", "SizeTypeSort" },
                values: new object[,]
                {
                    { 1, "RENK", 1 },
                    { 2, "BEDEN", 2 },
                    { 3, "NUMARA", 3 }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "SliderId", "SliderApproval", "SliderDescription", "SliderImage", "SliderLink", "SliderName", "SliderSort", "SliderTime" },
                values: new object[,]
                {
                    { 1, true, "Güncel Tişörtler", "750-1.jpg", "/", "Tişört", 1, "2000" },
                    { 2, true, "Moda Montlar", "750-2.jpg", "/", "Mont", 2, "2000" }
                });

            migrationBuilder.InsertData(
                table: "Subscribes",
                columns: new[] { "SubscribeId", "SubscribeContactApproval", "SubscribeDate", "SubscribeMail", "SubscribeMailApproval", "SubscribeToken" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 2, 27, 17, 24, 0, 0, DateTimeKind.Unspecified), "ali_06@gmail.com", true, null },
                    { 2, false, new DateTime(2023, 3, 1, 11, 29, 0, 0, DateTimeKind.Unspecified), "ayse_06@gmail.com", true, null }
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "BannerId", "BannerApproval", "BannerDescription", "BannerImage", "BannerLink", "BannerName", "BannerSort", "HomeDesignTypeId" },
                values: new object[,]
                {
                    { 1, true, "Banner 1 açıklama", "1920-4.jpg", "/", "Banner 1", 1, 1 },
                    { 2, true, "Banner 2 açıklama", "1920-3.jpg", "/", "Banner 2", 2, 1 },
                    { 3, true, "Banner 3 açıklama", "1920-2.jpg", "/", "Banner 3", 3, 1 },
                    { 4, true, "Banner 4 açıklama", "600-2.jpg", "/", "Banner 4", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Category2s",
                columns: new[] { "Category2Id", "Category2Approval", "Category2Description", "Category2Image", "Category2ListType", "Category2Name", "Category2SeoDescription", "Category2SeoKeyword", "Category2SeoTitle", "Category2Sort", "Category2Url", "Category2Visibility", "CategoryId" },
                values: new object[,]
                {
                    { 1, true, "", null, "Urun", "Üst Giyim", null, null, null, 1, "ust-giyim", "MenuTrue", 1 },
                    { 2, true, "", null, "Urun", "Alt Giyim", null, null, null, 2, "alt-giyim", "MenuTrue", 1 },
                    { 3, true, "", null, "Urun", "Dış Giyim", null, null, null, 3, "dis-giyim", "MenuTrue", 1 },
                    { 4, true, "", null, "Urun", "Casual", null, null, null, 1, "casual", "MenuTrue", 2 },
                    { 5, true, "", null, "Urun", "Bot", null, null, null, 2, "bot", "MenuTrue", 2 },
                    { 6, false, "", null, "Urun", "Klasik", null, null, null, 3, "klasik", "MenuTrue", 2 },
                    { 7, true, "<p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p><p>&nbsp;</p><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p><p>&nbsp;</p><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p>", null, "Icerik", "Üyelere Özel Kampanyalar", null, null, null, 1, "uyelere-ozel-kampanyalar", "MenuFalse", 4 },
                    { 8, true, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.", null, "Icerik", "Yüksek Tutar Kampanyaları", null, null, null, 2, "yuksek-tutar-kampanyalari", "MenuFalse", 4 },
                    { 9, true, "Üyelik İle İlgili Bilgi Sayfası", null, "Icerik", "Üyelik", null, null, null, 1, "uyelik", "Link", 6 },
                    { 10, true, "İletişim İle İlgili Bilgi Sayfası", null, "Icerik", "İletişim", null, null, null, 2, "iletisim", "Link", 6 },
                    { 11, true, "Kariyer İle İlgili Bilgi Sayfası", null, "Icerik", "Kariyer", null, null, null, 3, "kariyer", "Link", 6 },
                    { 12, true, "İade Ve Değişim İle İlgili Bilgi Sayfası", null, "Icerik", "İade Ve Değişim", null, null, null, 4, "iade-ve-degisim", "Link", 6 },
                    { 13, true, "SSS İle İlgili Bilgi Sayfası", null, "Icerik", "SSS", null, null, null, 5, "sss", "Link", 6 },
                    { 14, true, "Garanti İle İlgili Bilgi Sayfası", null, "Icerik", "Garanti", null, null, null, 6, "garanti", "Link", 6 },
                    { 15, true, "Sipariş Takibi İle İlgili Bilgi Sayfası", null, "Icerik", "Sipariş Takibi", null, null, null, 7, "siparis-takibi", "Link", 6 },
                    { 16, true, "Kargo Ve Teslimat İle İlgili Bilgi Sayfası", null, "Icerik", "Kargo Ve Teslimat", null, null, null, 8, "kargo-ve-teslimat", "Link", 6 }
                });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "DescriptionId", "DescriptionApproval", "DescriptionContent", "DescriptionName", "DescriptionSort", "ProductId" },
                values: new object[,]
                {
                    { 1, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 1 },
                    { 2, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 1 },
                    { 3, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 1 },
                    { 4, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 2 },
                    { 5, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 2 },
                    { 6, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 2 },
                    { 7, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 3 },
                    { 8, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 3 },
                    { 9, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 3 },
                    { 10, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 4 },
                    { 11, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 4 },
                    { 12, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 4 },
                    { 13, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 5 },
                    { 14, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 5 },
                    { 15, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 5 },
                    { 16, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 6 },
                    { 17, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 6 },
                    { 18, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 6 },
                    { 19, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 7 },
                    { 20, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 7 },
                    { 21, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 7 },
                    { 22, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 8 },
                    { 23, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 8 },
                    { 24, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 8 },
                    { 25, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 9 },
                    { 26, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 9 },
                    { 27, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 9 },
                    { 28, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 10 },
                    { 29, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 10 },
                    { 30, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 10 },
                    { 31, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 11 },
                    { 32, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 11 },
                    { 33, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 11 },
                    { 34, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Açıklama", 1, 12 },
                    { 35, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "İade ve Değişim", 2, 12 },
                    { 36, true, "<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>", "Taksit ve Ödeme", 3, 12 }
                });

            migrationBuilder.InsertData(
                table: "FooterAlts",
                columns: new[] { "FooterAltId", "FooterAltApproval", "FooterAltLink", "FooterAltSort", "FooterAltTitle", "FooterId" },
                values: new object[,]
                {
                    { 1, true, "/Category2/Category2ListClient?url=iletisim", 1, "İletişim", 1 },
                    { 2, true, "/Category2/Category2ListClient?url=kariyer", 2, "Kariyer", 1 },
                    { 3, true, "/Category/CategoryListClient?url=hakkimizda", 3, "Hakkımızda", 1 },
                    { 4, true, "/Category2/Category2ListClient?url=iade-ve-degisim", 1, "İade & Değişim", 2 },
                    { 5, true, "/Category2/Category2ListClient?url=sss", 2, "SSS", 2 },
                    { 6, true, "/Category2/Category2ListClient?url=garanti", 3, "Garanti", 2 },
                    { 7, true, "/Category2/Category2ListClient?url=uyelik", 4, "Üyelik", 2 },
                    { 8, true, "/Category2/Category2ListClient?url=siparis-takibi", 1, "Sipariş Takibi", 3 },
                    { 9, true, "/Category2/Category2ListClient?url=kargo-ve-teslimat", 2, "Kargo & Teslimat", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 2, 8 },
                    { 2, 10 },
                    { 2, 12 },
                    { 3, 6 },
                    { 3, 10 },
                    { 3, 11 }
                });

            migrationBuilder.InsertData(
                table: "ProductHomeDesignType",
                columns: new[] { "HomeDesignTypeId", "ProductId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ProductId", "ProductImageName", "ProductImageSort" },
                values: new object[,]
                {
                    { 1, 1, "product-1-1.jpg", 1 },
                    { 2, 1, "product-1-2.jpg", 2 },
                    { 3, 2, "product-2-1.jpg", 1 },
                    { 4, 2, "product-2-2.jpg", 2 },
                    { 5, 3, "product-4-1.jpg", 1 },
                    { 6, 3, "product-4-2.jpg", 2 },
                    { 7, 4, "product-5-1.jpg", 1 },
                    { 8, 4, "product-5-2.jpg", 2 },
                    { 9, 5, "product-3-1.jpg", 1 },
                    { 10, 5, "product-3-2.jpg", 2 },
                    { 11, 6, "product-6-1.jpg", 1 },
                    { 12, 6, "product-6-2.jpg", 2 },
                    { 13, 7, "product-7-1.jpg", 1 },
                    { 14, 7, "product-7-2.jpg", 2 },
                    { 15, 8, "product-8-1.jpg", 1 },
                    { 16, 8, "product-8-2.jpg", 2 },
                    { 17, 9, "product-9-1.jpg", 1 },
                    { 18, 9, "product-9-2.jpg", 2 },
                    { 19, 10, "product-10-1.jpg", 1 },
                    { 20, 10, "product-10-2.jpg", 2 },
                    { 21, 10, "product-10-3.jpg", 3 },
                    { 22, 10, "product-10-4.jpg", 4 },
                    { 23, 11, "product-11-1.jpg", 1 },
                    { 24, 11, "product-11-2.jpg", 2 },
                    { 25, 11, "product-11-3.jpg", 3 },
                    { 26, 12, "product-12-1.jpg", 1 },
                    { 27, 12, "product-12-2.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductList",
                columns: new[] { "ListId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 1, 5 },
                    { 2, 5 },
                    { 1, 6 },
                    { 1, 8 },
                    { 2, 8 },
                    { 2, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "SizeImage", "SizeSort", "SizeTitle", "SizeTypeId", "SizeWrite", "SizeWriteOrImg" },
                values: new object[,]
                {
                    { 1, "", 1, "S Beden", 2, "S", "Yazi" },
                    { 2, "", 2, "M Beden", 2, "M", "Yazi" },
                    { 3, "", 3, "L Beden", 2, "L", "Yazi" },
                    { 4, "", 4, "XL Beden", 2, "XL", "Yazi" },
                    { 5, "", 5, "XXL Beden", 2, "XXL", "Yazi" },
                    { 6, "beyaz.jpg", 1, "Beyaz", 1, "", "Resim" },
                    { 7, "sari.jpg", 2, "Sarı", 1, "", "Resim" },
                    { 8, "turuncu.jpg", 3, "Turuncu", 1, "", "Resim" },
                    { 9, "mavi.jpg", 4, "Mavi", 1, "", "Resim" },
                    { 10, "siyah.jpg", 5, "Siyah", 1, "", "Resim" },
                    { 11, "", 16, "42 Beden", 1, "42", "Yazi" },
                    { 12, "", 17, "44 Beden", 1, "44", "Yazi" },
                    { 13, "", 18, "46 Beden", 1, "46", "Yazi" },
                    { 14, "", 19, "48 Beden", 1, "48", "Yazi" },
                    { 15, "", 20, "50 Beden", 1, "50", "Yazi" },
                    { 16, "", 21, "52 Beden", 1, "52", "Yazi" },
                    { 17, "", 1, "40 Numara", 3, "40", "Yazi" },
                    { 18, "", 2, "41 Numara", 3, "41", "Yazi" },
                    { 19, "", 3, "42 Numara", 3, "42", "Yazi" },
                    { 20, "", 4, "43 Numara", 3, "43", "Yazi" },
                    { 21, "", 5, "44 Numara", 3, "44", "Yazi" }
                });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "VariantId", "ProductId", "VariantSecond" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 3, 3 },
                    { 3, 3, 5 },
                    { 4, 3, 7 },
                    { 5, 3, 9 },
                    { 6, 10, 5 },
                    { 7, 10, 6 },
                    { 8, 10, 7 },
                    { 9, 10, 12 },
                    { 10, 11, 1 },
                    { 11, 11, 7 },
                    { 12, 11, 8 },
                    { 13, 12, 9 },
                    { 14, 12, 10 },
                    { 15, 9, 7 },
                    { 16, 9, 8 },
                    { 17, 9, 10 },
                    { 18, 9, 11 },
                    { 19, 6, 5 },
                    { 20, 6, 7 },
                    { 21, 6, 8 },
                    { 22, 6, 9 },
                    { 23, 6, 10 },
                    { 24, 8, 1 },
                    { 25, 8, 2 },
                    { 26, 8, 5 },
                    { 27, 8, 6 },
                    { 28, 8, 7 },
                    { 29, 8, 9 },
                    { 30, 8, 10 },
                    { 31, 7, 2 },
                    { 32, 7, 5 },
                    { 33, 7, 6 },
                    { 34, 7, 9 },
                    { 35, 7, 10 },
                    { 36, 7, 12 },
                    { 37, 1, 2 },
                    { 38, 1, 3 },
                    { 39, 1, 5 },
                    { 40, 1, 7 },
                    { 41, 1, 9 },
                    { 42, 2, 2 },
                    { 43, 2, 6 },
                    { 44, 2, 8 },
                    { 45, 2, 10 },
                    { 46, 5, 1 },
                    { 47, 5, 2 },
                    { 48, 5, 3 },
                    { 49, 5, 5 },
                    { 50, 5, 6 },
                    { 51, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Category3s",
                columns: new[] { "Category3Id", "Category2Id", "Category3Approval", "Category3Description", "Category3Image", "Category3ListType", "Category3Name", "Category3SeoDescription", "Category3SeoKeyword", "Category3SeoTitle", "Category3Sort", "Category3Url", "Category3Visibility" },
                values: new object[,]
                {
                    { 1, 1, true, "", null, "Urun", "Gömlek", null, null, null, 1, "gomlek", "MenuTrue" },
                    { 2, 1, true, "", null, "Urun", "Tişört", null, null, null, 2, "tisort", "MenuTrue" },
                    { 3, 2, true, "", null, "Urun", "Pantolon", null, null, null, 1, "pantolon", "MenuTrue" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory2",
                columns: new[] { "Category2Id", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 5 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 11 },
                    { 2, 7 },
                    { 3, 7 },
                    { 4, 10 },
                    { 5, 12 },
                    { 6, 8 },
                    { 6, 12 }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "ProductSizeId", "ProductId", "ProductSizePrice", "ProductSizeStock", "SizeId" },
                values: new object[,]
                {
                    { 1, 1, 250.0, 10, 1 },
                    { 2, 1, 250.0, 10, 2 },
                    { 3, 1, 250.0, 10, 3 },
                    { 4, 2, 0.0, 10, 1 },
                    { 5, 2, 0.0, 0, 2 },
                    { 6, 2, 0.0, 0, 3 },
                    { 7, 4, 0.0, 0, 1 },
                    { 8, 4, 0.0, 0, 2 },
                    { 9, 4, 0.0, 0, 3 },
                    { 10, 4, 0.0, 0, 4 },
                    { 11, 4, 0.0, 0, 5 },
                    { 12, 5, 0.0, 0, 1 },
                    { 13, 5, 0.0, 10, 2 },
                    { 14, 5, 0.0, 0, 3 },
                    { 15, 5, 0.0, 10, 4 },
                    { 16, 7, 6999.0, 10, 4 },
                    { 17, 7, 5999.0, 10, 5 },
                    { 18, 8, 0.0, 10, 1 },
                    { 19, 8, 0.0, 10, 2 },
                    { 20, 8, 0.0, 10, 3 },
                    { 21, 8, 0.0, 0, 4 },
                    { 22, 8, 0.0, 0, 5 },
                    { 23, 9, 0.0, 10, 1 },
                    { 24, 9, 0.0, 10, 2 },
                    { 25, 9, 0.0, 10, 3 },
                    { 26, 9, 0.0, 10, 4 },
                    { 27, 9, 0.0, 10, 5 },
                    { 28, 10, 0.0, 10, 17 },
                    { 29, 10, 0.0, 10, 18 },
                    { 30, 10, 0.0, 10, 19 },
                    { 31, 10, 0.0, 10, 20 },
                    { 32, 10, 0.0, 10, 21 },
                    { 33, 11, 0.0, 10, 1 },
                    { 34, 11, 0.0, 10, 2 },
                    { 35, 11, 0.0, 10, 3 },
                    { 36, 11, 4999.0, 10, 4 },
                    { 37, 11, 4999.0, 10, 5 },
                    { 38, 12, 0.0, 10, 17 },
                    { 39, 12, 0.0, 10, 18 },
                    { 40, 12, 0.0, 10, 19 },
                    { 41, 12, 0.0, 10, 20 },
                    { 42, 12, 0.0, 10, 21 },
                    { 43, 3, 0.0, 10, 7 },
                    { 44, 3, 0.0, 10, 9 },
                    { 45, 3, 0.0, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory3",
                columns: new[] { "Category3Id", "ProductId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 11 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 7 },
                    { 3, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adreses_ProjeUserId",
                table: "Adreses",
                column: "ProjeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banners_HomeDesignTypeId",
                table: "Banners",
                column: "HomeDesignTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category2s_CategoryId",
                table: "Category2s",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category3s_Category2Id",
                table: "Category3s",
                column: "Category2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_ProductId",
                table: "Descriptions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_ProductId",
                table: "FavoriteProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProjeUserId",
                table: "Favorites",
                column: "ProjeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FooterAlts_FooterId",
                table: "FooterAlts",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCardUser_ProjeUserId",
                table: "GiftCardUser",
                column: "ProjeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAndAdresJunc_OrderAdresId",
                table: "OrderAndAdresJunc",
                column: "OrderAdresId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAndAdresJunc_OrderId",
                table: "OrderAndAdresJunc",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIades_OrderId",
                table: "OrderIades",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory2_ProductId",
                table: "ProductCategory2",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory3_ProductId",
                table: "ProductCategory3",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHomeDesignType_HomeDesignTypeId",
                table: "ProductHomeDesignType",
                column: "HomeDesignTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_ListId",
                table: "ProductList",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizeId",
                table: "ProductSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SepetLines_ProductId",
                table: "SepetLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SepetLines_SepetId",
                table: "SepetLines",
                column: "SepetId");

            migrationBuilder.CreateIndex(
                name: "IX_Sepets_ProjeUserId",
                table: "Sepets",
                column: "ProjeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeTypeId",
                table: "Sizes",
                column: "SizeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportLines_SupportId",
                table: "SupportLines",
                column: "SupportId");

            migrationBuilder.CreateIndex(
                name: "IX_Supports_ProjeUserId",
                table: "Supports",
                column: "ProjeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adreses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "EftHavales");

            migrationBuilder.DropTable(
                name: "FavoriteProduct");

            migrationBuilder.DropTable(
                name: "FooterAlts");

            migrationBuilder.DropTable(
                name: "GiftCardUser");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OrderAndAdresJunc");

            migrationBuilder.DropTable(
                name: "OrderIades");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Popup");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductCategory2");

            migrationBuilder.DropTable(
                name: "ProductCategory3");

            migrationBuilder.DropTable(
                name: "ProductHomeDesignType");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductList");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "SepetLines");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "SupportLines");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "GiftCards");

            migrationBuilder.DropTable(
                name: "OrderAdres");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Category3s");

            migrationBuilder.DropTable(
                name: "HomeDesignTypes");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Sepets");

            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category2s");

            migrationBuilder.DropTable(
                name: "SizeTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
