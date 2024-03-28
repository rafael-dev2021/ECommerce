namespace Domain.Entities.Products.Technology.Games.ObjectValues;

public class GeneralFeaturesObjectValue
{
    public string Collection { get; private set; } = string.Empty;
    public string Saga { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public string Edition { get; private set; } = string.Empty;
    public string Platform { get; private set; } = string.Empty;
    public string Developers { get; private set; } = string.Empty;
    public string Publishers { get; private set; } = string.Empty;
    public char GameRating { get; private set; }

    public void SetCollection(string collection) => Collection = collection;
    public void SetSaga(string saga) => Saga = saga;
    public void SetTitle(string title) => Title = title;
    public void SetEdition(string edition) => Edition = edition;
    public void SetPlatform(string platform) => Platform = platform;
    public void SetDevelopers(string developers) => Developers = developers;
    public void SetPublishers(string publishers) => Publishers = publishers;
    public void SetGameRating(char gameRating) => GameRating = gameRating;
}