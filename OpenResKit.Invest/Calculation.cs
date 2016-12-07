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

namespace OpenResKit.Invest
{
  public abstract class Calculation
  {
    public virtual int Id { get; set; }
    public virtual int Lifetime { get; set; }
    public virtual float InvestmentSum { get; set; }
    public virtual float RecoveryValueToday { get; set; }
    public virtual float RecoveryValueAfterLifetime { get; set; }
    public virtual float EnergyCostsAnnual { get; set; }
    public virtual float EnergyCostsChangePA { get; set; }
    public virtual float OtherCostsPA { get; set; }
    public virtual float OtherRevenuePA { get; set; }
  }
}