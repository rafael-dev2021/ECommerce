using Application.Dtos.Reviews;
using AutoMapper;
using Domain.Entities.Reviews;

namespace Application.Mappings;

public class MappingTheReviewProfile : Profile
{

    public MappingTheReviewProfile()
    {
        CreateMap<Review, ReviewDto>().ReverseMap();
    }
}
