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
  public class Disposer
  {
    public virtual int Id { get; set; }
    public virtual string Number { get; set; }
    public virtual string Name { get; set; }
    public virtual string EMail { get; set; }
    public virtual string Street { get; set; }
    public virtual string AdditionalInformation { get; set; }
    public virtual string ZipCode { get; set; }
    public virtual string City { get; set; }
    public virtual ICollection<Document> Documents { get; set; }
    public virtual ICollection<WasteContainer> Containers { get; set; }
  }
}