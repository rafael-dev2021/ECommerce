using Application.Dtos;
using Application.Dtos.DeliveriesDto;
using Application.Dtos.OrderDtos;
using Application.Dtos.PaymentsDto;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.OrdersDto;

public class OrderDetailDtoTests
{
    [Fact]
    public void OrderDetailDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        var orderDetails = new List<OrderDetailDto>();
        var deliveryAddress = new DeliveryAddressDto("", "", "", "", "", "", "");
        var userDelivery = new UserDeliveryDto("", "", "", "", "");
        var paymentMethodDto = new PaymentMethodDto(new CreditCardDto(), new DebitCardDto());
        var confirmedOrder = DateTime.Now;
        var dispatchedOrder = DateTime.Now;
        var requestReceived = DateTime.Now;
        var productDto = new ProductDto();

        var orderDto = new OrderDto(1, 100.0m, 5, confirmedOrder, dispatchedOrder, requestReceived, orderDetails, deliveryAddress, userDelivery, paymentMethodDto);

        // Act
        var orderDetailDto = new OrderDetailDto(1, 2, 50.0m, 101, productDto, 201, orderDto, 301, paymentMethodDto);

        // Assert
        Assert.Equal(1, orderDetailDto.Id);
        Assert.Equal(2, orderDetailDto.Quantity);
        Assert.Equal(50.0m, orderDetailDto.Price);
        Assert.Equal(101, orderDetailDto.ProductId);
        Assert.Same(productDto, orderDetailDto.Product);
        Assert.Equal(201, orderDetailDto.OrderId);
        Assert.Same(orderDto, orderDetailDto.Order);
        Assert.Equal(301, orderDetailDto.PaymentMethodId);
        Assert.Same(paymentMethodDto, orderDetailDto.PaymentMethod);
    }
}
