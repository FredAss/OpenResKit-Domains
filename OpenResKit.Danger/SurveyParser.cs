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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using Category = OpenResKit.Danger.Category;

namespace OpenResKit.Danger

{
  internal class GFHelper
  {
    public ArrayList arrDpoints;
    public ArrayList arrQuestion;
    public ArrayList arrThreatsource;
    public Category category;
    public string comments;
    public string gfactor;
    public int id;
    public string rightsource;

    public GFHelper()
    {
      arrDpoints = new ArrayList();
      arrQuestion = new ArrayList();
      arrThreatsource = new ArrayList();
    }
  }

  internal class CategoryHelper
  {
    public string Name { get; set; }
    public string id { get; set; }
  }

  internal class GFactorHelper
  {
    public Category Cat { get; set; }
    public string CatId { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
  }

  internal class DPointsHelper
  {
    public String GFID;
    public GFactor GFactor;
    public int Id;
    public string Name;
  }

  internal class QuestionHelper
  {
    public String GFID;
    public GFactor GFactor;
    public int Id;
    public string Name;
  }

  internal class SurveyParser
  {
    public List<Category> categories;
    public List<CategoryHelper> categoryHelpers;

    public List<Dangerpoint> dpoints;

    public List<DPointsHelper> dpointsHelpers;
    public List<GFactorHelper> gfactorHelpers;
    public List<GFactor> gfactors;
    public ModelFactory m_ModelFactory;
    public List<QuestionHelper> questionHelpers;
    public List<Question> questions;


    public SurveyType GenerateSurvey(DbContext dbContext)
    {
      var st = new SurveyType();
      st.Name = "Beispielfragebogen";
      GenerateSurvey(dbContext, st);
      return st;
    }


