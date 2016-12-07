using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using OpenResKit.Approval.Models;
using OpenResKit.DomainModel;

namespace OpenResKit.Approval
{
    [Export(typeof (IDomainEntityConfiguration))]
    public class PlantConfigurations : EntityTypeConfiguration<Plant>, IDomainEntityConfiguration
    {
        public PlantConfigurations()
        {
            HasMany(p => p.Permissions).WithMany(pe => pe.Plants).Map(x =>
            {
                x.MapLeftKey("Plant_Id");
                x.MapRightKey("Permission_Id");
                x.ToTable("PlantPermissions");
            });

            HasMany(p => p.Substances).WithOptional().WillCascadeOnDelete();
        }

        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof (IDomainEntityConfiguration))]
    public class SubstanceConfigurations : EntityTypeConfiguration<Substance>, IDomainEntityConfiguration
    {
        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof (IDomainEntityConfiguration))]
    public class PermissionConfigurations : EntityTypeConfiguration<Permission>, IDomainEntityConfiguration
    {
        public PermissionConfigurations()
        {
            HasMany(m => m.AttachedDocuments).WithOptional().WillCascadeOnDelete();
            HasMany(m => m.AuxillaryConditions).WithOptional().WillCascadeOnDelete();
        }

        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof (IDomainEntityConfiguration))]
    public class ConditionInspections : EntityTypeConfiguration<ConditionInspection>, IDomainEntityConfiguration
    {
        public ConditionInspections()
        {
            //HasKey(m => new { m.InspectionId, m.AuxillaryConditionId });
        }

        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof(IDomainEntityConfiguration))]
    public class PlantImageSourceConfigurations : EntityTypeConfiguration<PlantImageSource>, IDomainEntityConfiguration
    {
        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof(IDomainEntityConfiguration))]
    public class AuxillaryConditionConfigurations : EntityTypeConfiguration<AuxillaryCondition>, IDomainEntityConfiguration
    {
        public AuxillaryConditionConfigurations()
        {
            HasMany(m => m.ConditionInspections).WithRequired().HasForeignKey(m => m.AuxillaryConditionId);
        }

        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof(IDomainEntityConfiguration))]
    public class InspectionConfigurations : EntityTypeConfiguration<Approval_Inspection>, IDomainEntityConfiguration
    {
        public InspectionConfigurations()
        {
            HasMany(m => m.ConditionInspections).WithRequired().HasForeignKey(m => m.InspectionId);
        }

        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof(IDomainEntityConfiguration))]
    public class MeasureConfigurations : EntityTypeConfiguration<Approval_Measure>, IDomainEntityConfiguration
    {
        public MeasureConfigurations()
        {
            HasMany(m => m.AttachedDocuments).WithOptional().WillCascadeOnDelete();
        }

        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
