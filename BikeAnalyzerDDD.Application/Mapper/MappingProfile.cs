using AutoMapper;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.CreateBike;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.DeleteBike;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.UpdateBike;
using BikeAnalyzerDDD.Application.Functions.Bikes.Queries.GetBikeDetail;
using BikeAnalyzerDDD.Application.Functions.Bikes.Queries.GetBikesLists;
using BikeAnalyzerDDD.Domain.Entities;
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
            CreateMap<Bike, BikeDetailViewModel>().ReverseMap();
            CreateMap<Bike, BikeInListViewModel>().ReverseMap();
            CreateMap<Bike, CreateBikeCommand>().ReverseMap();
            CreateMap<Bike, UpdateBikeCommand>().ReverseMap();
            CreateMap<Bike, DeleteBikeCommand>().ReverseMap();
        }
    }
}