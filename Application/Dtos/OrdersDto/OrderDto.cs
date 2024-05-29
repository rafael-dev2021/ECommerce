using Application.Dtos.DeliveriesDto;
using Application.Dtos.PaymentsDto;

namespace Application.Dtos.OrderDtos;

public record OrderDto(
    int Id,
    decimal TotalOrder,
    int TotalItemsOrder,
    DateTime ConfirmedOrder,
    DateTime DispatchedOrder,
    DateTime RequestReceived,
    List<OrderDetailDto> OrderDetails,
    DeliveryAddressDto DeliveryAddress,
    UserDeliveryDto UserDelivery,
    PaymentMethodDto PaymentMethod){ }
