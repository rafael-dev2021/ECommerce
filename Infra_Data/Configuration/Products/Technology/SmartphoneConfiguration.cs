using Domain.Entities.Products.Technology.Smartphones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Technology;

public class SmartphoneConfiguration : IEntityTypeConfiguration<Smartphone>
{
    public void Configure(EntityTypeBuilder<Smartphone> builder)
    {
        builder.HasData(
            new Smartphone(
                1,
                "Samsung Galaxy S23 Ultra 512GB Unlocked - Black",
                "Maximum security so that only you can access your team. You can choose between the fingerprint sensor to activate your phone with a tap, or facial recognition that allows you to unlock up to 30% faster.",
                [
                    "https://http2.mlstatic.com/D_NQ_NP_856672-MLU70401529412_072023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_945544-MLU70401529414_072023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_808604-MLU70400221716_072023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_827555-MLU70400783806_072023-O.webp"
                ],
                20,
                1
            ),
            new Smartphone(
                2,
                "Samsung Galaxy S23 Ultra 256GB - Violet",
                "Maximum security so that only you can access your team. You can choose between the fingerprint sensor to activate your phone with a tap, or facial recognition that allows you to unlock up to 30% faster.",
                [
                    "https://http2.mlstatic.com/D_NQ_NP_683947-MLU73106437489_112023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_690989-MLU72932986551_112023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_612226-MLU72932986555_112023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_683459-MLU72932986549_112023-O.webp"
                ],
                25,
                1
            ),
            new Smartphone(
                3,
                "Apple iPhone 15 Pro (512 GB) - Titanium Blue",
                "FORGED FROM TITANIUM — iPhone 15 Pro features a rugged, lightweight design made from aerospace-grade titanium. On the back, textured matte glass and, on the front, Ceramic Shield, more resistant than any smartphone glass. It\'s also tough against splashes, water, and dust.",
                [
                    "https://http2.mlstatic.com/D_NQ_NP_918178-MLA71783088444_092023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_918178-MLA71783088444_092023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_829742-MLA71783365702_092023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_715495-MLA71783365704_092023-O.webps"
                ],
                15,
                1
            ),
            new Smartphone(
                4,
                "Apple iPhone 15 Pro (128 GB) - Titanium White",
                "FORGED FROM TITANIUM — iPhone 15 Pro features a rugged, lightweight design made from aerospace-grade titanium. On the back, textured matte glass and, on the front, Ceramic Shield, more resistant than any smartphone glass. It\'s also tough against splashes, water, and dust.",
                [
                    "https://http2.mlstatic.com/D_NQ_NP_812116-MLA71783168214_092023E-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_812116-MLA71783168214_092023E-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_658271-MLA71782871766_092023-O.webp",
                    "https://http2.mlstatic.com/D_NQ_NP_998898-MLA71782901894_092023-O.webp"
                ],
                10,
                1
            ));

        ConfigureSpecificationsOv(builder);
        ConfigurePriceOv(builder);
        ConfigureWarrantyOv(builder);
        ConfigureFlagsOv(builder);
        ConfigureDataOv(builder);
        ConfigureFeatureOv(builder);
        ConfigureDisplayOv(builder);
        ConfigureMemoryOv(builder);
        ConfigureCameraOv(builder);
        ConfigurePlatformOv(builder);
        ConfigureBatteryOv(builder);
        ConfigureDimensionsOv(builder);
        ConfigureCommonPropertiesOv(builder);
    }

