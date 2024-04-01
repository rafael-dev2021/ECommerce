// using Domain.Entities.Products.Fashion;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Infra_Data.Configuration.Products.Fashion;
//
// public class CommonPropertiesConfiguration : IEntityTypeConfiguration<CommonProperties>
// {
//     public void Configure(EntityTypeBuilder<CommonProperties> builder)
//     {
//         builder.HasNoKey();
//         builder.Property(x => x.Gender).HasMaxLength(10).IsRequired();
//         builder.Property(x => x.Color).HasMaxLength(20).IsRequired();
//         builder.Property(x => x.Age).HasMaxLength(10).IsRequired();
//         builder.Property(x => x.RecommendedUses).HasMaxLength(15).IsRequired();
//         builder.Property(x => x.Size).HasMaxLength(5).IsRequired();
//     }
// }