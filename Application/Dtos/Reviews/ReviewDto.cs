using Domain.Entities;

namespace Application.Dtos.Reviews;

public record ReviewDto(
    int Id,
    string Comment,
    string Image,
    int Rating,
    DateTime ReviewDate,
    int ProductId,
    Product? Product
    ) { }
