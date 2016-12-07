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

namespace OpenResKit.Discard
{
  public class ModelFactory
  {
    public InspectionAttribute CreateInspectionAttribute(string description, string number)
    {
      return new InspectionAttribute()
             {
               Description = description,
               Number = number
             };
    }

    public Inspection CreateInspection(String name, DateTime productionDate, DateTime inspectionDate, int productionShift, int inspectionShift, int inspectionType, int inspectionFrequencyOrSampleSize,
      string inspectionFrequencyUnit, int totalAmount, string description, ResponsibleSubject responsibleSubject, ProductionItem productionItem, ICollection<DiscardItem> discardItems, bool finished)
    {
      return new Inspection()
             {
               Name = name,
               ProductionDate = productionDate,
               InspectionDate = inspectionDate,
               ProductionShift = productionShift,
               InspectionShift = inspectionShift,
               InspectionType = inspectionType,
               SampleSize = inspectionFrequencyOrSampleSize,
               Unit = inspectionFrequencyUnit,
               TotalAmount = totalAmount,
               Description = description,
               ResponsibleSubject = responsibleSubject,
               ProductionItem = productionItem,
               DiscardItems = discardItems,
               Finished = finished
             };
    }

    public DiscardItem CreateDiscardItem(InspectionAttribute inspectionAttribute, string description, int quantity, byte[] picture)
    {
      return new DiscardItem()
             {
               InspectionAttribute = inspectionAttribute,
               Quantity = quantity,
               Description = description
             };
    }

    public ProductionItem CreateProductionItem(string itemNumber, string itemName, string itemDescription, string toolNumber, string changeIndex, string material, Customer customer,
      string referenceNumber1, string referenceNumber2, int itemCategory, ICollection<InspectionAttribute> inspectionAttributes)
    {
      return new ProductionItem()
             {
               ItemNumber = itemNumber,
               ItemName = itemName,
               ItemDescription = itemDescription,
               ToolNumber = toolNumber,
               ChangeIndex = changeIndex,
               Material = material,
               ReferenceNumber1 = referenceNumber1,
               ReferenceNumber2 = referenceNumber2,
               Customer = customer,
               ItemCategory = itemCategory,
               InspectionAttributes = inspectionAttributes
             };
    }

    public Customer CreateCustomer(string name)
    {
      return new Customer()
             {
               Name = name
             };
    }
  }
}