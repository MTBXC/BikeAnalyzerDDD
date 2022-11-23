using AutoMapper;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.CreateBike;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.UpdateBike;
using BikeAnalyzerDDD.Application.Functions.Bikes.Queries;
using BikeAnalyzerDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bike, BikeInListViewModel>().ReverseMap();
            CreateMap<Bike, CreateBikeCommand>().ReverseMap();
            CreateMap<Bike, UpdateBikeCommand>().ReverseMap();
        }
    }
}