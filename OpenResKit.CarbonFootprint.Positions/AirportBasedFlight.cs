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
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace OpenResKit.CarbonFootprint.Positions
{
  [Export(typeof (CarbonFootprintPosition))]
  public class AirportBasedFlight : CarbonFootprintPosition
  {
    public virtual ICollection<AirportPosition> Airports { get; set; }

    public override void Calculate()
    {
      if (Airports == null ||
          2 > Airports.Count())
      {
        Calculation = 0;
        return;
      }

      double intermidiateResult = 0;

      var orderedAirports = Airports.OrderBy(airp => airp.Order);

      for (var i = 2; i <= Airports.Count(); i++)
      {
        var kilometrage = GetDistance(AirportIdToGlobalAirport(orderedAirports.Where(a => a.Order == i - 1)
                                                                              .Select(a => a.AirportID)
                                                                              .Single()), AirportIdToGlobalAirport(orderedAirports.Where(a => a.Order == i)
                                                                                                                                  .Select(a => a.AirportID)
                                                                                                                                  .Single()));

        var flightType = DefineFlightRange(kilometrage);
        var radiativeForcing = kilometrage > 750;
        intermidiateResult += Utils.CalculateOneFlight(kilometrage, flightType, radiativeForcing);
      }

      Calculation = intermidiateResult;
    }

    private FlightRange DefineFlightRange(double kilometrage)
    {
      FlightRange flightType;
      if (kilometrage > 3700)
      {
        flightType = FlightRange.Langstrecke;
      }
      else if (kilometrage < 401)
      {
        flightType = FlightRange.Umgebungsstrecke;
      }
      else if (kilometrage >= 400 &&
               kilometrage <= 1000)
      {
        flightType = FlightRange.Kurzstrecke;
      }
      else
      {
        flightType = FlightRange.Mittelstrecke;
      }
      return flightType;
    }

    private double GetDistance(GlobalAirport airport1, GlobalAirport airport2)
    {
      var latitudeAirport1 = DegToRadianMeasure(airport1.latitude_deg);
      var longitudeAirport1 = DegToRadianMeasure(airport1.longitude_deg);

      var latitudeAirport2 = DegToRadianMeasure(airport2.latitude_deg);
      var longitudeAirport2 = DegToRadianMeasure(airport2.longitude_deg);

      var distance = Math.Acos(Math.Sin(latitudeAirport1) * Math.Sin(latitudeAirport2) + Math.Cos(latitudeAirport1) * Math.Cos(latitudeAirport2) * Math.Cos(longitudeAirport1 - longitudeAirport2)) *
                     6370;

      return distance;
    }

    private double DegToRadianMeasure(double decimalCoordinates)
    {
      var result = decimalCoordinates / 180 * Math.PI;
      return result;
    }

    private GlobalAirport AirportIdToGlobalAirport(int airportId)
    {
      return Utils.ParseCsvToGlobalAirport()
                  .Single(a => a.id == airportId);
    }
  }
}