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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Entity;
using OpenResKit.DomainModel;
using OpenResKit.Organisation;

namespace OpenResKit.CarbonFootprint.Positions
{
  [Export(typeof (IInitialSeed))]
  internal class InitialSeed : IInitialSeed
  {
    private readonly IEnumerable<ICarbonFootprintPositionFactory> m_PositionFactories;

    [ImportingConstructor]
    public InitialSeed([ImportMany] IEnumerable<ICarbonFootprintPositionFactory> positionFactories)
    {
      m_PositionFactories = positionFactories;
    }

    public void Seed(DbContext dbContext)
    {
      var employee = ResponsibleSubjectModelFactory.CreateEmployee("Dieter", "Schwarz");
      dbContext.Set<Employee>()
               .Add(employee);

      for (var i = 1; i < 3; i++)
      {
        var name = "CarbonFootprint " + i;
        var description = "Description of CarbonFootprint " + i;
        var cf = CarbonFootprintFactory.CreateCarbonFootprint(name, description);
        cf.Positions = new Collection<CarbonFootprintPosition>();
        foreach (var carbonFootprintPositionFactory in m_PositionFactories)
        {
          cf.Positions.Add(carbonFootprintPositionFactory.CreatePredefinedPosition(employee));
        }

        dbContext.Set<CarbonFootprint>()
                 .Add(cf);
      }
      dbContext.SaveChanges();
    }
  }
}