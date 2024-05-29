using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration;

public class CategoryConfigurationTests
{
    [Fact]
    public void Should_Configure_Category()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        // Ensure database is created and seeded
        context.Database.EnsureCreated();

        // Act
        var categories = context.Categories.ToList();

        // Assert
        Assert.Equal(7, categories.Count);

        Assert.Contains(categories, c => c.Id == 1 && c.Name == "Smartphones" && c.ImageUrl == "https://i5.walmartimages.com/seo/Straight-Talk-Apple-iPhone-12-64GB-Black-Prepaid-Smartphone-Locked-to-Straight-Talk_66b2853b-6cb5-4f20-b73a-b60b39b6de44.6b3bf83a920058a47342318925f1dc2b.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF");
        Assert.Contains(categories, c => c.Id == 7 && c.Name == "Furniture" && c.ImageUrl == "https://i5.walmartimages.com/seo/Intex-Corner-Sofa_b6271dd9-4704-436a-aa35-36293fa7482c_1.887862bad366185f36f3793d387c450e.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF");
    }
}
