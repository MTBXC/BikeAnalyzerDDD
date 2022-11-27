using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Queries.GetBikeDetail
{
    public class GetBikeDetailQuery : IRequest<BikeDetailViewModel>
    {
        public int Id { get; set; }
    }
}