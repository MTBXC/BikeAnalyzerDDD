using AutoMapper;
using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.UpdateBike;
using BikeAnalyzerDDD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Commands.UpdateBike
{
    public class UpdateBikeCommandHandler : IRequestHandler<UpdateBikeCommand>
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IMapper _mapper;

        public UpdateBikeCommandHandler(IBikeRepository bikeRepository, IMapper mapper)
        {
            _bikeRepository = bikeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = _mapper.Map<Bike>(request);

            await _bikeRepository.UpdateAsync(bike);

            return Unit.Value;
        }
    }
}