    public void GenerateSurvey(DbContext dbContext, SurveyType receivedSurveytype)
    {
      m_ModelFactory = new ModelFactory();
      categories = new List<Category>();
      gfactors = new List<GFactor>();

      dpoints = new List<Dangerpoint>();
      questions = new List<Question>();
      questionHelpers = new List<QuestionHelper>();
      dpointsHelpers = new List<DPointsHelper>();
      gfactorHelpers = new List<GFactorHelper>();
      categoryHelpers = new List<CategoryHelper>();


      var myAL = new ArrayList();
      WordprocessingDocument doc;
      //using (WordprocessingDocument doc = WordprocessingDocument.Open("checkliste.docx", false))
      if (receivedSurveytype.SurveyTypeDocx == null)
      {
        doc = WordprocessingDocument.Open("..\\OpenResKit.Danger\\Resources\\checkliste.docx", false);
      }
      else
      {
        File.WriteAllBytes(Path.GetTempPath() + receivedSurveytype.SurveyTypeDocx.Name, receivedSurveytype.SurveyTypeDocx.DocumentSource.BinarySource);

        doc = WordprocessingDocument.Open(Path.GetTempPath() + receivedSurveytype.SurveyTypeDocx.Name, false);
        Console.WriteLine("Versuche neuen Fragebogen zu parsen");
      }
      // Pfad zum Ressourcen Ordner
      {
        //es wird der MainDocumentPart geholt, welcher das eigenliche worddokument mit allen Referenzen darstellt
        var mainPart = doc.MainDocumentPart;

        //der reine Inhalt ist dann im Dokument
        var document = mainPart.Document;

        // hier holen wir uns die Tabellen
        var tables = document.Descendants<Table>();

        foreach (var tbl in tables)
        {
          //var tabledesc = tbl.Descendants<TableDescription>();
          //tabledesc.ToList().ForEach((dc) => Console.WriteLine(dc.InnerText));

          //hier holen wir uns alle Zeilen
          var rows = tbl.Descendants<TableRow>();


          foreach (var tblrw in rows)
          {
            //und nun holen wir und die Zellen
            var cells = tblrw.Descendants<TableCell>();


            //Inhalt von Zellen einer Zeile ausgeben
            //test - inhalt der zellen ausgeben
            var arrContent = new ArrayList();

            foreach (var tc in cells.ToList())
            {
              var myArr = new ArrayList();
              foreach (var tcc in tc.ToList())
              {
                if (tcc.InnerText != "")
                {
                  myArr.Add(tcc.InnerText);
                }
              }

              if (myArr.Count > 1)
              {
                arrContent.Add(myArr);
              }
              else if (myArr.Count == 1)
              {
                arrContent.Add(myArr[0]);
              }
            }

            myAL.Add(arrContent);

            //endtest
            //cells.ToList().ForEach((tc) => Console.Write(tc.InnerText + " | "));
            //PrintArray(myAL, 0);
          } //forech2
        } //freach1

        //var st = m_ModelFactory.CreateSurveytype(name);
        //dbContext.Set<OpenResKit.Danger.Models.Surveytype>().Add(st);

        //Gfactor gf = new Gfactor();
        var myarray = getArray(myAL);
        var catid = 0;

        //Speichern in die DB
        var newzeile = new ArrayList();
        var catcount = 1;
        foreach (var zeile in myarray)
        {
          // GFactor curline = (GFactor)zeile;
          var clh = (GFHelper) zeile;

          var curcat = (Category) clh.category;


          if (catid != clh.category.Id)
          {
            catid = clh.category.Id;
            //var ct = new OpenResKit.Danger.Models.Category { Name = clh.category.Name };

            var ct2 = new CategoryHelper
                      {
                        Name = clh.category.Name,
                        id = catid.ToString()
                      };

            /*m_ModelFactory.CreateCategory(clh.category.Name,st)*/

            //sqlKategorie = ("insert into category (catid, catname) VALUES (" + curline.category.id + ",'" + curline.category.name + "');");
            catcount = 1;
            //Console.WriteLine("Category dazu"+ct.Name+ct.Id);
            //categories.Add(ct);
            categoryHelpers.Add(ct2);

            // dbContext.Set<OpenResKit.Danger.Models.Category>().Add(ct);
          }

          var catidtext = catid.ToString() + "." + catcount.ToString();

          var gfa = new GFactorHelper
                    {
                      /*Cat = categoryHelpers.Last(),*/ Name = clh.gfactor,
                                                        Number = catidtext,
                                                        CatId = catid.ToString()
                    };
          //m_ModelFactory.CreateGFactor(clh.gfactor, catidtext, categories.Last());

          gfactorHelpers.Add(gfa);
          //var gfa = m_ModelFactory.CreateGFactor(clh.id,clh.gfactor,catidtext,curcat);
          //dbContext.Set<OpenResKit.Danger.Models.GFactor>().Add(gfa);
          // Console.WriteLine("GFactor dazu"+gfa.Name+gfa.Id);                    

          catcount++;

          foreach (var curquestion in clh.arrQuestion)
          {
            //string checkq = frage.ToString();
            //if(checkq.EndsWith("Sichtkontrolle:") || checkq.EndsWith("Befragung:") || checkq.EndsWith("Messung:")){

            //    curline.arrFrage.Remove(checkq);
            //    continue;
            //}
            //var tempgfactor = m_ModelFactory.CreateGFactor(clh.id, clh.gfactor, catidtext, curcat);
            //var quest = m_ModelFactory.CreateQuestion(questid, curquestion.ToString(), tempgfactor);

            var quest = new QuestionHelper
                        {
                          Name = curquestion.ToString(),
                          GFID = catidtext
                        }; /*m_ModelFactory.CreateQuestion(curquestion.ToString(), gfactorHelpers.Last());*/
            questionHelpers.Add(quest);

            //dbContext.Set<OpenResKit.Danger.Models.Question>().Add(quest);
            //Console.WriteLine(" Question dazu "+quest.QuestionName+quest.Id);
            //dbContext.SaveChanges(); 
          } //ende foreach2

          foreach (var curdpoint in clh.arrDpoints)
          {
            var dpoint = new DPointsHelper
                         {
                           Name = curdpoint.ToString(),
                           GFID = catidtext
                         };
            dpointsHelpers.Add(dpoint);
          }
        } //ende foreach

        //Console.ReadLine();
      } //ende using wordprocess


      //var categoriesForSurveytype = new List<Category>();

      foreach (var categoryHelper in categoryHelpers)
      {
        var gfactorsForCategory = new List<GFactor>();

        var gfactorHelperI = gfactorHelpers.Where(g1 => g1.CatId == categoryHelper.id);

        foreach (var gfactorHelper in gfactorHelperI)
        {
          var questionForGFactor = new List<Question>();
          var dpointForGFactor = new List<Dangerpoint>();
          var dpointHelperI = dpointsHelpers.Where(d1 => d1.GFID == gfactorHelper.Number);
          var questionHelperI = questionHelpers.Where(q1 => q1.GFID == gfactorHelper.Number);

          foreach (var dpointHelper in dpointHelperI)
          {
            var dpoint = m_ModelFactory.CreateDpoint(dpointHelper.Name);
            //    dbContext.Set<Dangerpoints>()
            //    .Add(dpoint);

            dpointForGFactor.Add(dpoint);
          }

          foreach (var questionHelper in questionHelperI)
          {
            var question = m_ModelFactory.CreateQuestion(questionHelper.Name);
            //     dbContext.Set<Question>()
            //     .Add(question);

            questionForGFactor.Add(question);
          }


          var gfactor = m_ModelFactory.CreateGFactor(gfactorHelper.Name, gfactorHelper.Number, questionForGFactor, dpointForGFactor);
          // dbContext.Set<GFactor>()
          // .Add(gfactor);

          gfactorsForCategory.Add(gfactor);
        }

        var category = m_ModelFactory.CreateCategory(categoryHelper.Name, gfactorsForCategory);
        // dbContext.Set<Category>()
        //  .Add(category);
        if (receivedSurveytype.Categories == null)
        {
          receivedSurveytype.Categories = new Collection<Category>();
        }
        receivedSurveytype.Categories.Add(category);
      }


      dbContext.SaveChanges();
      Console.WriteLine("Fragebogen hinzugefügt");
    } //ende main


