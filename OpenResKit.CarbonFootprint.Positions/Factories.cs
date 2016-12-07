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
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using OpenResKit.Organisation;

namespace OpenResKit.CarbonFootprint.Positions
{
  [Export(typeof (ICarbonFootprintPositionFactory))]
  internal class FlightFactory : ICarbonFootprintPositionFactory
  {
    public CarbonFootprintPosition CreatePosition(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ResponsibleSubject responsibleSubject = null)
    {
      return CreateFlight(name, description, tag, iconId, start, finish);
    }

    public CarbonFootprintPosition CreatePredefinedPosition(ResponsibleSubject responsibleSubject = null)
    {
      return CreateFlight("Flug", "Stellt einen Flug mit manuellen Eingaben dar.", "Flüge", "CfFlight.png", DateTime.Now, DateTime.Now.AddYears(1), 3000, FlightRange.Mittelstrecke, false,
        responsibleSubject);
    }

    private Flight CreateFlight(string name, string description, string tag, string iconId, DateTime start, DateTime finish, int kilometrage = 0, FlightRange flightRange = FlightRange.Kurzstrecke,
      bool radiativeForcing = false, ResponsibleSubject responsibleSubject = null)
    {
      return new Flight
             {
               Name = name,
               Description = description,
               Tag = tag,
               IconId = iconId,
               Start = start,
               Finish = finish,
               FlightType = flightRange,
               Kilometrage = kilometrage,
               RadiativeForcing = radiativeForcing,
               ResponsibleSubject = responsibleSubject
             };
    }
  }

  [Export(typeof (ICarbonFootprintPositionFactory))]
  internal class CarFactory : ICarbonFootprintPositionFactory
  {
    public CarbonFootprintPosition CreatePosition(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ResponsibleSubject responsibleSubject = null)
    {
      return CreateCar(name, description, tag, iconId, start, finish);
    }

    public CarbonFootprintPosition CreatePredefinedPosition(ResponsibleSubject responsibleSubject = null)
    {
      return CreateCar("Fahrzeug", "Stellt ein Fahrzeug für die individuelle Personenbeförderung dar.", "Fahrzeuge", "CfCar.png", DateTime.Now, DateTime.Now.AddYears(1), 2000, 10.2, 120, Fuel.Benzin,
        responsibleSubject);
    }

    private Car CreateCar(string name, string description, string tag, string iconId, DateTime start, DateTime finish, int kilometrage = 0, double consumption = 0, double carbonProduction = 0,
      Fuel fuelType = Fuel.Diesel, ResponsibleSubject responsibleSubject = null)
    {
      return new Car
             {
               Name = name,
               Description = description,
               Tag = tag,
               IconId = iconId,
               Start = start,
               Finish = finish,
               Kilometrage = kilometrage,
               CarbonProduction = carbonProduction,
               Fuel = fuelType,
               Consumption = consumption,
               ResponsibleSubject = responsibleSubject
             };
    }
  }

  [Export(typeof (ICarbonFootprintPositionFactory))]
  internal class AirportBasedFlightFactory : ICarbonFootprintPositionFactory
  {
    public CarbonFootprintPosition CreatePosition(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ResponsibleSubject responsibleSubject = null)
    {
      return CreateAirportBasedFlight(name, description, tag, iconId, start, finish);
    }

    public CarbonFootprintPosition CreatePredefinedPosition(ResponsibleSubject responsibleSubject = null)
    {
      return CreateAirportBasedFlight("Linienflug", "Stellt eine Flugkonfiguration basierend auf Linienflügen bereit.", "Flüge", "CfFlight.png", DateTime.Now, DateTime.Now.AddYears(1),
        new Collection<AirportPosition>
        {
          new AirportPosition
          {
            Order = 1,
            AirportID = 12243
          },
          new AirportPosition
          {
            Order = 2,
            AirportID = 57
          },
          new AirportPosition
          {
            Order = 3,
            AirportID = 124
          }
        }, responsibleSubject);
    }

