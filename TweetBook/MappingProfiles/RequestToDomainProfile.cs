using AutoMapper;
using TweetBook.Contracts.V1.Requests.Queries;
using TweetBook.Domain;

namespace TweetBook.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<GetAllPostsQuery, GetAllPostsFilter>();
        }
    }
}
