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
using System.IO;
using System.Linq;
using System.Reflection;
using FileHelpers;

namespace OpenResKit.CarbonFootprint.Positions
{
  public static class Utils
  {
    private static IEnumerable<FullyQualifiedCarData> m_FullyQualifiedCarData;
    private static IEnumerable<FullyQualifiedCarData> m_FullyQualifiedCarDataEuro4;
    private static IEnumerable<FullyQualifiedCarData> m_FullyQualifiedCarDataEuro5;

    private static IEnumerable<CarData> m_CarDataEuro4;
    private static IEnumerable<CarData> m_CarDataEuro5;

    private static IEnumerable<GlobalAirport> m_GlobalAirports;

    public static IEnumerable<CarData> ParseCsvToCarDataEuro4()
    {
      if (m_CarDataEuro4 == null)
      {
        try
        {
          var assembly = Assembly.GetExecutingAssembly();
          var euro4Stream = new StreamReader(assembly.GetManifestResourceStream("OpenResKit.CarbonFootprint.Positions.Resources.Euro_4_slim.csv"));

          var engine = new FileHelperEngine<CarData>();
          var cars4 = engine.ReadStream(euro4Stream);
          foreach (var carData in cars4)
          {
            carData.Description += " EURO 4";
          }

          m_CarDataEuro4 = cars4;
        }
        catch (Exception exception)
        {
          exception.GetType();
          throw;
        }
      }

      return m_CarDataEuro4;
    }

    public static IEnumerable<CarData> ParseCsvToCarDataEuro5()
    {
      if (m_CarDataEuro5 == null)
      {
        try
        {
          var assembly = Assembly.GetExecutingAssembly();
          var euro4Stream = new StreamReader(assembly.GetManifestResourceStream("OpenResKit.CarbonFootprint.Positions.Resources.Euro_5_slim.csv"));

          var engine = new FileHelperEngine<CarData>();
          var cars5 = engine.ReadStream(euro4Stream);
          foreach (var carData in cars5)
          {
            carData.Description += " EURO 5";
          }

          m_CarDataEuro5 = cars5;
        }
        catch (Exception exception)
        {
          exception.GetType();
          throw;
        }
      }

      return m_CarDataEuro5;
    }

    public static IEnumerable<FullyQualifiedCarData> ParseCsvToFullyQualifiedCarDataEuro4()
    {
      if (m_FullyQualifiedCarData == null)
      {
        try
        {
          var assembly = Assembly.GetExecutingAssembly();
          var euro4Stream = new StreamReader(assembly.GetManifestResourceStream("OpenResKit.CarbonFootprint.Positions.Resources.Euro_4_latest.csv"));

          var engine = new FileHelperEngine<FullyQualifiedCarData>();
          var cars4 = engine.ReadStream(euro4Stream);
          foreach (var fullyQualifiedCarData in cars4)
          {
            fullyQualifiedCarData.Description += " EURO 4";
          }

          m_FullyQualifiedCarDataEuro4 = cars4;
        }
        catch (Exception exception)
        {
          exception.GetType();
          throw;
        }
      }

      return m_FullyQualifiedCarDataEuro4;
    }

    public static IEnumerable<FullyQualifiedCarData> ParseCsvToFullyQualifiedCarDataEuro5()
    {
      if (m_FullyQualifiedCarData == null)
      {
        try
        {
          var assembly = Assembly.GetExecutingAssembly();
          var euro5Stream = new StreamReader(assembly.GetManifestResourceStream("OpenResKit.CarbonFootprint.Positions.Resources.Euro_5_latest.csv"));

          var engine = new FileHelperEngine<FullyQualifiedCarData>();
          var cars5 = engine.ReadStream(euro5Stream);
          foreach (var fullyQualifiedCarData in cars5)
          {
            fullyQualifiedCarData.Description += " EURO 5";
          }

          m_FullyQualifiedCarDataEuro5 = cars5;
        }
        catch (Exception exception)
        {
          exception.GetType();
          throw;
        }
      }

      return m_FullyQualifiedCarDataEuro5;
    }

    public static IEnumerable<FullyQualifiedCarData> ParseCsvToFullyQualifiedCarData()
    {
      if (m_FullyQualifiedCarData == null)
      {
        try
        {
          var assembly = Assembly.GetExecutingAssembly();
          var euro4Stream = new StreamReader(assembly.GetManifestResourceStream("OpenResKit.CarbonFootprint.Positions.Resources.Euro_4_latest.csv"));

          var euro5Stream = new StreamReader(assembly.GetManifestResourceStream("OpenResKit.CarbonFootprint.Positions.Resources.Euro_5_latest.csv"));

          var engine = new FileHelperEngine<FullyQualifiedCarData>();
          var cars4 = engine.ReadStream(euro4Stream);
          foreach (var fullyQualifiedCarData in cars4)
          {
            fullyQualifiedCarData.Description += " EURO 4";
          }

          var cars5 = engine.ReadStream(euro5Stream);
          foreach (var fullyQualifiedCarData in cars5)
          {
            fullyQualifiedCarData.Description += " EURO 5";
          }

          //m_FullyQualifiedCarData = cars4;

          m_FullyQualifiedCarData = cars4.Concat(cars5);
        }
        catch (Exception exception)
        {
          exception.GetType();
          throw;
        }
      }

      return m_FullyQualifiedCarData;
    }

    public static IEnumerable<GlobalAirport> ParseCsvToGlobalAirport()
    {
      if (m_GlobalAirports == null)
      {
        var assembly = Assembly.GetExecutingAssembly();
        var airpotsStream = new StreamReader(assembly.GetManifestResourceStream("OpenResKit.CarbonFootprint.Positions.Resources.GlobalAirportDatabase.csv"));

        var engine = new FileHelperEngine<GlobalAirport>();

        m_GlobalAirports = engine.ReadStream(airpotsStream);
      }

      return m_GlobalAirports;
    }

    public static double CalculateOneFlight(double kilometrage, FlightRange flightRange, bool radiativeForcing)
    {
      double intermidiateResult = 0;
      switch (flightRange)
      {
        case FlightRange.Umgebungsstrecke:
        {
          intermidiateResult = kilometrage * 260;
          break;
        }
        case FlightRange.Langstrecke:
        {
          intermidiateResult = kilometrage * 230;
          break;
        }
        case FlightRange.Mittelstrecke:
        {
          intermidiateResult = kilometrage * 200;
          break;
        }
        case FlightRange.Kurzstrecke:
        {
          intermidiateResult = kilometrage * 360;
          break;
        }
      }
      if (radiativeForcing)
      {
        intermidiateResult *= 1.9;
      }
      return intermidiateResult;
    }
  }
}