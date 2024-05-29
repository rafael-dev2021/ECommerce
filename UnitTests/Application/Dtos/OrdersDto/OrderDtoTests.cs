using Application.Dtos.DeliveriesDto;
using Application.Dtos.OrderDtos;
using Application.Dtos.PaymentsDto;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.OrdersDto;

public class OrderDtoTests
{
    [Fact]
    public void OrderDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        var orderDetails = new List<OrderDetailDto>();
        var deliveryAddress = new DeliveryAddressDto("", "", "", "", "", "", "");
        var userDelivery = new UserDeliveryDto("", "", "", "", "");
        var paymentMethod = new PaymentMethodDto(new CreditCardDto(), new DebitCardDto());
        var confirmedOrder = DateTime.Now;
        var dispatchedOrder = DateTime.Now;
        var requestReceived = DateTime.Now;

        var orderDto = new OrderDto(1, 100.0m, 5, confirmedOrder, dispatchedOrder, requestReceived, orderDetails, deliveryAddress, userDelivery, paymentMethod);

        // Assert
        Assert.Equal(1, orderDto.Id);
        Assert.Equal(100.0m, orderDto.TotalOrder);
        Assert.Equal(5, orderDto.TotalItemsOrder);
        Assert.Equal(confirmedOrder, orderDto.ConfirmedOrder);
        Assert.Equal(dispatchedOrder, orderDto.DispatchedOrder);
        Assert.Equal(requestReceived, orderDto.RequestReceived);
        Assert.Same(orderDetails, orderDto.OrderDetails);
        Assert.Same(deliveryAddress, orderDto.DeliveryAddress);
        Assert.Same(userDelivery, orderDto.UserDelivery);
        Assert.Same(paymentMethod, orderDto.PaymentMethod);
    }
}
