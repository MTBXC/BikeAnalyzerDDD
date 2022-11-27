using AutoMapper;
using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Queries.GetBikesLists
{
    public class GetBikesListQueryHandler : IRequestHandler<GetBikesListQuery, List<BikeInListViewModel>>
    {
        private readonly IAsyncRepository<Bike> _bikeRepository;
        private readonly IMapper _mapper;

        public GetBikesListQueryHandler(IAsyncRepository<Bike> postRepository, IMapper mapper)
        {
            _bikeRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<List<BikeInListViewModel>>
            Handle(GetBikesListQuery request, CancellationToken cancellationToken)
        {
            var all = await _bikeRepository.GetAllAsync();

            return _mapper.Map<List<BikeInListViewModel>>(all);
        }
    }
}