    private AirportBasedFlight CreateAirportBasedFlight(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ICollection<AirportPosition> airports = null,
      ResponsibleSubject responsibleSubject = null)
    {
      return new AirportBasedFlight
             {
               Name = name,
               Description = description,
               Tag = tag,
               IconId = iconId,
               Start = start,
               Finish = finish,
               Airports = airports,
               ResponsibleSubject = responsibleSubject
             };
    }
  }

  [Export(typeof (ICarbonFootprintPositionFactory))]
  internal class FullyQualifiedCarFactory : ICarbonFootprintPositionFactory
  {
    public CarbonFootprintPosition CreatePosition(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ResponsibleSubject responsibleSubject = null)
    {
      return CreateFullyQualifiedCar(name, description, tag, iconId, start, finish);
    }

    public CarbonFootprintPosition CreatePredefinedPosition(ResponsibleSubject responsibleSubject = null)
    {
      return CreateFullyQualifiedCar("Herstellerfahrzeug", "Stellt ein reales Fahrzeug eines konkreten Herstellers dar.", "Fahrzeuge", "CfCar.png", DateTime.Now, DateTime.Now.AddYears(1), 20000, 20, 0,
        responsibleSubject);
    }

    private FullyQualifiedCar CreateFullyQualifiedCar(string name, string description, string tag, string iconId, DateTime start, DateTime finish, int kilometrage = 0, int carId = 1,
      double consumption = 0, ResponsibleSubject responsibleSubject = null)
    {
      return new FullyQualifiedCar
             {
               Name = name,
               Description = description,
               Tag = tag,
               IconId = iconId,
               Start = start,
               Finish = finish,
               Kilometrage = kilometrage,
               Consumption = consumption,
               CarId = carId,
               ResponsibleSubject = responsibleSubject
             };
    }
  }

  [Export(typeof (ICarbonFootprintPositionFactory))]
  internal class GeoLocatedCarFactory : ICarbonFootprintPositionFactory
  {
    public CarbonFootprintPosition CreatePosition(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ResponsibleSubject responsibleSubject = null)
    {
      return CreateGeoLocatedCar(name, description, tag, iconId, start, finish, 47.64570362, -122.14073746, "Microsoft North", 47.64316917, -122.14032175, "Microsoft South");
    }

    public CarbonFootprintPosition CreatePredefinedPosition(ResponsibleSubject responsibleSubject = null)
    {
      return CreateGeoLocatedCar("Fahrtenbuch-Autofahrt", "", "Fahrzeuge", "CfCar.png", DateTime.Now, DateTime.Now.AddYears(1), 47.64570362, -122.14073746, "Microsoft North", 47.64316917,
        -122.14032175, "Microsoft South", kilometrage: 20000, carId: 20, consumption: 0, responsibleSubject: responsibleSubject);
    }

    private GeoLocatedCar CreateGeoLocatedCar(string name, string description, string tag, string iconId, DateTime start, DateTime finish, double destinationLatitude, double destinationLongitude,
      string destinationName, double startLatitude, double startLongitude, string startName, int kilometrage = 0, int carId = 1, double consumption = 0, ResponsibleSubject responsibleSubject = null)
    {
      return new GeoLocatedCar
             {
               Name = name,
               Description = description,
               Tag = tag,
               IconId = iconId,
               Start = start,
               Finish = finish,
               Kilometrage = kilometrage,
               Consumption = consumption,
               CarId = carId,
               ResponsibleSubject = responsibleSubject,
               DestinationLatitude = destinationLatitude,
               DestinationLongitude = destinationLongitude,
               DestinationName = destinationName,
               StartLatitude = startLatitude,
               StartLongitude = startLongitude,
               StartName = startName
             };
    }
  }

  [Export(typeof (ICarbonFootprintPositionFactory))]
  internal class EnergyConsumptionFactory : ICarbonFootprintPositionFactory
  {
    public CarbonFootprintPosition CreatePosition(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ResponsibleSubject responsibleSubject = null)
    {
      return CreateEnergyConsumption(name, description, tag, iconId, start, finish);
    }

