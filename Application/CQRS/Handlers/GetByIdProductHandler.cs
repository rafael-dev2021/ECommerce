﻿using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers;

public class GetByIdProductHandler(IProductRepository productRepository) : IRequestHandler<GetByIdProductQuery, Product>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Product> Handle(
        GetByIdProductQuery request,
        CancellationToken cancellationToken) =>
        await _productRepository.GetByIdAsync(request.Id);
}