using Application.CQRS.Command.Products.Fashion.T_Shirts;
using Application.CQRS.Queries.Products.Fashion.T_Shirts;
using Application.Dtos.Products.Fashion.T_Shirts;
using Application.Services.Entities.Products.Fashion;
using AutoMapper;
using Domain.Entities.Products.Fashion.T_Shirts;
using MediatR;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities.Fashion;

public class ShirtDtoServiceTests
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ShirtDtoService _shirtDtoService;

    public ShirtDtoServiceTests()
    {
        _mediator = Substitute.For<IMediator>();
        _mapper = Substitute.For<IMapper>();
        _shirtDtoService = new ShirtDtoService(_mediator, _mapper);
    }


    [Fact]
    public async Task GetEntitiesDtoAsync_ReturnsMappedShirts_WhenShirtsExist()
    {
        // Arrange
        var shirts = new List<Shirt> { new(1, "", "", [], 1, 1) };
        var shirtDtos = new List<ShirtDto> { new() };

        _mediator.Send(Arg.Any<ShirtsQueries>()).Returns(shirts);
        _mapper.Map<IEnumerable<ShirtDto>>(shirts).Returns(shirtDtos);

        // Act
        var result = await _shirtDtoService.GetEntitiesDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(shirtDtos, result);
    }

    [Fact]
    public async Task GetEntitiesDtoAsync_ReturnsEmptyList_WhenNoShirtsExist()
    {
        // Arrange
        _mediator.Send(Arg.Any<ShirtsQueries>()).Returns(new List<Shirt>());

        // Act
        var result = await _shirtDtoService.GetEntitiesDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsMappedShirt_WhenShirtExists()
    {
        // Arrange
        var shirt = new Shirt(1, "", "", [], 1, 1);
        var shirtDto = new ShirtDto();

        _mediator.Send(Arg.Any<GetByIdShirtQuery>()).Returns(shirt);
        _mapper.Map<ShirtDto>(shirt).Returns(shirtDto);

        // Act
        var result = await _shirtDtoService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(shirtDto, result);
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _shirtDtoService.GetByIdAsync(null));
    }

    [Fact]
    public async Task AddAsync_SendsCreateShirtCommand_WhenCalled()
    {
        // Arrange
        var shirtDto = new ShirtDto();
        var createCommand = new CreateShirtCommand();

        _mapper.Map<CreateShirtCommand>(shirtDto).Returns(createCommand);

        // Act
        await _shirtDtoService.AddAsync(shirtDto);

        // Assert
        await _mediator.Received(1).Send(createCommand);
    }

    [Fact]
    public async Task UpdateAsync_SendsUpdateShirtCommand_WhenCalled()
    {
        // Arrange
        var shirtDto = new ShirtDto();
        var updateCommand = new UpdateShirtCommand();

        _mapper.Map<UpdateShirtCommand>(shirtDto).Returns(updateCommand);

        // Act
        await _shirtDtoService.UpdateAsync(shirtDto);

        // Assert
        await _mediator.Received(1).Send(updateCommand);
    }

    [Fact]
    public async Task DeleteAsync_SendsRemoveShirtCommand_WhenIdIsValid()
    {
        // Arrange
        var id = 1;
        var removeCommand = new RemoveShirtCommand(id);

        // Act
        await _shirtDtoService.DeleteAsync(id);

        // Assert
        await _mediator.Received(1).Send(
            Arg.Is<RemoveShirtCommand>(cmd => cmd.Id == id),
            Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task DeleteAsync_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _shirtDtoService.DeleteAsync(null));
    }
}