    public CarbonFootprintPosition CreatePredefinedPosition(ResponsibleSubject responsibleSubject = null)
    {
      return CreateEnergyConsumption("Energieverbrauch", "Stellt den Verbrauch von Energie dar.", "Energieverbrauch", "CfSite.png", DateTime.Now, DateTime.Now.AddYears(1), 2000, EnergySource.Ecostrom,
        0, responsibleSubject);
    }

    private EnergyConsumption CreateEnergyConsumption(string name, string description, string tag, string iconId, DateTime start, DateTime finish, double consumption = 0,
      EnergySource energySource = EnergySource.Strommix, double carbonProduction = 0, ResponsibleSubject responsibleSubject = null)
    {
      return new EnergyConsumption
             {
               Name = name,
               Description = description,
               Tag = tag,
               IconId = iconId,
               Start = start,
               Finish = finish,
               Consumption = consumption,
               EnergySource = energySource,
               CarbonProduction = carbonProduction,
               ResponsibleSubject = responsibleSubject
             };
    }
  }

  [Export(typeof (ICarbonFootprintPositionFactory))]
  internal class MachineEnergyConsumptionFactory : ICarbonFootprintPositionFactory
  {
    public CarbonFootprintPosition CreatePosition(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ResponsibleSubject responsibleSubject = null)
    {
      return CreateMachineEnergyConsumption(name, description, tag, iconId, start, finish);
    }

    public CarbonFootprintPosition CreatePredefinedPosition(ResponsibleSubject responsibleSubject = null)
    {
      return CreateMachineEnergyConsumption("Maschinenverbrauch", "Stellt den Energieverbrauch von Maschinen(-zuständen) dar.", "Energieverbrauch", "CfSite.png", DateTime.Now, DateTime.Now.AddYears(1),
        EnergySource.Ecostrom, 1000, 100, 2000, 250, 0, responsibleSubject);
    }

    private MachineEnergyConsumption CreateMachineEnergyConsumption(string name, string description, string tag, string iconId, DateTime start, DateTime finish,
      EnergySource energySource = EnergySource.Strommix, double hoursInStandbyState = 0, double consumptionPerHourForStandby = 0, double hoursInProcessingState = 0,
      double consumptionPerHourForProcessing = 0, double carbonProduction = 0, ResponsibleSubject responsibleSubject = null)
    {
      return new MachineEnergyConsumption
             {
               Name = name,
               Description = description,
               Tag = tag,
               IconId = iconId,
               Start = start,
               Finish = finish,
               EnergySource = energySource,
               HoursInStandbyState = hoursInStandbyState,
               HoursInProcessingState = hoursInProcessingState,
               ConsumptionPerHourForProcessing = consumptionPerHourForProcessing,
               ConsumptionPerHourForStandby = consumptionPerHourForStandby,
               CarbonProduction = carbonProduction,
               ResponsibleSubject = responsibleSubject
             };
    }
  }

  [Export(typeof (ICarbonFootprintPositionFactory))]
  internal class PublicTransportFactory : ICarbonFootprintPositionFactory
  {
    public CarbonFootprintPosition CreatePosition(string name, string description, string tag, string iconId, DateTime start, DateTime finish, ResponsibleSubject responsibleSubject = null)
    {
      return CreatePublicTransport(name, description, tag, iconId, start, finish);
    }

    public CarbonFootprintPosition CreatePredefinedPosition(ResponsibleSubject responsibleSubject = null)
    {
      return CreatePublicTransport("Öffentlicher Verkehr", "Stellt den öffentlichen Verkehr bereit.", "Öffentlicher Verkehr", "CfPublicTransport.png", DateTime.Now, DateTime.Now.AddYears(1), 300100,
        TransportType.Reisebus, responsibleSubject);
    }

    private PublicTransport CreatePublicTransport(string name, string description, string tag, string iconId, DateTime start, DateTime finish, int kilometrage = 0,
      TransportType transportType = TransportType.Linienbus, ResponsibleSubject responsibleSubject = null)
    {
      return new PublicTransport
             {
               Name = name,
               Description = description,
               Tag = tag,
               IconId = iconId,
               Start = start,
               Finish = finish,
               TransportType = transportType,
               Kilometrage = kilometrage,
               ResponsibleSubject = responsibleSubject
             };
    }
  }
}