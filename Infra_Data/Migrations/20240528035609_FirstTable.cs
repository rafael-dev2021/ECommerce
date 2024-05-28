using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra_Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstTable : Migration
    {

        private const string AspNetRoles = "AspNetRoles";
        private const string AspNetUsers = "AspNetUsers";
        private const string NVarChar450 = "varchar(450)";
        private const string NVarChar256 = "nvarchar(256)";
        private const string NVarCharMax = "nvarchar(max)";
        private const string NVarChar50 = "nvarchar(50)";
        private const string NVarChar15 = "nvarchar(15)";
        private const string NVarChar20 = "nvarchar(20)";
        private const string NVarChar30 = "nvarchar(30)";
        private const string NVarChar10 = "nvarchar(10)";
        private const string Datetime2 = "datetime2";
        private const string SqlServerIdentity = "SqlServer:Identity";
        private const string Categories = "Categories";
        private const string Products = "Products";
        private const string Orders = "Orders";
        private const string Reviews = "Reviews";
        private const string ShoppingCartItems = "ShoppingCartItems";
        private const string OrdersDetails = "OrdersDetails";
        private const string CommonPropertiesObjectValue_Gender = "CommonPropertiesObjectValue_Gender";
        private const string CommonPropertiesObjectValue_Age = "CommonPropertiesObjectValue_Age";
        private const string CommonPropertiesObjectValue_Color = "CommonPropertiesObjectValue_Color";
        private const string CommonPropertiesObjectValue_RecommendedUses = "CommonPropertiesObjectValue_RecommendedUses";
        private const string CommonPropertiesObjectValue_Size = "CommonPropertiesObjectValue_Size";
        private const string DataObjectValue_ReleaseMonth = "DataObjectValue_ReleaseMonth";
        private const string DataObjectValue_ReleaseYear = "DataObjectValue_ReleaseYear";
        private const string PriceObjectValue_HistoryPrice = "PriceObjectValue_HistoryPrice";
        private const string PriceObjectValue_Price = "PriceObjectValue_Price";
        private const string SpecificationObjectValue_Brand = "SpecificationObjectValue_Brand";
        private const string SpecificationObjectValue_Line = "SpecificationObjectValue_Line";
        private const string SpecificationObjectValue_Model = "SpecificationObjectValue_Model";
        private const string SpecificationObjectValue_Type = "SpecificationObjectValue_Type";
        private const string SpecificationObjectValue_Weight = "SpecificationObjectValue_Weight";
        private const string WarrantyObjectValue_WarrantyInformation = "WarrantyObjectValue_WarrantyInformation";
        private const string WarrantyObjectValue_WarrantyLength = "WarrantyObjectValue_WarrantyLength";
        private const string Payment = "Payment";
        private const string Decimal18By2 = "decimal(18,2)";
        private const string Float = "float";
        private const string CategoryId = "CategoryId";
        private const string Description = "Description";
        private const string Discriminator = "Discriminator";
        private const string ImagesUrl = "ImagesUrl";
        private const string Stock = "Stock";
        private const string FlagsObjectValue_IsBestSeller = "FlagsObjectValue_IsBestSeller";
        private const string FlagsObjectValue_IsDailyOffer = "FlagsObjectValue_IsDailyOffer";
        private const string FlagsObjectValue_IsFavorite = "FlagsObjectValue_IsFavorite";
        private const string Smartphone = "Smartphone";
        private const string LimitedWarranty = "30-Day Limited Warranty";
        private const string YearWarranty = "1-year warranty";
        private const string SelfieCameraSpec = "12 Mpx";
        private const string DisplayProtection = "Corning Gorilla Glass Victus 2";
        private const string CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G";
        private const string Gender = "Adult";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: AspNetRoles,
                columns: table => new
                {
                    Id = table.Column<string>(type: NVarChar450, nullable: false),
                    Name = table.Column<string>(type: NVarChar256, maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: NVarChar256, maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: NVarCharMax, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: AspNetUsers,
                columns: table => new
                {
                    Id = table.Column<string>(type: NVarChar450, nullable: false),
                    FirstName = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: Datetime2, nullable: false),
                    IsSubscribedToNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: NVarChar256, maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: NVarChar256, maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(type: NVarChar256, maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: NVarCharMax, nullable: true),
                    SecurityStamp = table.Column<string>(type: NVarCharMax, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: NVarCharMax, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: false),
                    CardHolderName = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: false),
                    CardExpirationDate = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CardCvv = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Ssn = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: Categories,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Name = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: Payment,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Ssn = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: false),
                    Amount = table.Column<decimal>(type: Decimal18By2, precision: 18, scale: 2, nullable: false),
                    PaymentMethodObjectValue_PaymentMethod = table.Column<string>(type: NVarCharMax, nullable: false),
                    PaymentMethodObjectValue_PaymentStatusObjectValue_PaymentStatus = table.Column<string>(type: NVarCharMax, nullable: false),
                    PaymentMethodObjectValue_Reference = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodObjectValue_PaymentDate = table.Column<DateTime>(type: Datetime2, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    RoleId = table.Column<string>(type: NVarChar450, nullable: false),
                    ClaimType = table.Column<string>(type: NVarCharMax, nullable: true),
                    ClaimValue = table.Column<string>(type: NVarCharMax, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: AspNetRoles,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    UserId = table.Column<string>(type: NVarChar450, nullable: false),
                    ClaimType = table.Column<string>(type: NVarCharMax, nullable: true),
                    ClaimValue = table.Column<string>(type: NVarCharMax, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: AspNetUsers,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: NVarChar450, nullable: false),
                    ProviderKey = table.Column<string>(type: NVarChar450, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: NVarCharMax, nullable: true),
                    UserId = table.Column<string>(type: NVarChar450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: AspNetUsers,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: NVarChar450, nullable: false),
                    RoleId = table.Column<string>(type: NVarChar450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: AspNetRoles,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: AspNetUsers,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: NVarChar450, nullable: false),
                    LoginProvider = table.Column<string>(type: NVarChar450, nullable: false),
                    Name = table.Column<string>(type: NVarChar450, nullable: false),
                    Value = table.Column<string>(type: NVarCharMax, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: AspNetUsers,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: Products,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: NVarCharMax, maxLength: 10000, nullable: false),
                    ImagesUrl = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DataObjectValue_ReleaseMonth = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DataObjectValue_ReleaseYear = table.Column<int>(type: "int", maxLength: 4, nullable: true),
                    PriceObjectValue_Price = table.Column<decimal>(type: Decimal18By2, precision: 18, scale: 2, nullable: true),
                    PriceObjectValue_HistoryPrice = table.Column<decimal>(type: Decimal18By2, precision: 18, scale: 2, nullable: true),
                    SpecificationObjectValue_Model = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: true),
                    SpecificationObjectValue_Brand = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    SpecificationObjectValue_Line = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    SpecificationObjectValue_Weight = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    SpecificationObjectValue_Type = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    WarrantyObjectValue_WarrantyLength = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: true),
                    WarrantyObjectValue_WarrantyInformation = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: true),
                    CommonPropertiesObjectValue_Gender = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    CommonPropertiesObjectValue_Color = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    CommonPropertiesObjectValue_Age = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    CommonPropertiesObjectValue_RecommendedUses = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    CommonPropertiesObjectValue_Size = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    MaterialObjectValue_MaterialsFromAbroad = table.Column<string>(type: NVarChar10, maxLength: 10, nullable: true),
                    MaterialObjectValue_InteriorMaterials = table.Column<string>(type: NVarChar10, maxLength: 10, nullable: true),
                    MaterialObjectValue_SoleMaterials = table.Column<string>(type: NVarChar10, maxLength: 10, nullable: true),
                    FlagsObjectValue_IsFavorite = table.Column<bool>(type: "bit", nullable: true),
                    FlagsObjectValue_IsDailyOffer = table.Column<bool>(type: "bit", nullable: true),
                    FlagsObjectValue_IsBestSeller = table.Column<bool>(type: "bit", nullable: true),
                    MainFeaturesObjectValue_TypeOfClothing = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    MainFeaturesObjectValue_FabricDesign = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    OtherFeaturesObjectValue_Composition = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    OtherFeaturesObjectValue_MainMaterial = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    OtherFeaturesObjectValue_UnitsPerKit = table.Column<int>(type: "int", nullable: true),
                    OtherFeaturesObjectValue_WithRecycledMaterials = table.Column<bool>(type: "bit", nullable: true),
                    OtherFeaturesObjectValue_ItsSporty = table.Column<bool>(type: "bit", nullable: true),
                    GeneralFeaturesObjectValue_Collection = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    GeneralFeaturesObjectValue_Saga = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    GeneralFeaturesObjectValue_Title = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: true),
                    GeneralFeaturesObjectValue_Edition = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    GeneralFeaturesObjectValue_Platform = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    GeneralFeaturesObjectValue_Developers = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    GeneralFeaturesObjectValue_Publishers = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    GeneralFeaturesObjectValue_GameRating = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    MediaSpecificationObjectValue_Format = table.Column<string>(type: NVarChar20, maxLength: 20, nullable: true),
                    MediaSpecificationObjectValue_AudioLanguages = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: true),
                    MediaSpecificationObjectValue_SubtitleLanguages = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: true),
                    MediaSpecificationObjectValue_ScreenLanguages = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: true),
                    MediaSpecificationObjectValue_MaximumNumberOfOfflinePlayers = table.Column<int>(type: "int", nullable: true),
                    MediaSpecificationObjectValue_MaximumNumberOfOnlinePlayers = table.Column<int>(type: "int", nullable: true),
                    MediaSpecificationObjectValue_FileSize = table.Column<int>(type: "int", nullable: true),
                    MediaSpecificationObjectValue_IsMultiplayer = table.Column<bool>(type: "bit", nullable: true),
                    MediaSpecificationObjectValue_IsOnline = table.Column<bool>(type: "bit", nullable: true),
                    MediaSpecificationObjectValue_IsOffline = table.Column<bool>(type: "bit", nullable: true),
                    RequirementObjectValue_MinimumRamRequirementInMb = table.Column<int>(type: "int", nullable: true),
                    RequirementObjectValue_MinimumOperatingSystemsRequired = table.Column<string>(type: NVarChar10, maxLength: 10, nullable: true),
                    RequirementObjectValue_MinimumGraphicsProcessorsRequired = table.Column<string>(type: NVarChar10, maxLength: 10, nullable: true),
                    RequirementObjectValue_MinimumProcessorsRequired = table.Column<string>(type: NVarChar10, maxLength: 10, nullable: true),
                    BatteryObjectValue_BatteryType = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    BatteryObjectValue_BatteryCapacityMAh = table.Column<int>(type: "int", nullable: true),
                    BatteryObjectValue_IsBatteryRemovable = table.Column<bool>(type: "bit", nullable: true),
                    CameraObjectValue_MainCameraSpec = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    CameraObjectValue_MainCameraFeature = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: true),
                    CameraObjectValue_SelfieCameraSpec = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    CameraObjectValue_SelfieCameraFeature = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DimensionObjectValue_HeightInches = table.Column<double>(type: Float, nullable: true),
                    DimensionObjectValue_WidthInches = table.Column<double>(type: Float, nullable: true),
                    DimensionObjectValue_ThicknessInches = table.Column<double>(type: Float, nullable: true),
                    DisplayObjectValue_DisplayType = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: true),
                    DisplayObjectValue_DisplayResolution = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DisplayObjectValue_DisplayProtection = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DisplayObjectValue_DisplaySizeInches = table.Column<double>(type: Float, nullable: true),
                    FeatureObjectValue_CellNetworkTechnology = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: true),
                    FeatureObjectValue_VirtualAssistant = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: true),
                    FeatureObjectValue_ManufacturerPartNumber = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: true),
                    PlatformObjectValue_OperatingSystem = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: true),
                    PlatformObjectValue_Chipset = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: true),
                    PlatformObjectValue_Gpu = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: true),
                    PlatformObjectValue_Cpu = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: true),
                    StorageObjectValue_StorageGb = table.Column<int>(type: "int", nullable: true),
                    StorageObjectValue_RamGb = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: Categories,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: Orders,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    TotalOrder = table.Column<decimal>(type: Decimal18By2, precision: 18, scale: 2, nullable: false),
                    TotalItemsOrder = table.Column<int>(type: "int", nullable: false),
                    ConfirmedOrder = table.Column<DateTime>(type: Datetime2, nullable: false),
                    DispatchedOrder = table.Column<DateTime>(type: Datetime2, nullable: false),
                    RequestReceived = table.Column<DateTime>(type: Datetime2, nullable: false),
                    DeliveryAddress_Country = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: false),
                    DeliveryAddress_Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DeliveryAddress_Complement = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DeliveryAddress_ZipCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DeliveryAddress_State = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: false),
                    DeliveryAddress_City = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: false),
                    DeliveryAddress_Neighborhood = table.Column<string>(type: NVarChar30, maxLength: 30, nullable: false),
                    UserDelivery_FirstName = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: false),
                    UserDelivery_LastName = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: false),
                    UserDelivery_Email = table.Column<string>(type: NVarChar50, maxLength: 50, nullable: false),
                    UserDelivery_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    UserDelivery_Ssn = table.Column<string>(type: NVarChar15, maxLength: 15, nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Payment_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: Payment,
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: Reviews,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: Datetime2, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: Products,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: ShoppingCartItems,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<string>(type: NVarCharMax, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: Categories,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: Products,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: OrdersDetails,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: Decimal18By2, precision: 18, scale: 2, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: Orders,
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersDetails_Payment_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: Payment,
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: Categories,
                columns: ["Id", "ImageUrl", "IsActive", "Name"],
                values: new object[,]
                {
                    { 1, "https://i5.walmartimages.com/seo/Straight-Talk-Apple-iPhone-12-64GB-Black-Prepaid-Smartphone-Locked-to-Straight-Talk_66b2853b-6cb5-4f20-b73a-b60b39b6de44.6b3bf83a920058a47342318925f1dc2b.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", true, Smartphone },
                    { 2, "https://i5.walmartimages.com/seo/Reebok-Women-s-Flight-Jogger-with-Cargo-Pockets_eefde8e0-c787-48fc-962e-2d2d406391a1.70bc369116e0b1954b5eee14c1a67ea7.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", true, "Fashion" },
                    { 3, "https://i5.walmartimages.com/seo/Xbox-Series-X-Video-Game-Console-Black_9f8c06f5-7953-426d-9b68-ab914839cef4.5f15be430800ce4d7c3bb5694d4ab798.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", true, "Games" },
                    { 4, "https://i5.walmartimages.com/seo/Carote-Nonstick-Pots-and-Pans-Set-10-Pcs-Granite-Stone-Kitchen-Cookware-Sets-White_efe69ee7-6273-4cbe-a436-149b7b1d0d0c.a2320ff6519d540c3df326c48fdef207.png?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF", true, "Kitchen" },
                    { 5, "https://i5.walmartimages.com/seo/Friendship-Bracelet-Making-Kit-Girls-DIY-Craft-Kits-Toys-Cool-Arts-Crafts-Teen-Travel-Activity-Set-Gifts-Age-6-7-8-9-10-11-12-Year-Old_1c074238-f765-4bc9-bcd4-6aec3c63e831.61da6ea6dec87564dbe3452ae6d55039.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", true, "Kids" },
                    { 6, "https://i5.walmartimages.com/seo/Acer-Nitro-31-5-1500R-Curved-Full-HD-1920-x-1080-Gaming-Monitor-Black-ED320QR-S3biipx_026e53ed-7591-4f39-afb1-d5575a7fc06a.fae36db73738179d935b7d5e64a5be51.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", true, "Electronic" },
                    { 7, "https://i5.walmartimages.com/seo/Intex-Corner-Sofa_b6271dd9-4704-436a-aa35-36293fa7482c_1.887862bad366185f36f3793d387c450e.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", true, "Furniture" }
                });

            migrationBuilder.InsertData(
                table: Products,
                columns: ["Id", CommonPropertiesObjectValue_Age, CommonPropertiesObjectValue_Color, CommonPropertiesObjectValue_Gender, CommonPropertiesObjectValue_RecommendedUses, CommonPropertiesObjectValue_Size, DataObjectValue_ReleaseMonth, DataObjectValue_ReleaseYear, PriceObjectValue_HistoryPrice, PriceObjectValue_Price, SpecificationObjectValue_Brand, SpecificationObjectValue_Line, SpecificationObjectValue_Model, SpecificationObjectValue_Type, SpecificationObjectValue_Weight, WarrantyObjectValue_WarrantyInformation, WarrantyObjectValue_WarrantyLength, "BatteryObjectValue_BatteryCapacityMAh", "BatteryObjectValue_BatteryType", "BatteryObjectValue_IsBatteryRemovable", "CameraObjectValue_MainCameraFeature", "CameraObjectValue_MainCameraSpec", "CameraObjectValue_SelfieCameraFeature", "CameraObjectValue_SelfieCameraSpec", "DimensionObjectValue_HeightInches", "DimensionObjectValue_ThicknessInches", "DimensionObjectValue_WidthInches", "DisplayObjectValue_DisplayProtection", "DisplayObjectValue_DisplayResolution", "DisplayObjectValue_DisplaySizeInches", "DisplayObjectValue_DisplayType", "FeatureObjectValue_CellNetworkTechnology", "FeatureObjectValue_ManufacturerPartNumber", "FeatureObjectValue_VirtualAssistant", "PlatformObjectValue_Chipset", "PlatformObjectValue_Cpu", "PlatformObjectValue_Gpu", "PlatformObjectValue_OperatingSystem", "StorageObjectValue_RamGb", "StorageObjectValue_StorageGb", CategoryId, Description, Discriminator, ImagesUrl, "Name", Stock, FlagsObjectValue_IsBestSeller, FlagsObjectValue_IsDailyOffer, FlagsObjectValue_IsFavorite],
                values: new object[,]
                {
                    { 1, "", "Phantom Black", "", "", "", "June", 2023, 2299.99m, 2179.99m, "Samsung", "Galaxy S", "S23 Ultra", Smartphone, "233 g", LimitedWarranty, YearWarranty, 5000, "Li-Ion", false, "(Quad) 200 MP + 10 MP + 10 MP + 12 MP", "200 Mpx", "LED flash, auto-HDR, panorama", SelfieCameraSpec, 163.40000000000001, 8.9000000000000004, 78.099999999999994, DisplayProtection, "1440 px x 3088 px", 6.7999999999999998, "Dynamic AMOLED 2X 120 Hz", CellNetworkTechnology, "SM-S918UZKFXAA", "Samsung Bixby,Alexa,Google Assistant", "Qualcomm SM8550-AC Snapdragon 8 Gen 2", "Octa-core", "Adreno 740", "Android", 12, 512, 1, "Maximum security so that only you can access your team. You can choose between the fingerprint sensor to activate your phone with a tap, or facial recognition that allows you to unlock up to 30% faster.", "Smartphone", "[\"https://http2.mlstatic.com/D_NQ_NP_856672-MLU70401529412_072023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_945544-MLU70401529414_072023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_808604-MLU70400221716_072023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_827555-MLU70400783806_072023-O.webp\"]", "Samsung Galaxy S23 Ultra 512GB Unlocked - Black", 20, false, true, true },
                    { 2, "", "Violet", "", "", "", "August", 2022, 2199.99m, 1624.99m, "Samsung", "Galaxy S", "S23 Ultra",Smartphone, "235 g", LimitedWarranty,YearWarranty, 5000, "Lithium Ion", false, "200 Mpx/12 Mpx/10 Mpx/10 Mpx", "200 Mpx", "LED flash, auto-HDR, panorama", SelfieCameraSpec, 163.40000000000001, 8.9000000000000004, 78.099999999999994, DisplayProtection, "1440 px x 3088 px", 6.7999999999999998, "Dynamic AMOLED 2X",CellNetworkTechnology, "SM-B518UZKFX22", "Samsung Bixby,Alexa,Google Assistant", "Qualcomm SM8550-AC Snapdragon 8 Gen 2", "Octa-Core of up to 3.36GHz", "Adreno 740", "Android", 8, 258, 1, "Maximum security so that only you can access your team. You can choose between the fingerprint sensor to activate your phone with a tap, or facial recognition that allows you to unlock up to 30% faster.", "Smartphone", "[\"https://http2.mlstatic.com/D_NQ_NP_683947-MLU73106437489_112023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_690989-MLU72932986551_112023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_612226-MLU72932986555_112023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_683459-MLU72932986549_112023-O.webp\"]", "Samsung Galaxy S23 Ultra 256GB - Violet", 25, false, true, true },
                    { 3, "", "Titanium Blue", "", "", "", "Februery", 2023, 2199.99m, 2035.99m, "Apple", "iPhone", "iPhone 15 Pro", Smartphone, "235 g", LimitedWarranty, YearWarranty, 5000, "Lithium Ion", false, "48 Mpx/12 Mpx/12 Mpx", "48 Mpx", "Photonic engine, Deep fusion, Smart HDR 4, Portrait mode, Portrait lighting with six effects,", SelfieCameraSpec, 160.90000000000001, 7.7999999999999998, 77.799999999999997, DisplayProtection, "2556 px x 1179 px", 6.0999999999999996, "Super Retina XDR", CellNetworkTechnology, "AA-12SF7832SD301EW3", "Apple Watch,HomePod,Siri Assistant", "Apple A17 Pro", "Chip A16 Bionic", "5 cores", "iOS", 8, 512, 1, "FORGED FROM TITANIUM — iPhone 15 Pro features a rugged, lightweight design made from aerospace-grade titanium. On the back, textured matte glass and, on the front, Ceramic Shield, more resistant than any smartphone glass. It's also tough against splashes, water, and dust.", Smartphone, "[\"https://http2.mlstatic.com/D_NQ_NP_918178-MLA71783088444_092023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_918178-MLA71783088444_092023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_829742-MLA71783365702_092023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_715495-MLA71783365704_092023-O.webps\"]", "Apple iPhone 15 Pro (512 GB) - Titanium Blue", 15, false, true, false },
                    { 4, "", "Titanium White", "", "", "", "March", 2023, 1799.99m, 1624.99m, "Apple", "iPhone", "iPhone 15 Pro", Smartphone, "235 g", LimitedWarranty, YearWarranty, 5000, "Lithium Ion", false, "48 Mpx/12 Mpx/12 Mpx", "48 Mpx", "Photonic engine, Deep fusion, Smart HDR 4, Portrait mode, Portrait lighting with six effects,", SelfieCameraSpec, 160.90000000000001, 7.7999999999999998, 77.799999999999997, DisplayProtection, "2556 px x 1179 px", 6.0999999999999996, "Super Retina XDR",CellNetworkTechnology, "AA-12VD783HR230SW19", "Apple Watch,HomePod,Siri Assistant", "Apple A17 Pro", "Chip A16 Bionic", "5 cores", "iOS", 8, 128, 1, "FORGED FROM TITANIUM — iPhone 15 Pro features a rugged, lightweight design made from aerospace-grade titanium. On the back, textured matte glass and, on the front, Ceramic Shield, more resistant than any smartphone glass. It's also tough against splashes, water, and dust.", Smartphone, "[\"https://http2.mlstatic.com/D_NQ_NP_812116-MLA71783168214_092023E-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_812116-MLA71783168214_092023E-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_658271-MLA71782871766_092023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_998898-MLA71782901894_092023-O.webp\"]", "Apple iPhone 15 Pro (128 GB) - Titanium White", 10, false, true, true }
                });

            migrationBuilder.InsertData(
                table: Products,
                columns: ["Id", CommonPropertiesObjectValue_Age, CommonPropertiesObjectValue_Color, CommonPropertiesObjectValue_Gender, CommonPropertiesObjectValue_RecommendedUses, CommonPropertiesObjectValue_Size, DataObjectValue_ReleaseMonth, DataObjectValue_ReleaseYear, PriceObjectValue_HistoryPrice, PriceObjectValue_Price, SpecificationObjectValue_Brand, SpecificationObjectValue_Line, SpecificationObjectValue_Model, SpecificationObjectValue_Type, SpecificationObjectValue_Weight, WarrantyObjectValue_WarrantyInformation, WarrantyObjectValue_WarrantyLength, CategoryId, Description, Discriminator, ImagesUrl, "Name", Stock, FlagsObjectValue_IsBestSeller, FlagsObjectValue_IsDailyOffer, FlagsObjectValue_IsFavorite, "GeneralFeaturesObjectValue_Collection", "GeneralFeaturesObjectValue_Developers", "GeneralFeaturesObjectValue_Edition", "GeneralFeaturesObjectValue_GameRating", "GeneralFeaturesObjectValue_Platform", "GeneralFeaturesObjectValue_Publishers", "GeneralFeaturesObjectValue_Saga", "GeneralFeaturesObjectValue_Title", "MediaSpecificationObjectValue_AudioLanguages", "MediaSpecificationObjectValue_FileSize", "MediaSpecificationObjectValue_Format", "MediaSpecificationObjectValue_IsMultiplayer", "MediaSpecificationObjectValue_IsOffline", "MediaSpecificationObjectValue_IsOnline", "MediaSpecificationObjectValue_MaximumNumberOfOfflinePlayers", "MediaSpecificationObjectValue_MaximumNumberOfOnlinePlayers", "MediaSpecificationObjectValue_ScreenLanguages", "MediaSpecificationObjectValue_SubtitleLanguages", "RequirementObjectValue_MinimumGraphicsProcessorsRequired", "RequirementObjectValue_MinimumOperatingSystemsRequired", "RequirementObjectValue_MinimumProcessorsRequired", "RequirementObjectValue_MinimumRamRequirementInMb"],
                values: new object[,]
                {
                    { 5, "", "", "", "", "", "June", 2023, 0.0m, 30.99m, "Sony", "PS5", "Sony", "Video game", "100 g", LimitedWarranty, YearWarranty, 3, "With this Spider-Man game you will enjoy hours of fun and new challenges that will allow you to improve as a player.", "Game", "[\"https://http2.mlstatic.com/D_NQ_NP_739971-MLA44963396567_022021-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_717296-MLA44963321732_022021-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_902181-MLA44963396568_022021-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_952087-MLU69953465194_062023-O.webp\"]", "Marvel's Spider-Man: Miles Morales Standard Edition Sony PS5", 10, true, false, true, "Spider man", "Insomniac Games", "Standard Edition", "T", "PS5", "Sony", "30-Day Limited Warranty", "Marvel's Spider-Man: Miles Morales", "English", 60, "Physical", false, true, false, 1, 1, "English, Portuguese", "English, Portuguese", "V", "PS5", "Ps5", 60 },
                    { 6, "", "", "", "", "", "July", 2022, 0.0m, 38.99m, "Sony", "PS5", "Sony", "Video game", "100 g", LimitedWarranty, YearWarranty, 3, "With this God of War game you will enjoy hours of fun and new challenges that will allow you to improve as a player. You will be able to share each game with people from all over the world as you can connect online.", "Game", "[\"https://http2.mlstatic.com/D_NQ_NP_834716-MLU72751588558_112023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_924074-MLU69483138400_052023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_662378-MLU69483138404_052023-O.webp\",\"https://http2.mlstatic.com/D_NQ_NP_852774-MLU69482634062_052023-O.webp\"]", "God of War Ragnarök Standard Edition Sony PS5", 15, true, false, true, "God of War", "SIE Santa Monica Studio", "Standard Edition", "M", "PS5", "Sony",LimitedWarranty, "God of War Ragnarök", "English, Spanish, Portuguese", 91, "Physical", false, true, true, 1, 1, "Spanish, English, Portuguese", "Spanish, English, Portuguese", "V", "PS5", "Ps5", 60 }
                });

            migrationBuilder.InsertData(
                table: Products,
                columns: ["Id", CommonPropertiesObjectValue_Age, CommonPropertiesObjectValue_Color, CommonPropertiesObjectValue_Gender, CommonPropertiesObjectValue_RecommendedUses, CommonPropertiesObjectValue_Size, DataObjectValue_ReleaseMonth, DataObjectValue_ReleaseYear, PriceObjectValue_HistoryPrice, PriceObjectValue_Price, SpecificationObjectValue_Brand, SpecificationObjectValue_Line, SpecificationObjectValue_Model, SpecificationObjectValue_Type, SpecificationObjectValue_Weight, WarrantyObjectValue_WarrantyInformation, WarrantyObjectValue_WarrantyLength, "MainFeaturesObjectValue_FabricDesign", "MainFeaturesObjectValue_TypeOfClothing", "OtherFeaturesObjectValue_Composition", "OtherFeaturesObjectValue_ItsSporty", "OtherFeaturesObjectValue_MainMaterial", "OtherFeaturesObjectValue_UnitsPerKit", "OtherFeaturesObjectValue_WithRecycledMaterials", CategoryId, Description, Discriminator, ImagesUrl, "Name", Stock, FlagsObjectValue_IsBestSeller, FlagsObjectValue_IsDailyOffer, FlagsObjectValue_IsFavorite],
                values: new object[,]
                {
                    { 7, Gender, "Black", "Woman", "Casual", "S", "June", 2023, 0.0m, 16.99m, "Nike", "", "Nike T-Shirt", "T-Shirt", "200 g", "15-Day Limited Warranty", YearWarranty, "Straight", "T-shirt", "Polyester", false, "", 1, false, 2, "The Nike Classic Swoosh Future medium support women's workout top offers long-lasting comfort during training with sweat-wicking fabric and a compression fit.", "Shirt", "[\"https://imgnike-a.akamaihd.net/768x768/002897ID.jpg\",\"https://imgnike-a.akamaihd.net/768x768/002897IDA1.jpg\",\"https://imgnike-a.akamaihd.net/768x768/002897IDA4.jpg\",\"https://imgnike-a.akamaihd.net/768x768/002897IDA5.jpg\"]", "Top Nike Swoosh Woman", 5, true, false, true },
                    { 8, Gender, "Black", "Woman", "Casual", "XS", "March", 2023, 80.0m, 64.99m, "Adidas", "", "JACKET Adidas", "T-Shirt", "350 g", "15-Day Limited Warranty",YearWarranty, "Straight", "T-shirt", "", true, "Cotton", 1, false, 2, "Fresh and full of life, this Adi color Firebird track jacket celebrates the power and authenticity of adidas' legendary DNA.", "Shirt", "[\"https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a5757a66a549439cbac6afcd002ca57f_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_01_laydown.jpg\",\"https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/3cae025992434e889496afcd002c97ae_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_42_detail.jpg\",\"https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/c6f0e6def4bd4eefa0bfafcd002c7094_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_21_model.jpg\",\"https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a915172e29f24ce4b34bafcd002c78dc_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_23_hover_model.jpg\"]", "Adi color classics firebird track jacket", 8, false, true, false }
                });

            migrationBuilder.InsertData(
                table: Products,
                columns: ["Id", CommonPropertiesObjectValue_Age, CommonPropertiesObjectValue_Color, CommonPropertiesObjectValue_Gender, CommonPropertiesObjectValue_RecommendedUses, CommonPropertiesObjectValue_Size, DataObjectValue_ReleaseMonth, DataObjectValue_ReleaseYear, PriceObjectValue_HistoryPrice, PriceObjectValue_Price, SpecificationObjectValue_Brand, SpecificationObjectValue_Line, SpecificationObjectValue_Model, SpecificationObjectValue_Type, SpecificationObjectValue_Weight, WarrantyObjectValue_WarrantyInformation, WarrantyObjectValue_WarrantyLength, "MaterialObjectValue_InteriorMaterials", "MaterialObjectValue_MaterialsFromAbroad", "MaterialObjectValue_SoleMaterials", CategoryId, Description, Discriminator, ImagesUrl, "Name", Stock, FlagsObjectValue_IsBestSeller, FlagsObjectValue_IsDailyOffer, FlagsObjectValue_IsFavorite],
                values: new object[,]
                {
                    { 9, Gender, "Pink/Gold and Black", "Woman", "skateboarding", "7.5", "June", 2023, 95.0m, 71.99m, "Nike", "SB", "DM3493", "Shoes", "368,5 g", "45-Day Limited Warranty", YearWarranty, "Cotton", "Leather", "Rubber", 2, "Buoyed to the comfort you've come to trust, the Air Max Excee meets the needs of your 9 to 5 while keeping your outfit on-point with rich textures. These sneakers deliver just what you're looking for—soft cushioning that's easy to style.", "Shoe", "[\"https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/24d5a5ec-db76-4512-99a8-36231b9a9b41/streakfly-road-racing-shoes-8rTxtR.png\",\"https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/97fb810e-5803-43f5-98ac-67c8763deb15/streakfly-road-racing-shoes-8rTxtR.png\",\"https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/6d25c69b-b08b-4cc7-b97d-8384e196951f/streakfly-road-racing-shoes-8rTxtR.png\",\"https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/54e264aa-a85f-4152-b409-ed0372924d81/streakfly-road-racing-shoes-8rTxtR.png\"]", "Nike Streak-fly", 15, false, true, true },
                    { 10, Gender, "Black", "Man", "skateboarding", "7.5", "October", 2022, 0.0m, 75.99m, "Puma", "SB", "Basketball Classic XXI sneakers", "Shoes", "368,5 g", "45-Day Limited Warranty", YearWarranty, "Cotton", "Leather", "Rubber", 2, "The Suede hit the scene in 1968 and has been changing the game ever since. It’s been worn by icons of every generation, and it’s stayed classic through it all. Instantly recognizable and constantly reinvented, Suede’s legacy continues to grow and be legitimized by the authentic and expressive individuals that embrace the iconic shoe. Be apart of the history of Suede.", "Shoe", "[\"https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/sv01/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers\",\"https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/mod02/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers\",\"https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/mod03/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers\",\"https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/bv/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers\"]", "Suede Classic XXI Sneakers", 15, true, false, true }
                });

            migrationBuilder.InsertData(
                table: Reviews,
                columns: ["Id", "Comment", "Image", "ProductId", "Rating", "ReviewDate"],
                values: new object[,]
                {
                    { 1, "The quality of the photos is incredible.", "https://http2.mlstatic.com/D_NQ_NP_637616-MLA70484274053_072023-O.webp", 1, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1947) },
                    { 2, "Very good purchase, it arrived very quickly and it arrived like a totally new phone, it only has very slight details on the sides.", "https://m.media-amazon.com/images/I/71a4vqXqxbL._SY256.jpg", 1, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1963) },
                    { 3, "Good!", "https://http2.mlstatic.com/D_NQ_NP_2X_743184-MLA69501979268_052023-F.webp", 1, 4, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1964) },
                    { 4, "The best smartphone I've ever used!!! I left an iPhone 14 Pro Max, sold it, bought the S23 Ultra and still had money left. There's no comparison, with 8gb of ram you can use several applications in the background at the same time.", "https://http2.mlstatic.com/D_NQ_NP_2X_936910-MLA54765476953_032023-F.webp", 2, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1965) },
                    { 5, "Excellent, after all it is an Apple product. Worth every penny given ❤.", "https://http2.mlstatic.com/D_NQ_NP_2X_960098-MLA73264672831_122023-F.webp", 3, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1966) },
                    { 6, "The best.", "https://http2.mlstatic.com/D_NQ_NP_2X_911842-MLA73095448948_112023-F.webp", 4, 4, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1966) },
                    { 7, "New original product you can buy without fear!.", "https://http2.mlstatic.com/D_NQ_NP_2X_696237-MLA71736945652_092023-F.webp", 5, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1967) },
                    { 8, "Excellent product, came sealed.", "https://http2.mlstatic.com/D_NQ_NP_2X_918056-MLA72166744514_102023-F.webp", 5, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1968) },
                    { 9, "Perfect product.", "https://http2.mlstatic.com/D_NQ_NP_2X_661229-MLA72108620029_102023-F.webp", 6, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1969) },
                    { 10, "The best product, very good!", "https://http2.mlstatic.com/D_NQ_NP_2X_942915-MLA54965635426_042023-F.webp", 6, 4, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1970) },
                    { 11, "Pay attention to size. Nike models are smaller. The ideal is to buy 1 size larger.", "", 7, 4, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1971) },
                    { 12, "It was small on me. I want to return it. To get my refund.", "", 7, 1, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1972) },
                    { 14, "Excellent product.", "", 9, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1973) },
                    { 15, "I liked the original, it has to be laced but it's perfect.", "", 10, 5, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1974) },
                    { 16, "I'm a fan of this sneaker. One of the most beautiful on the foot, in my opinion.", "", 10, 4, new DateTime(2024, 5, 28, 0, 56, 8, 736, DateTimeKind.Local).AddTicks(1975) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: AspNetRoles,
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                table: AspNetUsers,
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: AspNetUsers,
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: Orders,
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_OrderId",
                table: OrdersDetails,
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_PaymentMethodId",
                table: OrdersDetails,
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: Products,
                column: CategoryId);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: Reviews,
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CategoryId",
                table: ShoppingCartItems,
                column: CategoryId);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: ShoppingCartItems,
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Card");

            migrationBuilder.DropTable(
                name: OrdersDetails);

            migrationBuilder.DropTable(
                name: Reviews);

            migrationBuilder.DropTable(
                name: ShoppingCartItems);

            migrationBuilder.DropTable(
                name: AspNetRoles);

            migrationBuilder.DropTable(
                name: AspNetUsers);

            migrationBuilder.DropTable(
                name: Orders);

            migrationBuilder.DropTable(
                name: Products);

            migrationBuilder.DropTable(
                name: Payment);

            migrationBuilder.DropTable(
                name: Categories);
        }
    }
}
