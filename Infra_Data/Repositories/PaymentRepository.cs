using Domain.Entities.Payments;
using Domain.Interfaces.Payments;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories;

public class PaymentRepository(AppDbContext appDbContext) : IPaymentRepository
{
    public async Task<IEnumerable<PaymentMethod>> ListPaymentsAsync() =>
        await appDbContext.PaymentMethods
            .AsNoTracking()
            .Include(x => x.PaymentMethodObjectValue)
            .ThenInclude(x => x.PaymentStatusObjectValue)
            .ToListAsync();

    public async Task<IEnumerable<CreditCard>> ListPaymentCreditCardsAsync() =>
        await appDbContext.CreditCards
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync();

    public async Task<IEnumerable<DebitCard>> ListPaymentDebitCardsAsync() =>
        await appDbContext.DebitCards
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync();

    public async Task<PaymentMethod> GetByIdPaymentAsync(int? id) =>
        await appDbContext.PaymentMethods
            .Include(x => x.PaymentMethodObjectValue)
            .ThenInclude(x => x.PaymentStatusObjectValue)
            .FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException();

    public async Task<CreditCard> GetByIdPaymentCreditCardAsync(Guid? id) =>
        await appDbContext.CreditCards.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<DebitCard> GetByIdPaymentDebitCardAsync(Guid? id) =>
        await appDbContext.DebitCards.FirstOrDefaultAsync(x => x.Id == id);
}