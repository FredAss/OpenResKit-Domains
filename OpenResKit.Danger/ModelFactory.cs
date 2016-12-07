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
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;


namespace OpenResKit.Danger
{
  [Export]
  public class ModelFactory
  {
    public Assessment CreateAssessment(DateTime date, int status, Person person, List<Threat> threat)
    {
      return new Assessment
             {
               AssessmentDate = date,
               Status = status,
               EvaluatingPerson = person,
               Threats = threat
             };
    }

    public Category CreateCategory(string categoryName, List<GFactor> gfactors)
    {
      return new Category
             {
               Name = categoryName,
               GFactors = gfactors
             };
    }

    public Company CreateCompany(string companyName, string companyAdress, string companyTelephone, string companyTypeOfBusiness, List<Workplace> companyWorkplace, List<Person> companyPerson)
    {
      return new Company
             {
               Name = companyName,
               Adress = companyAdress,
               Telephone = companyTelephone,
               TypeOfBusiness = companyTypeOfBusiness,
               Workplaces = companyWorkplace,
               Persons = companyPerson
             };
    }

    public Dangerpoint CreateDpoint(string dpointName)
    {
      return new Dangerpoint
             {
               Name = dpointName
             };
    }

    public GFactor CreateGFactor(string name, string number, List<Question> questions, List<Dangerpoint> dpoints)
    {
      return new GFactor
             {
               Name = name,
               Number = number,
               Questions = questions,
               Dangerpoints = dpoints
             };
    }

    public Person CreatePerson(string name)
    {
      return new Person
             {
               Name = name
             };
    }

    public Picture CreatePicture(byte[] pic)
    {
      return new Picture
             {
               Pic = pic
             };
    }

    public static Picture CreatePicture(Stream imageStream)
    {
      byte[] byteArray;
      using (var br = new BinaryReader(imageStream))
      {
        byteArray = br.ReadBytes((int) imageStream.Length);
      }

      return new Picture
             {
               Pic = byteArray
             };
    }

    public Question CreateQuestion(string questionName)
    {
      return new Question
             {
               QuestionName = questionName
             };
    }

    public SurveyType CreateSurveytype(string name, List<Category> categories)
    {
      return new SurveyType
             {
               Name = name,
               Categories = categories
             };
    }

    public Threat CreateThreat(string description, int riskdimension, int riskpos, bool actionneed, string status, GFactor gfactors, List<Picture> pics, List<ProtectionGoal> progoals,
      List<Action> actions, Activity activity)
    {
      return new Threat
             {
               Description = description,
               RiskDimension = riskdimension,
               RiskPossibility = riskpos,
               Actionneed = actionneed,
               Status = status,
               GFactor = gfactors,
               Pictures = pics,
               ProtectionGoals = progoals,
               Actions = actions,
               Activity = activity
             };
    }

    public Workplace CreateWorkplace(string name, string companyname, string description, Collection<Activity> activities, SurveyType surveytype, Person evaluatingPerson,
      Collection<Assessment> assessments)
    {
      return new Workplace
             {
               Name = name,
               NameCompany = companyname,
               Description = description,
               Activities = activities,
               SurveyType = surveytype,
               Assessments = assessments
             };
    }
  }
}