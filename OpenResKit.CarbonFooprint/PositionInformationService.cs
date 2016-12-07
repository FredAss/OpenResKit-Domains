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

using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using OpenResKit.DomainModel;
using OpenResKit.ODataHost;

namespace OpenResKit.CarbonFootprint
{
  [ExportMetadata("Name", "PositionInformationService")]
  [Export(typeof (IWCFService))]
  [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
  [ServiceContract]
  internal class PositionInformationService : IWCFService
  {
    private readonly Func<DomainModelContext> m_CreateContext;

    [ImportingConstructor]
    public PositionInformationService([Import] Func<DomainModelContext> createContext)
    {
      m_CreateContext = createContext;
    }


    [OperationContract]
    public void Calculate(int carbonFootprintId)
    {
      using (var context = m_CreateContext())
      {
        var carbonFootprint = context.Set<CarbonFootprint>()
                                     .Single(cf => cf.Id == carbonFootprintId);
        carbonFootprint.Calculate();
        context.SaveChanges();
      }
    }
  }
}