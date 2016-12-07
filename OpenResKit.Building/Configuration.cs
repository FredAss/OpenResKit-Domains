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

namespace OpenResKit.Building
{
    [Export(typeof (IDomainEntityConfiguration))]
    public class BuildingConfiguration : EntityTypeConfiguration<Building>, IDomainEntityConfiguration
    {
        public BuildingConfiguration()
        {
            HasMany(i => i.Rooms)
                .WithOptional(d => d.Building)
                .WillCascadeOnDelete(true);
        }

        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof (IDomainEntityConfiguration))]
    public class AddressConfiguration : EntityTypeConfiguration<Address>, IDomainEntityConfiguration
    {
        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof (IDomainEntityConfiguration))]
    public class BuildingRoomConfiguration : EntityTypeConfiguration<BuildingRoom>, IDomainEntityConfiguration
    {
        public BuildingRoomConfiguration()
        {
            HasMany(i => i.Inventories)
                .WithOptional(d => d.Room)
                .WillCascadeOnDelete(true);
        }

        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof (IDomainEntityConfiguration))]
    public class InventoryConfiguration : EntityTypeConfiguration<Inventory>, IDomainEntityConfiguration
    {
        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    [Export(typeof (IDomainEntityConfiguration))]
    public class InventoryTypeConfiguration : EntityTypeConfiguration<InventoryType>, IDomainEntityConfiguration
    {
        public void AddConfigurationToModel(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}