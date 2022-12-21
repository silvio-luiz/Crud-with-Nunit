using TruckDiscovery.Models;

namespace TruckDiscovery.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WarehouseContext context)
        {
            // Look for any students.
            if (context.Trucks.Any())
            {
                return;   // DB has been seeded
            }

            var trucks = new Truck[]
            {
                new Truck{Model="FH",FabYear=DateTime.Parse("2022-09-01"),ModelYear=DateTime.Parse("2023-09-01")},
                new Truck{Model="FM",FabYear=DateTime.Parse("2022-09-01"),ModelYear=DateTime.Parse("2022-09-01")}
            };

            context.Trucks.AddRange(trucks);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{TruckID=1,TruckModel=TruckModel.FH},
                new Enrollment{TruckID=1,TruckModel=TruckModel.FM}
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}