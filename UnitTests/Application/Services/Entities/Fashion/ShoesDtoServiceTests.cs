using Application.CQRS.Command.Products.Fashion.Shoes;
using Application.CQRS.Queries.Products.Fashion.Shoes;
using Application.Dtos.Products.Fashion.Shoes;
using Application.Services.Entities.Products.Fashion;
using AutoMapper;
using Domain.Entities.Products.Fashion.Shoes;
using MediatR;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities.Fashion;

public class ShoesDtoServiceTests
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ShoesDtoService _shoesDtoService;

    public ShoesDtoServiceTests()
    {
        _mediator = Substitute.For<IMediator>();
        _mapper = Substitute.For<IMapper>();
        _shoesDtoService = new ShoesDtoService(_mediator, _mapper);
    }

    [Fact]
    public async Task GetEntitiesDtoAsync_ReturnsMappedShoes_WhenShoesExist()
    {
        // Arrange
        var shoes = new List<Shoe> { new(1, "", "", [], 1, 1) };
        var shoeDtos = new List<ShoeDto> { new() };

        _mediator.Send(Arg.Any<ShoesQueries>()).Returns(shoes);
        _mapper.Map<IEnumerable<ShoeDto>>(shoes).Returns(shoeDtos);

        // Act
        var result = await _shoesDtoService.GetEntitiesDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(shoeDtos, result);
    }

    [Fact]
    public async Task GetEntitiesDtoAsync_ReturnsEmptyList_WhenNoShoesExist()
    {
        // Arrange
        _mediator.Send(Arg.Any<ShoesQueries>()).Returns(new List<Shoe>());

        // Act
        var result = await _shoesDtoService.GetEntitiesDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsMappedShoe_WhenShoeExists()
    {
        // Arrange
        var shoe = new Shoe(1, "", "", [], 1, 1);
        var shoeDto = new ShoeDto();

        _mediator.Send(Arg.Any<GetByIdShoesQuery>()).Returns(shoe);
        _mapper.Map<ShoeDto>(shoe).Returns(shoeDto);

        // Act
        var result = await _shoesDtoService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(shoeDto, result);
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _shoesDtoService.GetByIdAsync(null));
    }

    [Fact]
    public async Task AddAsync_SendsCreateShoesCommand_WhenCalled()
    {
        // Arrange
        var shoeDto = new ShoeDto();
        var createCommand = new CreateShoesCommand();

        _mapper.Map<CreateShoesCommand>(shoeDto).Returns(createCommand);

        // Act
        await _shoesDtoService.AddAsync(shoeDto);

        // Assert
        await _mediator.Received(1).Send(createCommand);
    }

    [Fact]
    public async Task UpdateAsync_SendsUpdateShoesCommand_WhenCalled()
    {
        // Arrange
        var shoeDto = new ShoeDto();
        var updateCommand = new UpdateShoesCommand();

        _mapper.Map<UpdateShoesCommand>(shoeDto).Returns(updateCommand);

        // Act
        await _shoesDtoService.UpdateAsync(shoeDto);

        // Assert
        await _mediator.Received(1).Send(updateCommand);
    }

    [Fact]
    public async Task DeleteAsync_SendsRemoveShoesCommand_WhenIdIsValid()
    {
        // Arrange
        var id = 1;
        var removeCommand = new RemoveShoesCommand(id);

        // Act
        await _shoesDtoService.DeleteAsync(id);

        // Assert
        await _mediator.Received(1).Send(
            Arg.Is<RemoveShoesCommand>(cmd => cmd.Id == id),
            Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task DeleteAsync_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _shoesDtoService.DeleteAsync(null));
    }
}
