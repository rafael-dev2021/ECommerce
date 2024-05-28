using Application.CQRS.Queries;
using Application.Dtos;
using Application.Services.Entities;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities;

public class ProductDtoServiceTests
{

    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ProductDtoService _productDtoService;

    public ProductDtoServiceTests()
    {
        _mapper = Substitute.For<IMapper>();
        _mediator = Substitute.For<IMediator>();
        _productDtoService = new ProductDtoService(_mapper, _mediator);
    }

    [Fact]
    public async Task GetProductsDtoAsync_ReturnsMappedProducts_WhenProductsExist()
    {
        // Arrange
        var products = new List<Product> { new() };
        var productDtos = new List<ProductDto> { new() {
            Id = 1,
            Name = "Test Product",
            Description = "Description",
            ImagesUrl= [],
            Stock = 1} };

        _mediator.Send(Arg.Any<ProductsQueries>()).Returns(products);
        _mapper.Map<IEnumerable<ProductDto>>(products).Returns(productDtos);

        // Act
        var result = await _productDtoService.GetProductsDtoAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(productDtos, result);
    }

    [Fact]
    [Test]
    public async Task GetProductsDtoFavoritesAsync_ReturnsMappedProducts_WhenProductsExist()
    {
        // Arrange
        var favoriteProducts = new List<Product> { new() };
        var favoriteProductDtos = new List<ProductDto> { new() {
            Id = 1,
            Name = "Test Product",
            Description = "Description",
            ImagesUrl= [],
            Stock = 1} };

        _mediator.Send(Arg.Any<ProductsFavoritesQueries>()).Returns(favoriteProducts);
        _mapper.Map<IEnumerable<ProductDto>>(favoriteProducts).Returns(favoriteProductDtos);

        // Act
        var result = await _productDtoService.GetProductsDtoFavoritesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(favoriteProductDtos, result);
    }


    [Fact]
    [Test]
    public async Task GetProductsDtoDailyOffersAsync_ReturnsMappedProducts_WhenProductsExist()
    {
        // Arrange
        var dailyOfferProducts = new List<Product> { new(1, "Daily Offer Productt", "Description", [], 1, 1) };
        var dailyOfferProductDtos = new List<ProductDto> { new() { Id = 1, Name = "Daily Offer Product" } };

        _mediator.Send(Arg.Any<ProductsDailyOfferQueries>()).Returns(dailyOfferProducts);
        _mapper.Map<IEnumerable<ProductDto>>(dailyOfferProducts).Returns(dailyOfferProductDtos);

        // Act
        var result = await _productDtoService.GetProductsDtoDailyOffersAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(dailyOfferProductDtos, result);
    }

    [Fact]
    [Test]
    public async Task GetProductsDtoBestSellersAsync_ReturnsMappedProducts_WhenProductsExist()
    {
        // Arrange
        var bestSellerProducts = new List<Product> { new(1, "Best Seller Productt", "Description", [], 1, 1) };
        var bestSellerProductDtos = new List<ProductDto> { new() { Id = 1, Name = "Best Seller Product" } };

        _mediator.Send(Arg.Any<ProductsBestSellerQueries>()).Returns(bestSellerProducts);
        _mapper.Map<IEnumerable<ProductDto>>(bestSellerProducts).Returns(bestSellerProductDtos);

        // Act
        var result = await _productDtoService.GetProductsDtoBestSellersAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(bestSellerProductDtos, result);
    }

    [Fact]
    [Test]
    public async Task GetProductsDtoByCategoriesAsync_ReturnsMappedProducts_WhenProductsExist()
    {
        // Arrange
        var category = "Electronics";
        var productsByCategory = new List<Product> { new(1, "Category Productt", "Description", [], 1, 1) };
        var productDtosByCategory = new List<ProductDto> { new() { Id = 1, Name = "Category Product" } };

        _mediator.Send(Arg.Any<ProductByCategoryQueries>()).Returns(productsByCategory);
        _mapper.Map<IEnumerable<ProductDto>>(productsByCategory).Returns(productDtosByCategory);

        // Act
        var result = await _productDtoService.GetProductsDtoByCategoriesAsync(category);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(productDtosByCategory, result);
    }

    [Fact]
    [Test]
    public async Task GetSearchProductsDtoAsync_ReturnsMappedProducts_WhenProductsExist()
    {
        // Arrange
        var keyword = "Test";
        var searchProducts = new List<Product> { new(1, "Search Productt", "Description", [], 1, 1) };
        var searchProductDtos = new List<ProductDto> { new() { Id = 1, Name = "Search Product" } };

        _mediator.Send(Arg.Any<SearchProductQueries>()).Returns(searchProducts);
        _mapper.Map<IEnumerable<ProductDto>>(searchProducts).Returns(searchProductDtos);

        // Act
        var result = await _productDtoService.GetSearchProductsDtoAsync(keyword);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(searchProductDtos, result);
    }

    [Fact]
    [Test]
    public async Task GetByIdAsync_ReturnsMappedProduct_WhenProductExists()
    {
        // Arrange
        var productId = 1;
        var product = new Product(1, "Test Product", "Description", [], 1, 1);
        var productDto = new ProductDto { Id = 1, Name = "Test Product" };

        _mediator.Send(Arg.Any<GetByIdProductQuery>()).Returns(product);
        _mapper.Map<ProductDto>(product).Returns(productDto);

        // Act
        var result = await _productDtoService.GetByIdAsync(productId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(productDto, result);
    }

    [Fact]
    [Test]
    public async Task GetByIdAsync_ThrowsArgumentException_WhenIdIsNullOrZero()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _productDtoService.GetByIdAsync(null));
        await Assert.ThrowsAsync<ArgumentException>(() => _productDtoService.GetByIdAsync(0));
    }
}
