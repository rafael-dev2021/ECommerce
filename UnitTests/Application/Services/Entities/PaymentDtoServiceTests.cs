using Application.CustomExceptions;
using Application.Dtos.PaymentsDto;
using Application.Services.Entities;
using AutoMapper;
using Domain.Entities.Payments;
using Domain.Interfaces.Payments;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities;

public class PaymentDtoServiceTests
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;
    private readonly PaymentDtoService _paymentDtoService;

    protected PaymentDtoServiceTests()
    {
        _paymentRepository = Substitute.For<IPaymentRepository>();
        _mapper = Substitute.For<IMapper>();
        _paymentDtoService = new PaymentDtoService(_paymentRepository, _mapper);
    }

    public class ListPaymentsDtoAsyncTests : PaymentDtoServiceTests
    {
        [Fact]
        public async Task ListPaymentsDtoAsync_ReturnsMappedPayments_WhenPaymentsExist()
        {
            // Arrange
            var payments = new List<PaymentMethod> { new() };
            var paymentsDto = new List<PaymentMethodDto> { new(new CreditCardDto(), new DebitCardDto()) };

            _paymentRepository.ListPaymentsAsync().Returns(payments);
            _mapper.Map<IEnumerable<PaymentMethodDto>>(payments).Returns(paymentsDto);

            // Act
            var result = await _paymentDtoService.ListPaymentsDtoAsync();

            // Assert
            Assert.NotNull(result);
            var paymentMethodDtos = result as PaymentMethodDto[] ?? result.ToArray();
            Assert.Single(paymentMethodDtos);
            Assert.Equal(paymentsDto, paymentMethodDtos);
        }

        [Fact]
        public async Task ListPaymentsDtoAsync_ReturnsEmptyList_WhenNoPaymentsExist()
        {
            // Arrange
            _paymentRepository.ListPaymentsAsync().Returns(new List<PaymentMethod>());

            // Act
            var result = await _paymentDtoService.ListPaymentsDtoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task ListPaymentsDtoAsync_ReturnsEmptyList_WhenPaymentsAreNull()
        {
            // Arrange
            _paymentRepository.ListPaymentsAsync().ReturnsNull();

            // Act
            var result = await _paymentDtoService.ListPaymentsDtoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    public class ListPaymentCreditCardsDtoAsyncTests : PaymentDtoServiceTests
    {
        [Fact]
        public async Task ListPaymentCreditCardsDtoAsync_ReturnsMappedCreditCards_WhenCreditCardsExist()
        {
            // Arrange
            var creditCards = new List<CreditCard> { new() };
            var creditCardsDto = new List<CreditCardDto>
            {
                new()
                {
                    Id = creditCards[0].Id,
                    CardNumber = "1234",
                    CardHolderName = "Test",
                    CardExpirationDate = "12/24",
                    CardCvv = "123",
                    Ssn = "12344335"
                }
            };

            _paymentRepository.ListPaymentCreditCardsAsync().Returns(creditCards);
            _mapper.Map<IEnumerable<CreditCardDto>>(creditCards).Returns(creditCardsDto);

            // Act
            var result = await _paymentDtoService.ListPaymentCreditCardsDtoAsync();

            // Assert
            Assert.NotNull(result);
            var creditCardDtos = result as CreditCardDto[] ?? result.ToArray();
            Assert.Single(creditCardDtos);
            Assert.Equal(creditCardsDto, creditCardDtos);
        }

        [Fact]
        public async Task ListPaymentCreditCardsDtoAsync_ReturnsEmptyList_WhenCreditCardsAreNull()
        {
            // Arrange
            _paymentRepository.ListPaymentCreditCardsAsync().ReturnsNull();

            // Act
            var result = await _paymentDtoService.ListPaymentCreditCardsDtoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    public class ListPaymentDebitCardsDtoAsyncTests : PaymentDtoServiceTests
    {
        [Fact]
        public async Task ListPaymentDebitCardsDtoAsync_ReturnsMappedDebitCards_WhenDebitCardsExist()
        {
            // Arrange
            var debitCards = new List<DebitCard> { new() };
            var debitCardsDto = new List<DebitCardDto>
            {
                new DebitCardDto
                {
                    Id = debitCards[0].Id,
                    CardNumber = "1234",
                    CardHolderName = "Test",
                    CardExpirationDate = "12/24",
                    CardCvv = "123",
                    Ssn = "12344335"
                }
            };

            _paymentRepository.ListPaymentDebitCardsAsync().Returns(debitCards);
            _mapper.Map<IEnumerable<DebitCardDto>>(debitCards).Returns(debitCardsDto);

            // Act
            var result = await _paymentDtoService.ListPaymentDebitCardsDtoAsync();

            // Assert
            Assert.NotNull(result);
            var debitCardDtos = result.ToList();
            Assert.Single(debitCardDtos);
            Assert.Equal(debitCardsDto, debitCardDtos);
        }

        [Fact]
        public async Task ListPaymentDebitCardsDtoAsync_ReturnsEmptyList_WhenDebitCardsAreNull()
        {
            // Arrange
            _paymentRepository.ListPaymentDebitCardsAsync().ReturnsNull();

            // Act
            var result = await _paymentDtoService.ListPaymentDebitCardsDtoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    public class GetByIdPaymentDtoAsyncTests : PaymentDtoServiceTests
    {
        [Fact]
        public async Task GetByIdPaymentDtoAsync_ReturnsMappedPayment_WhenPaymentExists()
        {
            // Arrange
            var payment = new PaymentMethod();
            var paymentDto = new PaymentMethodDto(new CreditCardDto(), new DebitCardDto());

            _paymentRepository.GetByIdPaymentAsync(1).Returns(payment);
            _mapper.Map<PaymentMethodDto>(payment).Returns(paymentDto);

            // Act
            var result = await _paymentDtoService.GetByIdPaymentDtoAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(paymentDto, result);
        }

        [Fact]
        public async Task GetByIdPaymentDtoAsync_ShouldThrowsOrderException_WhenRepositoryThrowsException()
        {
            // Arrange
            int? id = 1;
            _paymentRepository.GetByIdPaymentAsync(id)
                .Returns(Task.FromException<PaymentMethod>(new Exception("ID not found")));

            // Act & Assert
            await Assert.ThrowsAsync<PaymentException>(async () => await _paymentDtoService.GetByIdPaymentDtoAsync(id));
        }

        [Fact]
        public async Task GetByIdPaymentCreditCardDtoAsync_ReturnsMappedCreditCard_WhenCreditCardExists()
        {
            // Arrange
            var creditCard = new CreditCard();
            var creditCardDto = new CreditCardDto
            {
                Id = creditCard.Id,
                CardNumber = "1234",
                CardHolderName = "Test",
                CardExpirationDate = "12/24",
                CardCvv = "123",
                Ssn = "12344335"
            };

            _paymentRepository.GetByIdPaymentCreditCardAsync(creditCard.Id).Returns(creditCard);
            _mapper.Map<CreditCardDto>(creditCard).Returns(creditCardDto);

            // Act
            var result = await _paymentDtoService.GetByIdPaymentCreditCardDtoAsync(creditCard.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(creditCardDto, result);
        }

        [Fact]
        public async Task GetByIdPaymentCreditCardDtoAsync_ShouldThrowsPaymentException_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid? id = new Guid();

            _paymentRepository.GetByIdPaymentCreditCardAsync(id).ThrowsAsync(new PaymentException("ID not found"));

            // Act & Assert
            await Assert.ThrowsAsync<PaymentException>(() => _paymentDtoService.GetByIdPaymentCreditCardDtoAsync(id));
        }

        [Fact]
        public async Task GetByIdPaymentDebitCardDtoAsync_ReturnsMappedDebitCard_WhenDebitCardExists()
        {
            // Arrange
            var debitCard = new DebitCard();
            var debitCardDto = new DebitCardDto
            {
                Id = debitCard.Id,
                CardNumber = "1234",
                CardHolderName = "Test",
                CardExpirationDate = "12/24",
                CardCvv = "123",
                Ssn = "12344335"
            };

            _paymentRepository.GetByIdPaymentDebitCardAsync(debitCard.Id).Returns(debitCard);
            _mapper.Map<DebitCardDto>(debitCard).Returns(debitCardDto);

            // Act
            var result = await _paymentDtoService.GetByIdPaymentDebitCardDtoAsync(debitCard.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(debitCardDto, result);
        }

        [Fact]
        public async Task GetByIdPaymentDebitCardDtoAsync_ShouldThrowsPaymentException_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid? id = new Guid();

            _paymentRepository.GetByIdPaymentDebitCardAsync(id).ThrowsAsync(new PaymentException("ID not found"));

            // Act & Assert
            await Assert.ThrowsAsync<PaymentException>(() => _paymentDtoService.GetByIdPaymentDebitCardDtoAsync(id));
        }
    }
}