using AutoMapper;
using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Commands.CreateBike
{
    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, CreateBikeCommandResponse>
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IMapper _mapper;

        public CreateBikeCommandHandler(IBikeRepository bikeRepository, IMapper mapper)
        {
            _bikeRepository = bikeRepository;
            _mapper = mapper;
        }

        public async Task<CreateBikeCommandResponse> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBikeCommandValidator(_bikeRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateBikeCommandResponse(validatorResult);

            var bike = _mapper.Map<Bike>(request);

            bike = await _bikeRepository.AddAsync(bike);

            return new CreateBikeCommandResponse(bike.Id);
        }
    }
}