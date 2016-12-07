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
using OpenResKit.Organisation;

namespace OpenResKit.Meter
{
  internal static class ModelFactory
  {
    public static MeterReading CreateMeterReading(DateTime dueDateBegin, DateTime dueDateEnd, DateTime entryDateBegin, DateTime entryDateEnd, double counterReading,
      ResponsibleSubject appointmentResponsibleSubject, Meter readingMeter, Series series)
    {
      var dueDateAppointment = AppointmentModelFactory.CreateAppointment(dueDateBegin, dueDateEnd, series.IsAllDay);
      var entryDateAppointment = AppointmentModelFactory.CreateAppointment(entryDateBegin, entryDateEnd, series.IsAllDay);
      return new MeterReading
             {
               AppointmentResponsibleSubject = appointmentResponsibleSubject,
               DueDate = dueDateAppointment,
               EntryDate = entryDateAppointment,
               CounterReading = counterReading,
               ReadingMeter = readingMeter,
               RelatedSeries = series
             };
    }

    public static MeterReading CreateMeterReading(DateTime dueDateBegin, DateTime dueDateEnd, double counterReading, ResponsibleSubject appointmentResponsibleSubject, Meter readingMeter, Series series)
    {
      var dueDateAppointment = AppointmentModelFactory.CreateAppointment(dueDateBegin, dueDateEnd, series.IsAllDay);
      return new MeterReading
             {
               AppointmentResponsibleSubject = appointmentResponsibleSubject,
               DueDate = dueDateAppointment,
               CounterReading = counterReading,
               ReadingMeter = readingMeter,
               RelatedSeries = series
             };
    }


    public static Meter CreateMeter(string number, string barcode, string unit, MapPosition mapPosition)
    {
      var meter = new Meter
                  {
                    Number = number,
                    Barcode = barcode,
                    Unit = unit,
                    MapPosition = mapPosition
                  };
      return meter;
    }
  }
}