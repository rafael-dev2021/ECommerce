using Domain.Entities.Payments;

namespace Domain.Entities.Orders;

public class OrderDetail
{
    public int Id { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public int ProductId { get; private set; }
    public Product? Product { get; }
    public int OrderId { get; private set; }
    public Order? Order { get; }
    public int PaymentMethodId { get; private set; }
    public PaymentMethod? PaymentMethod { get; private set; }

    public OrderDetail()
    {
    }

    public OrderDetail(int quantity, decimal price, int orderId, int productId, int paymentMethodId)
    {
        Quantity = quantity;
        Price = price;
        OrderId = orderId;
        ProductId = productId;
        PaymentMethodId = paymentMethodId;
    }

    public void SetId(int id) => Id = id;
    public void SetQuantity(int quantity) => Quantity = quantity;
    public void SetPrice(decimal price) => Price = price;
    public void SetOrderId(int orderId) => OrderId = orderId;
    public void SetProductId(int productId) => ProductId = productId;
    public void SetPaymentMethodId(int paymentMethodId) => PaymentMethodId = paymentMethodId;
}