using Application.CQRS.Command.Products.Technology.Smartphones;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Interfaces.Products.Technology;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones;

public class RemoveSmartphoneHandler(ISmartphoneRepository smartphoneRepository)
    : IRequestHandler<RemoveSmartphoneCommand, Smartphone>
{
    private readonly ISmartphoneRepository _smartphoneRepository = smartphoneRepository;

    public async Task<Smartphone> Handle(RemoveSmartphoneCommand request, CancellationToken cancellationToken)
    {
        var product = await _smartphoneRepository.GetByIdAsync(request.Id);

        var result = await _smartphoneRepository.DeleteAsync(product);
        return result;
    }
}