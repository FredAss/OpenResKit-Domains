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
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;

using OpenResKit.DomainModel;
using OpenResKit.ODataHost;

namespace OpenResKit.Danger
{
  [ExportMetadata("Name", "SurveyParserService")]
  [Export(typeof (IWCFService))]
  [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
  [ServiceContract]
  internal class SurveyParserService : IWCFService
  {
    private readonly DomainModelContext m_Context;
    private readonly Func<DomainModelContext> m_CreateContext;

    [ImportingConstructor]
    public SurveyParserService([Import] Func<DomainModelContext> createContext)
    {
      m_CreateContext = createContext;
      m_Context = m_CreateContext();
    }

    [OperationContract]
    public void GenerateSurvey(int surveyTypeId)
    {
      using (var context = m_CreateContext())
      {
        var surveyType = context.Set<SurveyType>()
                                .Single(cf => cf.Id == surveyTypeId);
        var surveyParser = new SurveyParser();
        surveyParser.GenerateSurvey(m_Context, surveyType);

        context.SaveChanges();
      }
    }
  }
}