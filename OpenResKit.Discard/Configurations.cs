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

namespace OpenResKit.Discard
{
  [Export(typeof (IDomainEntityConfiguration))]
  public class DiscardItemConfiguration : EntityTypeConfiguration<DiscardItem>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class InspectionAttributeConfiguration : EntityTypeConfiguration<InspectionAttribute>, IDomainEntityConfiguration
  {
    public InspectionAttributeConfiguration()
    {
      //HasOptional(i => i.DiscardImageSource).WithRequired().WillCascadeOnDelete(true);
      HasOptional(i => i.DiscardImageSource)
        .WithOptionalPrincipal()
        .WillCascadeOnDelete(true);
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class DiscardImageSourceConfiguration : EntityTypeConfiguration<DiscardImageSource>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class InspectionConfiguration : EntityTypeConfiguration<Inspection>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class ProductionItemConfiguration : EntityTypeConfiguration<ProductionItem>, IDomainEntityConfiguration
  {
    public ProductionItemConfiguration()
    {
      HasMany(s => s.InspectionAttributes)
        .WithOptional()
        .WillCascadeOnDelete();
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class CustomerConfigurations : EntityTypeConfiguration<Customer>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }
}