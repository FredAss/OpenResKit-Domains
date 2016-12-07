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

using System.Collections.Generic;

namespace OpenResKit.Danger
{
  public class Threat
  {
    public virtual bool Actionneed { get; set; }
    public virtual ICollection<Action> Actions { get; set; }
    public virtual Activity Activity { get; set; }
    public virtual Dangerpoint Dangerpoint { get; set; }
    public virtual string Description { get; set; }
    public virtual GFactor GFactor { get; set; }
    public virtual int Id { get; set; }
    public virtual ICollection<Picture> Pictures { get; set; }
    public virtual ICollection<ProtectionGoal> ProtectionGoals { get; set; }
    public virtual int RiskDimension { get; set; }
    public virtual int RiskPossibility { get; set; }
    public virtual string Status { get; set; }
  }
}