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
  public class GlobalAirport
  {
    public int id;
    public string ident;
    public string type;
    public string name;
    public double latitude_deg;
    public double longitude_deg;
    public double? elevation_ft;
    public string continent;
    public string iso_country;
    public string iso_region;
    public string municipality;
    public string scheduled_service;
    public string gps_code;
    public string iata_code;
    public string local_code;
    public string home_link;
    public string wikipedia_link;
    public string keywords;

    public string DisplayMember
    {
      get { return string.Format("{0} ({1})", name.Trim('"'), iata_code.Trim('"')); }
    }

    public string ValueMember
    {
      get { return id.ToString(); }
    }
  }
}