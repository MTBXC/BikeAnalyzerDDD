using AutoMapper;
using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.CreateBike;
using BikeAnalyzerDDD.Application.Mapper;
using BikeAnalyzerDDD.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BikeAnalyzerDDD.Application.UnitTest.Commands
{
    public class CreateBikeTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBikeRepository> _mockBikeRepository;

        public CreateBikeTest()
        {
            _mockBikeRepository = RepositoryMocks.GetBikeRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }
            );

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidBike_AddedToBikeRepo()
        {
            var handler = new CreateBikeCommandHandler
                (_mockBikeRepository.Object, _mapper);

            var allBikesBeforeCount = (await _mockBikeRepository.Object.GetAllAsync()).Count;

            var command = new CreateBikeCommand()
            {
                Brand = "Scott",
                Model = "Spark RC Pro",
                YearOfProduction = 2022,
                HeadTubeAngle = 67.3,
                SeatTubeEffectiveAngle = 74,
                TravelFrontWheel = 120,
                TravelBackWheel = 120,
                InnerRimWidth = 30,
                TireWidth = 2.4,
                Weigth = 10.3
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allBikes = await _mockBikeRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allBikes.Count.ShouldBe(allBikesBeforeCount + 1);
            response.Id.ShouldNotBeNull();
        }

        [Fact]
        public async Task Handle_Not_ValidBike_TooLongBrand_21Characters_NotAddedToBikeRepo()
        {
            var handler = new CreateBikeCommandHandler
                (_mockBikeRepository.Object, _mapper);

            var allBikesBeforeCount = (await _mockBikeRepository.Object.GetAllAsync()).Count;

            var command = new CreateBikeCommand()
            {
                Brand = "Scotttttttttttttttttttttttttttttttttttttttttttttt",
                Model = "Spark RC Pro",
                YearOfProduction = 2022,
                HeadTubeAngle = 67.3,
                SeatTubeEffectiveAngle = 74,
                TravelFrontWheel = 120,
                TravelBackWheel = 120,
                InnerRimWidth = 30,
                TireWidth = 2.4,
                Weigth = 10.3
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allPosts = await _mockBikeRepository.Object.GetAllAsync();

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            allPosts.Count.ShouldBe(allBikesBeforeCount);
            response.Id.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_Not_ValidBike_SameBrandAndModel_NotAddedToBikeRepo()
        {
            var handler = new CreateBikeCommandHandler
                (_mockBikeRepository.Object, _mapper);

            var allBikesBeforeCount = (await _mockBikeRepository.Object.GetAllAsync()).Count;

            var command = new CreateBikeCommand()
            {
                Brand = "Scott",
                Model = "Spark RC World Cup Evo",
                YearOfProduction = 2022,
                HeadTubeAngle = 67.3,
                SeatTubeEffectiveAngle = 74,
                TravelFrontWheel = 120,
                TravelBackWheel = 120,
                InnerRimWidth = 30,
                TireWidth = 2.4,
                Weigth = 10.3
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allBikes = await _mockBikeRepository.Object.GetAllAsync();

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            allBikes.Count.ShouldBe(allBikesBeforeCount);
            response.Id.ShouldBeNull();
        }
    }
}