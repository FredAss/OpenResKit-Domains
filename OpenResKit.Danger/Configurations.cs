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

namespace OpenResKit.Danger
{
  [Export(typeof (IDomainEntityConfiguration))]
  public class ActionConfiguration : EntityTypeConfiguration<Action>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class AssessmentConfiguration : EntityTypeConfiguration<Assessment>, IDomainEntityConfiguration
  {
    public AssessmentConfiguration()
    {
      HasMany(m => m.Threats)
        .WithOptional()
        .WillCascadeOnDelete();
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class CategoryConfiguration : EntityTypeConfiguration<Category>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class CompanyConfiguration : EntityTypeConfiguration<Company>, IDomainEntityConfiguration
  {
    public CompanyConfiguration()
    {
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class GFactorConfiguration : EntityTypeConfiguration<GFactor>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }


  [Export(typeof (IDomainEntityConfiguration))]
  public class PersonConfiguration : EntityTypeConfiguration<Person>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class PictureConfiguration : EntityTypeConfiguration<Picture>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class ProtectionGoalConfiguration : EntityTypeConfiguration<ProtectionGoal>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class QuestionConfiguration : EntityTypeConfiguration<Question>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class SurveyTypeConfiguration : EntityTypeConfiguration<SurveyType>, IDomainEntityConfiguration
  {
    public SurveyTypeConfiguration()
    {
      HasOptional(m => m.SurveyTypeDocx);
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class ThreatConfiguration : EntityTypeConfiguration<Threat>, IDomainEntityConfiguration
  {
    public ThreatConfiguration()
    {
      HasMany(m => m.Actions)
        .WithOptional()
        .WillCascadeOnDelete();
      HasMany(m => m.Pictures)
        .WithOptional()
        .WillCascadeOnDelete();
      HasMany(m => m.ProtectionGoals)
        .WithOptional()
        .WillCascadeOnDelete();
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class WorkplaceConfigurations : EntityTypeConfiguration<Workplace>, IDomainEntityConfiguration
  {
    public WorkplaceConfigurations()
    {
      HasMany(m => m.Activities)
        .WithOptional()
        .WillCascadeOnDelete();
      HasMany(m => m.Assessments)
        .WithOptional()
        .WillCascadeOnDelete();
    }

    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class WorkplaceCategoryConfiguration : EntityTypeConfiguration<WorkplaceCategory>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class DangerpointsConfiguration : EntityTypeConfiguration<Dangerpoint>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }

  [Export(typeof (IDomainEntityConfiguration))]
  public class ActivityConfiguration : EntityTypeConfiguration<Activity>, IDomainEntityConfiguration
  {
    public void AddConfigurationToModel(ConfigurationRegistrar configurations)
    {
      configurations.Add(this);
    }
  }
}