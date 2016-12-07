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
using System.IO;
using System.Reflection;
using FileHelpers;

namespace OpenResKit.Waste
{
  internal static class Utils
  {
    private static IEnumerable<AvvWasteType> m_AvvWasteTypes;

    public static IEnumerable<AvvWasteType> ParseCsvToAvvWasteTypes()
    {
      if (m_AvvWasteTypes == null)
      {
        var assembly = Assembly.GetExecutingAssembly();
        var wasteStream = new StreamReader(assembly.GetManifestResourceStream("OpenResKit.Waste.Resources.AVVKatalog.csv"));

        var engine = new FileHelperEngine<AvvWasteType>();

        m_AvvWasteTypes = engine.ReadStream(wasteStream);
      }

      return m_AvvWasteTypes;
    }
  }
}