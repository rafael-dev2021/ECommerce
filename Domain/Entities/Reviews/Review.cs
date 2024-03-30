namespace Domain.Entities.Reviews;

public sealed class Review
{
    public int Id { get; private set; }
    public string Comment { get; private set; } = string.Empty;
    public string Image { get; private set; } = string.Empty;
    public int Rating { get; private set; }
    public DateTime ReviewDate { get; private set; }
    public int ProductId { get; private set; }
    public Product? Product { get; }

    public Review()
    {
    }

    public Review(int id, string comment, string image, int rating, DateTime reviewDate, int productId)
    {
        Id = id;
        Comment = comment;
        Image = image;
        Rating = rating;
        ReviewDate = reviewDate;
        ProductId = productId;
    }

    public void SetId(int id) => Id= id;
    public void SetComment(string comment) => Comment = comment;
    public void SetImage(string image) => Image = image;
    public void SetRating(int rating) => Rating = rating;
    public void SetProductId(int productId) => ProductId= productId;

}