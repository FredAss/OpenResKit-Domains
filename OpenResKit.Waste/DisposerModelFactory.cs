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
using OpenResKit.Organisation;

namespace OpenResKit.Waste
{
  internal class DisposerModelFactory
  {
    public Disposer CreateDisposer(string name, string number, string email, string street, string zipCode, string city, ICollection<Document> documents, ICollection<WasteContainer> containers,
      string additional)
    {
      return new Disposer()
             {
               Name = name,
               Number = number,
               Street = street,
               AdditionalInformation = additional,
               City = city,
               ZipCode = zipCode,
               EMail = email,
               Containers = containers,
               Documents = documents
             };
    }
  }
}