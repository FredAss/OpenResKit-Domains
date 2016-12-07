using System;
using System.Collections.ObjectModel;
using OpenResKit.Approval.Models;
using OpenResKit.Organisation;

namespace OpenResKit.Approval.Factory
{
    internal static class ModelFactory
    {
        public static Plant CreatePlant(string name, string description, string number, Collection<Permission> permissions, Collection<Substance> substances )
        {
            return new Plant
            {
                Name = name, 
                Description = description,
                Number = number, 
                Permissions = permissions,
                Substances = substances
            };
        }

        public static Permission CreatePermission(string name, string description, bool inEffect, int permissionKind, string fileNumber, DateTime dateOfApplication, DateTime startOfPermission, DateTime endOfPermission, Collection<AuxillaryCondition> auxillaryConditions )
        {
            return new Permission
            {
                Name = name, 
                Description = description, 
                InEffect = inEffect, 
                PermissionKind = permissionKind, 
                FileNumber = fileNumber, 
                DateOfApplication = dateOfApplication, 
                StartOfPermission = startOfPermission, 
                EndOfPermission = endOfPermission, 
                AuxillaryConditions = auxillaryConditions
            };
        }

        public static AuxillaryCondition CreateAuxillaryCondition(string condition, string reference, bool inEffect, Collection<ConditionInspection> conditionInspections)
        {
            return new AuxillaryCondition
            {
                Condition = condition, 
                Reference = reference, 
                InEffect = inEffect, 
                ConditionInspections = conditionInspections
            };
        }

        public static Approval_Inspection CreateInspection(Collection<ConditionInspection> conditionInspections, DateTime dueDateBegin, DateTime dueDateEnd, ResponsibleSubject responsibleSubject, Series series, float progress)
        {
            var dueDateAppointment = AppointmentModelFactory.CreateAppointment(dueDateBegin, dueDateEnd, series.IsAllDay);
            
            return new Approval_Inspection
            {
                AppointmentResponsibleSubject = responsibleSubject, 
                DueDate = dueDateAppointment, 
                RelatedSeries = series, 
                ConditionInspections = conditionInspections,
                Progress = progress
            };
        }

        public static ConditionInspection CreateConditionInspection(bool status, string description, Collection<Approval_Measure> measures, DateTime entryDate)
        {
            return new ConditionInspection
            {
                Status = status, 
                Description = description, 
                Measures = measures,
                EntryDate = entryDate
            };
        }

        public static Approval_Measure CreateMeasure(string description, int progress, ResponsibleSubject responsibleSubject, Collection<Document> attachedDocuments, int priority, DateTime dueDate, DateTime entryDate, string name )
        {
            return new Approval_Measure {Description = description, Progress = progress, ResponsibleSubject = responsibleSubject, AttachedDocuments = attachedDocuments, Priority = priority, DueDate = dueDate, EntryDate = entryDate, Name = name};
        }

        public static Substance CreateSubstance(string name, string description, int category, int type, string dangerTypes, string action, int riskPotential)
        {
            return new Substance
            {
                Name = name,
                Description = description,
                Category = category,
                Type = type,
                DangerTypes = dangerTypes,
                Action = action,
                RiskPotential = riskPotential
            };
        }
    }
}
