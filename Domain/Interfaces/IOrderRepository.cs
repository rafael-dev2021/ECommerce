using Domain.Entities.Orders;
using Domain.Entities.Payments.Enums;

namespace Domain.Interfaces;

public interface IOrderRepository : IGenericCRUDRepository<Order>
{
    IQueryable<Order> GetPagingListOrders(string filter);
    Task<IEnumerable<OrderDetail>> GetOrdersDetailsAsync();
    Task<IEnumerable<Order>> FindByOrderConfirmDateAsync(DateTime? minDate, DateTime? maxDate);
    Task<IEnumerable<Order>> FindByOrderDispatchedDateAsync(DateTime? minDate, DateTime? maxDate);
    Task<IEnumerable<Order>> FindByOrderRequestReceivedDateAsync(DateTime? minDate, DateTime? maxDate);
    Task CreateOrder(Order order, EPaymentMethod ePaymentMethod);
}