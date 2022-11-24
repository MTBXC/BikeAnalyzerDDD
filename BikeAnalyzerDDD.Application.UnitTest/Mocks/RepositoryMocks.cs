using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Domain.Entities;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IBikeRepository> GetBikeRepository()
        {
            var bikes = GetBikes();
            var mockBikeRepository = new Mock<IBikeRepository>();

            mockBikeRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(bikes);

            mockBikeRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var bik = bikes.FirstOrDefault(c => c.Id == id);
                return bik;
            });

            mockBikeRepository.Setup(repo => repo.AddAsync(It.IsAny<Bike>())).ReturnsAsync(
            (Bike bike) =>
            {
                bikes.Add(bike);
                return bike;
            });

            mockBikeRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Bike>())).Callback
                <Bike>((entity) => bikes.Remove(entity));

            mockBikeRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Bike>())).Callback
                <Bike>((entity) => { bikes.Remove(entity); bikes.Add(entity); });

            mockBikeRepository.Setup(repo => repo.IsModelAndBrandAlreadyExist
                (It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((string brand, string model) =>
                {
                    var matches = bikes.
                    Any(a => a.Brand.Equals(brand) && a.Model.Equals(model));
                    return matches;
                });

            return mockBikeRepository;
        }

        public static List<Bike> GetBikes()
        {
            Bike p1 = new Bike()
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
            Bike p2 = new Bike()
            {
                Brand = "Scott",
                Model = "Spark RC World Cup",
                YearOfProduction = 2022,
                HeadTubeAngle = 67.3,
                SeatTubeEffectiveAngle = 74,
                TravelFrontWheel = 120,
                TravelBackWheel = 120,
                InnerRimWidth = 30,
                TireWidth = 2.4,
                Weigth = 10.7
            };
            List<Bike> p = new List<Bike>();
            p.Add(p1);
            p.Add(p2);

            return p;
        }
    }
}