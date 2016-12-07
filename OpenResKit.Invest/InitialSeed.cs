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
using System.Data.Entity;
using OpenResKit.DomainModel;
using OpenResKit.Organisation;

namespace OpenResKit.Invest
{
  [Export(typeof (IInitialSeed))]
  internal class InitialSeed : IInitialSeed
  {
    public void Seed(DbContext dbContext)
    {
      var modelFactory = new ModelFactory();

      var responsibleSubject1 = ResponsibleSubjectModelFactory.CreateEmployee("Oliver", "Kahn");

      dbContext.Set<Employee>()
               .Add(responsibleSubject1);

      //var pointlessInvestmentPlan = modelFactory.CreateInvestPlan("Trainingszentrum Säbener Straße", "Neues Trainingszentrum für FC Bayern Nachwuchsspieler", responsibleSubject1,
      //  new DateTime(2014, 1, 1), (float) 0.1, (float) 0.1, (float) 0.5, null, 25, 1000000, 900000, 500000, 1000, (float) 0.1, 1000, 20000);

      //pointlessInvestmentPlan.Comparisons = new List<Comparison>
      //                                      {
      //                                        modelFactory.CreateComparison("Trainingszentrum in Braunschweig", 5, 50000000, 1200, 42, 31415.92f, (float) 0.1, 2000, 0)
      //                                      };
      //dbContext.Set<InvestmentPlan>()
      //         .Add(pointlessInvestmentPlan);

      var excelInvestmentPlan = modelFactory.CreateInvestPlan("Excel Investmentplan", "Der Investmentplan aus dem Dokument", responsibleSubject1, new DateTime(2010, 01, 01), 0.1f, 0, 0, null, 15, 5000,
        0, 0, 1500, 0, 0, 0);
      excelInvestmentPlan.Comparisons = new List<Comparison>
                                        {
                                          modelFactory.CreateComparison("Vergleich", 15, 8000, 0, 0, 750, 0, 0, 0)
                                        };
      dbContext.Set<InvestmentPlan>()
               .Add(excelInvestmentPlan);
      dbContext.SaveChanges();
    }
  }
}