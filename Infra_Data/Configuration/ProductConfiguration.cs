using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(60).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(10000).IsRequired();
        builder.Property(x => x.ImagesUrl).HasMaxLength(800).IsRequired();
        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        builder.Property(x => x.RowVersion).IsRowVersion();

        builder
            .OwnsOne(x => x.DataObjectValue, productData =>
            {
                productData.Property(pd => pd.ReleaseMonth)
                    .HasMaxLength(12)
                    .IsRequired();

                productData.Property(pd => pd.ReleaseYear)
                    .HasMaxLength(4)
                    .IsRequired();
            });


        builder
            .OwnsOne(x => x.WarrantyObjectValue, warranty =>
            {
                warranty.Property(w => w.WarrantyLength)
                    .HasMaxLength(30)
                    .IsRequired();

                warranty.Property(w => w.WarrantyInformation)
                    .HasMaxLength(30)
                    .IsRequired();
            });


        builder
            .OwnsOne(x => x.SpecificationObjectValue, specs =>
            {
                specs.Property(s => s.Model)
                    .HasMaxLength(50)
                    .IsRequired();

                specs.Property(s => s.Brand)
                    .HasMaxLength(20)
                    .IsRequired();

                specs.Property(s => s.Line)
                    .HasMaxLength(20)
                    .IsRequired();

                specs.Property(s => s.Weight)
                    .HasMaxLength(20)
                    .IsRequired();

                specs.Property(s => s.Type)
                    .HasMaxLength(20)
                    .IsRequired();
            });


        builder
            .OwnsOne(x => x.PriceObjectValue, pp =>
            {
                pp.Property(p => p.Price)
                    .HasPrecision(18, 2)
                    .IsRequired();

                pp.Property(p => p.HistoryPrice)
                    .HasPrecision(18, 2);
            });

        builder
            .OwnsOne(x => x.CommonPropertiesObjectValue, pp =>
            {
                pp.Property(p => p.Gender)
                    .HasMaxLength(20)
                    .IsRequired();

                pp.Property(p => p.Color)
                    .HasMaxLength(20)
                    .IsRequired();

                pp.Property(p => p.Age)
                    .HasMaxLength(20)
                    .IsRequired();

                pp.Property(p => p.RecommendedUses)
                    .HasMaxLength(20)
                    .IsRequired();

                pp.Property(p => p.Size)
                    .HasMaxLength(20)
                    .IsRequired();
            });
    }
}