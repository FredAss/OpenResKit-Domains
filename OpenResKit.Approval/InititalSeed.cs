using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Entity;
using OpenResKit.Approval.Factory;
using OpenResKit.Approval.Models;
using OpenResKit.DomainModel;
using OpenResKit.Organisation;
using DayOfWeek = System.DayOfWeek;

namespace OpenResKit.Approval
{
    [Export(typeof(IInitialSeed))]
    internal class InititalSeed: IInitialSeed
    {
        public void Seed(DbContext dbContext)
        {
            var responsibleSubject1 = ResponsibleSubjectModelFactory.CreateEmployee("Shawn", "Steinfeger", "1");
            var responsibleSubject2 = ResponsibleSubjectModelFactory.CreateGroup("Test");

            var measure1 = ModelFactory.CreateMeasure("Das und Das müssen gemacht werden", 0, responsibleSubject1, null, 1, DateTime.Now, DateTime.Now.AddDays(10), "Maßnahme1");
            var measure2 = ModelFactory.CreateMeasure("Das und Das müssen gemacht werden2", 1, responsibleSubject2, null, 2, DateTime.Now, DateTime.Now.AddDays(25), "Maßnahme2");

            var measures1 = new Collection<Approval_Measure>();
            measures1.Add(measure1);

            var measures2 = new Collection<Approval_Measure>();
            measures2.Add(measure2);

            dbContext.Set<Approval_Measure>().Add(measure1);
            dbContext.Set<Approval_Measure>().Add(measure2);
        
            var conditionInspection1 = ModelFactory.CreateConditionInspection(true, "Alles Ok", measures1, DateTime.Now/*, inspection2, auxillaryCondition1*/);
            var conditionInspection2 = ModelFactory.CreateConditionInspection(false, "Nicht alles ok", measures2, DateTime.Now/*, inspection1, auxillaryCondition2*/);
            var conditionInspection3 = ModelFactory.CreateConditionInspection(true, "AllesO Ok2", null, DateTime.Now/*, inspection1, auxillaryCondition2*/);

            dbContext.Set<ConditionInspection>().Add(conditionInspection1);
            dbContext.Set<ConditionInspection>().Add(conditionInspection2);
            dbContext.Set<ConditionInspection>().Add(conditionInspection3);

            var conditionInspections1 = new Collection<ConditionInspection>();
            conditionInspections1.Add(conditionInspection1);

            var conditionInspections2 = new Collection<ConditionInspection>();
            conditionInspections2.Add(conditionInspection2);
            conditionInspections2.Add(conditionInspection3);

            var conditionInspections3 = new Collection<ConditionInspection>();
            conditionInspections3.Add(conditionInspection1);
            conditionInspections3.Add(conditionInspection3);


            var auxillaryCondition1 = ModelFactory.CreateAuxillaryCondition("Wert muss unter 20 mg bleiben", "WHG §5", false, conditionInspections1);
            var auxillaryCondition2 = ModelFactory.CreateAuxillaryCondition("Wert muss unter 50 mg bleiben", "WHG §6", true, conditionInspections2);

            var auxillaryConditions = new Collection<AuxillaryCondition>();
            auxillaryConditions.Add(auxillaryCondition1);
            auxillaryConditions.Add(auxillaryCondition2);




            var date = DateTime.Now.AddYears(-1);
            var series = SeriesModelFactory.CreateSeries("Kontrolle", date, date.AddMinutes(30), date.AddDays(91), true,
                false, false, 1, 1, 13, new DayOfWeek[0]);

            var inspection1 = ModelFactory.CreateInspection(conditionInspections1, DateTime.Now,
                DateTime.Now.AddHours(1), responsibleSubject2, series, 0);

            var series2 = SeriesModelFactory.CreateSeries("Kontrolle2", date, date.AddMinutes(30), date.AddDays(91),
                true, true, false, 1, 1, 13, new DayOfWeek[1]);

            var inspection2 = ModelFactory.CreateInspection(conditionInspections2, DateTime.Now,
                DateTime.Now.AddHours(1), responsibleSubject1, series2, 2);
            

            
            //dbContext.Set<ConditionInspection>().Add(conditionInspection2);
            //dbContext.Set<ConditionInspection>().Add(conditionInspection3);

            dbContext.Set<Approval_Inspection>().Add(inspection1);
            dbContext.Set<Approval_Inspection>().Add(inspection2);
            dbContext.Set<AuxillaryCondition>().Add(auxillaryCondition1);
            dbContext.Set<AuxillaryCondition>().Add(auxillaryCondition2);         
            
            //dbContext.Set<Approval_Inspection>().Add(inspection2);

            var permission1 = ModelFactory.CreatePermission("Genehmigung 1", "Das ist eine Genehmigung.", true, 1, "AH-101", DateTime.Now, DateTime.Now, DateTime.Now, auxillaryConditions);
            var permission2 = ModelFactory.CreatePermission("Genehmigung 2", "Das ist eine Genehmigung.", true, 0, "AH-102", DateTime.Now, DateTime.Now, DateTime.Now, null);
            var permission3 = ModelFactory.CreatePermission("Genehmigung 3", "Das ist eine Genehmigung.", false, 2, "AH-103", DateTime.Now, DateTime.Now, DateTime.Now, null);

            dbContext.Set<Permission>().Add(permission1);
            dbContext.Set<Permission>().Add(permission2);
            dbContext.Set<Permission>().Add(permission3);

            var permissionCollection1 = new Collection<Permission>();
            permissionCollection1.Add(permission1);
            permissionCollection1.Add(permission2);

            var permissionCollection2 = new Collection<Permission>();
            permissionCollection2.Add(permission2);
            permissionCollection2.Add(permission3);

            var substance1 = ModelFactory.CreateSubstance("Wasser", "H2O", 1, 0, "0,1,2", "Abdichten", 2);
            var substance2 = ModelFactory.CreateSubstance("Kohlenstoffdioxid", "CO2", 0, 1, "3", "Gasmaske und abdichten", 1);

            var substanceList1 = new Collection<Substance>();
            substanceList1.Add(substance1);
            substanceList1.Add(substance2);


            var plant1 = ModelFactory.CreatePlant("Anlage 1", "Das ist eine Anlage", "Anlage 1", permissionCollection1, substanceList1);
            var plant2 = ModelFactory.CreatePlant("Anlage 2", "Das ist auch eine Anlage", "Anlage 2", permissionCollection2, null);

            dbContext.Set<Plant>().Add(plant1);
            dbContext.Set<Plant>().Add(plant2);

            

            dbContext.Set<Employee>().Add(responsibleSubject1);
            dbContext.Set<EmployeeGroup>().Add(responsibleSubject2);

            dbContext.SaveChanges();
        }
    }
}
