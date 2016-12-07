#region License

// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at
//  
// http://www.apache.org/licenses/LICENSE-2.0.html
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  
// Copyright (c) 2013, HTW Berlin

#endregion

using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using OpenResKit.DomainModel;

namespace OpenResKit.CarbonFootprint.Positions
{
  [Export(typeof (IDomainEntityConfiguration))]
  public class CarConfiguration : EntityTypeConfiguration<Car>, IDomainEntityConfiguration
  {
    public CarConfiguration()
    {
      Ignore(m => m.Fuel);
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class FlightConfiguration : EntityTypeConfiguration<Flight>, IDomainEntityConfiguration
  {
    public FlightConfiguration()
    {
      Ignore(e => e.FlightType);
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class AirportBasedFlightConfiguration : EntityTypeConfiguration<AirportBasedFlight>, IDomainEntityConfiguration
  {
    public AirportBasedFlightConfiguration()
    {
      HasMany(s => s.Airports)
        .WithOptional()
        .WillCascadeOnDelete();
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class AirportPositionConfiguration : EntityTypeConfiguration<AirportPosition>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class FullyQualifiedCarConfiguration : EntityTypeConfiguration<FullyQualifiedCar>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class EnergyConsumptionConfiguration : EntityTypeConfiguration<EnergyConsumption>, IDomainEntityConfiguration
  {
    public EnergyConsumptionConfiguration()
    {
      Ignore(e => e.EnergySource);
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class MachineEnergyConsumptionConfiguration : EntityTypeConfiguration<MachineEnergyConsumption>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class PublicTransportConfiguration : EntityTypeConfiguration<PublicTransport>, IDomainEntityConfiguration
  {
    public PublicTransportConfiguration()
    {
      Ignore(e => e.TransportType);
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }
}