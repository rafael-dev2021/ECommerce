using System.Linq.Expressions;
using Domain.Entities;
using Domain.Entities.Cart;
using Domain.Entities.Orders;
using Domain.Entities.Payments.Enums;
using Domain.Interfaces;
using Infra_Data.Context;
using Infra_Data.CustomExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infra_Data.Repositories.Orders.Helpers;

public class OrderRepositoryHelper(AppDbContext appDbContext, IShoppingCartItemRepository shoppingCartItemRepository)
{
    public async Task<IEnumerable<Order>> FindOrdersByDateAsync(
        DateTime? minDate,
        DateTime? maxDate,
        Expression<Func<Order, DateTime>> datePropertySelector)
    {
        return await appDbContext.Orders
            .AsNoTracking()
            .Include(o => o.OrderDetails)
            .ThenInclude(p => p.Product)
            .Include(x => x.UserDelivery)
            .Include(x => x.DeliveryAddress)
            .Where(x => !minDate.HasValue ||
                        EF.Property<DateTime>(x, datePropertySelector
                            .GetPropertyAccess().Name).Date >= minDate.Value.Date)
            .Where(x => !maxDate.HasValue ||
                        EF.Property<DateTime>(x, datePropertySelector
                            .GetPropertyAccess().Name).Date <= maxDate.Value.Date)
            .OrderByDescending(datePropertySelector)
            .ToListAsync();
    }

    public static void ConfirmOrder(Order order, EPaymentMethod ePaymentMethod)
    {
        order.WhenConfirmedOrder();
        order.PaymentMethod?.DefaultPayment(ePaymentMethod);

        if (order.PaymentMethod?.PaymentMethodObjectValue.PaymentStatusObjectValue.EPaymentStatus !=
            EPaymentStatus.Approved)
        {
            throw new OrderRepositoryHelperException("Payment was declined.");
        }
    }

    public async Task SaveMainOrder(Order order)
    {
        await appDbContext.AddAsync(order);
        await appDbContext.SaveChangesAsync();
    }

    public async Task ProcessShoppingCartItems(Order order)
    {
        var cartItems = await shoppingCartItemRepository.GetShoppingCartItemsAsync();

        foreach (var cartItem in cartItems)
        {
            await ProcessCartItem(order, cartItem);
        }
    }

    public async Task ProcessCartItem(Order order, ShoppingCartItem cartItem)
    {
        var product = await GetProductById(cartItem.Product?.Id ?? cartItem.ProductId);

        if (product.Stock < cartItem.Quantity)
        {
            throw new OrderRepositoryHelperException("Product stock not available.");
        }

        ReduceProductStock(product, cartItem.Quantity);
        await CreateOrderDetail(order, cartItem);
    }

    public async Task<Product> GetProductById(int productId)
    {
        var product = await appDbContext.Products.FindAsync(productId);
        if (product == null)
        {
            throw new OrderRepositoryHelperException("Product not found.");
        }

        return product;
    }

    private static void ReduceProductStock(Product product, int quantity)
    {
        product.SetStock(product.Stock - quantity);
    }

    private async Task CreateOrderDetail(Order order, ShoppingCartItem cartItem)
    {
        var orderDetails = new OrderDetail
        (
            cartItem.Quantity,
            cartItem.Product.PriceObjectValue.Price,
            order.Id,
            cartItem.Product.Id,
            order.PaymentMethod.Id
        );

        await appDbContext.OrdersDetails.AddAsync(orderDetails);

        await appDbContext.SaveChangesAsync();
    }
}