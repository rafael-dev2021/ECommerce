using Application.CQRS.Command.Products.Technology.Games;
using Application.CQRS.Queries.Products.Technology.Games;
using Application.Dtos.Products.Technology.Games;
using Application.Services.Entities.Products.Technology;
using AutoMapper;
using Domain.Entities.Products.Technology.Games;
using MediatR;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities.Technology;

public class GameDtoServiceTests
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly GameDtoService _gameDtoService;

    public GameDtoServiceTests()
    {
        _mediator = Substitute.For<IMediator>();
        _mapper = Substitute.For<IMapper>();
        _gameDtoService = new GameDtoService(_mapper, _mediator);
    }

    [Fact]
    public async Task GetEntitiesDtoAsync_ReturnsMappedGames_WhenGamesExist()
    {
        // Arrange
        var games = new List<Game> { new(1, "", "", [], 1, 1) };
        var gameDtos = new List<GameDto> { new() };

        _mediator.Send(Arg.Any<GamesQueries>()).Returns(games);
        _mapper.Map<IEnumerable<GameDto>>(games).Returns(gameDtos);

        // Act
        var result = await _gameDtoService.GetEntitiesDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(gameDtos, result);
    }

    [Fact]
    public async Task GetEntitiesDtoAsync_ReturnsEmptyList_WhenNoGamesExist()
    {
        // Arrange
        _mediator.Send(Arg.Any<GamesQueries>()).Returns(new List<Game>());

        // Act
        var result = await _gameDtoService.GetEntitiesDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsMappedGame_WhenGameExists()
    {
        // Arrange
        var game = new Game(1, "", "", [], 1, 1);
        var gameDto = new GameDto();

        _mediator.Send(Arg.Any<GetByIdGameQuery>()).Returns(game);
        _mapper.Map<GameDto>(game).Returns(gameDto);

        // Act
        var result = await _gameDtoService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(gameDto, result);
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _gameDtoService.GetByIdAsync(null));
    }

    [Fact]
    public async Task AddAsync_SendsCreateGameCommand_WhenCalled()
    {
        // Arrange
        var gameDto = new GameDto();
        var createCommand = new CreateGameCommand();

        _mapper.Map<CreateGameCommand>(gameDto).Returns(createCommand);

        // Act
        await _gameDtoService.AddAsync(gameDto);

        // Assert
        await _mediator.Received(1).Send(createCommand);
    }

    [Fact]
    public async Task UpdateAsync_SendsUpdateGameCommand_WhenCalled()
    {
        // Arrange
        var gameDto = new GameDto();
        var updateCommand = new UpdateGameCommand();

        _mapper.Map<UpdateGameCommand>(gameDto).Returns(updateCommand);

        // Act
        await _gameDtoService.UpdateAsync(gameDto);

        // Assert
        await _mediator.Received(1).Send(updateCommand);
    }

    [Fact]
    public async Task DeleteAsync_SendsRemoveGameCommand_WhenIdIsValid()
    {
        // Arrange
        var id = 1;
        var removeCommand = new RemoveGameCommand(id);

        // Act
        await _gameDtoService.DeleteAsync(id);

        // Assert
        await _mediator.Received(1).Send(
            Arg.Is<RemoveGameCommand>(cmd => cmd.Id == id),
            Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task DeleteAsync_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _gameDtoService.DeleteAsync(null));
    }
}