    public ArrayList getArray(ArrayList myAl)
    {
      var newArr = myAl;

      var kategorie = "";
      var kategorieid = 0;
      var finalarr = new ArrayList();
      var subcatcounter = 1;
      var counter = 1;

      var zeilencounter = 1;
      var curcat = new Category();

      foreach (ArrayList zeile in newArr)
      {
        if (zeile.Count == 1)
        {
          kategorie = zeile[0].ToString();
          subcatcounter = 1;
          curcat.Id = counter++;
          curcat.Name = kategorie;
          continue;
        }
        if (zeile.Count == 4 ||
            zeile.Count == 5)
        {
          var gfcell = new GFHelper();

          gfcell.gfactor = getString(zeile[0]);
          //gfcell.rightsource = gfcell.getString(zeile[2]);
          gfcell.id = zeilencounter++;

          if (zeile.Count == 5)
          {
            //gfcell.comments = gfcell.getString(zeile[4]);
          }

          if (zeile[1].GetType() == typeof (ArrayList))
          {
            var arrlst = (ArrayList) zeile[1];
            foreach (var arr in arrlst)
            {
              //gfcell.arrThreatsource.Add(arr);
              gfcell.arrDpoints.Add(arr);
            }
          }
          if (zeile[3].GetType() == typeof (ArrayList))
          {
            var arrlst = (ArrayList) zeile[3];
            foreach (var arr in arrlst)
            {
              gfcell.arrQuestion.Add(arr);
            }
          }

          var newcat = new Category();
          newcat.Id = curcat.Id;
          newcat.Name = curcat.Name;

          gfcell.category = newcat;

          finalarr.Add(gfcell);
        }
      } //ende foreach
      newArr = finalarr;

      return newArr;
    }

    public string getString(object para)
    {
      var str = "";

      var typ = para.GetType()
                    .ToString();
      if (para.GetType() == typeof (String))
      {
        str = para.ToString();
      }
      else if (para.GetType() == typeof (ArrayList))
      {
        var arr = (ArrayList) para;
        str = "";
        foreach (var str2 in arr)
        {
          str += str2;
        }
      }
      return str;
    }
  }
}