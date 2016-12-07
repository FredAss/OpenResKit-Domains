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

namespace OpenResKit.Measure
{
  public class Measure
  {
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual string Evaluation { get; set; }
    public virtual DateTime? EntryDate { get; set; }
    public virtual DateTime DueDate { get; set; }
    public virtual DateTime CreationDate { get; set; }
    public virtual ResponsibleSubject ResponsibleSubject { get; set; }
    public virtual int Status { get; set; }
    public virtual int Priority { get; set; }
    public virtual MeasureImageSource MeasureImageSource { get; set; }
    public virtual ICollection<Document> AttachedDocuments { get; set; }
    public virtual double EvaluationRating { get; set; }

    public Status StatusEnum
    {
      get { return (Status) Status; }
      set
      {
        if ((Status != (int) value))
        {
          Status = (int) value;
        }
      }
    }

    public Priority PriorityEnum
    {
      get { return (Priority) Priority; }
      set
      {
        if ((Priority != (int) value))
        {
          Priority = (int) value;
        }
      }
    }
  }
}