using AutoMapper;
using BikeAnalyzerDDD.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Commands.DeleteBike
{
    public class DeleteBikeCommandHandler : IRequestHandler<DeleteBikeCommand>
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IMapper _mapper;

        public DeleteBikeCommandHandler(IBikeRepository bikeRepository, IMapper mapper)
        {
            _bikeRepository = bikeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBikeCommand request, CancellationToken cancellationToken)
        {
            var biketodelete = await _bikeRepository.GetByIdAsync(request.Id);

            await _bikeRepository.DeleteAsync(biketodelete);

            return Unit.Value;
        }
    }
}