using Application.CustomExceptions;
using Application.Dtos;
using Application.Dtos.DeliveriesDto;
using Application.Dtos.OrderDtos;
using Application.Dtos.PaymentsDto;
using Application.Services.Entities;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Entities.Payments.Enums;
using Domain.Interfaces;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities;

public class OrderDtoServiceTests
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly OrderDtoService _orderDtoService;
    private readonly DeliveryAddressDto DeliveryAddressDto = new("Country", "Address", "Complement", "ZipCode", "State", "City", "Neighborhood");
    private readonly UserDeliveryDto UserDeliveryDto = new("FirstName", "LastName", "Email", "Phone", "Ssn");
    private readonly PaymentMethodDto PaymentMethodDto = new(new CreditCardDto(), new DebitCardDto());

    public OrderDtoServiceTests()
    {
        _mapper = Substitute.For<IMapper>();
        _orderRepository = Substitute.For<IOrderRepository>();
        _orderDtoService = new OrderDtoService(_mapper, _orderRepository);
    }

    [Fact]
    [Test]
    public async Task GetOrdersDtoAsync_ReturnsMappedOrders_WhenOrdersExist()
    {
        // Arrange
        var orders = new List<Order> { new() };
        var ordersDto = new List<OrderDto> { new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto) };

        _orderRepository.GetEntitiesAsync().Returns(orders);
        _mapper.Map<IEnumerable<OrderDto>>(orders).Returns(ordersDto);

        // Act
        var result = await _orderDtoService.GetOrdersDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(ordersDto, result);
    }

    [Fact]
    [Test]
    public async Task GetOrdersDtoAsync_ReturnsEmptyList_WhenNoOrdersExist()
    {
        // Arrange
        _orderRepository.GetEntitiesAsync().Returns(new List<Order>());

        // Act
        var result = await _orderDtoService.GetOrdersDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    [Test]
    public async Task GetByIdAsync_ReturnsMappedOrder_WhenOrderExists()
    {
        // Arrange
        var order = new Order();
        var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto);

        _orderRepository.GetByIdAsync(1).Returns(order);
        _mapper.Map<OrderDto>(order).Returns(orderDto);

        // Act
        var result = await _orderDtoService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(orderDto, result);
    }

    [Fact]
    [Test]
    public void GetPagingListOrdersDto_ReturnsMappedOrders_WhenOrdersExist()
    {
        // Arrange
        var orders = new List<Order> { new() }.AsQueryable();
        var ordersDto = new List<OrderDto> { new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, new List<OrderDetailDto>(), DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto) }.AsQueryable();

        _orderRepository.GetPagingListOrders("filter").Returns(orders);
        _mapper.ProjectTo<OrderDto>(orders).Returns(ordersDto);

        // Act
        var result = _orderDtoService.GetPagingListOrdersDto("filter");

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(ordersDto, result);
    }

    [Fact]
    [Test]
    public async Task GetOrdersDetailsAsync_ReturnsMappedOrderDetails_WhenOrdersExist()
    {
        // Arrange
        var orders = new List<OrderDetail> { new OrderDetail() };
        var ordersDto = new List<OrderDetailDto> { new OrderDetailDto(
            1,
            1,
            12m,
            1,
            new ProductDto(),
            1,
            new OrderDto(
                1,
                12m,
                1,
                new DateTime(),
                new DateTime(),
                new DateTime(),
                [],
                DeliveryAddressDto,
                UserDeliveryDto,
                PaymentMethodDto),
            1,
            PaymentMethodDto) };

        _orderRepository.GetOrdersDetailsAsync().Returns(orders);
        _mapper.Map<IEnumerable<OrderDetailDto>>(orders).Returns(ordersDto);

        // Act
        var result = await _orderDtoService.GetOrdersDetailsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(ordersDto, result);
    }

    [Fact]
    [Test]
    public async Task GetOrdersDetailsAsync_ReturnsEmptyList_WhenNoOrderDetailsExist()
    {
        // Arrange
        _orderRepository.GetOrdersDetailsAsync().Returns(new List<OrderDetail>());

        // Act
        var result = await _orderDtoService.GetOrdersDetailsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    [Test]
    public void GetPagingListOrdersDto_ReturnsEmptyQueryable_WhenNoOrdersExist()
    {
        // Arrange
        _orderRepository.GetPagingListOrders("filter").Returns(new List<Order>().AsQueryable());

        // Act
        var result = _orderDtoService.GetPagingListOrdersDto("filter");

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    [Test]
    public async Task GetByIdAsync_ShouldThrowsOrderException_WhenRepositoryThrowsException()
    {
        // Arrange
        int? id = 1;
        _orderRepository.GetByIdAsync(id).Returns(Task.FromException<Order>(new Exception($"An error occurred while retrieving the order with ID {id}.")));

        // Act & Assert
        await Assert.ThrowsAsync<OrderException>(async () => await _orderDtoService.GetByIdAsync(id));
    }

    [Fact]
    [Test]
    public async Task AddOrder_CallsRepositoryCreateOrder_WhenOrderIsValid()
    {
        // Arrange
        var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto);
        var order = new Order();

        _mapper.Map<Order>(orderDto).Returns(order);

        // Act
        await _orderDtoService.AddOrder(orderDto, EPaymentMethod.CreditCard);

        // Assert
        await _orderRepository.Received(1).CreateOrder(order, EPaymentMethod.CreditCard);
    }

    [Fact]
    [Test]
    public async Task UpdateOrderPropertyAsync_CallsRepositoryUpdateAsync_WhenOrderIsValid()
    {
        // Arrange
        var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, new List<OrderDetailDto>(), DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto);
        var order = new Order();

        _mapper.Map<Order>(orderDto).Returns(order);

        // Act
        await _orderDtoService.UpdateOrderPropertyAsync(orderDto);

        // Assert
        await _orderRepository.Received(1).UpdateAsync(order);
    }

    [Fact]
    [Test]
    public async Task UpdateOrderPropertyAsync_ShouldThrowCategoryException_WhenRepositoryThrowsException()
    {
        // Arrange
        var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto);

        _orderRepository.When(repo => repo.UpdateAsync(Arg.Any<Order>())).Do(x => throw new Exception("Error updating order."));

        // Act & Assert
        await Assert.ThrowsAsync<OrderException>(async () => await _orderDtoService.UpdateOrderPropertyAsync(orderDto));
    }

    [Fact]
    [Test]
    public async Task DeleteOrder_CallsRepositoryDeleteAsync_WhenOrderExists()
    {
        // Arrange
        var order = new Order();

        _orderRepository.GetByIdAsync(1).Returns(order);

        // Act
        await _orderDtoService.DeleteOrder(1);

        // Assert
        await _orderRepository.Received(1).DeleteAsync(order);
    }

    [Fact]
    [Test]
    public async Task DeleteOrder_ThrowsOrderException_WhenRepositoryThrowsException()
    {
        // Arrange
        int? id = 1;
        _orderRepository.GetByIdAsync(id).ThrowsAsync(new Exception("Simulated exception"));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<OrderException>(() => _orderDtoService.DeleteOrder(id));
        Assert.Equal($"Error deleting order.", exception.Message);
        Assert.NotNull(exception.InnerException);
        Assert.IsType<Exception>(exception.InnerException);
    }

    [Fact]
    [Test]
    public async Task FindByOrderConfirmDateDtoAsync_ReturnsMappedOrders_WhenOrdersExist()
    {
        // Arrange
        var orders = new List<Order> { new() };
        var ordersDto = new List<OrderDto> { new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto) };

        _orderRepository.FindByOrderConfirmDateAsync(DateTime.MinValue, DateTime.MaxValue).Returns(orders);
        _mapper.Map<IEnumerable<OrderDto>>(orders).Returns(ordersDto);

        // Act
        var result = await _orderDtoService.FindByOrderConfirmDateDtoAsync(DateTime.MinValue, DateTime.MaxValue);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(ordersDto, result);
    }

    [Fact]
    [Test]
    public async Task FindByOrderDispatchedDateDtoAsync_ReturnsMappedOrders_WhenOrdersExist()
    {
        // Arrange
        var orders = new List<Order> { new Order() };
        var ordersDto = new List<OrderDto> { new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto) };

        _orderRepository.FindByOrderDispatchedDateAsync(DateTime.MinValue, DateTime.MaxValue).Returns(orders);
        _mapper.Map<IEnumerable<OrderDto>>(orders).Returns(ordersDto);

        // Act
        var result = await _orderDtoService.FindByOrderDispatchedDateDtoAsync(DateTime.MinValue, DateTime.MaxValue);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(ordersDto, result);
    }

    [Fact]
    [Test]
    public async Task FindByOrderRequestReceivedDateDtoAsync_ReturnsMappedOrders_WhenOrdersExist()
    {
        // Arrange
        var orders = new List<Order> { new() };
        var ordersDto = new List<OrderDto> { new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto) };

        _orderRepository.FindByOrderRequestReceivedDateAsync(DateTime.MinValue, DateTime.MaxValue).Returns(orders);
        _mapper.Map<IEnumerable<OrderDto>>(orders).Returns(ordersDto);

        // Act
        var result = await _orderDtoService.FindByOrderRequestReceivedDateDtoAsync(DateTime.MinValue, DateTime.MaxValue);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(ordersDto, result);
    }

    [Fact]
    [Test]
    public void GetSalesByMonth_ReturnsCorrectSalesByMonth()
    {
        // Arrange
        var orderDtos = new List<OrderDto>
            {
                new(1, 100, 2, new DateTime(2022, 1, 1), DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto),
                new(2, 200, 3, new DateTime(2022, 1, 15), DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto),
                new(3, 300, 4, new DateTime(2022, 2, 1), DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto)
            };

        // Act
        var result = _orderDtoService.GetSalesByMonth(orderDtos);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(2022, result[0].Year);
        Assert.Equal(1, result[0].Month);
        Assert.Equal(300, result[0].TotalSales);
        Assert.Equal(2022, result[1].Year);
        Assert.Equal(2, result[1].Month);
        Assert.Equal(300, result[1].TotalSales);
    }

    [Fact]
    [Test]
    public async Task Average_ReturnsCorrectAverage()
    {
        // Arrange
        var orderDtos = new List<OrderDto>
            {
                new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto),
                new(2, 200, 3, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto)
            };

        _orderRepository.GetEntitiesAsync().Returns(new List<Order> { new(), new() });
        _mapper.Map<IEnumerable<OrderDto>>(Arg.Any<IEnumerable<Order>>()).Returns(orderDtos);

        // Act
        var result = await _orderDtoService.Average();

        // Assert
        Assert.Equal(150, result);
    }

    [Fact]
    [Test]
    public void OrderDtoIdNull_ShouldThrowArgumentNullException_WhenIdIsNull()
    {
        // Arrange
        int? id = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => OrderDtoService.OrderDtoIdNull(id));
    }

    [Fact]
    [Test]
    public void OrderDtoIdNull_ShouldNotThrowException_WhenIdIsNotNull()
    {
        // Arrange
        int? id = 1;

        // Act & Assert
        Assert.Null(Record.Exception(() => OrderDtoService.OrderDtoIdNull(id)));
    }

    [Fact]
    [Test]
    public void OrderDtoNull_ShouldThrowArgumentNullException_WhenCategoryDtoIsNull()
    {
        // Arrange
        OrderDto? orderDto = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => OrderDtoService.OrderDtoNull(orderDto));
    }

    [Fact]
    [Test]
    public void OrderDtoNull_ShouldNotThrowException_WhenCategoryDtoIsNotNull()
    {
        // Arrange
        var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], DeliveryAddressDto, UserDeliveryDto, PaymentMethodDto);

        // Act & Assert
        Assert.Null(Record.Exception(() => OrderDtoService.OrderDtoNull(orderDto)));
    }
}
