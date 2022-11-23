﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Queries
{
    public class BikeInListViewModel
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int? YearOfProduction { get; set; }

        public double? HeadTubeAngle { get; set; }

        public double? SeatTubeEffectiveAngle { get; set; }

        public int? TravelFrontWheel { get; set; }

        public int? TravelBackWheel { get; set; }

        public double? InnerRimWidth { get; set; }

        public double? TireWidth { get; set; }

        public double? Weigth { get; set; }

        public double? GeneralBikeRate { get; set; }
    }
}