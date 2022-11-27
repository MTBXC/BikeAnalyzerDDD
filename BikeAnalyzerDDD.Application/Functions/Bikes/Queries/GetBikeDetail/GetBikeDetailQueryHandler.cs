using AutoMapper;
using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Queries.GetBikeDetail
{
    public class GetBikeDetailQueryHandler :
           IRequestHandler<GetBikeDetailQuery, BikeDetailViewModel>
    {
        private readonly IAsyncRepository<Bike> _bikeRepository;
        private readonly IMapper _mapper;

        public GetBikeDetailQueryHandler(
            IAsyncRepository<Bike> bikeRepository,
            IMapper mapper)
        {
            _bikeRepository = bikeRepository;
            _mapper = mapper;
        }

        public async Task<BikeDetailViewModel> Handle
            (GetBikeDetailQuery request,
            CancellationToken cancellationToken)
        {
            var bike = await _bikeRepository.GetByIdAsync(request.Id);
            var bikedetail = _mapper.Map<BikeDetailViewModel>(bike);

            return bikedetail;
        }
    }
}