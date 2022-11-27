using BikeAnalyzerDDD.Domain.Entities;

namespace BikeAnalyzerDDD.Persistence.EF.DummyData
{
    public class DummyBike
    {
        public static List<Bike> GetBikes()
        {
            Bike p1 = new Bike()
            {
                Id = 1,
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
                Id = 2,
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