using Application.CQRS.Command.Products.Technology.Smartphones;
using Application.CQRS.Queries.Products.Technology.Smartphones;
using Application.Dtos.Products.Technology.Smartphones;
using Application.Services.Entities.Products.Technology;
using AutoMapper;
using Domain.Entities.Products.Technology.Smartphones;
using MediatR;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities.Technology;

public class SmartphoneDtoServiceTests
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly SmartphoneDtoService _smartphoneDtoService;

    public SmartphoneDtoServiceTests()
    {
        _mediator = Substitute.For<IMediator>();
        _mapper = Substitute.For<IMapper>();
        _smartphoneDtoService = new SmartphoneDtoService(_mediator, _mapper);
    }

    [Fact]
    public async Task GetEntitiesDtoAsync_ReturnsEmptyList_WhenNoSmartphonesExist()
    {
        // Arrange
        _mediator.Send(Arg.Any<SmartphonesQueries>()).Returns(new List<Smartphone>());

        // Act
        var result = await _smartphoneDtoService.GetEntitiesDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsMappedSmartphone_WhenSmartphoneExists()
    {
        // Arrange
        var smartphone = new Smartphone(1, "", "", [], 1, 1);
        var smartphoneDto = new SmartphoneDto();

        _mediator.Send(Arg.Any<GetByIdSmartphoneQuery>()).Returns(smartphone);
        _mapper.Map<SmartphoneDto>(smartphone).Returns(smartphoneDto);

        // Act
        var result = await _smartphoneDtoService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(smartphoneDto, result);
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _smartphoneDtoService.GetByIdAsync(null));
    }

    [Fact]
    public async Task AddAsync_SendsCreateSmartphoneCommand_WhenCalled()
    {
        // Arrange
        var smartphoneDto = new SmartphoneDto();
        var createCommand = new CreateSmartphoneCommand();

        _mapper.Map<CreateSmartphoneCommand>(smartphoneDto).Returns(createCommand);

        // Act
        await _smartphoneDtoService.AddAsync(smartphoneDto);

        // Assert
        await _mediator.Received(1).Send(createCommand);
    }

    [Fact]
    public async Task UpdateAsync_SendsUpdateSmartphoneCommand_WhenCalled()
    {
        // Arrange
        var smartphoneDto = new SmartphoneDto();
        var updateCommand = new UpdateSmartphoneCommand();

        _mapper.Map<UpdateSmartphoneCommand>(smartphoneDto).Returns(updateCommand);

        // Act
        await _smartphoneDtoService.UpdateAsync(smartphoneDto);

        // Assert
        await _mediator.Received(1).Send(updateCommand);
    }

    [Fact]
    public async Task DeleteAsync_SendsRemoveSmartphoneCommand_WhenIdIsValid()
    {
        // Arrange
        var id = 1;
        var removeCommand = new RemoveSmartphoneCommand(id);

        // Act
        await _smartphoneDtoService.DeleteAsync(id);

        // Assert
        await _mediator.Received(1).Send(
            Arg.Is<RemoveSmartphoneCommand>(cmd => cmd.Id == id),
            Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task DeleteAsync_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _smartphoneDtoService.DeleteAsync(null));
    }
}
