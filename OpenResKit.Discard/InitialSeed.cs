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
using OpenResKit.DomainModel;
using OpenResKit.Organisation;

namespace OpenResKit.Discard
{
  [Export(typeof (IInitialSeed))]
  internal class InitialSeed : IInitialSeed
  {
    public void Seed(DbContext dbContext)
    {
      var modelFactory = new ModelFactory();

      var responsibleSubject1 = ResponsibleSubjectModelFactory.CreateEmployee("Heinz", "Petersen");

      dbContext.Set<Employee>()
               .Add(responsibleSubject1);


      var inspectionAttribute1 = modelFactory.CreateInspectionAttribute("Teilequalität prüfen: nicht ausgespritzt", "1");
      var inspectionAttribute2 = modelFactory.CreateInspectionAttribute("Teilequalität prüfen: starke Gratbildung", "2");
      var inspectionAttribute3 = modelFactory.CreateInspectionAttribute("Teilequalität prüfen: Einlegeteile nicht vorhanden", "3");
      var inspectionAttribute4 = modelFactory.CreateInspectionAttribute("Laschen verbogen", "1");
      var inspectionAttribute5 = modelFactory.CreateInspectionAttribute("Kontakte fehlerhaft", "2");
      var inspectionAttribute6 = modelFactory.CreateInspectionAttribute("Kontakte fehlerhaft 2", "1");
      var inspectionAttribute7 = modelFactory.CreateInspectionAttribute("Laschen verbogen", "2");
      var inspectionAttribute8 = modelFactory.CreateInspectionAttribute("Bedienelemen definitiv Ausschuß", "1");
      var inspectionAttribute9 = modelFactory.CreateInspectionAttribute("Abdeckung definitiv Ausschuß", "2");
      var inspectionAttribute10 = modelFactory.CreateInspectionAttribute("Zahnrad definitiv Ausschuß", "3");
      var inspectionAttribute11 = modelFactory.CreateInspectionAttribute("Farbe falsch", "1");
      var inspectionAttribute12 = modelFactory.CreateInspectionAttribute("Formfehler", "2");
      var inspectionAttribute13 = modelFactory.CreateInspectionAttribute("Sonstiger Fehler", "3");


      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute1);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute2);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute3);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute4);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute5);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute6);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute7);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute8);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute9);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute10);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute11);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute12);
      dbContext.Set<InspectionAttribute>()
               .Add(inspectionAttribute13);

      var inspectionAttributeList1 = new Collection<InspectionAttribute>();
      var inspectionAttributeList3 = new Collection<InspectionAttribute>();
      var inspectionAttributeList2 = new Collection<InspectionAttribute>();
      var inspectionAttributeList4 = new Collection<InspectionAttribute>();
      var inspectionAttributeList5 = new Collection<InspectionAttribute>();

      inspectionAttributeList1.Add(inspectionAttribute1);
      inspectionAttributeList1.Add(inspectionAttribute2);
      inspectionAttributeList1.Add(inspectionAttribute3);

      inspectionAttributeList2.Add(inspectionAttribute4);
      inspectionAttributeList2.Add(inspectionAttribute5);

      inspectionAttributeList3.Add(inspectionAttribute6);
      inspectionAttributeList3.Add(inspectionAttribute7);

      inspectionAttributeList4.Add(inspectionAttribute8);
      inspectionAttributeList4.Add(inspectionAttribute9);
      inspectionAttributeList4.Add(inspectionAttribute10);

      inspectionAttributeList5.Add(inspectionAttribute11);
      inspectionAttributeList5.Add(inspectionAttribute12);
      inspectionAttributeList5.Add(inspectionAttribute13);

      var customer1 = modelFactory.CreateCustomer("HTW GmbH");
      var customer2 = modelFactory.CreateCustomer("Beispielunernehmen AG");

      var productionItem1 = modelFactory.CreateProductionItem("308231", "Bedienelement Spritz Groß", "Das ist die Beschreibung für ein großes Bedienelement", "Werkzeug Form 1", "AD/16",
        "Miramid VE30CW 802", customer1, "1337", "987654321", 1, inspectionAttributeList1);
      var productionItem2 = modelFactory.CreateProductionItem("AB20123", "Montagegruppe", "Das ist die Beschreibung für die Montagegruppe", "Werkzeug Hammer", "AB/23", "Baugruppenteil", customer2,
        " 42", "1234556789", 1, inspectionAttributeList2);
      var productionItem3 = modelFactory.CreateProductionItem("AB20124", "Löschbares Teil", "Ich bin löschbar", "Werkzeug Schweißgerät", "AB/24", "Baugruppenteil", customer2, " 42", "1234556789", 1,
        inspectionAttributeList3);
      var productionItem4 = modelFactory.CreateProductionItem("30829042", "Montagegruppe 42", "Beschreibung Montagegruppe", null, "AB/23", "Baugruppenteil", customer2, " 4212", "1234556789", 0,
        inspectionAttributeList4);
      var productionItem5 = modelFactory.CreateProductionItem("1900", "Kaffeetasse FCB", "Schwarze Kaffeetasse für Mitarbeiter", "Tassenform 1337", "Änd.Ind1", "Keramik", customer2, "123123", "123123",
        1, inspectionAttributeList5);

      dbContext.Set<ProductionItem>()
               .Add(productionItem1);
      dbContext.Set<ProductionItem>()
               .Add(productionItem2);
      dbContext.Set<ProductionItem>()
               .Add(productionItem3);
      dbContext.Set<ProductionItem>()
               .Add(productionItem4);
      dbContext.Set<ProductionItem>()
               .Add(productionItem5);

      var discardItem1 = modelFactory.CreateDiscardItem(inspectionAttribute1, "Teil nicht ausgespritzt", 20, null);
      var discardItem2 = modelFactory.CreateDiscardItem(inspectionAttribute2, "Teil stark vergratet", 10, null);
      var discardItem4 = modelFactory.CreateDiscardItem(inspectionAttribute4, "Lasche nach rechts verbogen", 10, null);
      var discardItem3 = modelFactory.CreateDiscardItem(inspectionAttribute5, "Kontakt leitet nicht", 20, null);
      var discardItem8 = modelFactory.CreateDiscardItem(inspectionAttribute8, "Bedienelement ist Ausschuß", 200, null);
      var discardItem9 = modelFactory.CreateDiscardItem(inspectionAttribute9, "Abdeckung fehlt", 2000, null);
      var discardItem10 = modelFactory.CreateDiscardItem(inspectionAttribute10, "Zahnrad hat keine Zähne", 5, null);
      var discardItem11 = modelFactory.CreateDiscardItem(inspectionAttribute11, "Farbe ist Blau", 10, null);
      var discardItem12 = modelFactory.CreateDiscardItem(inspectionAttribute11, "Farbe fehlt ganz", 15, null);
      var discardItem13 = modelFactory.CreateDiscardItem(inspectionAttribute12, "Henkel fehlt", 20, null);
      var discardItem14 = modelFactory.CreateDiscardItem(inspectionAttribute12, "Tasse hat keinen Boden", 5, null);
      var discardItem15 = modelFactory.CreateDiscardItem(inspectionAttribute13, "Schrift fehlt", 10, null);
      var discardItem16 = modelFactory.CreateDiscardItem(inspectionAttribute11, "Farbe ist Blau", 2, null);
      var discardItem17 = modelFactory.CreateDiscardItem(inspectionAttribute11, "Farbe fehlt ganz", 3, null);
      var discardItem18 = modelFactory.CreateDiscardItem(inspectionAttribute12, "Henkel fehlt", 4, null);
      var discardItem19 = modelFactory.CreateDiscardItem(inspectionAttribute12, "Tasse hat keinen Boden", 1, null);
      var discardItem20 = modelFactory.CreateDiscardItem(inspectionAttribute13, "Schrift fehlt", 4, null);


      var discardItemList1 = new Collection<DiscardItem>();
      discardItemList1.Add(discardItem1);
      discardItemList1.Add(discardItem2);

      var discardItemList2 = new Collection<DiscardItem>();
      discardItemList2.Add(discardItem3);
      discardItemList2.Add(discardItem4);

      var discardItemList3 = new Collection<DiscardItem>();
      discardItemList3.Add(discardItem8);
      discardItemList3.Add(discardItem9);
      discardItemList3.Add(discardItem10);

      var discardItemList4 = new Collection<DiscardItem>();
      discardItemList4.Add(discardItem11);
      discardItemList4.Add(discardItem12);
      discardItemList4.Add(discardItem13);
      discardItemList4.Add(discardItem14);
      discardItemList4.Add(discardItem15);

      var discardItemList5 = new Collection<DiscardItem>();
      discardItemList5.Add(discardItem16);
      discardItemList5.Add(discardItem17);
      discardItemList5.Add(discardItem18);
      discardItemList5.Add(discardItem19);
      discardItemList5.Add(discardItem20);

      dbContext.Set<DiscardItem>()
               .Add(discardItem1);
      dbContext.Set<DiscardItem>()
               .Add(discardItem2);
      dbContext.Set<DiscardItem>()
               .Add(discardItem3);
      dbContext.Set<DiscardItem>()
               .Add(discardItem4);
      dbContext.Set<DiscardItem>()
               .Add(discardItem8);
      dbContext.Set<DiscardItem>()
               .Add(discardItem9);
      dbContext.Set<DiscardItem>()
               .Add(discardItem10);
      dbContext.Set<DiscardItem>()
               .Add(discardItem11);
      dbContext.Set<DiscardItem>()
               .Add(discardItem12);
      dbContext.Set<DiscardItem>()
               .Add(discardItem13);
      dbContext.Set<DiscardItem>()
               .Add(discardItem14);
      dbContext.Set<DiscardItem>()
               .Add(discardItem15);
      dbContext.Set<DiscardItem>()
               .Add(discardItem16);
      dbContext.Set<DiscardItem>()
               .Add(discardItem17);
      dbContext.Set<DiscardItem>()
               .Add(discardItem18);
      dbContext.Set<DiscardItem>()
               .Add(discardItem19);
      dbContext.Set<DiscardItem>()
               .Add(discardItem20);

      var inspection1 = modelFactory.CreateInspection("Sichtprüfung Spritz", DateTime.Today, DateTime.Today, 0, 0, 0, 200, "Teile", 1000, "Reguläre Prüfung der Bedienelemente Spritz",
        responsibleSubject1, productionItem1, discardItemList1, false);

      var inspection2 = modelFactory.CreateInspection("Längenprüfung", DateTime.Today, DateTime.Today, 1, 1, 1, 200, "Meter", 1000, "Wieviel Meter wurden korrekt behämmert?", responsibleSubject1,
        productionItem2, discardItemList2, false);

      var inspection3 = modelFactory.CreateInspection("Ausschußprüfung", new DateTime(2013, 12, 24), new DateTime(2013, 12, 31), 2, 1, 0, 10, "Stück", 123, "Wieviel Teile sind pro Schicht Ausschuß",
        responsibleSubject1, productionItem4, discardItemList3, true);

      var inspection4 = modelFactory.CreateInspection("Erste Tassenprüfung", new DateTime(2014, 1, 15), new DateTime(2014, 1, 20), 1, 2, 0, 200, "Stück", 1000,
        "Die erste Charge FCB-Tassen für ORK-Mitarbeiter wird geprüft", responsibleSubject1, productionItem5, discardItemList4, true);

      var inspection5 = modelFactory.CreateInspection("zweite Tassenprüfung", new DateTime(2014, 1, 16), new DateTime(2014, 1, 21), 1, 2, 0, 150, "Stück", 1000,
        "Die zweite Charge FCB-Tassen für ORK-Mitarbeiter wird geprüft", responsibleSubject1, productionItem5, discardItemList5, true);

      dbContext.Set<Inspection>()
               .Add(inspection1);
      dbContext.Set<Inspection>()
               .Add(inspection2);
      dbContext.Set<Inspection>()
               .Add(inspection3);
      dbContext.Set<Inspection>()
               .Add(inspection4);
      dbContext.Set<Inspection>()
               .Add(inspection5);

      dbContext.SaveChanges();
    }
  }
}