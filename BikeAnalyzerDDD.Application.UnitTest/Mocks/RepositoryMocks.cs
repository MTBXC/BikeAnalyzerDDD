using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Domain;
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
            List<Bike> p = new List<Bike>();
            /*   p.Add(p1); p.Add(p3);
               p.Add(p2); p.Add(p4);
               p.Add(p5); p.Add(p6);
               p.Add(p8); p.Add(p7);
               p.Add(p9);

               return p;
            */
        }
    }
}