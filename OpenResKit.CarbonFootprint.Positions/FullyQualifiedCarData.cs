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

using FileHelpers;

namespace OpenResKit.CarbonFootprint.Positions
{
  [DelimitedRecord(",")]
  public class FullyQualifiedCarData
  {
    public int Id;
    public string Manufacturer;
    public string Model;
    public string Description;
    public string Transmission;
    public int EngineCapacity;
    public string FuelType;
    public double MetricUrbanCold;
    public double MetricExtraUrban;
    public double MetricCombined;
    public double ImperialUrbanCold;
    public double ImperialExtraUrban;
    public double ImperialCombined;
    public int CO2;
    public int FuelCost;
    public int EuroStandard;
    public double NoiseLevel;
    public double EmissionsCO;
    public double? EmissionsHCNOx;
    public double? EmissionsHC;
    public double? EmissionsNOx;
    public double? EmissionsParticulates;
    public string DateOfChange;
  }
}