    private static void ConfigureSpecificationsOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.SpecificationObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    Model = "S23 Ultra",
                    Brand = "Samsung",
                    Line = "Galaxy S",
                    Weight = "233 g",
                    Type = "Smartphone"
                });

                sa.HasData(new
                {
                    Id = 2,
                    Model = "S23 Ultra",
                    Brand = "Samsung",
                    Line = "Galaxy S",
                    Weight = "235 g",
                    Type = "Smartphone"
                });
                sa.HasData(new
                {
                    Id = 3,
                    Model = "iPhone 15 Pro",
                    Brand = "Apple",
                    Line = "iPhone",
                    Weight = "235 g",
                    Type = "Smartphone"
                });
                sa.HasData(new
                {
                    Id = 4,
                    Model = "iPhone 15 Pro",
                    Brand = "Apple",
                    Line = "iPhone",
                    Weight = "235 g",
                    Type = "Smartphone"
                });
            });
    }


    private static void ConfigurePriceOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.PriceObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    Price = 2179.99M,
                    HistoryPrice = 2299.99M
                });
                sa.HasData(new
                {
                    Id = 2,
                    Price = 1624.99M,
                    HistoryPrice = 2199.99M
                });
                sa.HasData(new
                {
                    Id = 3,
                    Price = 2035.99M,
                    HistoryPrice = 2199.99M
                });
                sa.HasData(new
                {
                    Id = 4,
                    Price = 1624.99M,
                    HistoryPrice = 1799.99M
                });
            });
    }

    private static void ConfigureWarrantyOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.WarrantyObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    WarrantyLength = "1-year warranty",
                    WarrantyInformation = "30-Day Limited Warranty"
                });
                sa.HasData(new
                {
                    Id = 2,
                    WarrantyLength = "1-year warranty",
                    WarrantyInformation = "30-Day Limited Warranty"
                });
                sa.HasData(new
                {
                    Id = 3,
                    WarrantyLength = "1-year warranty",
                    WarrantyInformation = "30-Day Limited Warranty"
                });
                sa.HasData(new
                {
                    Id = 4,
                    WarrantyLength = "1-year warranty",
                    WarrantyInformation = "30-Day Limited Warranty"
                });
            });
    }

    private static void ConfigureFlagsOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.FlagsObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    IsDailyOffer = true,
                    IsBestSeller = false,
                    IsFavorite = true
                });
                sa.HasData(new
                {
                    Id = 2,
                    IsDailyOffer = true,
                    IsBestSeller = false,
                    IsFavorite = true
                });
                sa.HasData(new
                {
                    Id = 3,
                    IsDailyOffer = true,
                    IsBestSeller = false,
                    IsFavorite = false
                });
                sa.HasData(new
                {
                    Id = 4,
                    IsDailyOffer = true,
                    IsBestSeller = false,
                    IsFavorite = true
                });
            });
    }

    private static void ConfigureDataOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.DataObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    ReleaseMonth = "June",
                    ReleaseYear = 2023
                });
                sa.HasData(new
                {
                    Id = 2,
                    ReleaseMonth = "August",
                    ReleaseYear = 2022
                });
                sa.HasData(new
                {
                    Id = 3,
                    ReleaseMonth = "Februery",
                    ReleaseYear = 2023
                });
                sa.HasData(new
                {
                    Id = 4,
                    ReleaseMonth = "March",
                    ReleaseYear = 2023
                });
            });
    }

    private static void ConfigureFeatureOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.FeatureObjectValue,
            sa =>
            {
                sa.Property(x => x.CellNetworkTechnology)
                    .HasMaxLength(30)
                    .IsRequired();
                sa.Property(x => x.VirtualAssistant)
                    .HasMaxLength(50)
                    .IsRequired();
                sa.Property(x => x.ManufacturerPartNumber)
                    .HasMaxLength(50)
                    .IsRequired();
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G",
                    VirtualAssistant = "Samsung Bixby,Alexa,Google Assistant",
                    ManufacturerPartNumber = "SM-S918UZKFXAA",
                });
                sa.HasData(new
                {
                    Id = 2,
                    CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G",
                    VirtualAssistant = "Samsung Bixby,Alexa,Google Assistant",
                    ManufacturerPartNumber = "SM-B518UZKFX22",
                });
                sa.HasData(new
                {
                    Id = 3,
                    CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G",
                    VirtualAssistant = "Apple Watch,HomePod,Siri Assistant",
                    ManufacturerPartNumber = "AA-12SF7832SD301EW3",
                });
                sa.HasData(new
                {
                    Id = 4,
                    CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G",
                    VirtualAssistant = "Apple Watch,HomePod,Siri Assistant",
                    ManufacturerPartNumber = "AA-12VD783HR230SW19",
                });
            });
    }

    private static void ConfigureCommonPropertiesOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.CommonPropertiesObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    Gender = "",
                    Color = "Phantom Black",
                    Age = "",
                    RecommendedUses = "",
                    Size = ""
                });
                sa.HasData(new
                {
                    Id = 2,
                    Gender = "",
                    Color = "Violet",
                    Age = "",
                    RecommendedUses = "",
                    Size = ""
                });
                sa.HasData(new
                {
                    Id = 3,
                    Gender = "",
                    Color = "Titanium Blue",
                    Age = "",
                    RecommendedUses = "",
                    Size = ""
                });
                sa.HasData(new
                {
                    Id = 4,
                    Gender = "",
                    Color = "Titanium White",
                    Age = "",
                    RecommendedUses = "",
                    Size = ""
                });
            });
    }

    private static void ConfigureDisplayOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.DisplayObjectValue,
            sa =>
            {
                sa.Property(x => x.DisplayType)
                    .HasMaxLength(30)
                    .IsRequired();
                sa.Property(x => x.DisplayResolution)
                    .HasMaxLength(25)
                    .IsRequired();
                sa.Property(x => x.DisplayProtection)
                    .HasMaxLength(40)
                    .IsRequired();
                sa.Property(x => x.DisplaySizeInches)
                    .IsRequired();
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    DisplayType = "Dynamic AMOLED 2X 120 Hz",
                    DisplayResolution = "1440 px x 3088 px",
                    DisplayProtection = "Corning Gorilla Glass Victus 2",
                    DisplaySizeInches = 6.8


                });
                sa.HasData(new
                {
                    Id = 2,
                    DisplayType = "Dynamic AMOLED 2X",
                    DisplayResolution = "1440 px x 3088 px",
                    DisplayProtection = "Corning Gorilla Glass Victus 2",
                    DisplaySizeInches = 6.8

                });
                sa.HasData(new
                {
                    Id = 3,
                    DisplayType = "Super Retina XDR",
                    DisplayResolution = "2556 px x 1179 px",
                    DisplayProtection = "Corning Gorilla Glass Victus 2",
                    DisplaySizeInches = 6.1
                });
                sa.HasData(new
                {
                    Id = 4,
                    DisplayType = "Super Retina XDR",
                    DisplayResolution = "2556 px x 1179 px",
                    DisplayProtection = "Corning Gorilla Glass Victus 2",
                    DisplaySizeInches = 6.1
                });
            });
    }


    private static void ConfigureMemoryOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.StorageObjectValue,
            sa =>
            {
                sa.Property(x => x.RamGb)
                    .HasConversion<int>()
                    .IsRequired();
                sa.Property(x => x.StorageGb)
                    .HasConversion<int>()
                    .IsRequired();
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    RamGb = 12,
                    StorageGb = 512
                });
                sa.HasData(new
                {
                    Id = 2,
                    RamGb = 8,
                    StorageGb = 258
                });
                sa.HasData(new
                {
                    Id = 3,
                    RamGb = 8,
                    StorageGb = 512
                });
                sa.HasData(new
                {
                    Id = 4,
                    RamGb = 8,
                    StorageGb = 128
                });
            });
    }

    private static void ConfigureCameraOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.CameraObjectValue,
            sa =>
            {
                sa.Property(x => x.MainCameraSpec)
                    .HasMaxLength(15)
                    .IsRequired();
                sa.Property(x => x.MainCameraFeature)
                    .HasMaxLength(50)
                    .IsRequired();
                sa.Property(x => x.SelfieCameraSpec)
                    .HasMaxLength(15)
                    .IsRequired();
                sa.Property(x => x.SelfieCameraFeature)
                    .HasMaxLength(150)
                    .IsRequired();

                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    MainCameraSpec = "200 Mpx",
                    MainCameraFeature = "(Quad) 200 MP + 10 MP + 10 MP + 12 MP",
                    SelfieCameraSpec = "12 Mpx",
                    SelfieCameraFeature = "LED flash, auto-HDR, panorama"
                });
                sa.HasData(new
                {
                    Id = 2,
                    MainCameraSpec = "200 Mpx",
                    MainCameraFeature = "200 Mpx/12 Mpx/10 Mpx/10 Mpx",
                    SelfieCameraSpec = "12 Mpx",
                    SelfieCameraFeature = "LED flash, auto-HDR, panorama"
                });
                sa.HasData(new
                {
                    Id = 3,
                    MainCameraSpec = "48 Mpx",
                    MainCameraFeature = "48 Mpx/12 Mpx/12 Mpx",
                    SelfieCameraSpec = "12 Mpx",
                    SelfieCameraFeature =
                        "Photonic engine, Deep fusion, Smart HDR 4, Portrait mode, Portrait lighting with six effects,"
                });
                sa.HasData(new
                {
                    Id = 4,
                    MainCameraSpec = "48 Mpx",
                    MainCameraFeature = "48 Mpx/12 Mpx/12 Mpx",
                    SelfieCameraSpec = "12 Mpx",
                    SelfieCameraFeature =
                        "Photonic engine, Deep fusion, Smart HDR 4, Portrait mode, Portrait lighting with six effects,"
                });
            });
    }

    private static void ConfigurePlatformOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.PlatformObjectValue,
            sa =>
            {
                sa.Property(x => x.OperatingSystem)
                    .HasMaxLength(15)
                    .IsRequired();
                sa.Property(x => x.Chipset)
                    .HasMaxLength(50)
                    .IsRequired();
                sa.Property(x => x.Gpu)
                    .HasMaxLength(30)
                    .IsRequired();
                sa.Property(x => x.Cpu)
                    .HasMaxLength(30)
                    .IsRequired();

                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    OperatingSystem = "Android",
                    Chipset = "Qualcomm SM8550-AC Snapdragon 8 Gen 2",
                    Gpu = "Adreno 740",
                    Cpu = "Octa-core"
                });
                sa.HasData(new
                {
                    Id = 2,
                    OperatingSystem = "Android",
                    Chipset = "Qualcomm SM8550-AC Snapdragon 8 Gen 2",
                    Gpu = "Adreno 740",
                    Cpu = "Octa-Core of up to 3.36GHz"
                });
                sa.HasData(new
                {
                    Id = 3,
                    OperatingSystem = "iOS",
                    Chipset = "Apple A17 Pro",
                    Gpu = "5 cores",
                    Cpu = "Chip A16 Bionic"
                });
                sa.HasData(new
                {
                    Id = 4,
                    OperatingSystem = "iOS",
                    Chipset = "Apple A17 Pro",
                    Gpu = "5 cores",
                    Cpu = "Chip A16 Bionic"
                });
            });
    }

    private static void ConfigureDimensionsOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.DimensionObjectValue,
            sa =>
            {
                sa.Property(x => x.HeightInches)
                    .HasConversion<double>()
                    .IsRequired();
                sa.Property(x => x.WidthInches)
                    .HasConversion<double>()
                    .IsRequired();
                sa.Property(x => x.ThicknessInches)
                    .HasConversion<double>()
                    .IsRequired();
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    HeightInches = 163.4,
                    WidthInches = 78.1,
                    ThicknessInches = 8.9
                });
                sa.HasData(new
                {
                    Id = 2,
                    HeightInches = 163.4,
                    WidthInches = 78.1,
                    ThicknessInches = 8.9
                });
                sa.HasData(new
                {
                    Id = 3,
                    HeightInches = 160.9,
                    WidthInches = 77.8,
                    ThicknessInches = 7.80
                });
                sa.HasData(new
                {
                    Id = 4,
                    HeightInches = 160.9,
                    WidthInches = 77.8,
                    ThicknessInches = 7.80
                });
            });
    }

    private static void ConfigureBatteryOv(EntityTypeBuilder<Smartphone> builder)
    {
        builder.OwnsOne(x => x.BatteryObjectValue,
            sa =>
            {
                sa.Property(b => b.BatteryType)
                    .HasMaxLength(15)
                    .IsRequired();
                sa.Property(b => b.BatteryCapacityMAh)
                    .HasConversion<int>()
                    .IsRequired();
                sa.Property(b => b.IsBatteryRemovable)
                    .HasConversion<bool>();
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    BatteryType = "Li-Ion",
                    BatteryCapacityMAh = 5000,
                    IsBatteryRemovable = false
                });
                sa.HasData(new
                {
                    Id = 2,
                    BatteryType = "Lithium Ion",
                    BatteryCapacityMAh = 5000,
                    IsBatteryRemovable = false
                });
                sa.HasData(new
                {
                    Id = 3,
                    BatteryType = "Lithium Ion",
                    BatteryCapacityMAh = 5000,
                    IsBatteryRemovable = false
                });
                sa.HasData(new
                {
                    Id = 4,
                    BatteryType = "Lithium Ion",
                    BatteryCapacityMAh = 5000,
                    IsBatteryRemovable = false
                });
            });
    }
}