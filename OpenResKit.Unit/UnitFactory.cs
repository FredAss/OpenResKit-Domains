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
using System.ComponentModel.Composition;

namespace OpenResKit.Unit
{
  [Export]
  public class UnitFactory
  {
    public IEnumerable<Unit> CreateSiUnits()
    {
      var gram = new Unit
                 {
                   Dimension = "Mass",
                   Name = "Gramm",
                   Symbol = "g",
                   Coefficient = 0,
                 };
      yield return gram;

      var hectogram = new Unit
                      {
                        Dimension = "Mass",
                        Name = "Hectogramm",
                        Symbol = "hg",
                        Coefficient = 10,
                        ReferencedUnit = gram,
                      };
      yield return hectogram;

      var kilogram = new Unit
                     {
                       Dimension = "Mass",
                       Name = "Kilogramm",
                       Symbol = "kg",
                       Coefficient = 100,
                       ReferencedUnit = hectogram
                     };
      yield return kilogram;
    }
  }
}