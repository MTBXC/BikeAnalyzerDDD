using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Domain.Entities;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Persistence.EF.Repositories
{
    public class BikeRepository : BaseRepository<Bike>, IBikeRepository
    {
        public BikeRepository(BikeAnalyzerDDDContext dbContext) : base(dbContext)
        { }

        public Task<bool> IsModelAndBrandAlreadyExist(string brand, string model)
        {
            var matches = _dbContext.Bikes.
                Any(a => a.Brand.Equals(brand) && a.Model.Equals(model));

            return Task.FromResult(matches);
        }
    }
}