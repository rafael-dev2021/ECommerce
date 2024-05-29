using Application.Dtos;
using Application.Dtos.DeliveriesDto;
using Application.Dtos.OrderDtos;
using Application.Dtos.PaymentsDto;
using Application.Mappings;
using AutoMapper;
using Domain.Entities.Deliveries;
using Domain.Entities.Orders;
using Domain.Entities.Payments;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings;

public class MappingTheOrderProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheOrderProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheOrderProfile>();
            cfg.AddProfile<MappingTheProductProfile>();
            cfg.AddProfile<MappingThePaymentProfile>();
            cfg.AddProfile<MappingTheDeliveriesProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_Order_To_OrderDto()
    {
        // Arrange
        var order = new Order();
        order.SetId(1);
        order.SetTotalOrder(100.00m);
        order.SetTotalItemsOrder(2);
        order.SetConfirmedOrder(DateTime.Now);
        order.SetDispatchedOrder(DateTime.Now.AddDays(1));
        order.SetRequestReceived(DateTime.Now.AddDays(-1));
        order.DeliveryAddress = new DeliveryAddress();
        order.UserDelivery = new UserDelivery();
        order.SetPaymentMethod(new PaymentMethod());

        // Act
        var orderDto = _mapper.Map<OrderDto>(order);

        // Assert
        orderDto.Id.Should().Be(order.Id);
        orderDto.TotalOrder.Should().Be(order.TotalOrder);
        orderDto.TotalItemsOrder.Should().Be(order.TotalItemsOrder);
        orderDto.ConfirmedOrder.Should().Be(order.ConfirmedOrder);
        orderDto.DispatchedOrder.Should().Be(order.DispatchedOrder);
        orderDto.RequestReceived.Should().Be(order.RequestReceived);
        orderDto.DeliveryAddress.Should().NotBeNull();
        orderDto.UserDelivery.Should().NotBeNull();
        orderDto.PaymentMethod.Should().NotBeNull();
    }

    [Fact]
    public void Should_Map_OrderDto_To_Order()
    {
        // Arrange
        var deliveryAddressDto = new DeliveryAddressDto("Street", "City", "State", "Country", "ZipCode", "ReceiverName", "PhoneNumber");
        var userDeliveryDto = new UserDeliveryDto("FirstName", "LastName", "Email", "PhoneNumber", "AdditionalInfo");
        var paymentMethodDto = new PaymentMethodDto(new CreditCardDto(), new DebitCardDto());

        var orderDto = new OrderDto(
            1,
            100.00m,
            2,
            DateTime.Now,
            DateTime.Now.AddDays(1),
            DateTime.Now.AddDays(-1),
            new List<OrderDetailDto>(),
            deliveryAddressDto,
            userDeliveryDto,
            paymentMethodDto);

        // Act
        var order = _mapper.Map<Order>(orderDto);

        // Assert
        order.Id.Should().Be(orderDto.Id);
        order.TotalOrder.Should().Be(orderDto.TotalOrder);
        order.TotalItemsOrder.Should().Be(orderDto.TotalItemsOrder);
        order.ConfirmedOrder.Should().Be(orderDto.ConfirmedOrder);
        order.DispatchedOrder.Should().Be(orderDto.DispatchedOrder);
        order.RequestReceived.Should().Be(orderDto.RequestReceived);
        order.DeliveryAddress.Should().NotBeNull();
        order.UserDelivery.Should().NotBeNull();
        order.PaymentMethod.Should().NotBeNull();
    }

    [Fact]
    public void Should_Map_OrderDetail_To_OrderDetailDto()
    {
        // Arrange
        var orderDetail = new OrderDetail(1, 50.00m, 1, 1, 1);
        orderDetail.SetId(1);

        // Act
        var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);

        // Assert
        orderDetailDto.Id.Should().Be(orderDetail.Id);
        orderDetailDto.Quantity.Should().Be(orderDetail.Quantity);
        orderDetailDto.Price.Should().Be(orderDetail.Price);
        orderDetailDto.ProductId.Should().Be(orderDetail.ProductId);
        orderDetailDto.OrderId.Should().Be(orderDetail.OrderId);
        orderDetailDto.PaymentMethodId.Should().Be(orderDetail.PaymentMethodId);
    }

    [Fact]
    public void Should_Map_OrderDetailDto_To_OrderDetail()
    {
        // Arrange
        var orderDetails = new List<OrderDetailDto>();
        var deliveryAddress = new DeliveryAddressDto("Street", "City", "State", "Country", "ZipCode", "ReceiverName", "PhoneNumber");
        var userDelivery = new UserDeliveryDto("FirstName", "LastName", "Email", "PhoneNumber", "AdditionalInfo");
        var paymentMethod = new PaymentMethodDto(new CreditCardDto(), new DebitCardDto());
        var confirmedOrder = DateTime.Now;
        var dispatchedOrder = DateTime.Now;
        var requestReceived = DateTime.Now;

        var orderDto = new OrderDto(1, 100.0m, 5, confirmedOrder, dispatchedOrder, requestReceived, orderDetails, deliveryAddress, userDelivery, paymentMethod);

        var orderDetailDto = new OrderDetailDto(
            1,
            1,
            50.00m,
            1,
            new ProductDto(),
            1,
            orderDto,
            1,
            new PaymentMethodDto(new CreditCardDto(), new DebitCardDto()));

        // Act
        var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);

        // Assert
        orderDetail.Id.Should().Be(orderDetailDto.Id);
        orderDetail.Quantity.Should().Be(orderDetailDto.Quantity);
        orderDetail.Price.Should().Be(orderDetailDto.Price);
        orderDetail.ProductId.Should().Be(orderDetailDto.ProductId);
        orderDetail.OrderId.Should().Be(orderDetailDto.OrderId);
        orderDetail.PaymentMethodId.Should().Be(orderDetailDto.PaymentMethodId);
    }
}
