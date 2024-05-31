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
using NSubstitute.ReturnsExtensions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities;

public class OrderDtoServiceTests
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly OrderDtoService _orderDtoService;

    private readonly DeliveryAddressDto _deliveryAddressDto =
        new("Country", "Address", "Complement", "ZipCode", "State", "City", "Neighborhood");

    private readonly UserDeliveryDto _userDeliveryDto = new("FirstName", "LastName", "Email", "Phone", "Ssn");
    private readonly PaymentMethodDto _paymentMethodDto = new(new CreditCardDto(), new DebitCardDto());

    public OrderDtoServiceTests()
    {
        _mapper = Substitute.For<IMapper>();
        _orderRepository = Substitute.For<IOrderRepository>();
        _orderDtoService = new OrderDtoService(_mapper, _orderRepository);
    }

    public class GetOrdersDtoAsyncTests : OrderDtoServiceTests
    {
        [Fact]
        public async Task GetOrdersDtoAsync_ReturnsMappedOrders_WhenOrdersExist()
        {
            // Arrange
            var orders = new List<Order> { new() };
            var ordersDto = new List<OrderDto>
            {
                new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto, _userDeliveryDto,
                    _paymentMethodDto)
            };

            _orderRepository.GetEntitiesAsync().Returns(orders);
            _mapper.Map<IEnumerable<OrderDto>>(orders).Returns(ordersDto);

            // Act
            var result = await _orderDtoService.GetOrdersDtoAsync();

            // Assert
            Assert.NotNull(result);
            var orderDtos = result as OrderDto[] ?? result.ToArray();
            Assert.Single(orderDtos);
            Assert.Equal(ordersDto, orderDtos);
        }

        [Fact]
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
    }

    public class GetByIdAsyncTests : OrderDtoServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_ReturnsMappedOrder_WhenOrderExists()
        {
            // Arrange
            var order = new Order();
            var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto,
                _userDeliveryDto, _paymentMethodDto);

            _orderRepository.GetByIdAsync(1).Returns(order);
            _mapper.Map<OrderDto>(order).Returns(orderDto);

            // Act
            var result = await _orderDtoService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderDto, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowsOrderException_WhenRepositoryThrowsException()
        {
            // Arrange
            int? id = 1;
            _orderRepository.GetByIdAsync(id)
                .Returns(Task.FromException<Order>(
                    new Exception($"An error occurred while retrieving the order with ID {id}.")));

            // Act & Assert
            await Assert.ThrowsAsync<OrderException>(async () => await _orderDtoService.GetByIdAsync(id));
        }
    }

    public class GetPagingListOrdersDtoTests : OrderDtoServiceTests
    {
        [Fact]
        public void GetPagingListOrdersDto_ReturnsMappedOrders_WhenOrdersExist()
        {
            // Arrange
            var orders = new List<Order> { new() }.AsQueryable();
            var ordersDto = new List<OrderDto>
            {
                new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto, _userDeliveryDto,
                    _paymentMethodDto)
            }.AsQueryable();

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
    }

    public class GetOrdersDetailsAsyncTests : OrderDtoServiceTests
    {
        [Fact]
        public async Task GetOrdersDetailsAsync_ReturnsMappedOrderDetails_WhenOrdersExist()
        {
            // Arrange
            var orders = new List<OrderDetail> { new OrderDetail() };
            var ordersDto = new List<OrderDetailDto>
            {
                new OrderDetailDto(
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
                        _deliveryAddressDto,
                        _userDeliveryDto,
                        _paymentMethodDto),
                    1,
                    _paymentMethodDto)
            };

            _orderRepository.GetOrdersDetailsAsync().Returns(orders);
            _mapper.Map<IEnumerable<OrderDetailDto>>(orders).Returns(ordersDto);

            // Act
            var result = await _orderDtoService.GetOrdersDetailsAsync();

            // Assert
            Assert.NotNull(result);
            var orderDetailDtos = result as OrderDetailDto[] ?? result.ToArray();
            Assert.Single(orderDetailDtos);
            Assert.Equal(ordersDto, orderDetailDtos);
        }

        [Fact]
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
    }

    public class UpdateOrderPropertyAsyncTests : OrderDtoServiceTests
    {
        [Fact]
        public async Task UpdateOrderPropertyAsync_CallsRepositoryUpdateAsync_WhenOrderIsValid()
        {
            // Arrange
            var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, new List<OrderDetailDto>(),
                _deliveryAddressDto, _userDeliveryDto, _paymentMethodDto);
            var order = new Order();

            _mapper.Map<Order>(orderDto).Returns(order);

            // Act
            await _orderDtoService.UpdateOrderPropertyAsync(orderDto);

            // Assert
            await _orderRepository.Received(1).UpdateAsync(order);
        }

        [Fact]
        public async Task UpdateOrderPropertyAsync_ShouldThrowCategoryException_WhenRepositoryThrowsException()
        {
            // Arrange
            var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto,
                _userDeliveryDto, _paymentMethodDto);

            _orderRepository.When(repo => repo.UpdateAsync(Arg.Any<Order>()))
                .Do(_ => throw new Exception("Error updating order."));

            // Act & Assert
            await Assert.ThrowsAsync<OrderException>(async () =>
                await _orderDtoService.UpdateOrderPropertyAsync(orderDto));
        }
    }

    public class DeleteOrderTests : OrderDtoServiceTests
    {
        [Fact]
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
        public async Task DeleteOrder_ShouldThrowOrderException_WhenOrderNotFound()
        {
            // Arrange
            int? id = 1;
            _orderRepository.GetByIdAsync(id).ReturnsNull();

            // Act & Assert
            await Assert.ThrowsAsync<OrderException>(() => _orderDtoService.DeleteOrder(id));
        }
    }

    public class FindByOrderConfirmDateDtoAsyncTests : OrderDtoServiceTests
    {
        [Fact]
        public async Task FindByOrderConfirmDateDtoAsync_ReturnsMappedOrders_WhenOrdersExist()
        {
            // Arrange
            var orders = new List<Order> { new() };
            var ordersDto = new List<OrderDto>
            {
                new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto, _userDeliveryDto,
                    _paymentMethodDto)
            };

            _orderRepository.FindByOrderConfirmDateAsync(DateTime.MinValue, DateTime.MaxValue).Returns(orders);
            _mapper.Map<IEnumerable<OrderDto>>(orders).Returns(ordersDto);

            // Act
            var result = await _orderDtoService.FindByOrderConfirmDateDtoAsync(DateTime.MinValue, DateTime.MaxValue);

            // Assert
            Assert.NotNull(result);
            var orderDtos = result as OrderDto[] ?? result.ToArray();
            Assert.Single(orderDtos);
            Assert.Equal(ordersDto, orderDtos);
        }

        [Fact]
        public async Task FindByOrderConfirmDateDtoAsync_ReturnsEmptyList_WhenNoOrdersExist()
        {
            // Arrange
            var minDate = DateTime.MinValue;
            var maxDate = DateTime.MaxValue;
            _orderRepository.FindByOrderConfirmDateAsync(minDate, maxDate).Returns(new List<Order>());

            // Act
            var result = await _orderDtoService.FindByOrderConfirmDateDtoAsync(minDate, maxDate);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    public class FindByOrderDispatchedDateDtoAsyncTests : OrderDtoServiceTests
    {
        [Fact]
        public async Task FindByOrderDispatchedDateDtoAsync_ReturnsMappedOrders_WhenOrdersExist()
        {
            // Arrange
            var orders = new List<Order> { new() };
            var ordersDto = new List<OrderDto>
            {
                new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto, _userDeliveryDto,
                    _paymentMethodDto)
            };

            _orderRepository.FindByOrderDispatchedDateAsync(DateTime.MinValue, DateTime.MaxValue).Returns(orders);
            _mapper.Map<IEnumerable<OrderDto>>(orders).Returns(ordersDto);

            // Act
            var result = await _orderDtoService.FindByOrderDispatchedDateDtoAsync(DateTime.MinValue, DateTime.MaxValue);

            // Assert
            Assert.NotNull(result);
            var orderDtos = result as OrderDto[] ?? result.ToArray();
            Assert.Single(orderDtos);
            Assert.Equal(ordersDto, orderDtos);
        }

        [Fact]
        public async Task FindByOrderDispatchedDateDtoAsync_ReturnsEmptyList_WhenNoOrdersExist()
        {
            // Arrange
            var minDate = DateTime.MinValue;
            var maxDate = DateTime.MaxValue;
            _orderRepository.FindByOrderDispatchedDateAsync(minDate, maxDate).Returns(new List<Order>());

            // Act
            var result = await _orderDtoService.FindByOrderDispatchedDateDtoAsync(minDate, maxDate);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    public class FindByOrderRequestReceivedDateDtoAsyncTests : OrderDtoServiceTests
    {
        [Fact]
        public async Task FindByOrderRequestReceivedDateDtoAsync_ReturnsMappedOrders_WhenOrdersExist()
        {
            // Arrange
            var orders = new List<Order> { new() };
            var ordersDto = new List<OrderDto>
            {
                new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto, _userDeliveryDto,
                    _paymentMethodDto)
            };

            _orderRepository.FindByOrderRequestReceivedDateAsync(DateTime.MinValue, DateTime.MaxValue).Returns(orders);
            _mapper.Map<IEnumerable<OrderDto>>(orders).Returns(ordersDto);

            // Act
            var result =
                await _orderDtoService.FindByOrderRequestReceivedDateDtoAsync(DateTime.MinValue, DateTime.MaxValue);

            // Assert
            Assert.NotNull(result);
            var orderDtos = result as OrderDto[] ?? result.ToArray();
            Assert.Single(orderDtos);
            Assert.Equal(ordersDto, orderDtos);
        }

        [Fact]
        public async Task FindByOrderRequestReceivedDateDtoAsync_ReturnsEmptyList_WhenNoOrdersExist()
        {
            // Arrange
            var minDate = DateTime.MinValue;
            var maxDate = DateTime.MaxValue;
            _orderRepository.FindByOrderRequestReceivedDateAsync(minDate, maxDate).Returns(new List<Order>());

            // Act
            var result = await _orderDtoService.FindByOrderRequestReceivedDateDtoAsync(minDate, maxDate);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    public class AverageTests : OrderDtoServiceTests
    {
        [Fact]
        public async Task Average_ReturnsCorrectAverage()
        {
            // Arrange
            var orderDtos = new List<OrderDto>
            {
                new(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto, _userDeliveryDto,
                    _paymentMethodDto),
                new(2, 200, 3, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto, _userDeliveryDto,
                    _paymentMethodDto)
            };

            _orderRepository.GetEntitiesAsync().Returns(new List<Order> { new(), new() });
            _mapper.Map<IEnumerable<OrderDto>>(Arg.Any<IEnumerable<Order>>()).Returns(orderDtos);

            // Act
            var result = await _orderDtoService.Average();

            // Assert
            Assert.Equal(150, result);
        }

        [Fact]
        public async Task Average_ReturnsZero_WhenNoOrdersExist()
        {
            // Arrange
            _orderRepository.GetEntitiesAsync().Returns(new List<Order>());

            // Act
            var result = await _orderDtoService.Average();

            // Assert
            Assert.Equal(0, result);
        }
    }

    public class OrderDtoIdNullTests
    {
        [Fact]
        public void OrderDtoIdNull_ShouldThrowArgumentNullException_WhenIdIsNull()
        {
            // Arrange
            int? id = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => OrderDtoService.OrderDtoIdNull(id));
        }

        [Fact]
        public void OrderDtoIdNull_ShouldNotThrowException_WhenIdIsNotNull()
        {
            // Arrange
            int? id = 1;

            // Act & Assert
            Assert.Null(Record.Exception(() => OrderDtoService.OrderDtoIdNull(id)));
        }
    }

    public class OrderDtoNullTests : OrderDtoServiceTests
    {
        [Fact]
        public void OrderDtoNull_ShouldThrowArgumentNullException_WhenCategoryDtoIsNull()
        {
            // Arrange
            OrderDto? orderDto = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => OrderDtoService.OrderDtoNull(orderDto));
        }

        [Fact]
        public void OrderDtoNull_ShouldNotThrowException_WhenCategoryDtoIsNotNull()
        {
            // Arrange
            var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto,
                _userDeliveryDto, _paymentMethodDto);

            // Act & Assert
            Assert.Null(Record.Exception(() => OrderDtoService.OrderDtoNull(orderDto)));
        }
    }

    [Fact]
    public async Task AddOrder_CallsRepositoryCreateOrder_WhenOrderIsValid()
    {
        // Arrange
        var orderDto = new OrderDto(1, 100, 2, DateTime.Now, DateTime.Now, DateTime.Now, [], _deliveryAddressDto,
            _userDeliveryDto, _paymentMethodDto);
        var order = new Order();

        _mapper.Map<Order>(orderDto).Returns(order);

        // Act
        await _orderDtoService.AddOrder(orderDto, EPaymentMethod.CreditCard);

        // Assert
        await _orderRepository.Received(1).CreateOrder(order, EPaymentMethod.CreditCard);
    }

    [Fact]
    public void GetSalesByMonth_ReturnsCorrectSalesByMonth()
    {
        // Arrange
        var orderDtos = new List<OrderDto>
        {
            new(1, 100, 2, new DateTime(2022, 1, 1), DateTime.Now, DateTime.Now, [], _deliveryAddressDto,
                _userDeliveryDto, _paymentMethodDto),
            new(2, 200, 3, new DateTime(2022, 1, 15), DateTime.Now, DateTime.Now, [], _deliveryAddressDto,
                _userDeliveryDto, _paymentMethodDto),
            new(3, 300, 4, new DateTime(2022, 2, 1), DateTime.Now, DateTime.Now, [], _deliveryAddressDto,
                _userDeliveryDto, _paymentMethodDto)
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
}