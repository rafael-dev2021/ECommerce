using Domain.Entities.Products.Fashion.T_Shirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Fashion;

public class ShirtConfiguration : IEntityTypeConfiguration<Shirt>
{
    public void Configure(EntityTypeBuilder<Shirt> builder)
    {
        builder.HasData(
            new Shirt(
                7,
                "Top Nike Swoosh Woman",
                "The Nike Classic Swoosh Future medium support women\'s workout top offers long-lasting comfort during training with sweat-wicking fabric and a compression fit.",
                [
                    "https://imgnike-a.akamaihd.net/768x768/002897ID.jpg",
                    "https://imgnike-a.akamaihd.net/768x768/002897IDA1.jpg",
                    "https://imgnike-a.akamaihd.net/768x768/002897IDA4.jpg",
                    "https://imgnike-a.akamaihd.net/768x768/002897IDA5.jpg"
                ],
                5,
                2
            ),
            new Shirt(
                8,
                "Adi color classics firebird track jacket",
                "Fresh and full of life, this Adi color Firebird track jacket celebrates the power and authenticity of adidas\' legendary DNA.",
                [
                    "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a5757a66a549439cbac6afcd002ca57f_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_01_laydown.jpg",
                    "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/3cae025992434e889496afcd002c97ae_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_42_detail.jpg",
                    "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/c6f0e6def4bd4eefa0bfafcd002c7094_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_21_model.jpg",
                    "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a915172e29f24ce4b34bafcd002c78dc_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_23_hover_model.jpg"
                ],
                8,
                2
            ));
        ConfigureSpecificationsOv(builder);
        ConfigurePriceOv(builder);
        ConfigureWarrantyOv(builder);
        ConfigureFlagsOv(builder);
        ConfigureDataOv(builder);
        ConfigureTshirtMainFeaturesOv(builder);
        ConfigureTshirtOtherFeaturesOv(builder);
        ConfigureCommonPropertiesOv(builder);
    }

    private static void ConfigureSpecificationsOv(EntityTypeBuilder<Shirt> builder)
    {
        builder.OwnsOne(x => x.SpecificationObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    Model = "Nike T-Shirt",
                    Brand = "Nike",
                    Line = "",
                    Weight = "200 g",
                    Type = "T-Shirt"
                });
                sa.HasData(new
                {
                    Id = 8,
                    Model = "JACKET Adidas",
                    Brand = "Adidas",
                    Line = "",
                    Weight = "350 g",
                    Type = "T-Shirt"
                });
            });
    }

    private static void ConfigurePriceOv(EntityTypeBuilder<Shirt> builder)
    {
        builder.OwnsOne(x => x.PriceObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    Price = 16.99M,
                    HistoryPrice = 0.0M
                });
                sa.HasData(new
                {
                    Id = 8,
                    Price = 64.99M,
                    HistoryPrice = 80.0M
                });
            });
    }

    private static void ConfigureWarrantyOv(EntityTypeBuilder<Shirt> builder)
    {
        builder.OwnsOne(x => x.WarrantyObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    WarrantyLength = "1-year warranty",
                    WarrantyInformation = "15-Day Limited Warranty"
                });
                sa.HasData(new
                {
                    Id = 8,
                    WarrantyLength = "1-year warranty",
                    WarrantyInformation = "15-Day Limited Warranty"
                });
            });
    }

    private static void ConfigureFlagsOv(EntityTypeBuilder<Shirt> builder)
    {
        builder.OwnsOne(x => x.FlagsObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    IsDailyOffer = false,
                    IsFavorite = true,
                    IsBestSeller = true
                });
                sa.HasData(new
                {
                    Id = 8,
                    IsDailyOffer = true,
                    IsFavorite = false,
                    IsBestSeller = false
                });
            });
    }

    private static void ConfigureDataOv(EntityTypeBuilder<Shirt> builder)
    {
        builder.OwnsOne(x => x.DataObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    ReleaseMonth = "June",
                    ReleaseYear = 2023
                });
                sa.HasData(new
                {
                    Id = 8,
                    ReleaseMonth = "March",
                    ReleaseYear = 2023
                });
            });
    }

    private static void ConfigureTshirtMainFeaturesOv(EntityTypeBuilder<Shirt> builder)
    {
        builder.OwnsOne(x => x.MainFeaturesObjectValue,
            sa =>
            {
                sa.Property(x => x.TypeOfClothing)
                    .HasMaxLength(15)
                    .IsRequired();
                sa.Property(x => x.FabricDesign)
                    .HasMaxLength(15);

                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    TypeOfClothing = "T-shirt",
                    FabricDesign = "Straight"
                });
                sa.HasData(new
                {
                    Id = 8,
                    TypeOfClothing = "T-shirt",
                    FabricDesign = "Straight"
                });
            });
    }
    
    private static void ConfigureCommonPropertiesOv(EntityTypeBuilder<Shirt> builder)
    {
        builder.OwnsOne(x => x.CommonPropertiesObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    Gender = "Woman",
                    Color = "Black",
                    Age = "Adult",
                    RecommendedUses = "Casual",
                    Size = "S"
                });
                sa.HasData(new
                {
                    Id = 8,
                    Gender = "Woman",
                    Color = "Black",
                    Age = "Adult",
                    RecommendedUses = "Casual",
                    Size = "XS"
                });
            });
    }

    private static void ConfigureTshirtOtherFeaturesOv(EntityTypeBuilder<Shirt> builder)
    {
        builder.OwnsOne(x => x.OtherFeaturesObjectValue,
            sa =>
            {
                sa.Property(x => x.Composition)
                    .HasMaxLength(15);
                sa.Property(x => x.MainMaterial)
                    .HasMaxLength(15)
                    .IsRequired();
                sa.Property(x => x.UnitsPerKit)
                    .HasConversion<int>();
                sa.Property(x => x.WithRecycledMaterials)
                    .HasConversion<bool>();
                sa.Property(x => x.ItsSporty)
                    .HasConversion<bool>();

                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    RecommendedUses = "Casual",
                    Composition = "Polyester",
                    MainMaterial = "Polyester",
                    UnitsPerKit = 1,
                    WithRecycledMaterials = false,
                    ItsSporty = false
                });
                sa.HasData(new
                {
                    Id = 8,
                    RecommendedUses = "Casual",
                    Composition = "Polyester",
                    MainMaterial = "Polyester",
                    UnitsPerKit = 1,
                    WithRecycledMaterials = false,
                    ItsSporty = true
                });
            });
    }
}