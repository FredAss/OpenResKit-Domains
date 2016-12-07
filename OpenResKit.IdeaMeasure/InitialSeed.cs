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
using OpenResKit.DomainModel;

namespace OpenResKit.IdeaMeasure
{
  [Export(typeof (IInitialSeed))]
  public class InitialSeed : IInitialSeed
  {
    public void Seed(DbContext dbContext)
    {
      var idea1 = ModelFactory.CreateIdea("Beleuchtung", "Beleuchtung in Gebäude F brennt die ganze Nacht durch", "Abschalten der Beleuchtung nach Betriebsschluss", new DateTime(2013, 11, 20),
        "Hans Meier", 0);
      var idea2 = ModelFactory.CreateIdea("RLT defekt", "RLT in Gebäude E Raum 200 scheint defekt", "Wartung durch Wartungspersonal", new DateTime(2013, 10, 20), "Olaf Scholz", 1);
      var idea3 = ModelFactory.CreateIdea("Raumtemperatur zu hoch", "Raumtemperatur in Büroräumen generell zu hoch", "Reduktion von Beheizung der Büroräume", new DateTime(2013, 11, 15), "Sabine Lowa",
        2);
      var idea4 = ModelFactory.CreateIdea("Bewegungsmelder defekt", "Der Bewegungsmelder in Gebäude L 2OG ist defekt und sorgt für Dauerbeleuchtung", "Bewegungsmelder austauschen",
        new DateTime(2013, 09, 11), "Sabine Lowa", 1);
      var idea5 = ModelFactory.CreateIdea("Restwärmenutzung in Labor 104", "Die Restwärme des Prozesses P201 könnte weiterhin genutzt werden", "Installation eines Wärmetauschers",
        new DateTime(2013, 11, 15), "Sabine Lowa", 0);
      var idea6 = ModelFactory.CreateIdea("Generator ineffizient", "Der Generator im Außenbereich von Gebäude C Ausgang Nord ist veraltet und ineffizient", "Generator gegen neues Modell austauschen",
        new DateTime(2013, 12, 15), "Olaf Scholz", 2);
      var idea7 = ModelFactory.CreateIdea("Belüftung defekt", "Die Belüftung des Labors X01 funktioniert nicht korrekt, wodurch die Klimaanlagen verstärkt arbeiten müssen", "Belüfung reparieren",
        new DateTime(2013, 08, 15), "Sabine Lowa", 1);
      var idea8 = ModelFactory.CreateIdea("Beleuchtungskonzept", "Das Bleuchtungskonzept in den Büros des Gebäudes A sollte überarbeitet werden", "Überarbeitung des Beleuchtungskonzepts in Gebäude A",
        new DateTime(2013, 11, 25), "Hans Meier", 2);


      dbContext.Set<Idea>()
               .Add(idea1);
      dbContext.Set<Idea>()
               .Add(idea2);
      dbContext.Set<Idea>()
               .Add(idea3);
      dbContext.Set<Idea>()
               .Add(idea4);
      dbContext.Set<Idea>()
               .Add(idea5);
      dbContext.Set<Idea>()
               .Add(idea6);
      dbContext.Set<Idea>()
               .Add(idea7);
      dbContext.Set<Idea>()
               .Add(idea8);


      dbContext.SaveChanges();
    }
  }
}