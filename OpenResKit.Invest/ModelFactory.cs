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
using OpenResKit.Organisation;

namespace OpenResKit.Invest
{
  public class ModelFactory
  {
    public InvestmentPlan CreateInvestPlan(string investmentName, string description, ResponsibleSubject responsibleSubject, DateTime startYear, float imputedInterestRate, float otherCostsChangePA,
      float otherRevenueChangePA, ICollection<Comparison> comparisons, int lifetime, float investmentSum, float recoveryValueToday, float recoveryValueAfterLifetime, float energyCostsAnnual,
      float energyCostsChangePA, float otherCostsPA, float otherRevenuePA)
    {
      return new InvestmentPlan()
             {
               InvestmentName = investmentName,
               Description = description,
               ResponsibleSubject = responsibleSubject,
               StartYear = startYear,
               ImputedInterestRate = imputedInterestRate,
               OtherCostsChangePA = otherCostsChangePA,
               OtherRevenueChangePA = otherRevenueChangePA,
               Comparisons = comparisons,
               Lifetime = lifetime,
               InvestmentSum = investmentSum,
               RecoveryValueToday = recoveryValueToday,
               RecoveryValueAfterLifetime = recoveryValueAfterLifetime,
               EnergyCostsAnnual = energyCostsAnnual,
               EnergyCostsChangePA = energyCostsChangePA,
               OtherCostsPA = otherCostsPA,
               OtherRevenuePA = otherRevenuePA
             };
    }

    public Comparison CreateComparison(string comparisonName, int lifetime, float investmentSum, float recoveryValueToday, float recoveryValueAfterLifetime, float energyCostsAnnual,
      float energyCostsChangePA, float otherCostsPA, float otherRevenuePA)
    {
      return new Comparison()
             {
               ComparisonName = comparisonName,
               Lifetime = lifetime,
               InvestmentSum = investmentSum,
               RecoveryValueToday = recoveryValueToday,
               RecoveryValueAfterLifetime = recoveryValueAfterLifetime,
               EnergyCostsAnnual = energyCostsAnnual,
               EnergyCostsChangePA = energyCostsChangePA,
               OtherCostsPA = otherCostsPA,
               OtherRevenuePA = otherRevenuePA
             };
    }
  }
}