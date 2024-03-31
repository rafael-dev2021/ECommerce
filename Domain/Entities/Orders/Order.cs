using Domain.Entities.Deliveries;
using Domain.Entities.Payments;

namespace Domain.Entities.Orders;

public class Order
{
    public int Id { get; private set; }
    public decimal TotalOrder { get; private set; }
    public int TotalItemsOrder { get; private set; }
    public DateTime ConfirmedOrder { get; private set; }
    public DateTime DispatchedOrder { get; private set; }
    public DateTime RequestReceived { get; private set; }
    public List<OrderDetail> OrderDetails { get; } = [];
    public DeliveryAddress DeliveryAddress { get; set; } = new DeliveryAddress();
    public UserDelivery UserDelivery { get; set; } = new UserDelivery();
    public PaymentMethod? PaymentMethod { get; private set; }


    public void SetId(int id) => Id = id;
    public void SetTotalOrder(decimal totalOrder) => TotalOrder = totalOrder;
    public void SetTotalItemsOrder(int totalItemsOrder) => TotalItemsOrder = totalItemsOrder;
    public void SetConfirmedOrder(DateTime confirmedOrder) => ConfirmedOrder = confirmedOrder;
    public void SetDispatchedOrder(DateTime dispatchedOrder) => DispatchedOrder = dispatchedOrder;
    public void SetRequestReceived(DateTime requestReceived) => RequestReceived = requestReceived;

    public void Update(DateTime dispatchedOrder, DateTime requestReceived)
    {
        DispatchedOrder = dispatchedOrder;
        RequestReceived = requestReceived;
    }

    public void WhenConfirmedOrder() => ConfirmedOrder = DateTime.Now;
}