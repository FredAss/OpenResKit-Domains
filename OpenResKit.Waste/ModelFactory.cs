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
using System.Collections.ObjectModel;
using OpenResKit.Organisation;

namespace OpenResKit.Waste
{
  public static class ModelFactory
  {
    private static readonly Random m_Random = new Random();

    public static FillLevelReading CreateFillLevelReading(DateTime dueDateBegin, DateTime dueDateEnd, DateTime entryDateBegin, DateTime entryDateEnd, float progress,
      ResponsibleSubject appointmentResponsibleSubject, ResponsibleSubject entryResponsibleSubject, WasteContainer readingContainer, Series series)
    {
      var dueDateAppointment = AppointmentModelFactory.CreateAppointment(dueDateBegin, dueDateEnd, series.IsAllDay);
      var entryDateAppointment = AppointmentModelFactory.CreateAppointment(entryDateBegin, entryDateEnd, series.IsAllDay);
      return new FillLevelReading
             {
               AppointmentResponsibleSubject = appointmentResponsibleSubject,
               DueDate = dueDateAppointment,
               EntryResponsibleSubject = entryResponsibleSubject,
               EntryDate = entryDateAppointment,
               Progress = progress,
               ReadingContainer = readingContainer,
               RelatedSeries = series
             };
    }

    public static FillLevelReading CreateFillLevelReading(DateTime dueDateBegin, DateTime dueDateEnd, ResponsibleSubject appointmentResponsibleSubject, WasteContainer readingContainer, Series series)
    {
      var dueDateAppointment = AppointmentModelFactory.CreateAppointment(dueDateBegin, dueDateEnd, series.IsAllDay);
      return new FillLevelReading
             {
               AppointmentResponsibleSubject = appointmentResponsibleSubject,
               DueDate = dueDateAppointment,
               ReadingContainer = readingContainer,
               RelatedSeries = series
             };
    }

    public static WasteContainer CreateWasteContainer(string name, string barcode, double size, MapPosition mapPosition)
    {
      var wc = new WasteContainer
               {
                 Name = name,
                 Barcode = barcode,
                 Size = size,
                 WasteTypes = new Collection<WasteType>
                              {
                                new WasteType
                                {
                                  AvvId = m_Random.Next(1, 940)
                                }
                              },
                 MapPosition = mapPosition
               };
      return wc;
    }

    public static WasteCollection CreateCollection(Disposer disposer, WasteContainer wasteContainer, double desiredState, double actualState, double desiredPrice, double actualPrice,
      DateTime scheduledDate)
    {
      return new WasteCollection()
             {
               ActualState = actualState,
               DesiredState = desiredState,
               Disposer = disposer,
               Container = wasteContainer,
               ScheduledDate = scheduledDate,
               DesiredPrice = desiredPrice,
               ActualPrice = actualPrice,
               GenerationDate = DateTime.Now
             };
    }
  }
}