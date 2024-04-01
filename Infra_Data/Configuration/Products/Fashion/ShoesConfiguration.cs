using Domain.Entities.Products.Fashion.Shoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Fashion;

public class ShoesConfiguration : IEntityTypeConfiguration<Shoe>
{
    public void Configure(EntityTypeBuilder<Shoe> builder)
    {
        builder.HasData(
            new Shoe(
                9,
                "Nike Streak-fly",
                "Buoyed to the comfort you\'ve come to trust, the Air Max Excee meets the needs of your 9 to 5 while keeping your outfit on-point with rich textures. These sneakers deliver just what you\'re looking for—soft cushioning that\'s easy to style.",
                [
                    "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/24d5a5ec-db76-4512-99a8-36231b9a9b41/streakfly-road-racing-shoes-8rTxtR.png",
                    "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/97fb810e-5803-43f5-98ac-67c8763deb15/streakfly-road-racing-shoes-8rTxtR.png",
                    "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/6d25c69b-b08b-4cc7-b97d-8384e196951f/streakfly-road-racing-shoes-8rTxtR.png",
                    "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/54e264aa-a85f-4152-b409-ed0372924d81/streakfly-road-racing-shoes-8rTxtR.png"
                ],
                15,
                2
            ),
            new Shoe(
                10,
                "Suede Classic XXI Sneakers",
                "The Suede hit the scene in 1968 and has been changing the game ever since. It’s been worn by icons of every generation, and it’s stayed classic through it all. Instantly recognizable and constantly reinvented, Suede’s legacy continues to grow and be legitimized by the authentic and expressive individuals that embrace the iconic shoe. Be apart of the history of Suede.",
                [
                    "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/sv01/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers",
                    "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/mod02/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers",
                    "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/mod03/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers",
                    "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/bv/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers"
                ],
                15,
                2
            ));
        ConfigureSpecificationsOv(builder);
        ConfigurePriceOv(builder);
        ConfigureWarrantyOv(builder);
        ConfigureFlagsOv(builder);
        ConfigureDataOv(builder);
        ConfigureCommonPropertiesOv(builder);
        ConfigureShoesMaterialsOv(builder);
    }

    private static void ConfigureSpecificationsOv(EntityTypeBuilder<Shoe> builder)
    {
        builder.OwnsOne(x => x.SpecificationObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 9,
                    Model = "DM3493",
                    Brand = "Nike",
                    Line = "SB",
                    Weight = "368,5 g",
                    Type = "Shoes"
                });
                sa.HasData(new
                {
                    Id = 10,
                    Model = "Basketball Classic XXI sneakers",
                    Brand = "Puma",
                    Line = "SB",
                    Weight = "368,5 g",
                    Type = "Shoes"
                });
            });
    }

    private static void ConfigurePriceOv(EntityTypeBuilder<Shoe> builder)
    {
        builder.OwnsOne(x => x.PriceObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 9,
                    Price = 71.99M,
                    HistoryPrice = 95.0M
                });
                sa.HasData(new
                {
                    Id = 10,
                    Price = 75.99M,
                    HistoryPrice = 0.0M
                });
            });
    }

    private static void ConfigureWarrantyOv(EntityTypeBuilder<Shoe> builder)
    {
        builder.OwnsOne(x => x.WarrantyObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 9,
                    WarrantyLength = "1-year warranty",
                    WarrantyInformation = "45-Day Limited Warranty"
                });
                sa.HasData(new
                {
                    Id = 10,
                    WarrantyLength = "1-year warranty",
                    WarrantyInformation = "45-Day Limited Warranty"
                });
            });
    }

    private static void ConfigureFlagsOv(EntityTypeBuilder<Shoe> builder)
    {
        builder.OwnsOne(x => x.FlagsObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 9,
                    IsDailyOffer = true,
                    IsBestSeller = false,
                    IsFavorite = true
                });
                sa.HasData(new
                {
                    Id = 10,
                    IsDailyOffer = false,
                    IsBestSeller = true,
                    IsFavorite = true
                });
            });
    }

    private static void ConfigureDataOv(EntityTypeBuilder<Shoe> builder)
    {
        builder.OwnsOne(x => x.DataObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 9,
                    ReleaseMonth = "June",
                    ReleaseYear = 2023
                });
                sa.HasData(new
                {
                    Id = 10,
                    ReleaseMonth = "October",
                    ReleaseYear = 2022
                });
            });
    }

    private static void ConfigureCommonPropertiesOv(EntityTypeBuilder<Shoe> builder)
    {
        builder.OwnsOne(x => x.CommonPropertiesObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 9,
                    Gender = "Woman",
                    Color = "Pink/Gold and Black",
                    Age = "Adult",
                    RecommendedUses = "skateboarding",
                    Size = "7.5",
                });
                sa.HasData(new
                {
                    Id = 10,
                    Gender = "Man",
                    Color = "Black",
                    Age = "Adult",
                    RecommendedUses = "skateboarding",
                    Size = "7.5"
                });
            });
    }

    private static void ConfigureShoesMaterialsOv(EntityTypeBuilder<Shoe> builder)
    {
        builder.OwnsOne(x => x.MaterialObjectValue,
            sa =>
            {
                sa.Property(x => x.MaterialsFromAbroad)
                    .HasMaxLength(10)
                    .IsRequired();
                sa.Property(x => x.InteriorMaterials)
                    .HasMaxLength(10);
                sa.Property(x => x.SoleMaterials)
                    .HasMaxLength(10);
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 9,
                    MaterialsFromAbroad = "Leather",
                    InteriorMaterials = "Cotton",
                    SoleMaterials = "Rubber",
                });
                sa.HasData(new
                {
                    Id = 10,
                    MaterialsFromAbroad = "Leather",
                    InteriorMaterials = "Cotton",
                    SoleMaterials = "Rubber",
                });
            });
    }
}