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

namespace OpenResKit.Discard
{
  public class ProductionItem
  {
    public virtual int Id { get; set; }
    public virtual string ItemNumber { get; set; }
    public virtual string ItemName { get; set; }
    public virtual string ItemDescription { get; set; }
    public virtual string ToolNumber { get; set; }
    public virtual string ChangeIndex { get; set; }
    public virtual string Material { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual string ReferenceNumber1 { get; set; }
    public virtual string ReferenceNumber2 { get; set; }
    public virtual int ItemCategory { get; set; }

    internal ItemCategory ItemCategoryEnum
    {
      get { return (ItemCategory) ItemCategory; }
      set
      {
        if ((ItemCategory != (int) value))
        {
          ItemCategory = (int) value;
        }
      }
    }

    public virtual ICollection<InspectionAttribute> InspectionAttributes { get; set; }
  }
}