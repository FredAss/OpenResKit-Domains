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
using System.ComponentModel.Composition;
using System.ServiceModel;
using OpenResKit.ODataHost;

namespace OpenResKit.CarbonFootprint.Positions
{
  [ExportMetadata("Name", "PositionDataContext")]
  [Export(typeof (IWCFService))]
  [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
  [ServiceContract]
  internal class PositionDataContext : IWCFService
  {
    [OperationContract]
    public IEnumerable<FullyQualifiedCarData> GetFullyQualifiedCarData()
    {
      return Utils.ParseCsvToFullyQualifiedCarData();
    }

    [OperationContract]
    public IEnumerable<FullyQualifiedCarData> GetFullyQualifiedCarDataEuro4()
    {
      return Utils.ParseCsvToFullyQualifiedCarDataEuro4();
    }

    [OperationContract]
    public IEnumerable<FullyQualifiedCarData> GetFullyQualifiedCarDataEuro5()
    {
      return Utils.ParseCsvToFullyQualifiedCarDataEuro5();
    }

    [OperationContract]
    public IEnumerable<CarData> GetCarDataEuro4()
    {
      return Utils.ParseCsvToCarDataEuro4();
    }

    [OperationContract]
    public IEnumerable<CarData> GetCarDataEuro5()
    {
      return Utils.ParseCsvToCarDataEuro5();
    }

    [OperationContract]
    public IEnumerable<GlobalAirport> GetAirportData()
    {
      return Utils.ParseCsvToGlobalAirport();
    }
  }
}