using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Entity;
using OpenResKit.DomainModel;

namespace OpenResKit.Building
{
    [Export(typeof (IInitialSeed))]
    public class InitialSeed : IInitialSeed
    {
        public void Seed(DbContext dbContext)
        {
            var address = new Address
            {
                Street = "Musterweg",
                Number = "1A",
                Zip = "12345",
                City = "Musterstadt"
            };
            dbContext.Set<Address>().Add(address);

            var building = new Building
            {
                Name = "neuer Name"
            };
            dbContext.Set<Building>().Add(building);

            var room1 = new BuildingRoom
            {
                Name = "102",
                Area = 100,
                Height = 220,
                Description = null,
                Building = building
            };

            var room2 = new BuildingRoom
            {
                Name = "103",
                Area = 20,
                Height = 220,
                Building = building
            };
            dbContext.Set<BuildingRoom>().Add(room1);
            dbContext.Set<BuildingRoom>().Add(room2);
            dbContext.SaveChanges();
        }
    }
}