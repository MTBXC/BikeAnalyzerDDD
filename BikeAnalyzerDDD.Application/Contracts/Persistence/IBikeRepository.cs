using BikeAnalyzerDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Contracts.Persistence
{
    public interface IBikeRepository : IAsyncRepository<Bike>
    {
        Task<bool> IsModelAndBrandAlreadyExist
            (string brand, string model);
    }
}