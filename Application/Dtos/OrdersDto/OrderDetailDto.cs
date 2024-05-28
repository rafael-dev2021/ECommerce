using Application.Dtos.PaymentsDto;

namespace Application.Dtos.OrderDtos;

public record OrderDetailDto(
    int Id,
    int Quantity,
    decimal Price,
    int ProductId,
    ProductDto Product,
    int OrderId,
    OrderDto Order,
    int PaymentMethodId,
    PaymentMethodDto PaymentMethod){}
