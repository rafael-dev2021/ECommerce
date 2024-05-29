using Application.Dtos.Products.Technology.Games.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Games.ObjectValues;

public class GeneralFeaturesDtoObjectValueTests
{
    [Fact]
    public void GeneralFeaturesDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string collection = "Assassin's Creed";
        string saga = "Assassin's Creed";
        string title = "Valhalla";
        string edition = "Gold";
        string platform = "Xbox";
        string developers = "Ubisoft";
        string publishers = "Ubisoft";
        char gameRating = 'M';

        // Act
        var generalFeaturesDtoObjectValue = new GeneralFeaturesDtoObjectValue(collection, saga, title, edition, platform, developers, publishers, gameRating);

        // Assert
        Assert.Equal(collection, generalFeaturesDtoObjectValue.Collection);
        Assert.Equal(saga, generalFeaturesDtoObjectValue.Saga);
        Assert.Equal(title, generalFeaturesDtoObjectValue.Title);
        Assert.Equal(edition, generalFeaturesDtoObjectValue.Edition);
        Assert.Equal(platform, generalFeaturesDtoObjectValue.Platform);
        Assert.Equal(developers, generalFeaturesDtoObjectValue.Developers);
        Assert.Equal(publishers, generalFeaturesDtoObjectValue.Publishers);
        Assert.Equal(gameRating, generalFeaturesDtoObjectValue.GameRating);
    }
}
