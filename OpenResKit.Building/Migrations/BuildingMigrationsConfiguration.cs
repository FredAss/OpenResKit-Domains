using System.ComponentModel.Composition;
using System.Data.Entity.Migrations;
using OpenResKit.DomainModel;

namespace OpenResKit.Building.Migrations
{
    [Export(typeof(DbMigrationsConfiguration))]
    internal sealed class BuildingMigrationsConfiguration : DbMigrationsConfiguration<DomainModelContext>
    {
        public BuildingMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
