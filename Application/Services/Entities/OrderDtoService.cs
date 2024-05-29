using Application.CustomExceptions;
using Application.Dtos.OrderDtos;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Entities.Payments.Enums;
using Domain.Interfaces;

namespace Application.Services.Entities;

public class OrderDtoService(IMapper mapper, IOrderRepository orderRepository) : IOrderDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<IEnumerable<OrderDto>> GetOrdersDtoAsync()
    {
        var ordersDto = await _orderRepository.GetEntitiesAsync();

        if (ordersDto == null || !ordersDto.Any()) return [];

        return _mapper.Map<IEnumerable<OrderDto>>(ordersDto);
    }

    public IQueryable<OrderDto> GetPagingListOrdersDto(string filter)
    {
        var ordersDto = _orderRepository.GetPagingListOrders(filter);

        if (ordersDto == null || !ordersDto.Any())
        {
            return Enumerable.Empty<OrderDto>().AsQueryable();
        }

        return _mapper.ProjectTo<OrderDto>(ordersDto.AsQueryable());
    }

    public async Task<OrderDto> GetByIdAsync(int? id)
    {
        OrderDtoIdNull(id);

        try
        {
            var getOrderId = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(getOrderId);
        }
        catch (Exception ex)
        {
            throw new OrderException($"An error occurred while retrieving the order with ID {id}.", ex);
        }
    }

    public async Task AddOrder(OrderDto orderDto, EPaymentMethod ePaymentMethod)
    {
        OrderDtoNull(orderDto);

        var addOrder = _mapper.Map<Order>(orderDto);

        await _orderRepository.CreateOrder(addOrder, ePaymentMethod);
    }

    public async Task UpdateOrderPropertyAsync(OrderDto orderDto)
    {
        OrderDtoNull(orderDto);

        try
        {
            var updateOrder = _mapper.Map<Order>(orderDto) ?? throw new RequestException(new RequestError()
            {
                Message = "Failed to map OrderDto to Order.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.BadRequest,
            });
            await _orderRepository.UpdateAsync(updateOrder);
        }
        catch (Exception ex)
        {
            throw new OrderException("Error updating order.", ex);
        }
    }

    public async Task DeleteOrder(int? id)
    {
        OrderDtoIdNull(id);

        try
        {
            var deleteOrder = await _orderRepository.GetByIdAsync(id) ??
                throw new OrderException($"Order with ID {id} not found.");

            await _orderRepository.DeleteAsync(deleteOrder);
        }
        catch (Exception ex)
        {
            throw new OrderException("Error deleting order.", ex);
        }
    }

    public async Task<IEnumerable<OrderDetailDto>> GetOrdersDetailsAsync()
    {
        var ordersDto = await _orderRepository.GetOrdersDetailsAsync();

        if (ordersDto == null || !ordersDto.Any()) return [];

        return _mapper.Map<IEnumerable<OrderDetailDto>>(ordersDto);
    }

    public async Task<IEnumerable<OrderDto>> FindByOrderConfirmDateDtoAsync(DateTime? minDate, DateTime? maxDate)
    {
        var orders = await _orderRepository.FindByOrderConfirmDateAsync(minDate, maxDate);

        if (orders == null || !orders.Any()) return [];

        var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

        return orderDtos;
    }

    public async Task<IEnumerable<OrderDto>> FindByOrderDispatchedDateDtoAsync(DateTime? minDate, DateTime? maxDate)
    {
        var orders = await _orderRepository.FindByOrderDispatchedDateAsync(minDate, maxDate);

        if (orders == null || !orders.Any()) return [];

        var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

        return orderDtos;
    }

    public async Task<IEnumerable<OrderDto>> FindByOrderRequestReceivedDateDtoAsync(DateTime? minDate, DateTime? maxDate)
    {
        var orders = await _orderRepository.FindByOrderRequestReceivedDateAsync(minDate, maxDate);

        if (orders == null || !orders.Any()) return [];

        var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

        return orderDtos;
    }

    public List<SalesByMonthDto> GetSalesByMonth(IEnumerable<OrderDto> orderDtos)
    {
        var salesByMonth = orderDtos
            .GroupBy(order => new { order.ConfirmedOrder.Year, order.ConfirmedOrder.Month })
            .Select(group => new SalesByMonthDto
            {
                Year = group.Key.Year,
                Month = group.Key.Month,
                TotalSales = group.Sum(order => order.TotalOrder)
            })
            .OrderBy(group => group.Year)
            .ThenBy(group => group.Month)
            .ToList();

        return salesByMonth;
    }

    public async Task<decimal> Average()
    {
        decimal totalSum = 0;

        var orders = await GetOrdersDtoAsync();

        if (orders != null)
        {
            int totalCount = orders.Count();
            foreach (var item in orders)
            {
                totalSum += item.TotalOrder;
            }

            if (totalCount > 0)
            {
                decimal average = totalSum / totalCount;
                return average;
            }
        }
        return 0;
    }

    public static void OrderDtoIdNull(int? id)
    {
        if (!id.HasValue)
            throw new ArgumentNullException(nameof(id), "Order ID cannot be null.");
    }

    public static void OrderDtoNull(OrderDto? orderDto)
    {
        if (orderDto == null)
            throw new ArgumentNullException(nameof(orderDto), "OrderDto cannot be null.");
    }
}

