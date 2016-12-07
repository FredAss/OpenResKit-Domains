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
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Reflection;
using OpenResKit.DomainModel;
using OpenResKit.Organisation;
using DayOfWeek = System.DayOfWeek;

namespace OpenResKit.Waste
{
  [Export(typeof (IInitialSeed))]
  internal class InitialSeed : IInitialSeed
  {
    public void Seed(DbContext dbContext)
    {
      var assembly = Assembly.GetExecutingAssembly();

      var initMap2 = MapModelFactory.CreateMap("Ebene 2", assembly.GetManifestResourceStream("OpenResKit.Waste.Resources.dummy_2.jpg"));

      var mp1 = MapModelFactory.CreateMapPosition(initMap2, 100, 100);
      var mp2 = MapModelFactory.CreateMapPosition(initMap2, 200, 200);
      var mp3 = MapModelFactory.CreateMapPosition(initMap2, 300, 300);

      var wc1 = ModelFactory.CreateWasteContainer("Restmülltonne", "AB1", 2, mp1);
      var wc2 = ModelFactory.CreateWasteContainer("Plastikmülltonne", "AB2", 2, mp2);
      var wc3 = ModelFactory.CreateWasteContainer("Schrottcontainer", "AB3", 6, mp3);

      dbContext.Set<WasteContainer>()
               .Add(wc1);
      dbContext.Set<WasteContainer>()
               .Add(wc2);
      dbContext.Set<WasteContainer>()
               .Add(wc3);

      var r1 = ResponsibleSubjectModelFactory.CreateEmployee("Shawn", "Steinfeger", "1234dqwe");

      //series 1 - two containers, weekly, 13 times, 30 minutes each
      var containers1 = new[]
                        {
                          wc1, wc2
                        };

      var s1 = SeriesModelFactory.CreateSeries("Abfalltonnen", DateTime.Now, DateTime.Now.AddMinutes(30), DateTime.Now.AddDays(91), true, false, false, 1, 1, 13, new[]
                                                                                                                                                                  {
                                                                                                                                                                    DateTime.Now.DayOfWeek
                                                                                                                                                                  });

      foreach (var container in containers1)
      {
        for (var i = 0; i < s1.NumberOfRecurrences; i++)
        {
          if (i < 5)
          {
            var flr = ModelFactory.CreateFillLevelReading(s1.Begin.AddDays(i * 7), s1.Begin.AddDays(i * 7)
                                                                                     .AddMinutes(30), s1.Begin.AddDays((i + 1) * 7), s1.Begin.AddDays((i + 1) * 7)
                                                                                                                                       .AddMinutes(30), 0.0f, r1, r1, container, s1);

            flr.EntryDate.Begin = s1.Begin.AddDays((i * 7) + 1);
            flr.FillLevel = (float) (i * 0.25);
            dbContext.Set<FillLevelReading>()
                     .Add(flr);
          }
          else
          {
            var flr = ModelFactory.CreateFillLevelReading(s1.Begin.AddDays(i * 7), s1.Begin.AddDays(i * 7)
                                                                                     .AddMinutes(30), r1, container, s1);
            dbContext.Set<FillLevelReading>()
                     .Add(flr);
          }
        }
      }

      //series 2 - one container, monthly, 3 times, all day
      var s2 = SeriesModelFactory.CreateSeries("Schrottrundgang", DateTime.Now, DateTime.Now.AddMinutes(30), DateTime.Now.AddDays(91), true, false, true, 2, 1, 3, new DayOfWeek[0]);


      for (var i = 0; i < s2.NumberOfRecurrences; i++)
      {
        if (i < 2)
        {
          var flr = ModelFactory.CreateFillLevelReading(s2.Begin.AddMonths(i), s2.Begin.AddMonths(i)
                                                                                 .AddMinutes(30), s2.Begin.AddMonths(i), s2.Begin.AddMonths(i)
                                                                                                                           .AddMinutes(30), 1, r1, r1, wc2, s2);
          flr.EntryDate.Begin = s2.Begin.AddMonths(i)
                                  .AddDays(2);
          flr.FillLevel = (0.5f * (i + 1));
          dbContext.Set<FillLevelReading>()
                   .Add(flr);
        }
        else
        {
          var flr = ModelFactory.CreateFillLevelReading(s2.Begin.AddMonths(i), s2.Begin.AddMonths(i)
                                                                                 .AddMinutes(30), r1, wc2, s2);

          dbContext.Set<FillLevelReading>()
                   .Add(flr);
        }
      }

      var disposerModelFactory = new DisposerModelFactory();

      var disposer1 = disposerModelFactory.CreateDisposer("ALBA", "A1", "alba@müll.de", "An der Waterkant 1", "12345", "Berlin", null, new Collection<WasteContainer>()
                                                                                                                                       {
                                                                                                                                         wc1,
                                                                                                                                         wc2
                                                                                                                                       }, "Nur Sondermüll");
      dbContext.Set<Disposer>()
               .Add(disposer1);

      var disposer2 = disposerModelFactory.CreateDisposer("Dino Container", "DinoX", "dino@saurier.de", "Holzstraße 2", "12345", "Berlin", null, new Collection<WasteContainer>()
                                                                                                                                                 {
                                                                                                                                                   wc3
                                                                                                                                                 }, "Bauschutt");
      dbContext.Set<Disposer>()
               .Add(disposer2);

      var collection1 = ModelFactory.CreateCollection(disposer1, wc1, 20, 18, 500, 485, DateTime.Now.AddDays(2));
      dbContext.Set<WasteCollection>()
               .Add(collection1);

      var collection2 = ModelFactory.CreateCollection(disposer2, wc2, 10, 10, 449, 499, DateTime.Now.AddDays(10));
      dbContext.Set<WasteCollection>()
               .Add(collection2);

      dbContext.SaveChanges();
    }
  }
}