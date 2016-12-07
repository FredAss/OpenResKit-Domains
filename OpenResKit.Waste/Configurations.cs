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

namespace OpenResKit.Waste
{
  [Export(typeof (IDomainEntityConfiguration))]
  public class WasteContainerConfiguration : EntityTypeConfiguration<WasteContainer>, IDomainEntityConfiguration
  {
    public WasteContainerConfiguration()
    {
      HasOptional(c => c.MapPosition)
        .WithOptionalDependent()
        .WillCascadeOnDelete();
      HasMany(s => s.WasteTypes)
        .WithOptional()
        .WillCascadeOnDelete();
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class FillLevelReadingConfiguration : EntityTypeConfiguration<FillLevelReading>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class WasteTypeConfiguration : EntityTypeConfiguration<WasteType>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class DisposerConfiguration : EntityTypeConfiguration<Disposer>, IDomainEntityConfiguration
  {
    public DisposerConfiguration()
    {
      HasMany(d => d.Containers)
        .WithOptional();

      HasMany(d => d.Documents)
        .WithOptional()
        .WillCascadeOnDelete();
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class CollectionConfiguration : EntityTypeConfiguration<WasteCollection>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }
}