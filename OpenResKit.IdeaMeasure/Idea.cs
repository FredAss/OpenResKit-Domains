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

namespace OpenResKit.IdeaMeasure
{
  public class Idea
  {
    public virtual int Id { get; set; }

    public virtual string ShortDescription { get; set; }

    public virtual string LongDescription { get; set; }

    public virtual string Solution { get; set; }

    public virtual int Status { get; set; }

    public virtual DateTime? CreationDate { get; set; }

    public virtual string Creator { get; set; }

    internal Status StatusEnum
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

    public virtual ICollection<Measure.Measure> Measures { get; set; }
  }
}