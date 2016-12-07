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
using System.Data.Entity;
using System.Reflection;
using OpenResKit.DomainModel;
using OpenResKit.Organisation;
using DayOfWeek = System.DayOfWeek;

namespace OpenResKit.Meter
{
  [Export(typeof (IInitialSeed))]
  internal class InitialSeed : IInitialSeed
  {
    public void Seed(DbContext dbContext)
    {
      var assembly = Assembly.GetExecutingAssembly();

      var initMap1 = MapModelFactory.CreateMap("Ebene 1", assembly.GetManifestResourceStream("OpenResKit.Meter.Resources.dummy_1.jpg"));

      var mp1 = MapModelFactory.CreateMapPosition(initMap1, 100, 100);
      var mp2 = MapModelFactory.CreateMapPosition(initMap1, 200, 200);
      var mp3 = MapModelFactory.CreateMapPosition(initMap1, 300, 300);


      var meter1 = ModelFactory.CreateMeter("Stromzähler", "AB1", "kWh", mp1);
      var meter2 = ModelFactory.CreateMeter("Generatorzähler", "AB2", "kWh", mp2);
      var meter3 = ModelFactory.CreateMeter("Wasserzähler", "AB3", "m³", mp3);

      dbContext.Set<Meter>()
               .Add(meter1);
      dbContext.Set<Meter>()
               .Add(meter2);
      dbContext.Set<Meter>()
               .Add(meter3);

      var emp1 = ResponsibleSubjectModelFactory.CreateEmployee("Peter", "Lustig");

      var date = DateTime.Now.AddYears(-1);

      var s1 = SeriesModelFactory.CreateSeries("Stromrundgang", date, date.AddMinutes(30), date.AddDays(91), true, false, false, 1, 1, 13, new DayOfWeek[0]);
      var s2 = SeriesModelFactory.CreateSeries("Wasserbegehung", date, date.AddMinutes(30), date.AddDays(91), true, false, true, 2, 1, 6, new DayOfWeek[0]);

      CreateReadingSeeds(dbContext, s1, emp1, meter1, 8);
      CreateReadingSeeds(dbContext, s2, emp1, meter3, -1);
      CreateReadingSeeds(dbContext, s1, emp1, meter2, -1);
      dbContext.SaveChanges();
    }

    private void CreateReadingSeeds(DbContext dbContext, Series series, Employee responsibleEmployee, Meter selectedMeter, int createOnlyNReadings)
    {
      var valueGenerator = new Random();
      var readingValue = 0;
      for (var i = 0; i <= series.NumberOfRecurrences; i++)
      {
        MeterReading meterReading;
        if (createOnlyNReadings == -1 ||
            i < createOnlyNReadings)
        {
          meterReading = ModelFactory.CreateMeterReading(series.Begin.AddMonths(i), series.Begin.AddMonths(i)
                                                                                          .AddMinutes(30), series.Begin.AddMonths(i), series.Begin.AddMonths(i)
                                                                                                                                            .AddMinutes(30), readingValue, responsibleEmployee,
            selectedMeter, series);
          readingValue += valueGenerator.Next(1, 350);
        }
        else
        {
          meterReading = ModelFactory.CreateMeterReading(series.Begin.AddMonths(i), series.Begin.AddMonths(i)
                                                                                          .AddMinutes(30), readingValue, responsibleEmployee, selectedMeter, series);
        }
        dbContext.Set<MeterReading>()
                 .Add(meterReading);
      }
    }
  }
}