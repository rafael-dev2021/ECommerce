using Application.CQRS.Queries.Products.Technology.Smartphones;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Interfaces.Products.Technology;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones
{
    public class SmartphonesQueriesHandlers(ISmartphoneRepository smartphoneRepository)
        : IRequestHandler<SmartphonesQueries, IEnumerable<Smartphone>>
    {
        private readonly ISmartphoneRepository _smartphoneRepository = smartphoneRepository ?? throw new ArgumentNullException(nameof(smartphoneRepository));

        public async Task<IEnumerable<Smartphone>> Handle(SmartphonesQueries request, CancellationToken cancellationToken)
        {
            return await _smartphoneRepository.GetEntitiesAsync();
        }
    }
}
