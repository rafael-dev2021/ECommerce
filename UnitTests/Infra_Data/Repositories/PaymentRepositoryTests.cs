using Domain.Entities.Payments;
using Infra_Data.Context;
using Infra_Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories;

public class PaymentRepositoryTests
{
    private static AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDatabase-{Guid.NewGuid()}")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task ListPaymentsAsync_ShouldReturnPaymentMethods()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new PaymentRepository(context);

        var creditCard = new CreditCard();
        var debitCard = new DebitCard();
        var paymentMethod = new PaymentMethod();

        context.CreditCards.Add(creditCard);
        context.DebitCards.Add(debitCard);
        context.PaymentMethods.Add(paymentMethod);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.ListPaymentsAsync();

        // Assert
        Assert.Single(result);
    }

    [Fact]
    public async Task GetByIdPaymentAsync_ShouldReturnPaymentMethod()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new PaymentRepository(context);

        var paymentMethod = new PaymentMethod();
        context.PaymentMethods.Add(paymentMethod);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdPaymentAsync(paymentMethod.Id);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ListPaymentCreditCardsAsync_ShouldReturnCreditCards()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new PaymentRepository(context);

        var creditCard1 = new CreditCard();
        var creditCard2 = new CreditCard();
        context.CreditCards.AddRange(creditCard1, creditCard2);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.ListPaymentCreditCardsAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task ListPaymentDebitCardsAsync_ShouldReturnDebitCards()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new PaymentRepository(context);

        var debitCard1 = new DebitCard();
        var debitCard2 = new DebitCard();
        context.DebitCards.AddRange(debitCard1, debitCard2);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.ListPaymentDebitCardsAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }
}
