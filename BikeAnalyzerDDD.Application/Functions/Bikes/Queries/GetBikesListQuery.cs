using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Queries
{
    public class GetBikesListQuery : IRequest<List<BikeInListViewModel>>
    {
    }
}